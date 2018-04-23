namespace TheLiveTimer.Client.Network
{
    using System;
    using System.Threading.Tasks;
    using TheLiveTimer.Network;

    internal class CommandProcessor
    {

        public CommandProcessor(ClientNetworkCommunicator communicator)
        {
            this.NetworkCommunicator = communicator;
        }

        public ClientNetworkCommunicator NetworkCommunicator { get; }

        internal ClientTimerController TimerController { get { return this.NetworkCommunicator.TimerController; }}

        public void ProcessCommand(TimerCommandData commandData)
        {
            switch (commandData.Command)
            {
                case TimerCommand.TimeUpdated:
                    {
                        Console.WriteLine("Command Data Arguments is null: {0}", commandData.Arguments == null);
                        double time = BitConverter.ToDouble(commandData.Arguments, 0);
                        this.TimerController.UpdateTime(time);
                        Console.WriteLine("Received time: " + time);

                        break;
                    }

                case TimerCommand.TimeStarted:
                    this.TimerController.StartTimer();
                    break;

                case TimerCommand.TimePaused:
                    this.TimerController.PauseTimer();
                    break;

                case TimerCommand.TimeStopped:
                    this.TimerController.StopTimer();
                    break;

                case TimerCommand.TimeExpired:
                    this.TimerController.ExpireTime();
                    break;

                case TimerCommand.SettingsUpdated:
                    {
                        var settings = SimpleTimerSettings.FromString(NetworkUtils.GetString(commandData.Arguments));
                        this.TimerController.UpdateSettings(settings);
                        break;
                    }

                case TimerCommand.BroadcastReady:
                    {
                        var message = NetworkUtils.GetString(commandData.Arguments);
                        this.TimerController.BroadcastMessage(message);
                        break;
                    }

                case TimerCommand.BroadcastOver:
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
    
    }
}
