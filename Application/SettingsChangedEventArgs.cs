﻿namespace SpeakerTimer.Application
{
    using System;

    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(TimerViewSettings settings)
        {
            this.Settings = settings;
        }

        public SettingsChangedEventArgs(TimerVisualSettings settings)
        {
            this.VisualSettings = settings;
        }

        public SettingsChangedEventArgs(TimerMessageSettings settings)
        {
            this.MessageSettings = settings;
        }

        public TimerViewSettings Settings { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }
    }
}
