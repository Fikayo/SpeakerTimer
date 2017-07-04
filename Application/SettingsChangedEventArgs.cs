﻿namespace ChurchTimer.Application
{
    using System;

    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(SimpleTimerSettings settings)
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

        public SimpleTimerSettings Settings { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }
    }
}
