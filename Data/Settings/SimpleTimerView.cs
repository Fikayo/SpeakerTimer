namespace SpeakerTimer.Data.Settings
{
    using System.Collections.Generic;
    using System.Data.SQLite;
    using SpeakerTimer.Application;

    public class SimpleTimerView : DataView
    {
        public const string ViewName = "SimpleTimerView";

        public SimpleTimerView() : base(ViewName)
        {
        }

        public override void CreateView()
        {
            var sql = "CREATE VIEW IF NOT EXISTS [" + ViewName + "] AS " +
                "SELECT " +
                "timer." + TimerSettingsModel.IdCol.Name + ", timer." + TimerSettingsModel.NameCol.Name + ", timer." + TimerSettingsModel.MessageCol.Name + ", timer." + TimerSettingsModel.BlinkCol.Name + ", " +
                "dur." + DurationSettingsModel.TitleCol.Name + ", dur." + DurationSettingsModel.DurationCol.Name + ", dur." + DurationSettingsModel.Warning1Col.Name + ", dur." + DurationSettingsModel.Warning2Col.Name + ", " +
                "vis." + VisualSettingsModel.TimerFontFamilyCol.Name + ", vis." + VisualSettingsModel.TimerFontSizeCol.Name + ", vis." + VisualSettingsModel.CounterModeCol.Name + ", vis." + VisualSettingsModel.DisplayModeCol.Name + ", " +
                "vis." + VisualSettingsModel.TimerColorCol.Name + ", vis." + VisualSettingsModel.RunningColorCol.Name + ", vis." + VisualSettingsModel.PausedColorCol.Name + ", vis." + VisualSettingsModel.WarningColorCol.Name + ", vis." + VisualSettingsModel.SecondWarningColorCol.Name + ", " +
                "vis." + VisualSettingsModel.StoppedColorCol.Name + ", vis." + VisualSettingsModel.ExpiredColorCol.Name + ", vis." + VisualSettingsModel.BackgroundColorCol.Name + ", vis." + VisualSettingsModel.MessageColorCol.Name + " " +
                "FROM [" + TimerSettingsModel.TableName + "] timer " +
                "LEFT JOIN [" + TimerDurationModel.TableName + "] td ON timer.Id = td." + TimerDurationModel.TimerIdCol.Name + " " +
                "LEFT JOIN [" + TimerVisualModel.TableName + "] tv ON timer.Id = tv." + TimerVisualModel.TimerIdCol.Name + " " +
                "LEFT JOIN [" + DurationSettingsModel.TableName + "] dur ON td." + TimerDurationModel.DurationIdCol.Name + " = dur.Id" +
                "LEFT JOIN [" + VisualSettingsModel.TableName + "] vis ON tv." + TimerVisualModel.VisualIdCol.Name + " = vis.Id;";

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
