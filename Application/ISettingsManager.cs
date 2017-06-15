namespace SpeakerTimer.Application
{
    using System.Collections.ObjectModel;

    internal interface ISettingsManager<T> where T : ITimerSettings
    {
        void AddOrUpdate(T timer);

        T Delete(int timerId);

        void DeleteAll();

        ReadOnlyCollection<T> FetchAll();

        T Fetch(int timerId);

        bool SaveAll();
    }
}