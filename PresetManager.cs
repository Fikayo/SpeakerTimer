namespace SpeakerTimer
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

        private Dictionary<string, string> savedSettings;

        public PresetManager()
        {
            this.savedSettings = new Dictionary<string, string>();
            this.EnsureFileExists();
        }

        public List<string> SettingsNames
        {
            get { return new List<string>(this.savedSettings.Keys); }
        }

        public string this[string settingName]
        {
            get { return this.LoadSetting(settingName); }
        }

        public bool HasSetting(string name)
        {
            return this.savedSettings.ContainsKey(name);
        }

        public bool AddOrUpdateSetting(KeyValuePair<string, string> setting)
        {
            if (this.savedSettings.ContainsKey(setting.Key))
            {
                // Update file
                this.savedSettings[setting.Key] = setting.Value;
                return this.SaveAll();
            }

            // Append to file
            this.savedSettings.Add(setting.Key, setting.Value);
            var preset = setting.Value + Environment.NewLine;

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

        public string LoadSetting(string name)
        {
            string settingsCsv = string.Empty;
            if (this.savedSettings.TryGetValue(name, out settingsCsv))
            {
                return settingsCsv;
            }

            return string.Empty;
        }

        public bool DeleteSetting(string name, bool flush = true)
        {
            this.savedSettings.Remove(name);

            if (flush)
            {
                return this.SaveAll();
            }

            return true;
        }

        public bool SaveAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in this.savedSettings)
            {
                sb.AppendLine(kvp.Value);
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

        public List<string> LoadAll()
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
            foreach (var line in lines)
            {
                var settings = TimerViewSettings.ParseCsv(line);
                var name = settings.Name;
                if (this.savedSettings.ContainsKey(name))
                {
                    this.savedSettings[name] = line;
                }
                else
                {
                    this.savedSettings.Add(name, line);
                }
            }

            return this.SettingsNames;
        }

        public bool DeleteAll()
        {
            try
            {
                this.EnsureFileExists();
                File.WriteAllText(PresetManager.SavedTimersPath, string.Empty);
                this.savedSettings.Clear();
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
    }
}
