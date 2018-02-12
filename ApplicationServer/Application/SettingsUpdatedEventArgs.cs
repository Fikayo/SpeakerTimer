using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChurchTimer.Application
{
    public class SettingsUpdatedEventArgs : EventArgs
    {
        public SettingsUpdatedEventArgs(int timerId)
        {
            this.TimerId = timerId;
        }

        public int TimerId { get; private set; }
    }
}
