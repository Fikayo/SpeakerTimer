namespace SpeakerTimer
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;

    public partial class ControlPanel : Form
    {
        public static readonly ResourceManager rm = SpeakerTimer.Properties.Resources.ResourceManager;
        public static readonly Image PlayImage = (Bitmap)rm.GetObject("play-sm");
        public static readonly Image PauseImage = (Bitmap)rm.GetObject("pause-sm");

        private PresetManager presetManager;
        private PresentationTimerForm presentForm;

        public ControlPanel()
        {
            InitializeComponent();

            this.presentForm = new PresentationTimerForm();
            this.timerPreview1.IsLive = false;
            this.timerPreview2.IsLive = false;

            this.presetManager = new PresetManager();
            this.LoadSavedTimers();

            this.HookPresentFormEvents();
            this.AddAllScreens();
        }

        private void HookPresentFormEvents()
        {
            this.presentForm.WindowStateChanged += presentForm_WindowStateChanged;
            this.presentForm.FormClosed += presentForm_FormClosed;
        }

        private void AddPresetsToPreviews(string name)
        {
            this.timerPreview1.SavedTimers.Add(name);
            this.timerPreview2.SavedTimers.Add(name);
        }

        private void ClearPresetFromPreviews(string name = "")
        {
            if (string.IsNullOrEmpty(name))
            {
                this.timerPreview1.SavedTimers.Clear();
                this.timerPreview2.SavedTimers.Clear();
                return;
            }

            this.timerPreview1.SavedTimers.Remove(name);
            this.timerPreview2.SavedTimers.Remove(name);
        }

        private void AddAllScreens()
        {
            this.tsmChangeDisplayScreen.DropDownItems.Clear();
            foreach (var screen in Screen.AllScreens)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(screen.DeviceName);
                if (screen == Screen.PrimaryScreen)
                {
                    item.Enabled = false;
                }

                this.tsmChangeDisplayScreen.DropDownItems.Add(item);
            }

            this.tsmChangeDisplayScreen.DropDownItems.Add(this.tsmRefreshScreens);
        }
        
        private void LoadSavedTimers()
        {
            var settings = this.presetManager.LoadAll();
            if (settings != null)
            {
                foreach (var name in settings)
                {
                    this.AddPresetsToPreviews(name);
                }

                return;
            }
            else
            {
                MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnsureDisplayFormActive()
        {
            if (this.presentForm == null || this.presentForm.IsDisposed)
            {
                this.presentForm = null;
                this.presentForm = new PresentationTimerForm();
                this.HookPresentFormEvents();
            }
        }

        private void TogglePresentationForm(bool forceShow = false)
        {
            this.EnsureDisplayFormActive();

            this.tsmShowDisplay.Checked = forceShow ? true : !this.tsmShowDisplay.Checked;
            if (this.tsmShowDisplay.Checked)
            {
                this.presentForm.Show();
            }
            else
            {
                this.presentForm.Hide();
            }

            var displayShown = this.tsmShowDisplay.Checked;
            foreach (ToolStripItem item in this.tsiMainDisplay.DropDownItems)
            {
                item.Enabled = displayShown;
            }

            this.tsmShowDisplay.Enabled = true;
            //this.tsmChangeDisplayScreen.Enabled = displayShown;
            //this.tsmKeepOnTop.Enabled = displayShown;
            //this.tsmMaximizeDisplay.Enabled = displayShown;
            //this.tsmFullScreen.Enabled = displayShown;
        }

        #region Event Handlers

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.presetManager.SaveAll();
        }

        #region ToolStrip Menu Items Event Handlers

        private void tsmShowDisplay_Click(object sender, EventArgs e)
        {
            this.TogglePresentationForm();
        }

        private void tsmKeepOnTop_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;
            this.presentForm.TopMost = this.tsmKeepOnTop.Checked;
        }

        private void tsmFullScreen_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.presentForm.ToggleFullScreen();
        }

        private void tsmMaximizeDisplay_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmMaximizeDisplay.Checked = !this.tsmMaximizeDisplay.Checked;
            if (this.tsmMaximizeDisplay.Checked)
            {
                this.presentForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.presentForm.WindowState = FormWindowState.Normal;
            }
        }
        
        private void tsmRemoveDisplayBorder_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmRemoveDisplayBorder.Checked = !this.tsmRemoveDisplayBorder.Checked;
            if (this.tsmRemoveDisplayBorder.Checked)
            {
                this.presentForm.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.presentForm.FormBorderStyle = PresentationTimerForm.BorderStyle;
            }
        }

        private void tsmChangeDisplayScreen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {           
            var count = this.tsmChangeDisplayScreen.DropDownItems.Count;
            var index = this.tsmChangeDisplayScreen.DropDownItems.IndexOf(e.ClickedItem);

            // If not lat item in list ie Refresh button
            if (index != count - 1)
            {
                this.EnsureDisplayFormActive();

                // Enable all other screen options
                foreach (ToolStripMenuItem item in this.tsmChangeDisplayScreen.DropDownItems)
                {
                    item.Enabled = true;
                }

                e.ClickedItem.Enabled = false;

                var newScreen = Screen.AllScreens[index].WorkingArea;
                Point newLocation = newScreen.Location;
                if (this.presentForm.WindowState == FormWindowState.Maximized)
                {
                    this.presentForm.WindowState = FormWindowState.Normal;
                    this.presentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
                    this.presentForm.WindowState = FormWindowState.Maximized;
                }

                newLocation.X += (newScreen.Width / 2) - (this.presentForm.Size.Width / 2);
                newLocation.Y += (newScreen.Height / 2) - (this.presentForm.Size.Height / 2);

                this.presentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
            }
        }

        private void tsmRefreshScreens_Click(object sender, EventArgs e)
        {
            this.AddAllScreens();
        }
        
        private void tsmTimerSettings_Click(object sender, EventArgs e)
        {
            using (var form = new TimerSettingsForm())
            {
                form.TimerSettings = this.presetManager.SettingsNames;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selections = form.TimerSettings;
                    switch (form.SelectedAction)
                    {

                        case TimerSettingsForm.Action.Open:
                            {
                                this.timerPreview1.Settings = TimerViewSettings.ParseCsv(this.presetManager[selections[0]]);
                                if (selections.Count > 1)
                                {
                                    this.timerPreview2.Settings = TimerViewSettings.ParseCsv(this.presetManager[selections[1]]);
                                }

                                break;
                            }

                        case TimerSettingsForm.Action.Delete:
                            {
                                var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    foreach (var setting in selections)
                                    {
                                        this.presetManager.DeleteSetting(setting, false);
                                        this.ClearPresetFromPreviews(setting);
                                    }

                                    this.presetManager.SaveAll();
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
                if (!this.presetManager.DeleteAll())
                {
                    MessageBox.Show("An error occurred. Could not clear settings.");
                    return;
                }

                this.ClearPresetFromPreviews();
            }
        }

        private void tsmRefreshList_Click(object sender, EventArgs e)
        {
            this.LoadSavedTimers();
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.presentForm.CheckKeyPress(e.KeyCode);
        }

        private void ControlPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.presentForm.CheckKeyPress(e.KeyCode);
        }

        #endregion

        #region Present Form Event Handlers

        private void presentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.tsmShowDisplay.Checked = false;
            this.timerPreview1.IsLive = false;
            this.timerPreview2.IsLive = false;
        }

        private void presentForm_WindowStateChanged(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmFullScreen.Checked = this.presentForm.IsFullScreen;
            this.tsmMaximizeDisplay.Checked = this.presentForm.IsFullScreen;
        }

        #endregion

        #region Preview Event Handlers

        private void timerPreview_SaveRequested(object sender, SettingIOEventArgs e)
        {
            TimerPreview preview = sender as TimerPreview;
            if (preview == null)
            {
                return;
            }

            var success = true;
            try
            {
                var name = e.SettingName;
                if (this.presetManager.HasSetting(name))
                {
                    var result = MessageBox.Show(
                        "A setting with the name '" + name + "' already exists.\r\n" +
                        "Do you wish to update the existing timer settings?\r\n\r\n" +
                        "Select 'Cancel' to choose a new name",
                        "Setting Already Exists",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button2);

                    if (result != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                }
                else
                {
                    this.AddPresetsToPreviews(name);
                }

                success = this.presetManager.AddOrUpdateSetting(new KeyValuePair<string, string>(name, e.Settings.SaveSettingsAsCsv()));
                preview.DisplayName = name;
            }
            catch
            {
                success = false;
            }

            if (!success)
            {
                MessageBox.Show("Could not save setting. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerPreview_LoadRequested(object sender, SettingIOEventArgs e)
        {
            string settingsCsv = this.presetManager.LoadSetting(e.SettingName);
            if (settingsCsv != string.Empty)
            {
                var timerPreview = sender as TimerPreview;
                if (timerPreview != null)
                {
                    timerPreview.Settings = TimerViewSettings.ParseCsv(settingsCsv);
                }
            }
        }

        private void timerPreview1_LiveStateChanged(object sender, EventArgs e)
        {
            if (this.timerPreview1.IsLive)
            {
                this.EnsureDisplayFormActive();

                this.presentForm.CommandIssuer = this.timerPreview1.CommandIssuer;
                this.timerPreview2.IsLive = false;
                this.TogglePresentationForm(true);
            }
            else if (!this.timerPreview2.IsLive)
            {
                // If no one is live then remove the presentation form
                if (this.presentForm != null)
                {
                    this.presentForm.Hide();
                }
            }
        }

        private void timerPreview2_LiveStateChanged(object sender, EventArgs e)
        {
            if (this.timerPreview2.IsLive)
            {
                if (this.presentForm == null)
                {
                    this.presentForm = new PresentationTimerForm();
                }

                this.presentForm.CommandIssuer = this.timerPreview2.CommandIssuer;
                this.timerPreview1.IsLive = false;
                this.TogglePresentationForm(true);
            }
            else if (!this.timerPreview1.IsLive)
            {
                // If no one is live then remove the presentation form
                if (this.presentForm != null)
                {
                    this.presentForm.Hide();
                }
            }
        }

        #endregion

        private void tslMakeTimePlan_Click(object sender, EventArgs e)
        {
            using (var form = new TimePlanForm())
            {
                form.ShowDialog();
            }
        }

        #endregion
    }
}
