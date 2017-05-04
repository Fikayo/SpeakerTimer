﻿namespace SpeakerTimer.Application
{
    using System;

    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(TimerViewSettings settings)
        {
            this.Settings = settings;
        }

        public TimerViewSettings Settings { get; set; }
    }
}
