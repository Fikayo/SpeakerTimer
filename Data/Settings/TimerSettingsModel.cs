namespace SpeakerTimer.Data.Settings
{
    using System.Text;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Drawing;
    using SpeakerTimer.Application;

    public class TimerSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("Id", "INTEGER");
        public static readonly DbColumn NameCol = new DbColumn("Name", "VARCHAR(255)");
        public static readonly DbColumn MessageCol = new DbColumn("FinalMessage", "VARCHAR(255)");
        public static readonly DbColumn BlinkCol = new DbColumn("Blink", "INTEGER");

        public const string TableName = "Timers";

        private static readonly TimerSettingsModel instance = null;

        static TimerSettingsModel()
        {
            instance = new TimerSettingsModel();
        }

        private TimerSettingsModel() : base(TableName)
        {
        }

        public static TimerSettingsModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} PRIMARY KEY AUTOINCREMENT, ", IdCol);
            tableColumns.AppendFormat("{0} DEFAULT 'Un-named', ", NameCol);
            tableColumns.AppendFormat("{0} DEFAULT 0, ", MessageCol);
            tableColumns.AppendFormat("{0} DEFAULT 1", BlinkCol);

            base.CreateTable(tableColumns.ToString());
        }

        public SimpleTimerSettings Save(SimpleTimerSettings simpleTimer)
        {
            var parameters = new List<SQLiteParameter>
            {
                    new SQLiteParameter() { ParameterName = "Name", Value = simpleTimer.Name},
                    new SQLiteParameter() { ParameterName = "Message", Value = simpleTimer.FinalMessage},
                    new SQLiteParameter() { ParameterName = "Blink", Value = simpleTimer.BlinkOnExpired},
            };

            if (simpleTimer.Id < 0)
            {
                var sql = "INSERT INTO [" + TableName + "]";
                var newId = this.Insert(sql, parameters.ToArray());
                return new SimpleTimerSettings(newId, simpleTimer);
            }

            var update = "UPDATE [" + TableName + "] SET " +
                "[" + NameCol + "] = @Name," +
                "[" + MessageCol + "] = @Message," +
                "[" + BlinkCol + "] = @Blink," +
                "WHERE [" + IdCol + "] = @Id";

            parameters.Add(new SQLiteParameter("Id", simpleTimer.Id));
            this.ExecuteNonQuery(update, parameters.ToArray());
            return simpleTimer;
        }

    }
}
