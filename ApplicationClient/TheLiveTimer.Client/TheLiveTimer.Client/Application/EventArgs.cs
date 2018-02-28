namespace TheLiveTimer.Client
{
    using System;

    internal class CurrentTimeEventArgs : EventArgs
    {
        public CurrentTimeEventArgs(double? currentTime)
        {
            this.CurrentTime = currentTime;
        }

        public double? CurrentTime { get; private set; }
    }

    internal class BroadcastReadyEventArgs : EventArgs
    {
        public BroadcastReadyEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}
