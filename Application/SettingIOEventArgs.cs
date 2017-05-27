namespace SpeakerTimer.Application
{
    using System;

    public class SettingIOEventArgs : EventArgs
    {
        public SettingIOEventArgs(string name, TimerViewSettings settings = null)
        {
            this.SettingName = name;
            this.Settings = settings;
        }

        public string SettingName { get; private set; }

        public TimerViewSettings Settings { get; private set; }
    }
}
