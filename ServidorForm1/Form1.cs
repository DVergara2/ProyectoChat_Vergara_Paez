using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServidorForm1
{
    public partial class Form1 : Form
    {
        private TcpListener server;
        private Thread serverThread;
        private List<TcpClient> clients = new List<TcpClient>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int port;
            if (int.TryParse(textBoxPort.Text, out port))
            {
                serverThread = new Thread(() => StartServer(port));
                serverThread.Start();
                btnStart.Enabled = false;
            }
            else
            {
                MessageBox.Show("Por favor ingrese un número de puerto válido.");
            }
        }

        private void StartServer(int port)
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            Invoke((Action)(() => listViewClientes.Items.Add($"Servidor iniciado en el puerto {port}")));
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                clients.Add(client);
                Invoke((Action)(() => listViewClientes.Items.Add(client.Client.RemoteEndPoint.ToString())));
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    BroadcastMessage(message, client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                clients.Remove(client);
                Invoke((Action)(() =>
                {
                    foreach (ListViewItem item in listViewClientes.Items)
                    {
                        if (item.Text == client.Client.RemoteEndPoint.ToString())
                        {
                            listViewClientes.Items.Remove(item);
                            break;
                        }
                    }
                }));
                client.Close();
            }
        }

        private void BroadcastMessage(string message, TcpClient senderClient)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(message);

            foreach (var client in clients)
            {
                if (client != senderClient)
                {
                    NetworkStream stream = client.GetStream();
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }

        private void listViewClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No es necesario implementar nada aquí por el momento
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
