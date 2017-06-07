namespace SpeakerTimer.Data.Settings
{
    using System.Text;

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
    }
}
