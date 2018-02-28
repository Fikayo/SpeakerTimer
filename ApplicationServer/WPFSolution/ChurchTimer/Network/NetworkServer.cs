
namespace TheLiveTimer.Server.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class NetworkServer : INetworkServer, INetworkAsyncServer
    {
        public const int ServerBacklogSize = 6;

        private Thread listenerThread;
        private TcpListener listener;
        private BroadcastServer broadcaster;

        public NetworkServer(int receivePort, int sendPort)
        {
            this.listener = new TcpListener(IPAddress.Any, receivePort);
            this.broadcaster = new BroadcastServer(sendPort);
        }

        public void Open()
        {
            this.StartListner();
        }

        public void OpenAsync()
        {
            if (this.listenerThread == null)
            {
                this.listenerThread = new Thread(this.StartListner);
                this.listenerThread.Start();
            }
        }

        private void Send(TcpClient client)
        {

        }

        public void Broadcast(byte[] data)
        {
            this.broadcaster.SendAsync(data);
        }

        private void StartListner()
        {
            this.listener.Start(ServerBacklogSize);

            while (true)
            {
                TcpClient client = this.listener.AcceptTcpClient();
                Thread clientHandlerThread = new Thread(this.ClientHandler);
                clientHandlerThread.Start(client);
            }
        }

        private void ClientHandler(object args)
        {
            TcpClient client = args as TcpClient;
            if (client != null)
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = new byte[1024];
                    stream.Read(data, 0, data.Length);

                    Console.WriteLine("Server received: " + Encoding.ASCII.GetString(data));

                    this.Broadcast(Encoding.ASCII.GetBytes("My broadcast"));
                }

                client.Close();
            }
        }
    }
}
