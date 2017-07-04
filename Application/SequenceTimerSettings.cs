using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchTimer.Application
{
    public class SequenceTimerSettings : TimerSettings
    {
        public SequenceTimerSettings(int id) : base(id)
        {
        }

        public override object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
