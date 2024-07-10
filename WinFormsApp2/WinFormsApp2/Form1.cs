using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string username;
        private string ipAddress;
        private int port;
        private bool isConnected = false;
        private Thread receiveThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            username = textBoxUsername.Text;
            ipAddress = textBoxIPAddress.Text;
            if (!int.TryParse(textBoxPort.Text, out port))
            {
                MessageBox.Show("El puerto debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(ipAddress) || port <= 0)
            {
                MessageBox.Show("Por favor complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                client = new TcpClient(ipAddress, port);
                stream = client.GetStream();
                isConnected = true;

                AppendMessage($"{username} ha entrado al chat.");
                byte[] data = Encoding.ASCII.GetBytes($"{username} ha entrado al chat.");
                stream.Write(data, 0, data.Length);

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void textBoxMessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.SuppressKeyPress = true;
            }
        }

        private void AppendMessage(string message)
        {
            string formattedMessage = $"{DateTime.Now.ToString("[HH:mm:ss]")} {message}";
            textBoxMessages.Invoke((MethodInvoker)delegate
            {
                textBoxMessages.AppendText(formattedMessage + Environment.NewLine);
            });
        }

        private void SendMessage()
        {
            if (isConnected && !string.IsNullOrWhiteSpace(textBoxMessageInput.Text))
            {
                string message = textBoxMessageInput.Text;
                string formattedMessage = $"{username}: {message}";
                byte[] data = Encoding.ASCII.GetBytes(formattedMessage);
                stream.Write(data, 0, data.Length);
                AppendMessage(formattedMessage);
                textBoxMessageInput.Clear();
            }
        }

        private void ReceiveMessages()
        {
            byte[] data = new byte[1024];
            while (isConnected)
            {
                try
                {
                    int bytes = stream.Read(data, 0, data.Length);
                    if (bytes == 0) continue;
                    string message = Encoding.ASCII.GetString(data, 0, bytes);
                    AppendMessage(message);
                }
                catch
                {
                    AppendMessage("Se ha perdido la conexión con el servidor.");
                    Disconnect();
                }
            }
        }

        private void Disconnect()
        {
            if (isConnected)
            {
                try
                {
                    string exitMessage = $"{username} ha salido del chat.";
                    byte[] data = Encoding.ASCII.GetBytes(exitMessage);
                    stream.Write(data, 0, data.Length);
                    AppendMessage(exitMessage);
                }
                catch { }

                stream?.Close();
                client?.Close();
                isConnected = false;

                receiveThread?.Interrupt();
                receiveThread = null;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Disconnect();
            base.OnFormClosing(e);
        }
    }
}