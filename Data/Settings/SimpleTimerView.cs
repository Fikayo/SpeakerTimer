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
                "t." + TimerSettingsModel.IdCol + ", t." + TimerSettingsModel.NameCol + ", t." + TimerSettingsModel.MessageCol + ", t." + TimerSettingsModel.BlinkCol + ", " +
                "d." + DurationSettingsModel.TitleCol + ", d." + DurationSettingsModel.DurationCol + ", d." + DurationSettingsModel.Warning1Col + ", d." + DurationSettingsModel.Warning2Col + ", " +
                "v." + VisualSettingsModel.TimerFontFamilyCol + ", v." + VisualSettingsModel.TimerFontSizeCol + ", v." + VisualSettingsModel.CounterModeCol + ", v." + VisualSettingsModel.DisplayModeCol + ", " +
                "v." + VisualSettingsModel.TimerColorCol + ", v." + VisualSettingsModel.RunningColorCol + ", v." + VisualSettingsModel.PausedColorCol + ", v." + VisualSettingsModel.WarningColorCol + ", v." + VisualSettingsModel.SecondWarningColorCol + ", " +
                "v." + VisualSettingsModel.StoppedColorCol + ", v." + VisualSettingsModel.ExpiredColorCol + ", v." + VisualSettingsModel.BackgroundColorCol + ", v." + VisualSettingsModel.MessageColorCol + " " +
                "FROM [" + TimerSettingsModel.TableName + "] timer " +
                "LEFT JOIN [" + TimerDurationModel.TableName + "] td ON timer.Id = td.timerId " +
                "LEFT JOIN [" + TimerVisualModel.TableName + "] tv ON timer.Id = tv.timerId" +
                "LEFT JOIN [" + DurationSettingsModel.TableName + "] d ON t.durationId = d.Id" +
                "LEFT JOIN [" + VisualSettingsModel.TableName + "] v ON tv.visualId = v.Id;";

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
            int id = (int)reader[TimerSettingsModel.IdCol.Name];
            string name = (string)reader[TimerSettingsModel.NameCol.Name];
            string finalMessage = (string)reader[TimerSettingsModel.MessageCol.Name];
            bool blinkOnExpired = (int)reader[TimerSettingsModel.BlinkCol.Name] > 0;

            TimerDurationSettings durationSettings = DurationSettingsModel.Parse(reader);
            TimerVisualSettings visualSettings = VisualSettingsModel.Parse(reader);

            return new SimpleTimerSettings(id, name, finalMessage, blinkOnExpired, durationSettings, visualSettings);
        }
    }
}
