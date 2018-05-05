namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Collections.Concurrent;
    using System.Net.Sockets;
    using System.Threading;
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
        //private readonly BlockingCollection<ReceivedPacket> commandQueue;
        private readonly BufferBlock<ReceivedPacket> commandQueue;
        private readonly IReceiverAsync broadcastReceiver;
        private CommandProcessor commandProcessor;
        private ServerMessageProcessor messageProcessor;
        //private Thread receivingThread;
        private long communicationId;

        private readonly object _lock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.ClientNetworkCommunicator"/> class.
        /// </summary>
        /// <param name="port">Port to listen on. Default is <see cref="UdpDefaultPort"/>/> </param>
        /// <param name="queueCapacity">Determins the capacity of the network queue.</param>
        public ClientNetworkCommunicator(int port = UdpDefaultPort, int queueCapacity = 20)
        {
            //this.commandQueue = new BlockingCollection<ReceivedPacket>(queueCapacity);
            this.commandQueue = new BufferBlock<ReceivedPacket>(new DataflowBlockOptions() { BoundedCapacity = queueCapacity });
            //this.broadcastReceiver = new UdpReceiver(port, commandQueue);
            this.broadcastReceiver = new BroadcastReceiver(port, commandQueue);

            var clientIP = NetworkUtils.GetUnicastAddressV4(System.Net.NetworkInformation.NetworkInterfaceType.Wireless80211);
            this.ClientAddress = new NetworkAddress(clientIP, port);
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
                bool connChanged;
                lock (this._lock)
                {
                    connChanged = this.isConnAllowed != value;
                    this.isConnAllowed = value;
                }

                if (connChanged)
                {
                    this.OnConnectionChanged();
                }
            }

        }

        private long CommunicationId
        {
            set
            {
                lock (this._lock)
                {
                    this.communicationId = value;
                }
            }

        }

        /// <summary>
        /// Gets the <see cref="NetworkAddress"/> of this client.
        /// </summary>
        /// <value>The client address.</value>
        public NetworkAddress ClientAddress { get; }

        public void Initialise()
        {
            this.Init();
            this.StartListening();
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

        #region Internal Members

        private async void Init()
        {
            this.IsConnectionAllowed = false;

            if (this.commandProcessor == null)
            {
                this.commandProcessor = new CommandProcessor(this);
            }

            if (this.messageProcessor == null)
            {
                this.messageProcessor = new ServerMessageProcessor(this);
                this.messageProcessor.ClientAccepted += MessageHandler_ClientAccepted;
                this.messageProcessor.ClientDeclined += MessageProcessor_ClientDeclined;
                this.messageProcessor.ServerReady += MessageProcessor_ServerReady;
            }

            //if (this.receivingThread == null)
            //{
            //    this.receivingThread = new Thread(() =>
            //    {
            //        this.ConsumePacketAsync(this.commandQueue);
            //    });
            //
            //    this.receivingThread.Start();
            //}
            await this.ConsumePacketAsync(this.commandQueue);
        }

        private async void StartListening()
        {
            if (!this.broadcastReceiver.IsListening)
            {
                System.Console.WriteLine("---------- Opening commnication ----------- ");
                await this.broadcastReceiver.StartListeningAsync();
            }
        }

        private void IssueClientRequest(NetworkAddress serverAddress)
        {
            Console.WriteLine("--- have the addy");

            var serverTcpClient = new TcpClient(serverAddress.IP.ToString(), serverAddress.Port);
            Console.WriteLine("--- have the tcp client");

            // Transmit request to server
            this.Transmit(serverTcpClient, ClientMessage.ClientRequest);
        }

        private async Task ConsumePacketAsync(BufferBlock<ReceivedPacket> queue)
        {
            Console.WriteLine("--- Opening consumer ");

            while (await queue.OutputAvailableAsync())
            {
                var packet = await queue.ReceiveAsync();

                Console.WriteLine("--- Consuming packet");
                this.ProcessNetworkData(packet);
            }
        }

        private void ConsumePacketAsync(BlockingCollection<ReceivedPacket> queue)
        {
            while (true)
            {
                var packet = queue.Take();

                Console.WriteLine("--- Consuming packet");
                this.ProcessNetworkData(packet);
            }
        }

        private void ProcessNetworkData(ReceivedPacket packet)
        {
            var networkData = packet.Packet.NetworkData;
            if (networkData is TimerCommandData commandData)
            {
                Console.WriteLine("--- Timer Command Received");

                this.IsConnectionAllowed = this.communicationId == commandData.CommunicationId;

                if (this.IsConnectionAllowed)
                {
                    this.commandProcessor.ProcessCommand(commandData);
                }
                else
                {
                    // Connection not allowed, issue client request
                    this.IssueClientRequest(packet.Sender);
                }
            }
            else if (networkData is ServerMessageData messageData)
            {
                Console.WriteLine("--- Server Message received");

                this.messageProcessor.ProcessServerMessage(messageData);
            }
        }

        #endregion

        #region Event Handlers

        private void MessageHandler_ClientAccepted(object sender, ClientAcceptedEventArgs e)
        {
            Console.WriteLine("---->>> CLIENT ACCPETED: {0}", this.communicationId);
            this.CommunicationId = e.CommunicationId;
            this.IsConnectionAllowed = true;
        }

        private void MessageProcessor_ClientDeclined(object sender, ClientDeclinedEventArgs e)
        {
            this.IsConnectionAllowed = false;

            if (e.MaxClientsReached)
            {

            }
        }

        private void MessageProcessor_ServerReady(object sender, ServerReadyEventArgs e)
        {
            var serverAddress = e.ServerAddress;
            this.IssueClientRequest(serverAddress);
        }

        #endregion

        #region Event Triggers

        private void OnConnectionChanged()
        {
            var handler = this.ConnectionChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

    }
}
