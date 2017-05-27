using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer.Application
{
    public class TimerMessageSettings
    {
        private TimerMessageSettings()
        {
            this.SetDefaultSettings();
        }

        public static TimerMessageSettings Default
        {
            get { return new TimerMessageSettings(); }
        }

        public string TimerMessage { get; set; }

        public int MessageDuration { get; set; }

        public int MessageFontSize { get; set; }

        public bool IsIndefiniteMessage { get; set; }

        public TimerMessageSettings Clone()
        {
            TimerMessageSettings settings = new TimerMessageSettings();
            settings.TimerMessage = this.TimerMessage;
            settings.MessageDuration = this.MessageDuration;
            settings.MessageFontSize = this.MessageFontSize;
            settings.IsIndefiniteMessage = this.IsIndefiniteMessage;

            return settings;
        }

        private void SetDefaultSettings()
        {
            this.TimerMessage = string.Empty;
            this.MessageDuration = 0;
            this.MessageFontSize = 50;
            this.IsIndefiniteMessage = true;
        }
    }
}
