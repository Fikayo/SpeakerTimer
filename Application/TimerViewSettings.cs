namespace SpeakerTimer.Application
{
    using System.Drawing;

    public class TimerViewSettings
    {
        private static readonly string DefaultName = "Un-named";
        private static readonly string DefaultTitle = "Untitled";

        private string name;
        private static int count = 0;

        public TimerViewSettings(bool isDefault = false)
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

        public string Title { get; set; }

        public string FinalMessage { get; set; }

        public bool BlinkOnExpired { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        ////#region Visual Settings

        ////public Font TimerFont
        ////{
        ////    get { return this.VisualSettings.TimerFont; }

        ////    set
        ////    {
        ////        this.VisualSettings.TimerFont = value;
        ////    }
        ////}
        
        ////public Color TimerColor
        ////{
        ////    get { return this.VisualSettings.TimerColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.TimerColor = value;
        ////    }
        ////}

        ////public Color RunningColor
        ////{
        ////    get { return this.VisualSettings.RunningColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.RunningColor = value;
        ////    }
        ////}

        ////public Color PausedColor
        ////{
        ////    get { return this.VisualSettings.PausedColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.PausedColor = value;
        ////    }
        ////}

        ////public Color WarningColor
        ////{
        ////    get { return this.VisualSettings.WarningColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.WarningColor = value;
        ////    }
        ////}

        ////public Color SecondWarningColor
        ////{
        ////    get { return this.VisualSettings.SecondWarningColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.SecondWarningColor = value;
        ////    }
        ////}

        ////public Color StoppedColor
        ////{
        ////    get { return this.VisualSettings.StoppedColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.StoppedColor = value;
        ////    }
        ////}

        ////public Color ExpiredColor
        ////{
        ////    get { return this.VisualSettings.ExpiredColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.ExpiredColor = value;
        ////    }
        ////}

        ////public Color BackgroundColor
        ////{
        ////    get { return this.VisualSettings.BackgroundColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.BackgroundColor = value;
        ////    }
        ////}

        ////public Color MessageColor
        ////{
        ////    get { return this.VisualSettings.MessageColor; }

        ////    set
        ////    {
        ////        this.VisualSettings.MessageColor = value;
        ////    }
        ////}

        ////#endregion

        #region Times

        public double Duration { get; set; } // In seconds

        public double WarningTime { get; set; }

        public double SecondWarningTime { get; set; }

        #endregion

        #region Variable Settings

        public TimerMessageSettings MessageSettings { get; set; }

        #endregion

        #region Propeties

        public bool HasFirstWarning
        {
            get { return this.WarningTime > 0; }
        }

        public bool HasSecondWarning
        {
            get { return this.SecondWarningTime > 0; }
        }

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

        public string SaveSettingsAsCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                this.Id,
                this.Name,
                this.Title,
                this.Duration,
                this.WarningTime,
                this.SecondWarningTime,
                this.BlinkOnExpired,
                this.FinalMessage,
                this.VisualSettings.SaveSettingsAsCsv());
        }

        public TimerViewSettings Clone()
        {
            TimerViewSettings clone = TimerViewSettings.ParseCsv(this.SaveSettingsAsCsv());
            clone.VisualSettings = this.VisualSettings.Clone();
            clone.MessageSettings = this.MessageSettings.Clone();

            return clone;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TimerViewSettings that = obj as TimerViewSettings;
            if (that == null) return false;

            return this.Name.Equals(that.Name)
                && this.Title.Equals(that.Title)
                && this.Duration.Equals(that.Duration)
                && this.WarningTime.Equals(that.WarningTime)
                && this.SecondWarningTime.Equals(that.SecondWarningTime)
                && this.BlinkOnExpired.Equals(that.BlinkOnExpired)
                && this.FinalMessage.Equals(that.FinalMessage)
                && this.VisualSettings.Equals(that.VisualSettings);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private void SetDefaultSettings()
        {
            this.Title = TimerViewSettings.DefaultTitle;
            this.VisualSettings = TimerVisualSettings.Default;
            this.MessageSettings = TimerMessageSettings.Default;
            this.BlinkOnExpired = false;
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
                settings.Title = values[2];
                settings.Duration = double.Parse(values[3]);
                settings.WarningTime = double.Parse(values[4]);
                settings.SecondWarningTime = double.Parse(values[5]);
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
    }
}