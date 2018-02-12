namespace ChurchTimer.Application
{
    using System;

    public class CurrentTimeEventArgs : EventArgs
    {
        public CurrentTimeEventArgs(double? currentTime)
        {
            this.CurrentTime = currentTime;
        }

        public double? CurrentTime { get; private set; }
    }
}
