namespace TheLiveTimer.Server.Network
{
    using System;
    using TheLiveTimer.Network;

    internal class NetworkCommunicator
    {
        private NetworkServer server;

        public NetworkCommunicator(int receivePort, int sendPort)
        {
            this.server = new NetworkServer(receivePort, sendPort);
            ////this.server.OpenAsync();
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
            var packet = new TimerNetworkPacket(0, 0, command, args);
            if (command == TimerNetworkCommand.BroadcastReady)
            {
                Console.WriteLine("args: " + NetworkUtils.GetString(args));
                Console.WriteLine("args length: " + args.Length);
                Console.WriteLine("packet byte length: " + packet.ToByteArray().Length);
            }

            //var packet = new TimerNetworkPacket(0, 0, command, args);
            this.server.Broadcast(packet.ToByteArray());
        }
    }
}
