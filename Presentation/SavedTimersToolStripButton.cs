namespace SpeakerTimer.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class SavedTimersTSDDButton : ToolStripDropDownButton
    {
        public SavedTimersTSDDButton()
        {
            InitializeComponent();
            
            this.PresetManager = new PresetManager();
        }

        #region Events

        public event EventHandler<PresetEventArgs> PresetsLoaded;

        public event EventHandler<PresetEventArgs> TimersSettingsOpened;

        public event EventHandler<PresetEventArgs> TimersSettingsDeleted;

        #endregion

        #region Properties

        internal PresetManager PresetManager { get; private set; }

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
            var settings = this.PresetManager.LoadAll();
            if (settings != null)
            {
                this.OnPresetsLoaded(settings);
            }
            else
            {
                MessageBox.Show("There was an error when trying to load saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Event Triggers

        private void OnPresetsLoaded(List<IdNamePair> names)
        {
            var handler = this.PresetsLoaded;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(names));
            }
        }

        private void OnTimersSettingsOpened(List<IdNamePair> selections)
        {
            var handler = this.TimersSettingsOpened;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(selections));
            }
        }

        private void OnTimerSettingsDeleted(List<IdNamePair> selections)
        {
            var handler = this.TimersSettingsDeleted;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(selections));
            }
        }

        #endregion

        #region Event Handlers

        private void tsmOpenSettings_Click(object sender, EventArgs e)
        {
            using (var form = new TimerSettingsForm())
            {
                form.TimerSettings = this.PresetManager.SettingsIdNamePairs;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selections = form.TimerSettings;
                    switch (form.SelectedAction)
                    {
                        case TimerSettingsForm.Action.Open:
                            {
                                this.OnTimersSettingsOpened(selections as List<IdNamePair>);
                                break;
                            }

                        case TimerSettingsForm.Action.Delete:
                            {
                                var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    this.PresetManager.DeleteSettings(selections as List<string>, false);
                                    this.OnTimerSettingsDeleted(selections as List<IdNamePair>);

                                    this.PresetManager.SaveAll();
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
                if (!this.PresetManager.DeleteAll())
                {
                    MessageBox.Show("An error occurred. Could not clear settings.");
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
