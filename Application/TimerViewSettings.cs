namespace SpeakerTimer.Application
{
    using System.Drawing;

    public class TimerViewSettings
    {
        private static readonly string DefaultName = "Un-named";

        private string name;
        private static int count = 0;

        private TimerViewSettings(bool isDefault = false)
        {
            this.SetDefaultSettings();
            if (isDefault)
            {
                this.Id = TimerViewSettings.count++;
            }
        }

        public int Id { get; private set; }

        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(this.name))
                {
                    return TimerViewSettings.DefaultName + TimerViewSettings.count;
                }

                return this.name;
            }

            set
            {
                this.name = value;
                if (!string.IsNullOrEmpty(this.name))
                {
                    TimerViewSettings.count--;
                }
            }
        }

        public string FinalMessage { get; set; }

        public bool BlinkOnExpired { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public TimerMessageSettings MessageSettings { get; set; }

        public TimerDuration TimerDuration { get; set; }

        #region Time Duration

        ////public string Title { get { return this.TimerDuration.Title; } set { this.TimerDuration.Title = value; } }

        ////public double Duration { get { return this.TimerDuration.Duration; } set { this.TimerDuration.Duration = value; } }

        ////public double WarningTime { get { return this.TimerDuration.WarningTime; } set { this.TimerDuration.WarningTime = value; } }

        ////public double SecondWarningTime { get { return this.TimerDuration.SecondWarningTime; } set { this.TimerDuration.SecondWarningTime = value; } }

        #endregion

        #region Propeties

        ////public bool HasFirstWarning
        ////{
        ////    get { return this.WarningTime > 0; }
        ////}

        ////public bool HasSecondWarning
        ////{
        ////    get { return this.SecondWarningTime > 0; }
        ////}

        public static TimerViewSettings Default
        {
            get { return new TimerViewSettings(true); }
        }

        private static TimerViewSettings Empty
        {
            get { return new TimerViewSettings(); }
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

        public TimerViewSettings Clone()
        {
            TimerViewSettings clone = TimerViewSettings.ParseCsv(this.ToCsv());
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

            TimerViewSettings that = obj as TimerViewSettings;
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
            this.TimerDuration = TimerDuration.Default;
            this.VisualSettings = TimerVisualSettings.Default;
            this.MessageSettings = TimerMessageSettings.Default;
            this.BlinkOnExpired = false;
        }

        public static bool IsUntitled(string name)
        {
            if (name.StartsWith(TimerViewSettings.DefaultName))
            {
                string remnant = name.Replace(TimerViewSettings.DefaultName, string.Empty);
                int value;
                return int.TryParse(remnant, out value);
            }

            return false;
        }

        public static TimerViewSettings ParseCsv(string csv)
        {
            TimerViewSettings settings = TimerViewSettings.Empty;

            try
            {
                var values = csv.Split(new char[] { ',' });
                int id = TimerViewSettings.count;
                int.TryParse(values[0], out id);

                settings.Id = id;
                settings.Name = values[1];

                ////settings.TimerDuration.Title = values[2];
                ////settings.TimerDuration.Duration = double.Parse(values[3]);
                ////settings.TimerDuration.WarningTime = double.Parse(values[4]);
                ////settings.TimerDuration.SecondWarningTime = double.Parse(values[5]);

                settings.TimerDuration = TimerDuration.ParseCsv(csv, 2);

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