namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Threading.Tasks.Dataflow;

    /// <summary>
    /// Receives timer commands and sends them to the local timer controller
    /// </summary>
    internal class ClientNetworkCommunicator
    {
        public const int UdpDefaultPort = 5004;

        private BufferBlock<TimerNetworkPacket> queue;
        private BroadcastReceiver receiver;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TheLiveTimer.Client.Network.ClientNetworkCommunicator"/> class.
        /// </summary>
        /// <param name="port">Port to listen on. Default is <see cref="UdpDefaultPort"/>/> </param>
        /// <param name="queueCapacity">Determins the capacity of the network queue.</param>
        public ClientNetworkCommunicator(int port = UdpDefaultPort, int queueCapacity = 20)
        {
            this.queue = new BufferBlock<TimerNetworkPacket>(new DataflowBlockOptions { BoundedCapacity = queueCapacity });
            this.receiver = new BroadcastReceiver(port, queue);
            this.TimerController = new ClientTimerController();
        }

        public ClientTimerController TimerController { get; private set; }

        /// <summary>
        /// Starts a UDP receiver which listens for commands from the server
        /// </summary>
        public void OpenCommnuication()
        {
            System.Console.WriteLine("---------- Opening commnication ----------- ");
            this.receiver.StartListeningAsync();
            this.Consume(this.queue);
        }

        private async void Consume(BufferBlock<TimerNetworkPacket> queue)
        {
            while (await queue.OutputAvailableAsync())
            {
                var packet = await queue.ReceiveAsync();

                ProcessCommand(packet);
            }
        }

        private void ProcessCommand(TimerNetworkPacket packet)
        {
            switch (packet.Command)
            {
                case TimerNetworkCommand.TimeUpdated:
                    {
                        double time = BitConverter.ToDouble(packet.Arguments, 0);
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
                        break;
                    }

                case TimerNetworkCommand.BroadcastReady:
                    {
                        var message = NetworkUtils.GetString(packet.Arguments);
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
                        Console.WriteLine("Unknown command: {0}", packet.Command);
                        break;
                    }

            }
        }
    }
}
