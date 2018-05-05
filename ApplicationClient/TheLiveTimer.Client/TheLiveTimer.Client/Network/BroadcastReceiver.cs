namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Network;

    /// <summary>
    /// A UDP reciever which listens for a <see cref="TimerNetworkPacket"/> on the specified port.
    /// </summary>
    internal class BroadcastReceiver : IReceiverAsync
    {
        private readonly int port;
        private readonly UdpClient udp;
        //private readonly Thread listeneningThread;
        private BufferBlock<ReceivedPacket> buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.BroadcastReceiver"/> class.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        /// <param name="buffer">Buffer to store received packets. Must not be null</param>
        public BroadcastReceiver(int port, BufferBlock<ReceivedPacket> buffer)
        {
            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, this.port = port);
                this.udp = new UdpClient(ip);
            }
            catch(Exception e)
            {
                
            }

            this.buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
            //this.listeneningThread = new Thread(this.StartListening);
        }

        public bool IsListening { get; private set; }

        /// <summary>
        /// Starts listening asynchronously on another thread
        /// </summary>
        public async Task StartListeningAsync()
        {
            //if (!this.listeneningThread.IsAlive)
            //{
            //    this.listeneningThread.Start();
            //}

            this.IsListening = true;

            Console.WriteLine("----- trying to receive");
            while (true)
            {
                Console.WriteLine("----- waiting for packet");

                var result = await this.udp.ReceiveAsync();

                Console.WriteLine("----- received packet");

                var data = result.Buffer;
                var sender = new NetworkAddress(result.RemoteEndPoint);

                await this.ProcessData(result.Buffer, sender);
            }
        }

        public void Dispose()
        {
            this.IsListening = false;

            this.udp.Close();

            //if (this.listeneningThread.IsAlive)
            //{
            //    this.listeneningThread.Abort();
            //    this.listeneningThread.Join();
            //}
        }

        //private void StartListening()
        //{
        //    while (true)
        //    {
        //        this.udp.BeginReceive(Receive, new object());
        //    }
        //}

        //private void Receive(IAsyncResult ar)
        //{
        //    IPEndPoint ip = new IPEndPoint(IPAddress.Any, this.port);
        //    byte[] bytes = udp.EndReceive(ar, ref ip);

        //    var sender = new NetworkAddress(ip);
        //    this.ProcessData(bytes, sender);
        //    //StartListening();
        //}

        private async Task ProcessData(byte[] data, NetworkAddress sender)
        {
            Console.WriteLine("------ Processing packet: \n");

            var packet = NetworkUtils.ByteArrayToObject(data);
            if (packet is TimerNetworkPacket networkPacket)
            {
                Console.WriteLine("----- packet added to queue");

                // Add network data to the buffer
                await this.buffer.SendAsync(new ReceivedPacket(networkPacket, sender));
            }
        }
    }

}
