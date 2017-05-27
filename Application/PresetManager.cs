namespace SpeakerTimer.Application
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal class PresetManager
    {

#if DEBUG
        private const string SavedTimersDirectory = @"..\..\SavedTimers\";
#else
        private const string SavedTimersDirectory = @".\SavedTimers\";
#endif

        private const string SavedTimersFilename = "presets.csv";
        private static readonly string SavedTimersPath = Path.Combine(PresetManager.SavedTimersDirectory, PresetManager.SavedTimersFilename);

        private Dictionary<int, int> idToSettingIdx;
        private Dictionary<string, int> nameToSettingIdx;
        private List<TimerViewSettings> savedSettings;

        public PresetManager()
        {
            this.idToSettingIdx = new Dictionary<int, int>();
            this.nameToSettingIdx = new Dictionary<string, int>();
            this.savedSettings = new List<TimerViewSettings>();
            this.EnsureFileExists();
        }

        public List<string> SettingsNames
        {
            get { return new List<string>(this.nameToSettingIdx.Keys); }
        }

        public List<IdNamePair> SettingsIdNamePairs
        {
            get
            {
                var idNamePairs = new List<IdNamePair>();
                foreach (var setting in this.savedSettings)
                {
                    idNamePairs.Add(new IdNamePair(setting.Id, setting.Name));
                }

                return idNamePairs;
            }
        }

        public TimerViewSettings this[int settingId]
        {
            get { return this.LoadSetting(settingId); }
        }

        public TimerViewSettings this[string settingName]
        {
            get { return this.LoadSetting(settingName); }
        }

        public bool HasSetting(string name)
        {
            return this.nameToSettingIdx.ContainsKey(name);
        }

        public bool HasSetting(int id)
        {
            return this.idToSettingIdx.ContainsKey(id);
        }

        public bool AddOrUpdateSetting(KeyValuePair<int, TimerViewSettings> setting)
        {
            if (this.idToSettingIdx.ContainsKey(setting.Key))
            {
                // Update file
                this.UpdateSetting(setting.Key, setting.Value);
                return this.SaveAll();
            }

            // Append to file
            this.AddNewSetting(setting.Key, setting.Value);
            var preset = setting.Value.ToCsv() + Environment.NewLine;

            try
            {
                this.EnsureFileExists();
                File.AppendAllText(PresetManager.SavedTimersPath, preset);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TimerViewSettings LoadSetting(string name)
        {
            int index;
            if (this.nameToSettingIdx.TryGetValue(name, out index))
            {
                return this.savedSettings[index];
            }

            return null;
        }

        public TimerViewSettings LoadSetting(int id)
        {
            int index;
            if (this.idToSettingIdx.TryGetValue(id, out index))
            {
                return this.savedSettings[index];
            }

            return null;
        }

        public bool DeleteSetting(string name, bool flush = true)
        {
            int index;
            if (this.nameToSettingIdx.TryGetValue(name, out index))
            {
                var settingId = this.savedSettings[index].Id;

                this.savedSettings.RemoveAt(index);
                this.nameToSettingIdx.Remove(name);
                this.idToSettingIdx.Remove(settingId);
            }

            if (flush)
            {
                return this.SaveAll();
            }

            return true;
        }

        public bool DeleteSettings(List<string> names, bool flush = true)
        {
            foreach(string name in names)
            {
                if(!this.DeleteSetting(name, flush))
                {
                    return false;
                }
            }

            return true;
        }

        public bool SaveAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var setting in this.savedSettings)
            {
                sb.AppendLine(setting.ToCsv());
            }

            try
            {
                this.EnsureFileExists();
                File.WriteAllText(PresetManager.SavedTimersPath, sb.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<IdNamePair> LoadAll()
        {
            string[] lines = { };
            try
            {
                this.EnsureFileExists();
                lines = File.ReadAllLines(PresetManager.SavedTimersPath);
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

            this.savedSettings.Clear();
            var idNamePairs = new List<IdNamePair>();
            foreach (var line in lines)
            {
                var setting = TimerViewSettings.ParseCsv(line);
                var id = setting.Id;
                if (this.HasSetting(id))
                {
                    this.UpdateSetting(id, setting);
                }
                else
                {
                    this.AddNewSetting(id, setting);
                }

                idNamePairs.Add(new IdNamePair(id, setting.Name));
            }

            return idNamePairs;
        }

        public bool DeleteAll()
        {
            try
            {
                this.EnsureFileExists();
                File.WriteAllText(PresetManager.SavedTimersPath, string.Empty);

                this.savedSettings.Clear();
                this.nameToSettingIdx.Clear();
                this.idToSettingIdx.Clear();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void EnsureFileExists()
        {
            if (!Directory.Exists(PresetManager.SavedTimersDirectory))
            {
                Directory.CreateDirectory(PresetManager.SavedTimersDirectory);
            }

            if (!File.Exists(PresetManager.SavedTimersPath))
            {
                // Create the file without creating a file stream
                using (var sw = new StreamWriter(PresetManager.SavedTimersPath)) { }
            }
        }

        private void AddNewSetting(int id, TimerViewSettings setting)
        {
            this.savedSettings.Add(setting.Clone());

            var index = this.savedSettings.Count - 1;
            this.idToSettingIdx[id] = index;
            this.nameToSettingIdx[setting.Name] = index;
        }

        private void UpdateSetting(int id, TimerViewSettings setting)
        {
            var index = this.idToSettingIdx[id];

            // First check if this setting was under a different name
            var oldName = this.savedSettings[index].Name;
            if(oldName != setting.Name)
            {
                // Remove ties to old name
                this.nameToSettingIdx.Remove(oldName);

                // Add the new name
                this.nameToSettingIdx.Add(setting.Name, index);
            }

            // Update setting
            this.savedSettings[index] = setting.Clone();
            this.nameToSettingIdx[setting.Name] = index;
        }
    }
}
