namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Network;

    /// <summary>
    /// Receives timer commands and sends them to the local timer controller
    /// </summary>
    internal class ClientNetworkCommunicator
    {
        public const int UdpDefaultPort = 5004;

        private volatile bool isConnAllowed;
        private BufferBlock<NetworkData> commandQueue;
        private BroadcastReceiver broadcastReceiver;
        private CommandProcessor commandProcessor;
        private ServerMessageProcessor messageProcessor;
        private long communicationId;

        private object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.ClientNetworkCommunicator"/> class.
        /// </summary>
        /// <param name="port">Port to listen on. Default is <see cref="UdpDefaultPort"/>/> </param>
        /// <param name="queueCapacity">Determins the capacity of the network queue.</param>
        public ClientNetworkCommunicator(int port = UdpDefaultPort, int queueCapacity = 20)
        {
            this.commandQueue = new BufferBlock<NetworkData>(new DataflowBlockOptions { BoundedCapacity = queueCapacity });
            this.broadcastReceiver = new BroadcastReceiver(port, commandQueue);

            this.commandProcessor = new CommandProcessor(this);
            this.messageProcessor = new ServerMessageProcessor(this);
            this.messageProcessor.ClientAccepted += MessageHandler_ClientAccepted;
            this.messageProcessor.ClientDeclined += MessageProcessor_ClientDeclined;

            var clientIP = NetworkUtils.GetUnicastAddressV4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            this.ClientAddress = new NetworkAddress(clientIP, port);

            this.IsConnectionAllowed = false;
        }

        public event EventHandler ConnectionChanged;

        /// <summary>
        /// Gets or sets the timer controller.
        /// </summary>
        /// <value>The timer controller.</value>
        public ClientTimerController TimerController { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:TheLiveTimer.Client.Network.ClientNetworkCommunicator"/>
        /// is allowed connections to the server.
        /// </summary>
        /// <value><c>true</c> if connection allowed; otherwise, <c>false</c>.</value>
        public bool IsConnectionAllowed
        {
            get { return this.isConnAllowed; }

            set
            {
                var oldConn = this.isConnAllowed;
                lock (this._lock)
                {
                    this.isConnAllowed = value;
                }

                if(oldConn != value)
                {
                    this.OnConnectionChanged();
                }
            }

        }

        /// <summary>
        /// Gets the <see cref="NetworkAddress"/> of this client.
        /// </summary>
        /// <value>The client address.</value>
        public NetworkAddress ClientAddress { get; }

        /// <summary>
        /// Starts a UDP receiver which listens for commands from the server
        /// </summary>
        public void StartListening()
        {
            System.Console.WriteLine("---------- Opening commnication ----------- ");
            this.broadcastReceiver.StartListeningAsync();
            this.ConsumeAsync(this.commandQueue);
        }

        /// <summary>
        /// Transmit's the specified message to the server
        /// </summary>
        /// <returns>The transmit.</returns>
        /// <param name="message">Message.</param>
        public void Transmit(TcpClient tcpClient, ClientMessage message)
        {
            var messageData = new ClientMessageData(message, this.ClientAddress);
            var packet = NetworkPacketFactory.Instance.GetNetworkPacket(messageData);
            var data = NetworkUtils.ObjectToByteArray(packet);

            // Send data to server
            using (NetworkStream stream = tcpClient.GetStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }

        private async void ConsumeAsync(BufferBlock<NetworkData> queue)
        {
            while (await queue.OutputAvailableAsync())
            {
                var networkData = await queue.ReceiveAsync();

                Console.WriteLine("--- Receiving network data");
                this.ProcessNetworkData(networkData);
            }
        }

        private void ProcessNetworkData(NetworkData networkData)
        {
            if (networkData is TimerCommandData commandData)
            {
                Console.WriteLine("--- Timer Command Received");

                this.IsConnectionAllowed = this.communicationId == commandData.CommunicationId;

                if (this.IsConnectionAllowed)
                    this.commandProcessor.ProcessCommand(commandData);
            }
            else if (networkData is ServerMessageData messageData)
            {
                Console.WriteLine("--- Server Message received");

                this.messageProcessor.ProcessServerMessage(messageData);
            }
        }

        private void MessageHandler_ClientAccepted(object sender, ClientAcceptedEventArgs e)
        {
            this.communicationId = e.CommunicationId;
            this.IsConnectionAllowed = true;
        }

        private void MessageProcessor_ClientDeclined(object sender, ClientDeclinedEventArgs e)
        {
            this.IsConnectionAllowed = false;

            if (e.MaxClientsReached)
            {

            }
        }

        private void OnConnectionChanged()
        {
            var handler = this.ConnectionChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

    }
}
