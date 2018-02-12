namespace ChurchTimer.Application
{
	using System;
	using System.Collections.Generic;

    public class PresetEventArgs<T> : EventArgs where T : TimerSettings
    {
        public PresetEventArgs(List<T> pairs)
        {
            this.Pairs = pairs;
        }

        public List<T> Pairs { get; private set; }
    }
}
