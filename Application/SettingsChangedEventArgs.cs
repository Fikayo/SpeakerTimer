﻿namespace SpeakerTimer
{
    using System;

    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(TimerViewSettings settings)
        {
            this.Settings = settings;
        }

        public SettingsChangedEventArgs(TimerViewSettings.TimerVisualSettings settings)
        {
            this.VisualSettings = settings;
        }

        public SettingsChangedEventArgs(TimerViewSettings.TimerMessageSettings settings)
        {
            this.MessageSettings = settings;
        }

        public TimerViewSettings Settings { get; set; }

        public TimerViewSettings.TimerVisualSettings VisualSettings { get; set; }

        public TimerViewSettings.TimerMessageSettings MessageSettings { get; set; }
    }
}
