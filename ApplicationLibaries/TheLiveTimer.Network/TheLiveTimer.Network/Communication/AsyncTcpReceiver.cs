namespace TheLiveTimer.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;

    public class AsyncTcpReceiver : IReceiverAsync
    {
        public const int ServerBacklogSize = 6;

        private readonly TcpListener tcpListener;
        private readonly BlockingCollection<ReceivedPacket> clientResponseQueue;

        public AsyncTcpReceiver(int receivePort, BlockingCollection<ReceivedPacket> clientResponseQueue)
        {
            this.tcpListener = new TcpListener(IPAddress.Any, receivePort);
            this.clientResponseQueue = clientResponseQueue;
        }

        public bool IsListening { get; private set; }

        public async Task StartListeningAsync()
        {
            this.tcpListener.Start(ServerBacklogSize);
            this.IsListening = true;

            while (true)
            {
                TcpClient client = await this.tcpListener.AcceptTcpClientAsync();
                Thread clientHandlerThread = new Thread(this.ClientHandler);
                clientHandlerThread.Start(client);
            }
        }

        public void Dispose()
        {
            this.tcpListener.Stop();

            this.IsListening = false;
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
