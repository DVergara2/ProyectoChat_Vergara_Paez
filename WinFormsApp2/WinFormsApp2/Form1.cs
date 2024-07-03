/*using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private List<string> messages;
        private bool isConnected;

        public Form1()
        {
            InitializeComponent();
            messages = new List<string>();
            isConnected = false;
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            isConnected = true;
            AppendMessage("Has entrado al chat.");
        }

        private void ButtonSend_Click(object sender, EventArgs e)
        {
            if (isConnected && !string.IsNullOrWhiteSpace(textBoxMessageInput.Text))
            {
                string message = textBoxMessageInput.Text;
                AppendMessage("Tú: " + message);
                textBoxMessageInput.Clear();
            }
            else if (!isConnected)
            {
                MessageBox.Show("¡Debes entrar al chat primero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AppendMessage(string message)
        {
            messages.Add(message);
            textBoxMessages.Text = string.Join(Environment.NewLine, messages);
        }
    }
}*/



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
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            username = textBoxUsername.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("El nombre de usuario no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                client = new TcpClient("172.20.11.5", 5000);
                stream = client.GetStream();
                isConnected = true;

                AppendMessage($"{username} ha entrado al chat.");
                byte[] data = Encoding.ASCII.GetBytes($"{username} ha entrado al chat.");
                stream.Write(data, 0, data.Length);

                Thread receiveThread = new Thread(ReceiveMessages);
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
            textBoxMessages.AppendText(formattedMessage + Environment.NewLine);
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
            else if (!isConnected)
            {
                MessageBox.Show("¡Debes conectarte al servidor primero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReceiveMessages()
        {
            while (isConnected)
            {
                try
                {
                    byte[] data = new byte[256];
                    int bytes = stream.Read(data, 0, data.Length);
                    if (bytes == 0) break;
                    string message = Encoding.ASCII.GetString(data, 0, bytes);
                    Invoke(new Action(() => AppendMessage(message)));
                }
                catch (Exception)
                {
                    break;
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

                    stream.Close();
                    client.Close();
                    isConnected = false;
                    AppendMessage(exitMessage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al desconectar: " + ex.Message);
                }
            }
        }
    }
}










