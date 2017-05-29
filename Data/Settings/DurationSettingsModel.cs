using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer.Data.Settings
{
    public class DurationSettingsModel : DataModel
    {
        public const string TableName = "Duration Settings";
        private readonly DbColumn[] columns;
        
        public DurationSettingsModel() : base(DurationSettingsModel.TableName)
        {
            this.columns = new DbColumn[] {
                new DbColumn("Title", "VARCHAR(20)"),
                new DbColumn("Duration", "REAL"),
                new DbColumn("Warning1", "REAL"),
                new DbColumn("Warning2", "REAL"),
            };
        }

        protected override DbColumn[] Columns
        {
            get { return this.columns; }
        }
    }
}
