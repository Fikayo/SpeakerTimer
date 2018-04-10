
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
        private BufferBlock<ClientResponse> clientResponseQueue;

        public NetworkServer(int receivePort, int sendPort, BufferBlock<ClientResponse> clientResponseQueue)
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
            if (args is TcpClient client)
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] data = new byte[1024];
                    stream.Read(data, 0, data.Length);

                    var packet = NetworkUtils.ByteArrayToObject(data);
                    if (packet is TimerNetworkPacket networkPacket)
                    {
                        // Add response to the buffer
                        EndPoint clientAddress = client.Client.RemoteEndPoint;
                        if (networkPacket.NetworkData is ClientMessageData messageData)
                        {
                            var response = new ClientResponse(clientAddress, messageData.ClientMessage);
                            this.clientResponseQueue.SendAsync(response);
                        }
                    }
                }

                client.Close();
            }
        }
    }
}
