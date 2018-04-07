namespace TheLiveTimer.Client
{
    using System.Text;
    using System.Text.RegularExpressions;

    public class SimpleTimerSettings
    {
        public SimpleTimerSettings()
        {
            this.Metadata = new SettingsMetaData();

            this.Metadata.Title = string.Empty;
            this.Metadata.Name = string.Empty;
            this.Metadata.FinalMessage = string.Empty;

            this.DurationSettings = new TimerDurationSettings();
            this.VisualSettings = new TimerVisualSettings();
        }

        public SettingsMetaData Metadata { get; set; }

        public TimerDurationSettings DurationSettings { get; set; }

        public TimerVisualSettings VisualSettings { get; set; }

        public static SimpleTimerSettings FromString(string str)
        {
            var settings = new SimpleTimerSettings();

            Regex regex = new Regex("(" + nameof(Metadata) + "):(.*?);/end/;");
            var match = regex.Match(str);
            var metatDataString = match.Groups[2].ToString();
            settings.Metadata = SettingsMetaData.ParseTransportString(metatDataString);

            regex = new Regex("(" + nameof(DurationSettings) + "):(.*?);/end/;");
            match = regex.Match(str);
            var durationString = match.Groups[2].ToString();
            settings.DurationSettings = TimerDurationSettings.ParseTransportString(durationString);

            regex = new Regex("(" + nameof(VisualSettings) + "):(.*?);/end/;");
            match = regex.Match(str);
            var visualString = match.Groups[2].ToString();
            settings.VisualSettings = TimerVisualSettings.ParseTransportString(visualString);

            return settings;
        }

        public string ToTransportString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("{0}:{1};/end/;", nameof(this.Metadata), this.Metadata.ToCsv()));
            output.Append(string.Format("{0}:{1};/end/;", nameof(this.DurationSettings), this.DurationSettings.ToTransportString()));
            output.Append(string.Format("{0}:{1};/end/;", nameof(this.VisualSettings), this.VisualSettings.ToTransportString()));

            return output.ToString();
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

            return true
            ////return this.id.Equals(that.id)
                && this.Metadata.Equals(that.Metadata)
                && this.DurationSettings.Equals(that.DurationSettings)
            ////    && this.BlinkOnExpired.Equals(that.BlinkOnExpired)
                && this.VisualSettings.Equals(that.VisualSettings);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() * 17;
        }

        public class SettingsMetaData
        {
            public string Title { get; set; }

            public string Name { get; set; }

            public string FinalMessage { get; set; }

            public bool BlinkingWhenExpired { get; set; }

            public static SettingsMetaData ParseTransportString(string csv)
            {
                var values = csv.Split(new char[] { ',' });

                var metadata = new SettingsMetaData()
                {
                    Title = values[0],
                    Name = values[1],
                    FinalMessage = values[2],
                    BlinkingWhenExpired = bool.Parse(values[3]),
                };

                return metadata;
            }

            public string ToCsv()
            {
                return string.Format("{0},{1},{2},{3}",
                  this.Title,
                  this.Name,
                  this.FinalMessage,
                  this.BlinkingWhenExpired);
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

                SettingsMetaData that = obj as SettingsMetaData;
                if (that == null) return false;

                return this.Title.Equals(that.Title)
                    && this.Name.Equals(that.Name)
                    && this.FinalMessage.Equals(that.FinalMessage)
                    && this.BlinkingWhenExpired.Equals(that.BlinkingWhenExpired);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode() * 11;
            }
        }

    }
}
