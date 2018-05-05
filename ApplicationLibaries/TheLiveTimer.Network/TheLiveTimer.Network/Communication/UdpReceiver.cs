namespace TheLiveTimer.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;

    /// <summary>
    /// A UDP reciever which listens for a <see cref="TimerNetworkPacket"/> on the specified port.
    /// </summary>
    public class UdpReceiver : IReceiverAsync
    {
        private readonly int port;
        private readonly UdpClient udp;
        private readonly Thread listeneningThread;
        private readonly BlockingCollection<ReceivedPacket> queue;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.BroadcastReceiver"/> class.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        /// <param name="queue">Buffer to store received packets. Must not be null</param>
        public UdpReceiver(int port, BlockingCollection<ReceivedPacket> queue)
        {
            this.udp = new UdpClient(port);
            this.port = port;
            this.listeneningThread = new Thread(this.StartListening);
            this.queue = queue ?? throw new ArgumentNullException(nameof(queue));;
        }

        public bool IsListening => this.listeneningThread != null && this.listeneningThread.IsAlive;

        /// <summary>
        /// Starts listening asynchronously on another thread
        /// </summary>
        public Task StartListeningAsync()
        {
            if (!this.listeneningThread.IsAlive)
            {
                this.listeneningThread.Start();
            }

            return null;
        }

        public void Dispose()
        {
            this.udp.Close();

            if (this.listeneningThread.IsAlive)
            {
                this.listeneningThread.Abort();
                this.listeneningThread.Join();
            }
        }

        private void StartListening()
        {
            while (true)
            {
                this.udp.BeginReceive(Receive, new object());
            }
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, this.port);
            byte[] bytes = udp.EndReceive(ar, ref ip);

            var sender = new NetworkAddress(ip);
            this.ProcessData(bytes, sender);
            //StartListening();
        }

        private void ProcessData(byte[] data, NetworkAddress sender)
        {
            Console.WriteLine("------ Received broadcast: \n");

            var packet = NetworkUtils.ByteArrayToObject(data);
            if (packet is TimerNetworkPacket networkPacket)
            {
                // Add network data to the buffer
                this.queue.Add(new ReceivedPacket(networkPacket, sender));
            }
        }
    }

}
