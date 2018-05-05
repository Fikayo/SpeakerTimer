namespace TheLiveTimer.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public class TcpReceiver : IReceiver
    {
        public const int ServerBacklogSize = 6;

        private readonly Thread listenerThread;
        private readonly TcpListener tcpListener;
        private readonly BlockingCollection<ReceivedPacket> clientResponseQueue;

        public TcpReceiver(int receivePort, BlockingCollection<ReceivedPacket> clientResponseQueue)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, receivePort);
            this.listenerThread = new Thread(this.StartListner);
            this.clientResponseQueue = clientResponseQueue;
        }

        public bool IsListening => this.listenerThread != null && this.listenerThread.IsAlive;

        public void StartListening()
        {
            if (!this.listenerThread.IsAlive)
            {
                this.listenerThread.Start();
            }
        }

        public void Dispose()
        {
            if(this.listenerThread.IsAlive)
            {
                this.listenerThread.Abort();
                this.listenerThread.Join();
            }

            this.tcpListener.Stop();
        }

        private void StartListner()
        {
            this.tcpListener.Start(ServerBacklogSize);

            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                Thread clientHandlerThread = new Thread(this.ClientHandler);
                clientHandlerThread.Start(client);
            }
        }

        private void ClientHandler(object args)
        {
            if (args is TcpClient client)
            {
                var endpoint = (IPEndPoint)client.Client.RemoteEndPoint;
                var sender = new NetworkAddress(endpoint.Address, endpoint.Port);

                try
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] data = new byte[client.ReceiveBufferSize];
                        stream.Read(data, 0, data.Length);

                        var packet = NetworkUtils.ByteArrayToObject(data);
                        if (packet is TimerNetworkPacket networkPacket)
                        {
                            // Add response to the buffer
                            this.clientResponseQueue.Add(new ReceivedPacket(networkPacket, sender));
                        }
                    }

                    client.Close();
                }
                catch (Exception)
                {
                    // If an exception is thrown, add an error packet
                    // Put this false client message data in the queue
                    this.clientResponseQueue.Add(new ReceivedPacket(null, sender, true));
                }

            }
        }
    }

}
