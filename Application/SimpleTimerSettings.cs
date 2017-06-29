namespace SpeakerTimer.Application
{
    using System.Drawing;

    public class SimpleTimerSettings : TimerSettings
    {
        public SimpleTimerSettings(int id, string name, string finalmessage, bool blinkOnExpired, TimerDurationSettings durationSettings, TimerVisualSettings visualSettings, TimerMessageSettings messageSettings)
            : base(id)
        {
            this.name = name ?? TimerSettings.DefaultName;
            this.FinalMessage = finalmessage ?? string.Empty;
            this.BlinkOnExpired = blinkOnExpired;
            this.TimerDuration = new TimerDurationSettings(durationSettings.DurationId, durationSettings);
            this.VisualSettings = new TimerVisualSettings(visualSettings.VisualId, visualSettings);
            this.MessageSettings = messageSettings ?? TimerMessageSettings.Default;
        }

        public SimpleTimerSettings(int id, SimpleTimerSettings copy) :
            this(id, copy.name, copy.FinalMessage, copy.BlinkOnExpired, copy.TimerDuration, copy.VisualSettings, copy.MessageSettings)
        { }

        private SimpleTimerSettings(int id) : base(id)
        {
            this.SetDefaultSettings();
        }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }

        public TimerDurationSettings TimerDuration { get; set; }

        #region Propeties

        private static System.Random rand = new System.Random();
        public static SimpleTimerSettings Default
        {
            get { return new SimpleTimerSettings(-1 * rand.Next()); }
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

            if (ReferenceEquals(this, obj))
            {
                return true;
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

        public override string ToString()
        {
            return string.Format("{0}: {1}", this.id, this.name);
        }

        protected override void SetDefaultSettings()
        {
            base.SetDefaultSettings();
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

                var settings = new SimpleTimerSettings(id)
                {
                    Name = values[1],
                    TimerDuration = TimerDurationSettings.ParseCsv(csv, 2),
                    BlinkOnExpired = bool.Parse(values[6]),
                    FinalMessage = values[7],
                    VisualSettings = TimerVisualSettings.ParseCsv(csv, 8),
                };

                return settings;
            }
            catch
            {
                return SimpleTimerSettings.Default;
            }
        }
    }
}