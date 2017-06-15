namespace SpeakerTimer.Data
{
    using System.Collections.Generic;
    using SpeakerTimer.Application;

    public interface ISettingsModel<T> where T : ITimerSettings
    {
        List<T> FetchAll();

        T Fetch(int timerId);

        void Save(T timer);

        bool Delete(int timerId);
    }
}
