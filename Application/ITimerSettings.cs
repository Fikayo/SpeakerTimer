using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer.Application
{
    public interface ITimerSettings : ICloneable
    {
        int Id { get; }

        string Name { get; set; }
    }
}
