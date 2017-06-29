namespace SpeakerTimer.Application
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using SpeakerTimer.Data;

    public static class SettingsManager
    {
        private static SettingsManager<SimpleTimerSettings> simpleSettingsManager;
        private static SettingsManager<SequenceTimerSettings> sequenceSettingsManager;

        static SettingsManager()
        {
            simpleSettingsManager = new SettingsManager<SimpleTimerSettings>(new Data.Settings.SimpleTimerModel());
            sequenceSettingsManager = new SettingsManager<SequenceTimerSettings>(new Data.Settings.SequenceTimerModel());
        }

        public static SettingsManager<SimpleTimerSettings> SimpleSettingsManager
        {
            get { return simpleSettingsManager; }
        }

        public static SettingsManager<SequenceTimerSettings> SequenceSettingsManager
        {
            get { return sequenceSettingsManager; }
        }
    }

    public class SettingsManager<T> : ISettingsManager<T> where T : ITimerSettings
    {
        ////private const int MaxActionBeforeFlush = 5;

        ////private int actionCount;

        /// <summary>
        /// A local map of Id to timer
        /// </summary>
        private readonly Dictionary<int, T> localDb;
        private readonly HashSet<int> deletedTimers;
        private readonly HashSet<int> modifiedTimers;
        private readonly ISettingsModel<T> settingsModel;

        private readonly object objectLock = new object();

        public SettingsManager(ISettingsModel<T> settingsModel)
        {
            this.settingsModel = settingsModel;

            this.localDb = new Dictionary<int, T>();
            this.deletedTimers = new HashSet<int>();
            this.modifiedTimers = new HashSet<int>();

            this.Refresh();
        }

        #region External Members

        public void Refresh()
        {
            this.localDb.Clear();
            this.modifiedTimers.Clear();
            this.deletedTimers.Clear();

            var allTimers = this.settingsModel.FetchAll();
            foreach (T timer in allTimers)
            {
                this.localDb.Add(timer.Id, timer);
            }

            ////this.actionCount = 0;
        }

        public void AddOrUpdate(T timer)
        {
            if (timer == null) return;

            int timerId = timer.Id;
            if (this.localDb.ContainsKey(timerId))
            {
                if (!timer.Equals(this.localDb[timerId]))
                {
                    this.localDb[timerId] = (T)timer.Clone();
                    this.modifiedTimers.Add(timerId);
                }
            }
            else
            {
                this.localDb.Add(timerId, timer);
                this.modifiedTimers.Add(timerId);
            }

            ////this.ConsiderFlush();
        }

        public T Fetch(int timerId)
        {
            if (this.localDb.ContainsKey(timerId))
            {
                return (T)this.localDb[timerId].Clone();
            }

            return default(T);
        }

        public T Save(int timerId)
        {
            if (this.localDb.ContainsKey(timerId))
            {
                var savedTimer = this.settingsModel.Save(this.localDb[timerId]);

                var a = this.localDb[timerId];
                if (!savedTimer.Equals(a))
                {
                    int b =5;
                }

                // If Id updated then replace the old timer with the saved tiemr
                if (savedTimer.Id != timerId)
                {
                    this.AddOrUpdate(savedTimer);
                    this.Delete(timerId);
                }

                return savedTimer;
            }

            return default(T);
        }

        public T Delete(int timerId)
        {
            if (this.localDb.ContainsKey(timerId))
            {
                var old = this.localDb[timerId];
                this.localDb.Remove(timerId);

                if (this.modifiedTimers.Contains(timerId))
                {
                    this.modifiedTimers.Remove(timerId);
                }

                this.deletedTimers.Add(timerId);
                ////this.ConsiderFlush();

                return old;
            }

            return default(T);
        }

        public ReadOnlyCollection<T> FetchAll()
        {
            var timers = new List<T>();
            foreach (var timer in this.localDb.Values)
            {
                timers.Add(timer);
            }

            return new ReadOnlyCollection<T>(timers);
        }

        public void DeleteAll()
        {
            foreach (var id in this.localDb.Keys)
            {
                this.deletedTimers.Add(id);
            }

            this.modifiedTimers.Clear();
            this.localDb.Clear();
            this.Flush();

            ////this.ConsiderFlush();
        }

        public bool SaveAll()
        {
            try
            {
                // Save all positive id's
                foreach (var id in this.localDb.Keys)
                {
                    if (id >= 0)
                    {
                        this.settingsModel.Save(this.localDb[id]);
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        public void Close()
        {
            this.SaveAll();
            this.settingsModel.Dispose();
        }

        #endregion

        #region Internal Members

        ////private void ConsiderFlush()
        ////{
        ////    var flush = false;
        ////    lock (this.objectLock)
        ////    {
        ////        this.actionCount++;
        ////        if (this.actionCount >= MaxActionBeforeFlush)
        ////        {
        ////            flush = true;
        ////            this.actionCount = 0;
        ////        }
        ////    }

        ////    if (flush)
        ////    {
        ////        this.Flush();
        ////    }
        ////}

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
                foreach (var id in this.deletedTimers)
                {
                    this.settingsModel.Delete(id);
                }

                this.deletedTimers.Clear();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
