﻿namespace SpeakerTimer.Application
{
    public class TimerDurationSettings
    {
        private static readonly string DefaultTitle = "Untitled";
        private readonly int id;

        private TimerDurationSettings(int durationId)
        {
            this.id = durationId;
            this.SetDefaultSettings();
        }

        public TimerDurationSettings(int durationId, TimerDurationSettings copy)
        {
            this.id = durationId;
            this.Title = copy.Title;
            this.Duration = copy.Duration;
            this.WarningTime = copy.WarningTime;
            this.SecondWarningTime = copy.SecondWarningTime;
        }

        public int DurationId { get { return this.id; } }

        public string Title { get; set; }

        public double Duration { get; set; } // In seconds

        public double WarningTime { get; set; }

        public double SecondWarningTime { get; set; }

        public bool HasFirstWarning { get { return this.WarningTime > 0; } }

        public bool HasSecondWarning { get { return this.SecondWarningTime > 0; } }

        public static TimerDurationSettings Default
        {
            get { return new TimerDurationSettings(-1); }
        }

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3}",
                this.Title,
                this.Duration,
                this.WarningTime,
                this.SecondWarningTime);
        }

        public TimerDurationSettings Clone()
        {
            return new TimerDurationSettings(this.DurationId, this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TimerDurationSettings that = obj as TimerDurationSettings;
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
            this.Title = TimerDurationSettings.DefaultTitle;
        }

        public static TimerDurationSettings ParseCsv(string csv, int start = 0)
        {

            try
            {
                var values = csv.Split(new char[] { ',' });

                var settings = new TimerDurationSettings(int.Parse(values[start + 0]));

                settings.Title = values[start + 1];
                settings.Duration = double.Parse(values[start + 2]);
                settings.WarningTime = double.Parse(values[start + 3]);
                settings.SecondWarningTime = double.Parse(values[start + 4]);

                return settings;
            }
            catch
            {
                return TimerDurationSettings.Default;
            }
        }

    }
}