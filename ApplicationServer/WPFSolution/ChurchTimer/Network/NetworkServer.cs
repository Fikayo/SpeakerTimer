
namespace TheLiveTimer.Server.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Network;

    public class NetworkServer : INetworkServer, INetworkAsyncServer
    {
        public const int ServerBacklogSize = 6;

        private Thread listenerThread;
        private TcpListener listener;
        private BroadcastServer broadcaster;
        private readonly BufferBlock<ReceivedParcel> clientResponseQueue;

        public NetworkServer(int receivePort, int sendPort, BufferBlock<ReceivedParcel> clientResponseQueue)
        {
            this.listener = new TcpListener(IPAddress.Any, receivePort);
            this.broadcaster = new BroadcastServer(sendPort);
            this.clientResponseQueue = clientResponseQueue;
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

        private void Send(TcpClient client, byte[] data)
        {
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        public void BroadcastAsync(byte[] data)
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
            if (args is TcpClient client)
            {
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
                            EndPoint clientAddress = client.Client.RemoteEndPoint;
                            if (networkPacket.NetworkData is ClientMessageData messageData)
                            {
                                this.clientResponseQueue.SendAsync(new ReceivedParcel(messageData));
                            }
                        }
                    }

                    client.Close();
                }
                catch(Exception)
                {
                    // If an exception is thrown, the server needs to respond with a declined message
                    // Create the client message data
                    var endpoint = (IPEndPoint)client.Client.RemoteEndPoint;
                    var clientAddress = new NetworkAddress(endpoint.Address, endpoint.Port);
                    var clientMessageData = new ClientMessageData(default(ClientMessage), clientAddress);

                    // Put this false client message data in the queue
                    this.clientResponseQueue.SendAsync(new ReceivedParcel(clientMessageData, true));
                }

            }
        }
    }
}
