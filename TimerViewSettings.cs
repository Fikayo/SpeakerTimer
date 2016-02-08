﻿namespace SpeakerTimer
{
    using System.Drawing;

    public class TimerViewSettings
    {
        private static readonly string DefaultName = "Untitled";

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

        #region Display Settings

        public double Duration { get; set; } // In seconds

        public Font TimerFont { get; set; }

        public TimerCounterMode CounterMode { get; set; }

        public TimerDisplayMode DisplayMode { get; set; }

        public string FinalMessage { get; set; }

        #endregion

        #region Colors

        public Color TimerColor { get; set; }

        public Color RunningColor { get; set; }

        public Color PausedColor { get; set; }

        public Color WarningColor { get; set; }

        public Color StoppedColor { get; set; }

        public Color ExpiredColor { get; set; }

        public Color BackgroundColor { get; set; }

        public Color MessageColor { get; set; }

        #endregion

        #region Times

        public double WarningTime { get; set; }

        public double AutoPauseTime { get; set; }

        #endregion

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
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}",
                this.Name,
                this.Duration,
                this.TimerFont.FontFamily.Name,
                this.TimerFont.Size,
                this.CounterMode,
                this.DisplayMode,
                this.FinalMessage,
                this.TimerColor.Name,
                this.RunningColor.Name,
                this.PausedColor.Name,
                this.WarningColor.Name,
                this.StoppedColor.Name,
                this.ExpiredColor.Name,
                this.BackgroundColor.Name,
                this.MessageColor.Name,
                this.WarningTime,
                this.AutoPauseTime);
        }

        public static TimerViewSettings ParseCsv(string csv)
        {
            TimerViewSettings settings = TimerViewSettings.Default;

            try
            {
                var values = csv.Split(new char[] { ',' });
                settings.Name = values[0];
                settings.Duration = double.Parse(values[1]);

                var fontFamily = values[2];
                var fontSize = float.Parse(values[3]);
                settings.SetFont(fontFamily, fontSize);

                settings.CounterMode = Util.ToEnum<TimerCounterMode>(values[4]);
                settings.DisplayMode = Util.ToEnum<TimerDisplayMode>(values[5]);
                settings.FinalMessage = values[6];
                settings.TimerColor = Util.FromARGBString(Color.FromName(values[7]));
                settings.RunningColor = Util.FromARGBString(Color.FromName(values[8]));
                settings.PausedColor = Util.FromARGBString(Color.FromName(values[9]));
                settings.WarningColor = Util.FromARGBString(Color.FromName(values[10]));
                settings.StoppedColor = Util.FromARGBString(Color.FromName(values[11]));
                settings.ExpiredColor = Util.FromARGBString(Color.FromName(values[12]));
                settings.BackgroundColor = Util.FromARGBString(Color.FromName(values[13]));
                settings.MessageColor = Util.FromARGBString(Color.FromName(values[14]));
                settings.WarningTime = double.Parse(values[15]);
                settings.AutoPauseTime = double.Parse(values[16]);

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
            this.SetFont("Arial", 50f);

            this.TimerColor = Color.White;
            this.RunningColor = Color.White;
            this.PausedColor = Color.Cyan;
            this.WarningColor = Color.Yellow;
            this.ExpiredColor = Color.Red;
            this.StoppedColor = Color.Silver;
            this.BackgroundColor = Color.Black;
            this.MessageColor = Color.DodgerBlue;
        }

        public static TimerViewSettings Default
        {
            get { return new TimerViewSettings(); }
        }

        public enum TimerCounterMode
        {
            CountDownToZero, CountDownToMinus, CountUp
        }

        public enum TimerDisplayMode
        {
            FullWidth, SuppressLeadingZeros, DisplayInSeconds
        }
    }
}
