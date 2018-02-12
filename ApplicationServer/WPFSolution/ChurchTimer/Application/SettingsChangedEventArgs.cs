﻿namespace ChurchTimer.Application
{
    using System;
    using ChurchTimer.Application.Settings;

    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(SimpleTimerSettings settings)
        {
            this.Settings = settings;
        }

        public SimpleTimerSettings Settings { get; set; }
    }
}
