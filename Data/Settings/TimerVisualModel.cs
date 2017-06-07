namespace SpeakerTimer.Data.Settings
{
    using System.Text;

    public class TimerVisualModel : DataModel
    {
        public static readonly DbColumn TimerIdCol = new DbColumn("TimerId", "INTEGER");
        public static readonly DbColumn VisualIdCol = new DbColumn("VisualId", "INTEGER");

        public const string TableName = "Timers";

        private static readonly TimerVisualModel instance = null;

        static TimerVisualModel()
        {
            instance = new TimerVisualModel();
        }

        private TimerVisualModel() : base(TableName)
        {
        }

        public static TimerVisualModel Instance
        {
            get { return instance; }
        }

        public override void CreateTable()
        {
            StringBuilder tableColumns = new StringBuilder();
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerVisualModel.TimerIdCol);
            tableColumns.AppendFormat("{0} NOT NULL, ", TimerVisualModel.VisualIdCol);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}]), ", TimerVisualModel.TimerIdCol.Name, TimerSettingsModel.TableName, TimerSettingsModel.IdCol.Name);
            tableColumns.AppendFormat("FOREIGN KEY([{0}]) REFERENCES [{1}]([{2}])", TimerVisualModel.VisualIdCol.Name, VisualSettingsModel.TableName, VisualSettingsModel.IdCol.Name);

            base.CreateTable(tableColumns.ToString());
        }
    }
}