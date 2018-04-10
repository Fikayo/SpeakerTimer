namespace TheLiveTimer.Server.Network
{
    using System;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Server.Network;
    using TheLiveTimer.Network;

    internal class NetworkCommunicator
    {
        private const int MaxClients = 10;

        private NetworkServer server;
        private BufferBlock<ClientResponse> clientQueue;

        public NetworkCommunicator(int receivePort, int sendPort)
        {
            this.clientQueue = new BufferBlock<ClientResponse>(new DataflowBlockOptions { BoundedCapacity = MaxClients });
            this.server = new NetworkServer(receivePort, sendPort, clientQueue);
            this.server.OpenAsync();
        }

        public void AcceptClients()
        {
            // First send out ServerReady message
            var data = new ServerMessageData(ServerMessage.ServerReady);
            this.TransmitData(data);

            // Wait for client responses up to max number of clients
            //server.
        }

        public void BroadcastCommand(TimerNetworkCommand command, params double[] args)
        {
            if (args != null)
            {
                byte[] result = new byte[args.Length * sizeof(double)];
                Buffer.BlockCopy(args, 0, result, 0, result.Length);
                this.BroadcastCommand(command, result);
            }
            else
            {
                this.BroadcastCommand(command, new byte[0]);
            }
        }

        public void BroadcastCommand(TimerNetworkCommand command, byte[] args)
        {
            Console.WriteLine("Broadcasting command: " + command.ToString());
            var commandData = new TimerCommandData(0, command, args);
            this.TransmitData(commandData);
        }

        private void TransmitData(NetworkData data)
        {
            var packet = new TimerNetworkPacket(0, data);
            var bytes = NetworkUtils.ObjectToByteArray(packet);
            this.server.Broadcast(bytes);
        }

    }
}
