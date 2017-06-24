namespace SpeakerTimer.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class SavedTimersTSDDButton<T> : ToolStripDropDownButton where T : TimerSettings
    {
        public SavedTimersTSDDButton(SettingsManager<T> settingsManager)
        {
            InitializeComponent();

            this.SettingsManager = settingsManager;
        }

        #region Events

        public event EventHandler<PresetEventArgs<T>> PresetsLoaded;

        public event EventHandler<PresetEventArgs<T>> TimersSettingsOpened;

        public event EventHandler<PresetEventArgs<T>> TimersSettingsDeleted;

        #endregion

        #region Properties

        internal SettingsManager<T> SettingsManager { get; private set; }

        #endregion

        #region External Members

        public void Init()
        {
            this.LoadSavedTimers();
        }

        #endregion

        #region Internal Members

        private void LoadSavedTimers()
        {
            var settings = this.SettingsManager.FetchAll();
            if (settings != null)
            {
                this.OnPresetsLoaded(new List<T>(settings));
            }
            else
            {
                MessageBox.Show("There was an error when trying to load saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Event Triggers

        private void OnPresetsLoaded(List<T> names)
        {
            var handler = this.PresetsLoaded;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs<T>(names));
            }
        }

        private void OnTimersSettingsOpened(List<T> selections)
        {
            var handler = this.TimersSettingsOpened;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs<T>(selections));
            }
        }

        private void OnTimerSettingsDeleted(List<T> selections)
        {
            var handler = this.TimersSettingsDeleted;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs<T>(selections));
            }
        }

        #endregion

        #region Event Handlers

        private void tsmOpenSettings_Click(object sender, EventArgs e)
        {
            using (var form = new TimerSettingsForm())
            {
                form.TimerSettings = new List<T>(this.SettingsManager.FetchAll()) as List<TimerSettings>;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selections = form.TimerSettings;
                    switch (form.SelectedAction)
                    {
                        case TimerSettingsForm.Action.Open:
                            {
                                this.OnTimersSettingsOpened(selections as List<T>);
                                break;
                            }

                        case TimerSettingsForm.Action.Delete:
                            {
                                var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    foreach (var timer in selections)
                                    {
                                        this.SettingsManager.Delete(timer.Id);
                                    }

                                    this.OnTimerSettingsDeleted(selections as List<T>);

                                    this.SettingsManager.SaveAll();
                                }

                                break;
                            }

                        default:
                            break;
                    }
                }
            }
        }

        private void tsmClearAll_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("All pre-saved timer settings will be deleted permanently.\r\nProceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    this.SettingsManager.DeleteAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred. Could not clear settings.\n" + ex);
                    return;
                }

                this.OnTimerSettingsDeleted(null);
            }
        }

        private void tsmRefreshList_Click(object sender, EventArgs e)
        {
            this.LoadSavedTimers();
        }

        #endregion
    }
}
