namespace SpeakerTimer.Application
{
    using System;

    public class SettingIOEventArgs : EventArgs
    {
        public SettingIOEventArgs(string name, SimpleTimerSettings settings = null)
        {
            this.SettingName = name;
            this.Settings = settings;
        }

        public string SettingName { get; private set; }

        public SimpleTimerSettings Settings { get; private set; }
    }
}
