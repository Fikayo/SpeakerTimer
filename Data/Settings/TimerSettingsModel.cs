namespace SpeakerTimer.Data.Settings
{
    using System.Text;

    public class TimerSettingsModel : DataModel
    {
        public static readonly DbColumn IdCol = new DbColumn("Id", "INT");
        public static readonly DbColumn NameCol = new DbColumn("Name", "VARCHAR(255)");
        public static readonly DbColumn MessageCol = new DbColumn("FinalMessage", "VARCHAR(255)");
        public static readonly DbColumn BlinkCol = new DbColumn("Blink", "INT");

        public const string TableName = "Timers";

        public TimerSettingsModel() : base(TableName)
        {
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("[{0}] PRIMARY KEY AUTOINCREMENT, ", IdCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 'Un-named', ", NameCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 0, ", MessageCol);
            tableColumns.AppendFormat("[{0}] DEFAULT 1", BlinkCol);

            base.CreateTable(tableColumns.ToString());
        }
    }
}
