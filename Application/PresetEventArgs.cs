namespace SpeakerTimer.Application
{
	using System;
	using System.Collections.Generic;

    public class PresetEventArgs : EventArgs
    {
        public PresetEventArgs(List<IdNamePair> pairs)
        {
            this.Pairs = pairs;
        }

        public List<IdNamePair> Pairs { get; private set; }
    }
}
