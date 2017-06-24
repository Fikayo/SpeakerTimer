namespace SpeakerTimer.Data.Settings
{
    using System;
    using System.Collections.Generic;
    using SpeakerTimer.Application;

    public class SequenceTimerModel : DataModel, ISettingsModel<SequenceTimerSettings>
    {
        public const string ViewName = "SequenceTimer";

        public SequenceTimerModel() : base(ViewName)
        {
        }

        public override void CreateTable()
        {
            throw new NotImplementedException();
        }

        public bool Delete(int timerId)
        {
            throw new NotImplementedException();
        }

        public SimpleTimerSettings Fetch(int timerId)
        {
            throw new NotImplementedException();
        }

        public List<SimpleTimerSettings> FetchAll()
        {
            throw new NotImplementedException();
        }

        public void Save(SimpleTimerSettings timer)
        {
            throw new NotImplementedException();
        }

        public void Save(SequenceTimerSettings timer)
        {
            throw new NotImplementedException();
        }

        SequenceTimerSettings ISettingsModel<SequenceTimerSettings>.Fetch(int timerId)
        {
            throw new NotImplementedException();
        }

        List<SequenceTimerSettings> ISettingsModel<SequenceTimerSettings>.FetchAll()
        {
            throw new NotImplementedException();
        }
    }
}
