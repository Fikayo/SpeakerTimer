namespace TheLiveTimer.Server.Network
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Server.Network;
    using TheLiveTimer.Network;
    using System.Net;

    internal class NetworkCommunicator
    {
        private NetworkServer server;
        private BufferBlock<ReceivedParcel> clientResponseQueue;
        private ClientManager clientManager;

        public NetworkCommunicator(int receivePort, int sendPort)
        {
            this.clientResponseQueue = new BufferBlock<ReceivedParcel>(new DataflowBlockOptions { BoundedCapacity = ClientManager.MaxClients + 1 });
            this.server = new NetworkServer(receivePort, sendPort, clientResponseQueue);
            this.clientManager = new ClientManager(clientResponseQueue, this);
            this.server.OpenAsync();

            var serverIP = NetworkUtils.GetLocalIPv4(System.Net.NetworkInformation.NetworkInterfaceType.Ethernet);
            Console.WriteLine("server Ip: {0}", serverIP);
            this.ServerAddress = new NetworkAddress(serverIP, receivePort);
        }

        /// <summary>
        /// Gets the <see cref="NetworkAddress"/> of the server
        /// </summary>
        /// <value>The server address.</value>
        public NetworkAddress ServerAddress { get; }

        public void AcceptClients()
        {
            this.clientManager.ListenForClients();
        }

        public void BroadcastCommand(TimerCommand command, params double[] args)
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

        public void BroadcastCommand(TimerCommand command, byte[] args)
        {
            Console.WriteLine("Broadcasting command: " + command.ToString());
            var commandData = CommandDataFactory.Instance.GetCommandData(command, args);
            this.TransmitData(commandData);
        }

        public void TransmitData(NetworkData data)
        {
            var packet = NetworkPacketFactory.Instance.GetNetworkPacket(data);
            var bytes = NetworkUtils.ObjectToByteArray(packet);
            this.server.BroadcastAsync(bytes);
        }

    }
}

