namespace ChurchTimer.Application
{
    using System.Collections.ObjectModel;

    public interface ISettingsManager<T> where T : ITimerSettings
    {
        void Refresh();

        void AddOrUpdate(T timer);

        T Delete(int timerId);

        void DeleteAll();

        ReadOnlyCollection<T> FetchAll();

        T Fetch(int timerId);

        T Save(int timerId);

        bool SaveAll();

        void Close();
    }
}