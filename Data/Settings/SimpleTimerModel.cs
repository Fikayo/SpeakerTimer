namespace ChurchTimer.Data.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using ChurchTimer.Application;

    public class SimpleTimerModel : DataModel, ISettingsModel<SimpleTimerSettings>
    {
        public const string ViewName = "SimpleTimer";

        public SimpleTimerModel() : base(ViewName)
        {
        }

        public override void CreateTable()
        {
            var sql = "CREATE VIEW IF NOT EXISTS [" + ViewName + "] AS " +
                "SELECT " +
                "timer." + TimerSettingsModel.IdCol.Name + ", dur." + DurationSettingsModel.IdCol.Name + ", vis." + VisualSettingsModel.IdCol.Name + ", " +
                "timer." + TimerSettingsModel.NameCol.Name + ", timer." + TimerSettingsModel.MessageCol.Name + ", timer." + TimerSettingsModel.BlinkCol.Name + ", " +
                "dur." + DurationSettingsModel.TitleCol.Name + ", dur." + DurationSettingsModel.DurationCol.Name + ", dur." + DurationSettingsModel.Warning1Col.Name + ", dur." + DurationSettingsModel.Warning2Col.Name + ", " +
                "vis." + VisualSettingsModel.TimerFontFamilyCol.Name + ", vis." + VisualSettingsModel.TimerFontSizeCol.Name + ", vis." + VisualSettingsModel.CounterModeCol.Name + ", vis." + VisualSettingsModel.DisplayModeCol.Name + ", " +
                "vis." + VisualSettingsModel.TimerColorCol.Name + ", vis." + VisualSettingsModel.RunningColorCol.Name + ", vis." + VisualSettingsModel.PausedColorCol.Name + ", vis." + VisualSettingsModel.WarningColorCol.Name + ", vis." + VisualSettingsModel.SecondWarningColorCol.Name + ", " +
                "vis." + VisualSettingsModel.StoppedColorCol.Name + ", vis." + VisualSettingsModel.ExpiredColorCol.Name + ", vis." + VisualSettingsModel.BackgroundColorCol.Name + ", vis." + VisualSettingsModel.MessageColorCol.Name + " " +
                "FROM [" + TimerSettingsModel.TableName + "] timer " +
                "LEFT JOIN [" + TimerDurationModel.TableName + "] td ON timer." + TimerSettingsModel.IdCol.Name + " = td." + TimerDurationModel.TimerIdCol.Name + " " +
                "LEFT JOIN [" + TimerVisualModel.TableName + "] tv ON timer." + TimerSettingsModel.IdCol.Name + " = tv." + TimerVisualModel.TimerIdCol.Name + " " +
                "LEFT JOIN [" + DurationSettingsModel.TableName + "] dur ON td." + TimerDurationModel.DurationIdCol.Name + " = dur." + DurationSettingsModel.IdCol.Name + " " +
                "LEFT JOIN [" + VisualSettingsModel.TableName + "] vis ON tv." + TimerVisualModel.VisualIdCol.Name + " = vis." + VisualSettingsModel.IdCol.Name + ";" ;

            base.ExecuteNonQuery(sql);
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

        public SimpleTimerSettings Fetch(int timerId)
        {
            var sql = "SELECT * FROM [" + ViewName + "] WHERE " + TimerSettingsModel.IdCol.Name + " = @" + TimerSettingsModel.IdCol.ParameterName + ";";

            var reader = this.Query(sql, new SQLiteParameter(TimerSettingsModel.IdCol.ParameterName, timerId));
            reader.Read();

            return this.Parse(reader);
        }

        public SimpleTimerSettings Save(SimpleTimerSettings timer)
        {
            var savedTimer = TimerSettingsModel.Instance.Save(timer);
            savedTimer.TimerDuration = DurationSettingsModel.Instance.Save(timer.TimerDuration);
            savedTimer.VisualSettings = VisualSettingsModel.Instance.Save(timer.VisualSettings);

            // Insert into the link up tables
            TimerDurationModel.Instance.Insert(savedTimer.Id, savedTimer.TimerDuration.DurationId);
            TimerVisualModel.Instance.Insert(savedTimer.Id, savedTimer.VisualSettings.VisualId);

            return savedTimer;
        }

        public bool Delete(int timerId)
        {
            return TimerSettingsModel.Instance.Delete(timerId);
        }

        private SimpleTimerSettings Parse(SQLiteDataReader reader)
        {
            if (reader[TimerSettingsModel.IdCol.Name] is DBNull) return null;

            int id = Convert.ToInt32(reader[TimerSettingsModel.IdCol.Name]);
            string name = Convert.ToString(reader[TimerSettingsModel.NameCol.Name]);
            string finalMessage = Convert.ToString(reader[TimerSettingsModel.MessageCol.Name]);
            bool blinkOnExpired = Convert.ToInt32(reader[TimerSettingsModel.BlinkCol.Name]) > 0;
            
            TimerDurationSettings durationSettings = DurationSettingsModel.Parse(reader);
            TimerVisualSettings visualSettings = VisualSettingsModel.Parse(reader);

            return new SimpleTimerSettings(id, name, finalMessage, blinkOnExpired, durationSettings, visualSettings, null);
        }
    }
}
