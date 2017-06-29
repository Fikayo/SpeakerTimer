namespace SpeakerTimer.Application
{
    using System;

    public class SettingIOEventArgs : EventArgs
    {
        public SettingIOEventArgs(IdNamePair settingPair)
        {
            this.SettingPair = settingPair;
        }

        public SettingIOEventArgs(SimpleTimerSettings settings)
        {
            this.Settings = settings;
        }
        
        public IdNamePair SettingPair { get; private set; }

        public SimpleTimerSettings Settings { get; private set; }
    }
}
