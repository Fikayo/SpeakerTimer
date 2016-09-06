using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer
{
    public class PresetEventArgs : EventArgs
    {
        public PresetEventArgs(List<string> names)
        {
            this.Names = names;
        }

        public List<string> Names { get; private set; }
    }
}
