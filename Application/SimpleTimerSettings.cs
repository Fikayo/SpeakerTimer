namespace SpeakerTimer.Application
{
    using System.Drawing;

    public class SimpleTimerSettings : TimerSettings
    {
        public SimpleTimerSettings(int id, string name, string finalmessage, bool blinkOnExpired, TimerDurationSettings durationSettings, TimerVisualSettings visualSettings)
            : base(id)
        {
            this.name = name;
            this.FinalMessage = finalmessage;
            this.BlinkOnExpired = blinkOnExpired;
            this.TimerDuration = new TimerDurationSettings(durationSettings.DurationId, durationSettings);
            this.VisualSettings = new TimerVisualSettings(visualSettings.VisualId, visualSettings);
        }

        public SimpleTimerSettings(int id, SimpleTimerSettings copy) :
            this(id, copy.name, copy.FinalMessage, copy.BlinkOnExpired, copy.TimerDuration, copy.VisualSettings)
        { }

        private SimpleTimerSettings(int id) : base(id)
        {
            this.SetDefaultSettings();
        }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }

        public TimerDurationSettings TimerDuration { get; set; }

        #region Propeties

        public static SimpleTimerSettings Default
        {
            get { return new SimpleTimerSettings(-1); }
        }

        #endregion

        public void SetFont(string fontFamily = "", float fontSize = 0f)
        {
            this.VisualSettings.SetFont(fontFamily, fontSize);
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5}",
                this.Id,
                this.Name,
                ////this.Title,
                ////this.Duration,
                ////this.WarningTime,
                ////this.SecondWarningTime,
                this.TimerDuration.ToCsv(),

                this.BlinkOnExpired,
                this.FinalMessage,
                this.VisualSettings.ToCsv());
        }

        public override object Clone()
        {
            return new SimpleTimerSettings(this.Id, this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            SimpleTimerSettings that = obj as SimpleTimerSettings;
            if (that == null) return false;

            return this.id.Equals(that.id)
                && this.Name.Equals(that.Name)
                && this.TimerDuration.Equals(that.TimerDuration)
                && this.BlinkOnExpired.Equals(that.BlinkOnExpired)
                && this.FinalMessage.Equals(that.FinalMessage)
                && this.VisualSettings.Equals(that.VisualSettings);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void SetDefaultSettings()
        {
            this.TimerDuration = TimerDurationSettings.Default;
            this.VisualSettings = TimerVisualSettings.Default;
            this.MessageSettings = TimerMessageSettings.Default;
            this.BlinkOnExpired = false;
        }

        public static SimpleTimerSettings ParseCsv(string csv)
        {
            try
            {
                var values = csv.Split(new char[] { ',' });
                int id = -1;
                int.TryParse(values[0], out id);

                SimpleTimerSettings settings = new SimpleTimerSettings(id);

                settings.Name = values[1];

                ////settings.TimerDuration.Title = values[2];
                ////settings.TimerDuration.Duration = double.Parse(values[3]);
                ////settings.TimerDuration.WarningTime = double.Parse(values[4]);
                ////settings.TimerDuration.SecondWarningTime = double.Parse(values[5]);

                settings.TimerDuration = TimerDurationSettings.ParseCsv(csv, 2);

                settings.BlinkOnExpired = bool.Parse(values[6]);
                settings.FinalMessage = values[7];

                settings.VisualSettings = TimerVisualSettings.ParseCsv(csv, 8);

                return settings;
            }
            catch
            {
                return SimpleTimerSettings.Default;
            }
        }
    }
}