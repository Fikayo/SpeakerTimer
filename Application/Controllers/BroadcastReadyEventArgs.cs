using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchTimer.Application.Controllers
{
    public class BroadcastReadyEventArgs : EventArgs
    {
        public BroadcastReadyEventArgs(TimerMessageSettings message)
        {
            this.Message = message;
        }

        public TimerMessageSettings Message { get; private set; }
    }
}
