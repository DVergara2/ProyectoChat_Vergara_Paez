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
            serverThread = new Thread(StartServer);
            serverThread.Start();
            btnStart.Enabled = false;
        }
        private void StartServer()
        {
            server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Invoke((Action)(() => listViewClientes.Items.Add("Sevidor Iniciado")));
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

        }
    }
}/*
