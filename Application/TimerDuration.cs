namespace SpeakerTimer.Application
{
    public class TimerDuration
    {
        private static readonly string DefaultTitle = "Untitled";

        private TimerDuration()
        {
            this.SetDefaultSettings();
        }

        public string Title { get; set; }

        public double Duration { get; set; } // In seconds

        public double WarningTime { get; set; }

        public double SecondWarningTime { get; set; }

        public bool HasFirstWarning { get { return this.WarningTime > 0; } }

        public bool HasSecondWarning { get { return this.SecondWarningTime > 0; } }

        public static TimerDuration Default
        {
            get { return new TimerDuration(); }
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3}",
                this.Title,
                this.Duration,
                this.WarningTime,
                this.SecondWarningTime);
        }

        public TimerDuration Clone()
        {
            TimerDuration clone = new TimerDuration();
            clone.Title = this.Title;
            clone.Duration = this.Duration;
            clone.WarningTime = this.WarningTime;
            clone.SecondWarningTime = this.SecondWarningTime;

            return clone;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TimerDuration that = obj as TimerDuration;
            if (that == null) return false;

            return this.Title.Equals(that.Title)
                && this.Duration.Equals(that.Duration)
                && this.WarningTime.Equals(that.WarningTime)
                && this.SecondWarningTime.Equals(that.SecondWarningTime);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void SetDefaultSettings()
        {
            this.Title = TimerDuration.DefaultTitle;
        }

        public static TimerDuration ParseCsv(string csv, int start = 0)
        {
            TimerDuration settings = new TimerDuration();

            try
            {
                var values = csv.Split(new char[] { ',' });

                settings.Title = values[start + 0];
                settings.Duration = double.Parse(values[start + 1]);
                settings.WarningTime = double.Parse(values[start + 2]);
                settings.SecondWarningTime = double.Parse(values[start + 3]);

                return settings;
            }
            catch
            {
                return settings;
            }
        }

    }
}
