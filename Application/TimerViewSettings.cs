namespace SpeakerTimer
{
    using System.Drawing;

    public class TimerViewSettings
    {
        private static readonly string DefaultName = "Un-named";
        private static readonly string DefaultTitle = "Untitled";

        private string name;
        private static int count = 0;

        public TimerViewSettings()
        {
            this.SetDefaultSettings();
            TimerViewSettings.count++;
        }

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

        #region Visual Settings

        public Font TimerFont
        {
            get { return this.VisualSettings.TimerFont; }

            set
            {
                this.VisualSettings.TimerFont = value;
            }
        }

        public TimerCounterMode CounterMode
        {
            get { return this.VisualSettings.CounterMode; }

            set
            {
                this.VisualSettings.CounterMode = value;
            }
        }

        public TimerDisplayMode DisplayMode
        {
            get { return this.VisualSettings.DisplayMode; }

            set
            {
                this.VisualSettings.DisplayMode = value;
            }
        }

        public Color TimerColor
        {
            get { return this.VisualSettings.TimerColor; }

            set
            {
                this.VisualSettings.TimerColor = value;
            }
        }

        public Color RunningColor
        {
            get { return this.VisualSettings.RunningColor; }

            set
            {
                this.VisualSettings.RunningColor = value;
            }
        }

        public Color PausedColor
        {
            get { return this.VisualSettings.PausedColor; }

            set
            {
                this.VisualSettings.PausedColor = value;
            }
        }

        public Color WarningColor
        {
            get { return this.VisualSettings.WarningColor; }

            set
            {
                this.VisualSettings.WarningColor = value;
            }
        }

        public Color SecondWarningColor
        {
            get { return this.VisualSettings.SecondWarningColor; }

            set
            {
                this.VisualSettings.SecondWarningColor = value;
            }
        }

        public Color StoppedColor
        {
            get { return this.VisualSettings.StoppedColor; }

            set
            {
                this.VisualSettings.StoppedColor = value;
            }
        }

        public Color ExpiredColor
        {
            get { return this.VisualSettings.ExpiredColor; }

            set
            {
                this.VisualSettings.ExpiredColor = value;
            }
        }

        public Color BackgroundColor
        {
            get { return this.VisualSettings.BackgroundColor; }

            set
            {
                this.VisualSettings.BackgroundColor = value;
            }
        }

        public Color MessageColor
        {
            get { return this.VisualSettings.MessageColor; }

            set
            {
                this.VisualSettings.MessageColor = value;
            }
        }

        #endregion

        #region Times

        public double Duration { get; set; } // In seconds

        public double WarningTime { get; set; }

        public double SecondWarningTime { get; set; }

        #endregion

        public bool HasFirstWarning
        {
            get { return this.WarningTime > 0; }
        }

        public bool HasSecondWarning
        {
            get { return this.SecondWarningTime > 0; }
        }
        
        public void SetFont(string fontFamily = "", float fontSize = 0f)
        {
            this.VisualSettings.SetFont(fontFamily, fontSize);
        }

        public string SaveSettingsAsCsv()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                this.Name,
                this.Title,
                this.Duration,
                this.WarningTime,
                this.SecondWarningTime,
                this.BlinkOnExpired,
                this.VisualSettings.SaveSettingsAsCsv());
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

        public static TimerViewSettings ParseCsv(string csv)
        {
            TimerViewSettings settings = TimerViewSettings.Default;

            try
            {
                var values = csv.Split(new char[] { ',' });
                settings.Name = values[0];
                settings.Name = values[1];
                settings.Duration = double.Parse(values[2]);
                settings.WarningTime = double.Parse(values[3]);
                settings.SecondWarningTime = double.Parse(values[4]);
                settings.BlinkOnExpired = bool.Parse(values[5]);
                settings.FinalMessage = values[6];

                settings.VisualSettings = TimerVisualSettings.ParseCsv(csv, 7);

                return settings;
            }
            catch
            {
                return settings;
            }
        }

        private void SetDefaultSettings()
        {
            //this.CounterMode = TimerCounterMode.CountDownToMinus;
            //this.DisplayMode = TimerDisplayMode.FullWidth;
            //this.SetFont("Arial", 250f);

            //this.TimerColor = Color.White;
            //this.RunningColor = Color.White;
            //this.PausedColor = Color.Cyan;
            //this.WarningColor = Color.Yellow;
            //this.SecondWarningColor = Color.Orange;
            //this.ExpiredColor = Color.Red;
            //this.StoppedColor = Color.Silver;
            //this.BackgroundColor = Color.Black;
            //this.MessageColor = Color.DodgerBlue;

            this.Title = TimerViewSettings.DefaultTitle;
            this.VisualSettings = TimerVisualSettings.Default;
            this.BlinkOnExpired = false;
        }

        public static TimerViewSettings Default
        {
            get { return new TimerViewSettings(); }
        }

        public enum TimerCounterMode
        {
            CountDownToMinus, CountDownToZero, CountUp
        }

        public enum TimerDisplayMode
        {
            FullWidth, SuppressLeadingZeros, DisplayInSeconds
        }

        public class TimerVisualSettings
        {

            public TimerVisualSettings()
            {
                this.SetDefaultSettings();
                TimerViewSettings.count++;
            }

            #region Display Settings

            public Font TimerFont { get; set; }

            public TimerCounterMode CounterMode { get; set; }

            public TimerDisplayMode DisplayMode { get; set; }

            #endregion

            #region Colors

            public Color TimerColor { get; set; }

            public Color RunningColor { get; set; }

            public Color PausedColor { get; set; }

            public Color WarningColor { get; set; }

            public Color SecondWarningColor { get; set; }

            public Color StoppedColor { get; set; }

            public Color ExpiredColor { get; set; }

            public Color BackgroundColor { get; set; }

            public Color MessageColor { get; set; }

            #endregion

            public static TimerVisualSettings Default
            {
                get { return new TimerVisualSettings(); }
            }

            public void SetFont(string fontFamily = "", float fontSize = 0f)
            {
                fontSize = fontSize <= 0 ? this.TimerFont.Size : fontSize;

                if (string.IsNullOrEmpty(fontFamily))
                {
                    this.TimerFont = new Font(this.TimerFont.FontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
                else
                {
                    this.TimerFont = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Point, 0);
                }
            }

            public string SaveSettingsAsCsv()
            {
                return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    this.TimerFont.FontFamily.Name,
                    this.TimerFont.Size,
                    this.CounterMode,
                    this.DisplayMode,
                    this.TimerColor.Name,
                    this.RunningColor.Name,
                    this.PausedColor.Name,
                    this.WarningColor.Name,
                    this.StoppedColor.Name,
                    this.ExpiredColor.Name,
                    this.BackgroundColor.Name,
                    this.MessageColor.Name,
                    this.SecondWarningColor);
            }

            // override object.Equals
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                TimerVisualSettings that = obj as TimerVisualSettings;
                if (that == null) return false;

                return this.TimerFont.FontFamily.Name.Equals(that.TimerFont.FontFamily.Name)
                    && this.TimerFont.Size.Equals(that.TimerFont.Size)
                    && this.CounterMode.Equals(that.CounterMode)
                    && this.DisplayMode.Equals(that.DisplayMode)
                    && this.TimerColor.Name.Equals(that.TimerColor)
                    && this.RunningColor.Equals(that.RunningColor)
                    && this.PausedColor.Equals(that.PausedColor)
                    && this.WarningColor.Equals(that.WarningColor)
                    && this.StoppedColor.Equals(that.StoppedColor)
                    && this.ExpiredColor.Equals(that.ExpiredColor)
                    && this.BackgroundColor.Equals(that.BackgroundColor)
                    && this.MessageColor.Equals(that.MessageColor)
                    && this.SecondWarningColor.Equals(that.SecondWarningColor);
            }

            // override object.GetHashCode
            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public static TimerVisualSettings ParseCsv(string csv, int start = 0)
            {
                TimerVisualSettings settings = TimerVisualSettings.Default;

                try
                {
                    var values = csv.Split(new char[] { ',' });

                    var fontFamily = values[start + 0];
                    var fontSize = float.Parse(values[start + 1]);
                    settings.SetFont(fontFamily, fontSize);

                    settings.CounterMode = Util.ToEnum<TimerCounterMode>(values[start + 2]);
                    settings.DisplayMode = Util.ToEnum<TimerDisplayMode>(values[start + 3]);
                    settings.TimerColor = Util.FromARGBString(Color.FromName(values[start + 4]));
                    settings.RunningColor = Util.FromARGBString(Color.FromName(values[start + 5]));
                    settings.PausedColor = Util.FromARGBString(Color.FromName(values[start + 6]));
                    settings.WarningColor = Util.FromARGBString(Color.FromName(values[start + 7]));
                    settings.StoppedColor = Util.FromARGBString(Color.FromName(values[start + 8]));
                    settings.ExpiredColor = Util.FromARGBString(Color.FromName(values[start + 9]));
                    settings.BackgroundColor = Util.FromARGBString(Color.FromName(values[start + 10]));
                    settings.MessageColor = Util.FromARGBString(Color.FromName(values[start + 11]));
                    settings.SecondWarningColor = Util.FromARGBString(Color.FromName(values[start + 12]));

                    return settings;
                }
                catch
                {
                    return settings;
                }
            }

            private void SetDefaultSettings()
            {
                this.CounterMode = TimerCounterMode.CountDownToMinus;
                this.DisplayMode = TimerDisplayMode.FullWidth;
                this.SetFont("Arial", 250f);

                this.TimerColor = Color.White;
                this.RunningColor = Color.White;
                this.PausedColor = Color.Cyan;
                this.WarningColor = Color.Yellow;
                this.SecondWarningColor = Color.Orange;
                this.ExpiredColor = Color.Red;
                this.StoppedColor = Color.Silver;
                this.BackgroundColor = Color.Black;
                this.MessageColor = Color.DodgerBlue;
            }

        }
    }
}