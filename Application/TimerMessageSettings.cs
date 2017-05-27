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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TimerMessageSettings that = obj as TimerMessageSettings;
            if (that == null) return false;

            return this.TimerMessage.Equals(that.TimerMessage)
                && this.MessageDuration.Equals(that.MessageDuration)
                && this.MessageFontSize.Equals(that.MessageFontSize)
                && this.IsIndefiniteMessage.Equals(that.IsIndefiniteMessage);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
