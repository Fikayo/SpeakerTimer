namespace ChurchTimer.Application
{
    using System;

    public class DurationChangedEventArgs : EventArgs
    {
        public DurationChangedEventArgs(double duration)
        {
            this.Duration = duration;
        }

        public double Duration { get; set; }
    }
}
