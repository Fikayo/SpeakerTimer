namespace SpeakerTimer.Application
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

    public class PresetEventArgs : EventArgs
    {
        public PresetEventArgs(List<string> names)
        {
            this.Names = names;
        }

        public List<string> Names { get; private set; }
    }
}
