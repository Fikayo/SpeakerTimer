namespace SpeakerTimer.Application
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SpeakerTimer.Data;

    public class NewSettingsManager<T> : ISettingsManager<T> where T : ITimerSettings
    {
        private const int MaxActionBeforeFlush = 5;

        private int actionCount;
        private readonly Dictionary<int, T> localDb;
        private readonly List<int> deletedTimers;
        private readonly HashSet<int> modifiedTimers;
        private readonly ISettingsModel<T> settingsModel;
        private readonly object objectLock = new object();

        public NewSettingsManager()
        {
            this.localDb = new Dictionary<int, T>();
            this.deletedTimers = new List<int>();
            this.modifiedTimers = new HashSet<int>();

            this.actionCount = 0;
        }

        #region External Members

        public void AddOrUpdate(T timer)
        {
            int timerId = timer.Id;
            if (this.localDb.ContainsKey(timerId))
            {
                this.localDb[timerId] = (T)timer.Clone();
            }
            else
            {
                this.localDb.Add(timerId, timer);
            }

            this.modifiedTimers.Add(timerId);
            this.ConsiderFlush();
        }

        public T Fetch(int timerId)
        {
            if (this.localDb.ContainsKey(timerId))
            {
                return (T)this.localDb[timerId].Clone();
            }

            return default(T);
        }

        public T Delete(int timerId)
        {
            if (this.localDb.ContainsKey(timerId))
            {
                var old = this.localDb[timerId];
                this.localDb.Remove(timerId);

                this.deletedTimers.Add(timerId);
                this.ConsiderFlush();
                return old;
            }

            return default(T);
        }

        public ReadOnlyCollection<T> FetchAll()
        {
            var timers = new List<T>();
            foreach(var timer in this.localDb.Values)
            {
                timers.Add(timer);
            }

            return new ReadOnlyCollection<T>(timers);
        }

        public void DeleteAll()
        {
            this.deletedTimers.AddRange(this.localDb.Keys);
            this.localDb.Clear();

            this.ConsiderFlush();
        }

        public bool SaveAll()
        {
            return this.Flush();
        }

        #endregion

        #region Internal Members

        private void ConsiderFlush()
        {
            var flush = false;
            lock (this.objectLock)
            {
                this.actionCount++;
                if (this.actionCount >= MaxActionBeforeFlush)
                {
                    flush = true;
                }
            }

            if (flush)
            {
                this.Flush();
            }
        }

        private bool Flush()
        {
            try
            {
                // Save modified timers
                foreach (var id in this.modifiedTimers)
                {
                    this.settingsModel.Save(this.localDb[id]);
                }

                this.modifiedTimers.Clear();

                // Delete timers marked for deletion
                foreach(var id in this.deletedTimers)
                {
                    this.settingsModel.Delete(id);
                }

                this.deletedTimers.Clear();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
