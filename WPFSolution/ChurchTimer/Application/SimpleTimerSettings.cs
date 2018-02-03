using System;
using System.Collections.Generic;
namespace ChurchTimer.Application.Settings
{
    public class SimpleTimerSettings
    {
        public SimpleTimerSettings()
        {
            this.Metadata = new SettingsMetaData();

            this.Metadata.Title = string.Empty;
            this.Metadata.Name = string.Empty;
            this.Metadata.FinalMessage = string.Empty;

            this.DurationSettings = new TimerDurationSettings();
            this.VisualSettings = new TimerVisualSettings();
        }

        public SettingsMetaData Metadata { get; set; }

        public TimerDurationSettings DurationSettings { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            SimpleTimerSettings that = obj as SimpleTimerSettings;
            if (that == null) return false;

            return true
            ////return this.id.Equals(that.id)
                && this.Metadata.Equals(that.Metadata)
                && this.DurationSettings.Equals(that.DurationSettings)
            ////    && this.BlinkOnExpired.Equals(that.BlinkOnExpired)
                && this.VisualSettings.Equals(that.VisualSettings);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 17;
        }

        public class SettingsMetaData
        {
            public string Title { get; set; }

            public string Name { get; set; }

            public string FinalMessage { get; set; }

            public bool BlinkingWhenExpired { get; set; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                SettingsMetaData that = obj as SettingsMetaData;
                if (that == null) return false;

                return this.Title.Equals(that.Title)
                    && this.Name.Equals(that.Name)
                    && this.FinalMessage.Equals(that.FinalMessage)
                    && this.BlinkingWhenExpired.Equals(that.BlinkingWhenExpired);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode() * 11;
            }
        }

    }
}
