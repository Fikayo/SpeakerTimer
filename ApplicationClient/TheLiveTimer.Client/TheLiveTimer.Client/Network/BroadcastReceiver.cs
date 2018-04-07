namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Network;

    /// <summary>
    /// A UDP reciever which listens for a <see cref="TimerNetworkPacket"/> on the specified port.
    /// </summary>
    internal class BroadcastReceiver : IDisposable
    {
        private readonly int port;
        private readonly UdpClient udp;
        private Thread listeneningThread;
        private BufferBlock<TimerCommandData> buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.BroadcastReceiver"/> class.
        /// </summary>
        /// <param name="port">Port to listen on</param>
        /// <param name="buffer">Buffer to store received packets. Must not be null</param>
        public BroadcastReceiver(int port, BufferBlock<TimerCommandData> buffer)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }


            this.udp = new UdpClient(port);
            this.port = port;
            this.buffer = buffer;
        }

        /// <summary>
        /// Starts listening asynchronously on another thread
        /// </summary>
        public void StartListeningAsync()
        {
            this.listeneningThread = new Thread(this.StartListening);
            this.listeneningThread.Start();
        }

        public void Close()
        {
            this.udp.Close();
        }

        public void Dispose()
        {
            this.Close();
        }

        private void StartListening()
        {
            this.udp.BeginReceive(Receive, new object());
        }

        private void Receive(IAsyncResult ar)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, this.port);
            byte[] bytes = udp.EndReceive(ar, ref ip);
            this.ProcessData(bytes);
            StartListening();
        }

        private void ProcessData(byte[] data)
        {
            Console.WriteLine("received broadcast: \n");

            //var packet = TimerNetworkPacket.FromBytes(data);
            var packet = NetworkUtils.ByteArrayToObject(data);
            if (packet is TimerNetworkPacket)
            {
                var networkPacket = (TimerNetworkPacket)packet;

                // The expected data *should* be TimerCommandData since this is the broadcast receiver
                var commandData = networkPacket.NetworkData as TimerCommandData;

                // Add network data to the buffer
                this.buffer.SendAsync(commandData);
            }
        }
    }

}
