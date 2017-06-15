namespace SpeakerTimer.Application
{
    using System;
    using System.Collections.Generic;
    using SpeakerTimer.Data;

    internal class SettingsManager<T>  where T : ITimerSettings
    {
        private readonly ISettingsModel<T> settingsModel;
        private Dictionary<int, int> idToSettingIdx;
        private Dictionary<string, int> nameToSettingIdx;
        private List<T> savedSettings;

        public SettingsManager(ISettingsModel<T> settingsModel)
        {
            this.settingsModel = settingsModel;
        }
        
        public List<IdNamePair> SettingsIdNamePairs => throw new NotImplementedException();

        public List<string> SettingsNames => throw new NotImplementedException();

        public bool AddOrUpdateSetting(KeyValuePair<int, T> setting)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAll()
        {
            throw new NotImplementedException();
        }

        public bool DeleteSetting(string name, bool flush = true)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSettings(List<string> names, bool flush = true)
        {
            throw new NotImplementedException();
        }

        public bool HasSetting(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasSetting(string name)
        {
            throw new NotImplementedException();
        }

        public List<IdNamePair> FetchAll()
        {
            var timers = this.settingsModel.FetchAll();
            this.savedSettings.Clear();
            var idNamePairs = new List<IdNamePair>();
            foreach (var timer in timers)
            {
                var id = timer.Id;
                if (this.HasSetting(id))
                {
                    this.UpdateTimer(id, timer);
                }
                else
                {
                    this.AddNewTimer(id, timer);
                }

                idNamePairs.Add(new IdNamePair(id, timer.Name));
            }

            return idNamePairs;
        }

        public T Fetch(int id)
        {
            int index;
            if (this.idToSettingIdx.TryGetValue(id, out index))
            {
                return this.savedSettings[index];
            }

            return default(T);
        }

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }

        private void AddNewTimer(int id, T timer)
        {
            this.savedSettings.Add((T)timer.Clone());

            var index = this.savedSettings.Count - 1;
            this.idToSettingIdx[id] = index;
            this.nameToSettingIdx[timer.Name] = index;
        }

        private void UpdateTimer(int id, T timer)
        {
            var index = this.idToSettingIdx[id];

            // First check if this setting was under a different name
            var oldName = this.savedSettings[index].Name;
            if (oldName != timer.Name)
            {
                // Remove ties to old name
                this.nameToSettingIdx.Remove(oldName);

                // Add the new name
                this.nameToSettingIdx.Add(timer.Name, index);
            }

            // Update setting
            this.savedSettings[index] = (T)timer.Clone();
            this.nameToSettingIdx[timer.Name] = index;
        }

    }
}
