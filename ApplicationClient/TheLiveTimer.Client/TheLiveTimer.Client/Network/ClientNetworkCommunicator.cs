namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using TheLiveTimer.Network;

    /// <summary>
    /// Receives timer commands and sends them to the local timer controller
    /// </summary>
    internal class ClientNetworkCommunicator
    {
        public const int UdpDefaultPort = 5004;

        private BufferBlock<NetworkData> commandQueue;
        private BroadcastReceiver broadcastReceiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.ClientNetworkCommunicator"/> class.
        /// </summary>
        /// <param name="port">Port to listen on. Default is <see cref="UdpDefaultPort"/>/> </param>
        /// <param name="queueCapacity">Determins the capacity of the network queue.</param>
        public ClientNetworkCommunicator(int port = UdpDefaultPort, int queueCapacity = 20)
        {
            this.commandQueue = new BufferBlock<NetworkData>(new DataflowBlockOptions { BoundedCapacity = queueCapacity });
            this.broadcastReceiver = new BroadcastReceiver(port, commandQueue);
            this.TimerController = new ClientTimerController();
        }

        public ClientTimerController TimerController { get; private set; }

        /// <summary>
        /// Starts a UDP receiver which listens for commands from the server
        /// </summary>
        public void OpenCommnuication()
        {
            System.Console.WriteLine("---------- Opening commnication ----------- ");
            this.broadcastReceiver.StartListeningAsync();
            this.ConsumeAsync(this.commandQueue);
        }

        private async void ConsumeAsync(BufferBlock<NetworkData> queue)
        {
            while (await queue.OutputAvailableAsync())
            {
                var networkData = await queue.ReceiveAsync();

                ProcessNetworkData(networkData);
            }
        }

        private void ProcessNetworkData(NetworkData networkData)
        {
            if (networkData is TimerCommandData commandData)
            {
                ProcessCommand(commandData);
            }
            else if (networkData is ServerMessageData messageData)
            {
                ProcessServerMessage(messageData);
            }
        }

        private void ProcessCommand(TimerCommandData commandData)
        {
            switch (commandData.Command)
            {
                case TimerNetworkCommand.TimeUpdated:
                    {
                        double time = BitConverter.ToDouble(commandData.Arguments, 0);
                        this.TimerController.UpdateTime(time);
                        Console.WriteLine("Received time: " + time);

                        break;
                    }

                case TimerNetworkCommand.TimeStarted:
                    this.TimerController.StartTimer();
                    break;

                case TimerNetworkCommand.TimePaused:
                    this.TimerController.PauseTimer();
                    break;

                case TimerNetworkCommand.TimeStopped:
                    this.TimerController.StopTimer();
                    break;

                case TimerNetworkCommand.TimeExpired:
                    this.TimerController.ExpireTime();
                    break;

                case TimerNetworkCommand.SettingsUpdated:
                    {
                        var settings = SimpleTimerSettings.FromString(NetworkUtils.GetString(commandData.Arguments));
                        this.TimerController.UpdateSettings(settings);
                        break;
                    }

                case TimerNetworkCommand.BroadcastReady:
                    {
                        var message = NetworkUtils.GetString(commandData.Arguments);
                        this.TimerController.BroadcastMessage(message);
                        break;
                    }

                case TimerNetworkCommand.BroadcastOver:
                    {
                        this.TimerController.ClearBroadcast();
                        break;   
                    }

                default:
                    {
                        Console.WriteLine("Unknown command: {0}", commandData.Command);
                        break;
                    }

            }
        }
    
        private void ProcessServerMessage(ServerMessageData serverMessage)
        {
            switch(serverMessage.ServerMessage)
            {
                case ServerMessage.ServerReady:
                    {
                        break;
                    }

                case ServerMessage.ClientAccepted:
                    {
                        break;
                    }

                case ServerMessage.ClientDeclined:
                    {
                        break;
                    }

                case ServerMessage.ClientMax:
                    {
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Unknown server message: {0}", serverMessage.ServerMessage);
                        break;
                    }
            }

        }

    }
}
