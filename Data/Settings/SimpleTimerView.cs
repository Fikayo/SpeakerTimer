namespace SpeakerTimer.Data.Settings
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using SpeakerTimer.Application;

    public class SimpleTimerView : ViewModel
    {
        public const string ViewName = "SimpleTimerView";

        public SimpleTimerView() : base(ViewName)
        {
        }

        public override void CreateView()
        {
            var sql = "CREATE VIEW IF NOT EXISTS [" + ViewName + "] AS " +
                "SELECT " +
                "t.Id, t.Name, t.Message, t.Blink" +
                "d.Title, d.Duration, d.Warning1, d.Warning2, " +
                "v.TimerFontFamily, v.TimerFontSize, v.CounterMode, v.DisplayMode, " +
                "v.TimerColor, v.RunningColor, v.PausedColor, v.WarningColor, v.SecondWarningColor, v.StoppedColor, v.ExpiredColor, v.BackgroundColor, v.MessageColor" +
                "FROM [" + SimpleTimerModel.TableName + "] simple " +
                "LEFT JOIN [" + TimerSettingsModel.TableName + "] t ON simple.timerId = t.Id " +
                "LEFT JOIN [" + DurationSettingsModel.TableName + "] d ON simple.durationId = d.Id" +
                "LEFT JOIN [" + VisualSettingsModel.TableName + "] v ON simple.visualId = v.Id;";

            base.CreateView(sql);
        }

        public List<SimpleTimerSettings> FetchAll()
        {
            var durationSettings = new List<SimpleTimerSettings>();

            var reader = this.Select();
            while (reader.Read())
            {
                var setting = this.Parse(reader);
                durationSettings.Add(setting);
            }

            return durationSettings;
        }

        private SimpleTimerSettings Parse(SQLiteDataReader reader)
        {
            int id = (string)reader[TimerSettingsModel.Id.Name];
            int name = (double)reader[DurationCol.Name];
            int finalMessage = (double)reader[Warning1Col.Name];
            int blinkOnExpired = (double)reader[Warning2Col.Name];

            return new SimpleTimerSettings(;
        }
    }
}
