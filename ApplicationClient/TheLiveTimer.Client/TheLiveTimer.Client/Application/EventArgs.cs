namespace TheLiveTimer.Client
{
    using System;

    internal class CurrentTimeEventArgs : EventArgs
    {
        public CurrentTimeEventArgs(double? currentTime)
        {
            this.CurrentTime = currentTime;
        }

        public double? CurrentTime { get; }
    }

    internal class BroadcastReadyEventArgs : EventArgs
    {
        public BroadcastReadyEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get;}
    }

    internal class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(SimpleTimerSettings settings)
        {
            this.Settings = settings;
        }

        public SimpleTimerSettings Settings { get; }
    }

    internal class ClientDeclinedEventArgs : EventArgs
    {
        public ClientDeclinedEventArgs(bool maxClients)
        {
            this.MaxClientsReached = maxClients;
        }

        public bool MaxClientsReached { get; }
    }

    internal class ClientAcceptedEventArgs : EventArgs
    {
        public ClientAcceptedEventArgs(long commId)
        {
            this.CommunicationId = commId;
        }

        public long CommunicationId { get; }
    }
}
