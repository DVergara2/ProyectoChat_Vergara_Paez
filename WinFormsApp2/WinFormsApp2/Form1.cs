using System;
using System.Media;
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
        private SoundPlayer notificationSound;

        public Form1()
        {
            InitializeComponent();
            notificationSound = new SoundPlayer(@"C:\Windows\Media\notify.wav"); // Ruta al archivo de sonido
            // Establecer el tama�o fijo del formulario
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(347, 338); // Tama�o fijo del formulario
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            username = textBoxUsername.Text;
            ipAddress = textBoxIPAddress.Text;
            if (!int.TryParse(textBoxPort.Text, out port))
            {
                MessageBox.Show("El puerto debe ser un n�mero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Deshabilitar el bot�n despu�s de un solo clic
                ButtonEnter.Enabled = false;

                // Notificar a todos que un usuario ha entrado
                NotifyUserStatus($"{username} ha entrado al chat.");

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
            // Notificar a todos que un usuario ha salido
            NotifyUserStatus($"{username} ha salido del chat.");

            Disconnect();
            // Habilitar el bot�n cuando el usuario salga del chat
            ButtonEnter.Enabled = true;
        }

        private void ButtonBuzz_Click(object sender, EventArgs e)
        {
            SendBuzz();
        }

        private void textBoxMessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SendMessage()
        {
            if (!isConnected || string.IsNullOrWhiteSpace(textBoxMessageInput.Text)) return;

            string message = $"{username}: {textBoxMessageInput.Text}";
            AppendMessage(message);
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            textBoxMessageInput.Clear();
        }

        private void SendBuzz()
        {
            if (!isConnected) return;

            string buzzMessage = $"{username} ha enviado un zumbido!";
            byte[] data = Encoding.ASCII.GetBytes(buzzMessage);
            stream.Write(data, 0, data.Length);
            VibrateWindow();
        }

        private void AppendMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AppendMessage), message);
                return;
            }
            textBoxMessages.AppendText(message + Environment.NewLine);
            PlayNotificationSound();
        }

        private void ReceiveMessages()
        {
            while (isConnected)
            {
                try
                {
                    byte[] data = new byte[1024];
                    int bytes = stream.Read(data, 0, data.Length);
                    if (bytes > 0)
                    {
                        string message = Encoding.ASCII.GetString(data, 0, bytes);
                        AppendMessage(message);

                        if (message.Contains("ha enviado un zumbido!"))
                        {
                            VibrateWindow();
                        }
                    }
                }
                catch (Exception)
                {
                    isConnected = false;
                    Disconnect();
                }
            }
        }

        private void PlayNotificationSound()
        {
            try
            {
                notificationSound.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al reproducir el sonido: " + ex.Message);
            }
        }

        private void VibrateWindow()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(VibrateWindow));
                return;
            }

            var originalLocation = this.Location;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                this.Location = new System.Drawing.Point(originalLocation.X + random.Next(-10, 10), originalLocation.Y + random.Next(-10, 10));
                Thread.Sleep(20);
            }
            this.Location = originalLocation;
        }

        private void NotifyUserStatus(string statusMessage)
        {
            if (!isConnected) return;

            byte[] data = Encoding.ASCII.GetBytes(statusMessage);
            stream.Write(data, 0, data.Length);
        }

        private void Disconnect()
        {
            if (isConnected)
            {
                isConnected = false;
                stream.Close();
                client.Close();
                AppendMessage($"{username} ha salido del chat.");
                receiveThread?.Join();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}