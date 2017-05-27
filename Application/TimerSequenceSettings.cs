namespace SpeakerTimer.Application
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;.

    public class TimerSequenceSettings
    {
        private static readonly string DefaultName = "Un-named";

        private string name;
        private static int count = 0;
        private readonly List<TimerDuration> timerDurations;

        public TimerSequenceSettings(bool isDefault = false)
        {
            this.timerDurations = new List<TimerDuration>();
            this.SetDefaultSettings();
            if (isDefault)
            {
                this.Id = TimerSequenceSettings.count++;
            }
        }

        public int Id { get; private set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.name))
                {
                    return TimerSequenceSettings.DefaultName + TimerSequenceSettings.count;
                }

                return this.name;
            }

            set
            {
                this.name = value;
                if (!string.IsNullOrEmpty(this.name))
                {
                    TimerSequenceSettings.count--;
                }
            }
        }

        public string FinalMessage { get; set; }

        public bool BlinkOnExpired { get; set; }

        public ReadOnlyCollection<TimerDuration> TimerDurations
        {
            get { return new ReadOnlyCollection<TimerDuration>(this.timerDurations); }
        }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }

        #region Propeties

        public static TimerSequenceSettings Default
        {
            get { return new TimerSequenceSettings(true); }
        }

        private static TimerSequenceSettings Empty
        {
            get { return new TimerSequenceSettings(); }
        }

        #endregion

        public string ToCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                this.Id,
                this.Name,
                this.BlinkOnExpired,
                this.FinalMessage,
                this.timerDurations.ToString(),
                this.VisualSettings.ToCsv());
        }

        public TimerSequenceSettings Clone()
        {
            TimerSequenceSettings clone = new TimerSequenceSettings();
            clone.timerDurations.AddRange(this.TimerDurations);
            clone.VisualSettings = this.VisualSettings.Clone();
            clone.MessageSettings = this.MessageSettings.Clone();

            return clone;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TimerSequenceSettings that = obj as TimerSequenceSettings;
            if (that == null) return false;

            return this.Id.Equals(that.Id)
                && this.Name.Equals(that.Name)
                && this.BlinkOnExpired.Equals(that.BlinkOnExpired)
                && this.FinalMessage.Equals(that.FinalMessage)
                && this.timerDurations.Equals(that.timerDurations)
                && this.VisualSettings.Equals(that.VisualSettings)
                && this.MessageSettings.Equals(that.MessageSettings);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void SetDefaultSettings()
        {
            this.VisualSettings = TimerVisualSettings.Default;
            this.MessageSettings = TimerMessageSettings.Default;
            this.BlinkOnExpired = false;
            this.FinalMessage = "Time Up!";
        }

        public static TimerSequenceSettings ParseCsv(string csv)
        {
            TimerSequenceSettings settings = TimerSequenceSettings.Empty;

            try
            {
                var values = csv.Split(new char[] { ',' });
                int id = TimerSequenceSettings.count;
                int.TryParse(values[0], out id);

                settings.Id = id;
                settings.Name = values[1];
                settings.BlinkOnExpired = bool.Parse(values[2]);
                settings.FinalMessage = values[3];

                settings.VisualSettings = TimerVisualSettings.ParseCsv(csv, 5);

                return settings;
            }
            catch
            {
                return settings;
            }
        }

        public static bool IsUntitled(string name)
        {
            if (name.StartsWith(TimerSequenceSettings.DefaultName))
            {
                string remnant = name.Replace(TimerSequenceSettings.DefaultName, string.Empty);
                int value;
                return int.TryParse(remnant, out value);
            }

            return false;
        }
    }
}
