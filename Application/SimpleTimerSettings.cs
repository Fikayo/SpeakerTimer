namespace SpeakerTimer.Application
{
    using System.Drawing;

    public class SimpleTimerSettings : ITimerSettings
    {
        private static readonly string DefaultName = "Un-named";

        private string name;
        private static int count = 0;

        public SimpleTimerSettings(int id, string name, string finalmessage, bool blinkOnExpired, TimerDurationSettings durationSettings, TimerVisualSettings visualSettings)
        {
            this.Id = id;
            this.name = name;
            this.FinalMessage = finalmessage;
            this.BlinkOnExpired = blinkOnExpired;
            this.TimerDuration = new TimerDurationSettings(durationSettings.DurationId, durationSettings);
            this.VisualSettings = new TimerVisualSettings(visualSettings.VisualId, visualSettings);
        }

        public SimpleTimerSettings(int id, SimpleTimerSettings copy) :
            this(id, copy.name, copy.FinalMessage, copy.BlinkOnExpired, copy.TimerDuration, copy.VisualSettings)
        { }

        private SimpleTimerSettings(bool isDefault = false)
        {
            this.SetDefaultSettings();
            if (isDefault)
            {
                this.Id = SimpleTimerSettings.count++;
            }
        }

        public int Id { get; private set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.name))
                {
                    return SimpleTimerSettings.DefaultName + SimpleTimerSettings.count;
                }

                return this.name;
            }

            set
            {
                this.name = value;
                if (!string.IsNullOrEmpty(this.name))
                {
                    SimpleTimerSettings.count--;
                }
            }
        }

        public string FinalMessage { get; set; }

        public bool BlinkOnExpired { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }

        public TimerDurationSettings TimerDuration { get; set; }

        #region Propeties

        public static SimpleTimerSettings Default
        {
            get { return new SimpleTimerSettings(true); }
        }

        private static SimpleTimerSettings Empty
        {
            get { return new SimpleTimerSettings(); }
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

        public ITimerSettings Clone()
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

            return this.Name.Equals(that.Name)
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

        public static bool IsUntitled(string name)
        {
            if (name.StartsWith(SimpleTimerSettings.DefaultName))
            {
                string remnant = name.Replace(SimpleTimerSettings.DefaultName, string.Empty);
                int value;
                return int.TryParse(remnant, out value);
            }

            return false;
        }

        public static SimpleTimerSettings ParseCsv(string csv)
        {
            SimpleTimerSettings settings = SimpleTimerSettings.Empty;

            try
            {
                var values = csv.Split(new char[] { ',' });
                int id = SimpleTimerSettings.count;
                int.TryParse(values[0], out id);

                settings.Id = id;
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
                return settings;
            }
        }
    }
}