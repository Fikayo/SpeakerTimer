namespace SpeakerTimer
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Resources;
	using System.Windows.Forms;
	using SpeakerTimer;

    ////    public partial class ControlPanel : Form
    ////    {
    ////        public static readonly ResourceManager rm = SpeakerTimer.Properties.Resources.ResourceManager;
    ////        public static readonly Image PlayImage = (Bitmap)rm.GetObject("play-sm");
    ////        public static readonly Image PauseImage = (Bitmap)rm.GetObject("pause-sm");

    ////        private PresetManager presetManager;
    ////        private PresentationTimerForm presentForm;
    ////        private PresentationTimerForm livePreviewForm;

    ////        public ControlPanel()
    ////        {
    ////            InitializeComponent();

    ////            this.ptsToolStrip.PresentForm = new PresentationTimerForm();
    ////            this.timerPreview1.IsLive = false;
    ////            this.timerPreview2.IsLive = false;

    ////            this.presetManager = new PresetManager();
    ////            this.LoadSavedTimers();

    ////            this.HookPresentFormEvents();
    ////            this.AddAllScreens();

    ////#if DEBUG
    ////            this.tslMakeTimePlan.Enabled = true;
    ////#else
    ////            this.tslMakeTimePlan.Enabled = false;
    ////#endif
    ////        }

    ////        #region Internal Members

    ////        private void HookPresentFormEvents()
    ////        {
    ////            this.ptsToolStrip.PresentForm.WindowStateChanged += presentForm_WindowStateChanged;
    ////            this.ptsToolStrip.PresentForm.FormClosed += presentForm_FormClosed;
    ////        }

    ////        private void HookLivePreviewFormEvents()
    ////        {
    ////            this.ptsToolStrip.LivePreviewForm.FormClosed += (s, e) => { this.tsmShowLivePreview.Checked = false; };
    ////        }

    ////        private void AddPresetsToPreviews(string name)
    ////        {
    ////            this.timerPreview1.SavedTimers.Add(name);
    ////            this.timerPreview2.SavedTimers.Add(name);
    ////        }

    ////        private void ClearPresetFromPreviews(string name = "")
    ////        {
    ////            if (string.IsNullOrEmpty(name))
    ////            {
    ////                this.timerPreview1.SavedTimers.Clear();
    ////                this.timerPreview2.SavedTimers.Clear();
    ////                return;
    ////            }

    ////            this.timerPreview1.SavedTimers.Remove(name);
    ////            this.timerPreview2.SavedTimers.Remove(name);
    ////        }

    ////        private void AddAllScreens()
    ////        {
    ////            this.tsmChangeDisplayScreen.DropDownItems.Clear();
    ////            foreach (var screen in Screen.AllScreens)
    ////            {
    ////                ToolStripMenuItem item = new ToolStripMenuItem(screen.DeviceName);
    ////                if (screen == Screen.PrimaryScreen)
    ////                {
    ////                    item.Enabled = false;
    ////                }

    ////                this.tsmChangeDisplayScreen.DropDownItems.Add(item);
    ////            }

    ////            this.tsmChangeDisplayScreen.DropDownItems.Add(this.tsmRefreshScreens);
    ////        }

    ////        private void LoadSavedTimers()
    ////        {
    ////            var settings = this.ptsToolStrip.PresetManager.LoadAll();
    ////            if (settings != null)
    ////            {
    ////                foreach (var name in settings)
    ////                {
    ////                    this.AddPresetsToPreviews(name);
    ////                }

    ////                return;
    ////            }
    ////            else
    ////            {
    ////                MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
    ////            }
    ////        }

    ////        private void EnsureDisplayFormActive()
    ////        {
    ////            if (this.ptsToolStrip.PresentForm == null || this.ptsToolStrip.PresentForm.IsDisposed)
    ////            {
    ////                this.ptsToolStrip.PresentForm = null;
    ////                this.ptsToolStrip.PresentForm = new PresentationTimerForm();
    ////                this.HookPresentFormEvents();
    ////            }

    ////            this.EnsureLivePreviewFormActive();
    ////        }

    ////        private void EnsureLivePreviewFormActive()
    ////        {
    ////            if (this.ptsToolStrip.LivePreviewForm == null || this.ptsToolStrip.LivePreviewForm.IsDisposed)
    ////            {
    ////                this.ptsToolStrip.LivePreviewForm = null;
    ////                this.ptsToolStrip.LivePreviewForm = new PresentationTimerForm();
    ////                this.ptsToolStrip.LivePreviewForm.Text = "Live Preview";
    ////                this.ptsToolStrip.LivePreviewForm.IsPreviewForm = true;
    ////                this.ptsToolStrip.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
    ////                this.HookLivePreviewFormEvents();
    ////            }
    ////        }

    ////        private void TogglePresentationForm(bool forceShow = false)
    ////        {
    ////            this.EnsureDisplayFormActive();

    ////            this.tsmShowDisplay.Checked = forceShow || !this.tsmShowDisplay.Checked;
    ////            if (this.tsmShowDisplay.Checked)
    ////            {
    ////                this.ptsToolStrip.PresentForm.Show();
    ////            }
    ////            else
    ////            {
    ////                this.ptsToolStrip.PresentForm.Hide();
    ////            }

    ////            var displayShown = this.tsmShowDisplay.Checked;
    ////            foreach (ToolStripItem item in this.tsiMainDisplay.DropDownItems)
    ////            {
    ////                item.Enabled = displayShown;
    ////            }

    ////            this.tsmShowDisplay.Enabled = true;
    ////            //this.tsmChangeDisplayScreen.Enabled = displayShown;
    ////            //this.tsmKeepOnTop.Enabled = displayShown;
    ////            //this.tsmMaximizeDisplay.Enabled = displayShown;
    ////            //this.tsmFullScreen.Enabled = displayShown;

    ////            if (this.tsmShowLivePreview.Checked)
    ////            {
    ////                this.ToggleLivePreviewForm(forceShow);
    ////            }
    ////        }

    ////        private void ToggleLivePreviewForm(bool forceShow = false)
    ////        {
    ////            this.EnsureLivePreviewFormActive();

    ////            this.tsmShowLivePreview.Checked = forceShow || !this.tsmShowLivePreview.Checked;
    ////            if (this.tsmShowLivePreview.Checked)
    ////            {
    ////                this.ptsToolStrip.LivePreviewForm.Show();
    ////            }
    ////            else
    ////            {
    ////                this.ptsToolStrip.LivePreviewForm.Hide();
    ////            }

    ////            var displayShown = this.tsmShowLivePreview.Checked;
    ////            foreach (ToolStripItem item in this.tsmShowLivePreview.DropDownItems)
    ////            {
    ////                item.Enabled = displayShown;
    ////            }
    ////        }

    ////        #endregion

    ////        #region Event Handlers

    ////        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
    ////        {
    ////            this.ptsToolStrip.PresetManager.SaveAll();
    ////        }

    ////        #region ToolStrip Menu Items Event Handlers

    ////        private void tsmShowDisplay_Click(object sender, EventArgs e)
    ////        {
    ////            this.TogglePresentationForm();
    ////        }

    ////        private void tsmKeepPreviewOnTop_Click(object sender, EventArgs e)
    ////        {
    ////            this.EnsureLivePreviewFormActive();
    ////            this.tsmKeepPreviewOnTop.Checked = !this.tsmKeepPreviewOnTop.Checked;
    ////            this.ptsToolStrip.LivePreviewForm.TopMost = this.tsmKeepPreviewOnTop.Checked;
    ////        }

    ////        private void tsmShowLivePreview_Click(object sender, EventArgs e)
    ////        {
    ////            this.ToggleLivePreviewForm();
    ////        }

    ////        private void tsmKeepOnTop_Click(object sender, EventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;
    ////            this.ptsToolStrip.PresentForm.TopMost = this.tsmKeepOnTop.Checked;
    ////        }

    ////        private void tsmFullScreen_Click(object sender, EventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.ptsToolStrip.PresentForm.ToggleFullScreen();
    ////        }

    ////        private void tsmMaximizeDisplay_Click(object sender, EventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.tsmMaximizeDisplay.Checked = !this.tsmMaximizeDisplay.Checked;
    ////            if (this.tsmMaximizeDisplay.Checked)
    ////            {
    ////                this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Maximized;
    ////            }
    ////            else
    ////            {
    ////                this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Normal;
    ////            }
    ////        }

    ////        private void tsmRemoveDisplayBorder_Click(object sender, EventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.tsmRemoveDisplayBorder.Checked = !this.tsmRemoveDisplayBorder.Checked;
    ////            if (this.tsmRemoveDisplayBorder.Checked)
    ////            {
    ////                this.ptsToolStrip.PresentForm.FormBorderStyle = FormBorderStyle.None;
    ////            }
    ////            else
    ////            {
    ////                this.ptsToolStrip.PresentForm.FormBorderStyle = PresentationTimerForm.BorderStyle;
    ////            }
    ////        }

    ////        private void tsmChangeDisplayScreen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    ////        {
    ////            var count = this.tsmChangeDisplayScreen.DropDownItems.Count;
    ////            var index = this.tsmChangeDisplayScreen.DropDownItems.IndexOf(e.ClickedItem);

    ////            // If not lat item in list ie Refresh button
    ////            if (index != count - 1)
    ////            {
    ////                this.EnsureDisplayFormActive();

    ////                // Enable all other screen options
    ////                foreach (ToolStripMenuItem item in this.tsmChangeDisplayScreen.DropDownItems)
    ////                {
    ////                    item.Enabled = true;
    ////                }

    ////                e.ClickedItem.Enabled = false;

    ////                var newScreen = Screen.AllScreens[index].WorkingArea;
    ////                Point newLocation = newScreen.Location;
    ////                if (this.ptsToolStrip.PresentForm.WindowState == FormWindowState.Maximized)
    ////                {
    ////                    this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Normal;
    ////                    this.ptsToolStrip.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
    ////                    this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Maximized;
    ////                }

    ////                newLocation.X += (newScreen.Width / 2) - (this.ptsToolStrip.PresentForm.Size.Width / 2);
    ////                newLocation.Y += (newScreen.Height / 2) - (this.ptsToolStrip.PresentForm.Size.Height / 2);

    ////                this.ptsToolStrip.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
    ////            }
    ////        }

    ////        private void tsmRefreshScreens_Click(object sender, EventArgs e)
    ////        {
    ////            this.AddAllScreens();
    ////        }

    ////        private void tsmOpenSettings_Click(object sender, EventArgs e)
    ////        {
    ////            using (var form = new TimerSettingsForm())
    ////            {
    ////                form.TimerSettings = this.ptsToolStrip.PresetManager.SettingsNames;
    ////                if (form.ShowDialog() == DialogResult.OK)
    ////                {
    ////                    var selections = form.TimerSettings;
    ////                    switch (form.SelectedAction)
    ////                    {

    ////                        case TimerSettingsForm.Action.Open:
    ////                            {
    ////                                this.timerPreview1.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[selections[0]]);
    ////                                if (selections.Count > 1)
    ////                                {
    ////                                    this.timerPreview2.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[selections[1]]);
    ////                                }

    ////                                break;
    ////                            }

    ////                        case TimerSettingsForm.Action.Delete:
    ////                            {
    ////                                var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
    ////                                if (result == System.Windows.Forms.DialogResult.Yes)
    ////                                {
    ////                                    foreach (var setting in selections)
    ////                                    {
    ////                                        this.ptsToolStrip.PresetManager.DeleteSetting(setting, false);
    ////                                        this.ClearPresetFromPreviews(setting);
    ////                                    }

    ////                                    this.ptsToolStrip.PresetManager.SaveAll();
    ////                                }

    ////                                break;
    ////                            }

    ////                        default:
    ////                            break;
    ////                    }
    ////                }
    ////            }
    ////        }

    ////        private void tsmClearAll_Click(object sender, EventArgs e)
    ////        {
    ////            var result = MessageBox.Show("All pre-saved timer settings will be deleted permanently.\r\nProceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    ////            if (result == System.Windows.Forms.DialogResult.Yes)
    ////            {
    ////                if (!this.ptsToolStrip.PresetManager.DeleteAll())
    ////                {
    ////                    MessageBox.Show("An error occurred. Could not clear settings.");
    ////                    return;
    ////                }

    ////                this.ClearPresetFromPreviews();
    ////            }
    ////        }

    ////        private void tsmRefreshList_Click(object sender, EventArgs e)
    ////        {
    ////            this.LoadSavedTimers();
    ////        }

    ////        private void tslMakeTimePlan_Click(object sender, EventArgs e)
    ////        {
    ////            using (var form = new TimePlanForm())
    ////            {
    ////                form.ShowDialog();
    ////            }
    ////        }

    ////        private void ControlPanel_KeyDown(object sender, KeyEventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.ptsToolStrip.PresentForm.CheckKeyPress(e.KeyCode);
    ////        }

    ////        private void ControlPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.ptsToolStrip.PresentForm.CheckKeyPress(e.KeyCode);
    ////        }

    ////        #endregion

    ////        #region Present Form Event Handlers

    ////        private void presentForm_FormClosed(object sender, FormClosedEventArgs e)
    ////        {
    ////            this.tsmShowDisplay.Checked = false;
    ////            this.timerPreview1.IsLive = false;
    ////            this.timerPreview2.IsLive = false;
    ////        }

    ////        private void presentForm_WindowStateChanged(object sender, EventArgs e)
    ////        {
    ////            this.EnsureDisplayFormActive();
    ////            this.tsmFullScreen.Checked = this.ptsToolStrip.PresentForm.IsFullScreen;
    ////            this.tsmMaximizeDisplay.Checked = this.ptsToolStrip.PresentForm.IsFullScreen;
    ////        }

    ////        #endregion

    ////        #region Preview Event Handlers

    ////        private void timerPreview_SaveRequested(object sender, SettingIOEventArgs e)
    ////        {
    ////            TimerPreview preview = sender as TimerPreview;
    ////            if (preview == null)
    ////            {
    ////                return;
    ////            }

    ////            var success = true;
    ////            try
    ////            {
    ////                var name = e.SettingName;
    ////                if (this.ptsToolStrip.PresetManager.HasSetting(name))
    ////                {
    ////                    var result = MessageBox.Show(
    ////                        "A setting with the name '" + name + "' already exists.\r\n" +
    ////                        "Do you wish to update the existing timer settings?\r\n\r\n" +
    ////                        "Select 'Cancel' to choose a new name",
    ////                        "Setting Already Exists",
    ////                        MessageBoxButtons.OKCancel,
    ////                        MessageBoxIcon.Information,
    ////                        MessageBoxDefaultButton.Button2);

    ////                    if (result != System.Windows.Forms.DialogResult.OK)
    ////                    {
    ////                        return;
    ////                    }
    ////                }
    ////                else
    ////                {
    ////                    this.AddPresetsToPreviews(name);
    ////                }

    ////                success = this.ptsToolStrip.PresetManager.AddOrUpdateSetting(new KeyValuePair<string, string>(name, e.Settings.SaveSettingsAsCsv()));
    ////                preview.DisplayName = name;
    ////            }
    ////            catch
    ////            {
    ////                success = false;
    ////            }

    ////            if (!success)
    ////            {
    ////                MessageBox.Show("Could not save setting. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    ////            }
    ////        }

    ////        private void timerPreview_LoadRequested(object sender, SettingIOEventArgs e)
    ////        {
    ////            string settingsCsv = this.ptsToolStrip.PresetManager.LoadSetting(e.SettingName);
    ////            if (settingsCsv != string.Empty)
    ////            {
    ////                var timerPreview = sender as TimerPreview;
    ////                if (timerPreview != null)
    ////                {
    ////                    timerPreview.Settings = TimerViewSettings.ParseCsv(settingsCsv);
    ////                }
    ////            }
    ////        }

    ////        private void timerPreview1_LiveStateChanged(object sender, EventArgs e)
    ////        {
    ////            if (this.timerPreview1.IsLive)
    ////            {
    ////                this.EnsureDisplayFormActive();

    ////                this.ptsToolStrip.PresentForm.CommandIssuer = this.timerPreview1.CommandIssuer;
    ////                this.ptsToolStrip.LivePreviewForm.CommandIssuer = this.timerPreview1.CommandIssuer;
    ////                this.timerPreview2.IsLive = false;
    ////                this.TogglePresentationForm(true);
    ////            }
    ////            else if (!this.timerPreview2.IsLive)
    ////            {
    ////                // If no one is live then remove the presentation form
    ////                if (this.ptsToolStrip.PresentForm != null)
    ////                {
    ////                    this.ptsToolStrip.PresentForm.Hide();
    ////                }

    ////                if (this.ptsToolStrip.LivePreviewForm != null)
    ////                {
    ////                    this.ptsToolStrip.LivePreviewForm.Hide();
    ////                }
    ////            }
    ////        }

    ////        private void timerPreview2_LiveStateChanged(object sender, EventArgs e)
    ////        {
    ////            if (this.timerPreview2.IsLive)
    ////            {
    ////                this.EnsureDisplayFormActive();

    ////                this.ptsToolStrip.PresentForm.CommandIssuer = this.timerPreview2.CommandIssuer;
    ////                this.ptsToolStrip.LivePreviewForm.CommandIssuer = this.timerPreview2.CommandIssuer;
    ////                this.timerPreview1.IsLive = false;
    ////                this.TogglePresentationForm(true);
    ////            }
    ////            else if (!this.timerPreview1.IsLive)
    ////            {
    ////                // If no one is live then remove the presentation form
    ////                if (this.ptsToolStrip.PresentForm != null)
    ////                {
    ////                    this.ptsToolStrip.PresentForm.Hide();
    ////                }

    ////                if (this.ptsToolStrip.LivePreviewForm != null)
    ////                {
    ////                    this.ptsToolStrip.LivePreviewForm.Hide();
    ////                }
    ////            }
    ////        }

    ////        #endregion

    ////        #endregion

    ////        private void ptsToolStrip_PresetsAdded(object sender, PresetEventArgs e)
    ////        {

    ////        }

    ////        private void ptsToolStrip_PresetsDeleted(object sender, PresetEventArgs e)
    ////        {

    ////        }

    ////        private void ptsToolStrip_TimersSettingsOpened(object sender, PresetEventArgs e)
    ////        {

    ////        }

    ////        private void ptsToolStrip_TimersSettingsDeleted(object sender, PresetEventArgs e)
    ////        {

    ////        }

    ////        private void ptsToolStrip_PresentFormEventsRequired(object sender, EventArgs e)
    ////        {

    ////        }
    ////        private void ptsToolStrip_PresentFormRequired(object sender, EventArgs e) { }
    ////        private void ptsToolStrip_LivePreviewFormRequired(object sender, EventArgs e) { }
    ////        private void ptsToolStrip_PresentFormEventsRemoved(object sender, EventArgs e) { }
    ////    }

    public partial class ControlPanel : Form
    {
        public static readonly ResourceManager rm = SpeakerTimer.Properties.Resources.ResourceManager;
        public static readonly Image PlayImage = (Bitmap)rm.GetObject("play-sm");
        public static readonly Image PauseImage = (Bitmap)rm.GetObject("pause-sm");

        public ControlPanel()
        {
            InitializeComponent();
            
            this.timerPreview1.IsLive = false;
            this.timerPreview2.IsLive = false;
            this.ptsToolStrip.FetchTimerView = this.CreateTimerView;
            this.ptsToolStrip.Init();

#if DEBUG
            this.ptsToolStrip.ShowTimePlanMenu = true;
#else
                this.ptsToolStrip.HideTimePlanMenu = false;
#endif
        }

        #region Internal Members

        private void HookPresentFormEvents()
        {
            //this.ptsToolStrip.PresentForm.WindowStateChanged += presentForm_WindowStateChanged;
            this.ptsToolStrip.PresentForm.FormClosed += presentForm_FormClosed;
        }

        private void UnHookPresentFormEvents()
        {
            //this.ptsToolStrip.PresentForm.WindowStateChanged -= presentForm_WindowStateChanged;
            this.ptsToolStrip.PresentForm.FormClosed -= presentForm_FormClosed;
        }

        private TimeViewControl CreateTimerView()
        {
            TimerView timerView = new SpeakerTimer.TimerView();
            timerView.BlinkInterval = 3000;
            timerView.ShowLabel = true;
            timerView.TimerColor = System.Drawing.SystemColors.ControlText;
            timerView.TimerFont = new System.Drawing.Font("Arial", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            timerView.BackgroundColor = System.Drawing.SystemColors.Control;
            timerView.TimerState = SpeakerTimer.TimerState.Stopped;

            return timerView;
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

        ////private void AddAllScreens()
        ////{
        ////    this.tsmChangeDisplayScreen.DropDownItems.Clear();
        ////    foreach (var screen in Screen.AllScreens)
        ////    {
        ////        ToolStripMenuItem item = new ToolStripMenuItem(screen.DeviceName);
        ////        if (screen == Screen.PrimaryScreen)
        ////        {
        ////            item.Enabled = false;
        ////        }

        ////        this.tsmChangeDisplayScreen.DropDownItems.Add(item);
        ////    }

        ////    this.tsmChangeDisplayScreen.DropDownItems.Add(this.tsmRefreshScreens);
        ////}

        ////private void LoadSavedTimers()
        ////{
        ////    var settings = this.ptsToolStrip.PresetManager.LoadAll();
        ////    if (settings != null)
        ////    {
        ////        foreach (var name in settings)
        ////        {
        ////            this.AddPresetsToPreviews(name);
        ////        }

        ////        return;
        ////    }
        ////    else
        ////    {
        ////        MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        ////    }
        ////}

        ////private void EnsureDisplayFormActive()
        ////{
        ////    this.ptsToolStrip.EnsureDisplayFormActive();
        ////    if (this.ptsToolStrip.PresentForm == null || this.ptsToolStrip.PresentForm.IsDisposed)
        ////    {
        ////        this.ptsToolStrip.PresentForm = null;
        ////        this.ptsToolStrip.PresentForm = new PresentationTimerForm(this.CreateTimerView());
        ////        this.HookPresentFormEvents();
        ////    }

        ////    this.EnsureLivePreviewFormActive();
        ////}

        ////private void EnsureLivePreviewFormActive()
        ////{
        ////    this.ptsToolStrip.EnsureLivePreviewFormActive();
        ////    if (this.ptsToolStrip.LivePreviewForm == null || this.ptsToolStrip.LivePreviewForm.IsDisposed)
        ////    {
        ////        this.ptsToolStrip.LivePreviewForm = null;
        ////        this.ptsToolStrip.LivePreviewForm = new PresentationTimerForm(this.CreateTimerView());
        ////        this.ptsToolStrip.LivePreviewForm.Text = "Live Preview";
        ////        this.ptsToolStrip.LivePreviewForm.IsPreviewForm = true;
        ////        this.ptsToolStrip.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        ////    }
        ////}

        ////private void TogglePresentationForm(bool forceShow = false)
        ////{
        ////    this.ptsToolStrip.TogglePresentationForm(forceShow);
        ////    this.EnsureDisplayFormActive();

        ////    this.tsmShowDisplay.Checked = forceShow || !this.tsmShowDisplay.Checked;
        ////    if (this.tsmShowDisplay.Checked)
        ////    {
        ////        this.ptsToolStrip.PresentForm.Show();
        ////    }
        ////    else
        ////    {
        ////        this.ptsToolStrip.PresentForm.Hide();
        ////    }

        ////    var displayShown = this.tsmShowDisplay.Checked;
        ////    foreach (ToolStripItem item in this.tsiMainDisplay.DropDownItems)
        ////    {
        ////        item.Enabled = displayShown;
        ////    }

        ////    this.tsmShowDisplay.Enabled = true;
        ////    this.tsmChangeDisplayScreen.Enabled = displayShown;
        ////    this.tsmKeepOnTop.Enabled = displayShown;
        ////    this.tsmMaximizeDisplay.Enabled = displayShown;
        ////    this.tsmFullScreen.Enabled = displayShown;

        ////    if (this.tsmShowLivePreview.Checked)
        ////    {
        ////        this.ToggleLivePreviewForm(forceShow);
        ////    }
        ////}

        ////private void ToggleLivePreviewForm(bool forceShow = false)
        ////{
        ////    this.ptsToolStrip.ToggleLivePreviewForm(forceShow);
        ////    this.EnsureLivePreviewFormActive();

        ////    this.tsmShowLivePreview.Checked = forceShow || !this.tsmShowLivePreview.Checked;
        ////    if (this.tsmShowLivePreview.Checked)
        ////    {
        ////        this.ptsToolStrip.LivePreviewForm.Show();
        ////    }
        ////    else
        ////    {
        ////        this.ptsToolStrip.LivePreviewForm.Hide();
        ////    }

        ////    var displayShown = this.tsmShowLivePreview.Checked;
        ////    foreach (ToolStripItem item in this.tsmShowLivePreview.DropDownItems)
        ////    {
        ////        item.Enabled = displayShown;
        ////    }
        ////}

        #endregion

        #region Event Handlers

        private void ControlPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ptsToolStrip.PresetManager.SaveAll();
        }

        #region ToolStrip Menu Items Event Handlers

        private void tsmShowDisplay_Click(object sender, EventArgs e)
        {
            ////this.TogglePresentationForm();
        }

        private void tsmKeepPreviewOnTop_Click(object sender, EventArgs e)
        {
            ////this.EnsureLivePreviewFormActive();
            ////this.tsmKeepPreviewOnTop.Checked = !this.tsmKeepPreviewOnTop.Checked;
            ////this.ptsToolStrip.LivePreviewForm.TopMost = this.tsmKeepPreviewOnTop.Checked;
        }

        private void tsmShowLivePreview_Click(object sender, EventArgs e)
        {
            ////this.ToggleLivePreviewForm();
        }

        private void tsmKeepOnTop_Click(object sender, EventArgs e)
        {
            ////this.EnsureDisplayFormActive();
            ////this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;
            ////this.ptsToolStrip.PresentForm.TopMost = this.tsmKeepOnTop.Checked;
        }

        private void tsmFullScreen_Click(object sender, EventArgs e)
        {
            ////this.EnsureDisplayFormActive();
            ////this.ptsToolStrip.PresentForm.ToggleFullScreen();
        }

        private void tsmMaximizeDisplay_Click(object sender, EventArgs e)
        {
            ////this.EnsureDisplayFormActive();
            ////this.tsmMaximizeDisplay.Checked = !this.tsmMaximizeDisplay.Checked;
            ////if (this.tsmMaximizeDisplay.Checked)
            ////{
            ////    this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Maximized;
            ////}
            ////else
            ////{
            ////    this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Normal;
            ////}
        }

        private void tsmRemoveDisplayBorder_Click(object sender, EventArgs e)
        {
            ////this.EnsureDisplayFormActive();
            ////this.tsmRemoveDisplayBorder.Checked = !this.tsmRemoveDisplayBorder.Checked;
            ////if (this.tsmRemoveDisplayBorder.Checked)
            ////{
            ////    this.ptsToolStrip.PresentForm.FormBorderStyle = FormBorderStyle.None;
            ////}
            ////else
            ////{
            ////    this.ptsToolStrip.PresentForm.FormBorderStyle = PresentationTimerForm.BorderStyle;
            ////}
        }

        private void tsmChangeDisplayScreen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ////var count = this.tsmChangeDisplayScreen.DropDownItems.Count;
            ////var index = this.tsmChangeDisplayScreen.DropDownItems.IndexOf(e.ClickedItem);

            ////// If not lat item in list ie Refresh button
            ////if (index != count - 1)
            ////{
            ////    this.EnsureDisplayFormActive();

            ////    // Enable all other screen options
            ////    foreach (ToolStripMenuItem item in this.tsmChangeDisplayScreen.DropDownItems)
            ////    {
            ////        item.Enabled = true;
            ////    }

            ////    e.ClickedItem.Enabled = false;

            ////    var newScreen = Screen.AllScreens[index].WorkingArea;
            ////    Point newLocation = newScreen.Location;
            ////    if (this.ptsToolStrip.PresentForm.WindowState == FormWindowState.Maximized)
            ////    {
            ////        this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Normal;
            ////        this.ptsToolStrip.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
            ////        this.ptsToolStrip.PresentForm.WindowState = FormWindowState.Maximized;
            ////    }

            ////    newLocation.X += (newScreen.Width / 2) - (this.ptsToolStrip.PresentForm.Size.Width / 2);
            ////    newLocation.Y += (newScreen.Height / 2) - (this.ptsToolStrip.PresentForm.Size.Height / 2);

            ////    this.ptsToolStrip.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
            ////}
        }

        private void tsmRefreshScreens_Click(object sender, EventArgs e)
        {
            ////this.AddAllScreens();
        }

        private void tsmOpenSettings_Click(object sender, EventArgs e)
        {
            ////using (var form = new TimerSettingsForm())
            ////{
            ////    form.TimerSettings = this.ptsToolStrip.PresetManager.SettingsNames;
            ////    if (form.ShowDialog() == DialogResult.OK)
            ////    {
            ////        var selections = form.TimerSettings;
            ////        switch (form.SelectedAction)
            ////        {

            ////            case TimerSettingsForm.Action.Open:
            ////                {
            ////                    this.timerPreview1.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[selections[0]]);
            ////                    if (selections.Count > 1)
            ////                    {
            ////                        this.timerPreview2.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[selections[1]]);
            ////                    }

            ////                    break;
            ////                }

            ////            case TimerSettingsForm.Action.Delete:
            ////                {
            ////                    var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
            ////                    if (result == System.Windows.Forms.DialogResult.Yes)
            ////                    {
            ////                        foreach (var setting in selections)
            ////                        {
            ////                            this.ptsToolStrip.PresetManager.DeleteSetting(setting, false);
            ////                            this.ClearPresetFromPreviews(setting);
            ////                        }

            ////                        this.ptsToolStrip.PresetManager.SaveAll();
            ////                    }

            ////                    break;
            ////                }

            ////            default:
            ////                break;
            ////        }
            ////    }
            ////}
        }

        private void tsmClearAll_Click(object sender, EventArgs e)
        {
            ////var result = MessageBox.Show("All pre-saved timer settings will be deleted permanently.\r\nProceed?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            ////if (result == System.Windows.Forms.DialogResult.Yes)
            ////{
            ////    if (!this.ptsToolStrip.PresetManager.DeleteAll())
            ////    {
            ////        MessageBox.Show("An error occurred. Could not clear settings.");
            ////        return;
            ////    }

            ////    this.ClearPresetFromPreviews();
            ////}
        }

        private void tsmRefreshList_Click(object sender, EventArgs e)
        {
            ////this.LoadSavedTimers();
        }

        private void tslMakeTimePlan_Click(object sender, EventArgs e)
        {
            ////using (var form = new TimePlanForm())
            ////{
            ////    form.ShowDialog();
            ////}
        }

        private void ControlPanel_KeyDown(object sender, KeyEventArgs e)
        {
            this.ptsToolStrip.EnsureDisplayFormActive();
            this.ptsToolStrip.PresentForm.CheckKeyPress(e.KeyCode);
        }

        private void ControlPanel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.ptsToolStrip.EnsureDisplayFormActive();
            this.ptsToolStrip.PresentForm.CheckKeyPress(e.KeyCode);
        }

        #endregion

        #region Present Form Event Handlers

        private void presentForm_WindowStateChanged(object sender, EventArgs e)
        {
            this.ptsToolStrip.EnsureDisplayFormActive();
            this.tsmFullScreen.Checked = this.ptsToolStrip.PresentForm.IsFullScreen;
            this.tsmMaximizeDisplay.Checked = this.ptsToolStrip.PresentForm.IsFullScreen;
        }

        private void presentForm_FormClosed(object sender, EventArgs e)
        {
            this.timerPreview1.IsLive = false;
            this.timerPreview2.IsLive = false;
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
                if (!TimerViewSettings.IsUntitled(name))
                {
                    ////if (this.ptsToolStrip.PresetManager.HasSetting(name))
                    ////{
                    ////var result = MessageBox.Show(
                    ////    "A setting with the name '" + name + "' already exists.\r\n" +
                    ////    "Do you wish to update the existing timer settings?\r\n\r\n" +
                    ////    "Select 'Cancel' to choose a new name",
                    ////    "Setting Already Exists",
                    ////    MessageBoxButtons.OKCancel,
                    ////    MessageBoxIcon.Information,
                    ////    MessageBoxDefaultButton.Button2);

                    ////if (result != System.Windows.Forms.DialogResult.OK)
                    ////{
                    ////    return;
                    ////}
                    ////}
                    ////else
                    if (!this.ptsToolStrip.PresetManager.HasSetting(name))
                    {
                        this.AddPresetsToPreviews(name);
                    }

                    success = this.ptsToolStrip.PresetManager.AddOrUpdateSetting(new KeyValuePair<string, string>(name, e.Settings.SaveSettingsAsCsv()));
                    preview.DisplayName = name;
                }
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
            string settingsCsv = this.ptsToolStrip.PresetManager.LoadSetting(e.SettingName);
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
                this.ptsToolStrip.EnsureDisplayFormActive();

                this.ptsToolStrip.PresentForm.CommandIssuer = this.timerPreview1.CommandIssuer;
                this.ptsToolStrip.LivePreviewForm.CommandIssuer = this.timerPreview1.CommandIssuer;
                this.timerPreview2.IsLive = false;
                this.ptsToolStrip.TogglePresentationForm(true);
                if (this.ptsToolStrip.IsLivePreviewVisible)
                {
                    this.ptsToolStrip.ToggleLivePreviewForm(true);
                }
            }
            else if (!this.timerPreview2.IsLive)
            {
                // If no one is live then remove the presentation form
                if (this.ptsToolStrip.PresentForm != null)
                {
                    this.ptsToolStrip.PresentForm.Hide();
                }

                if (this.ptsToolStrip.LivePreviewForm != null)
                {
                    this.ptsToolStrip.LivePreviewForm.Hide();
                }
            }

            this.pcbLiveIndicator.Visible = this.timerPreview1.IsLive || this.timerPreview2.IsLive;
        }

        private void timerPreview2_LiveStateChanged(object sender, EventArgs e)
        {
            if (this.timerPreview2.IsLive)
            {
                this.ptsToolStrip.EnsureDisplayFormActive();

                this.ptsToolStrip.PresentForm.CommandIssuer = this.timerPreview2.CommandIssuer;
                this.ptsToolStrip.LivePreviewForm.CommandIssuer = this.timerPreview2.CommandIssuer;
                this.timerPreview1.IsLive = false;
                this.ptsToolStrip.TogglePresentationForm(true);
                if(this.ptsToolStrip.IsLivePreviewVisible)
                {
                    this.ptsToolStrip.ToggleLivePreviewForm(true);
                }
            }
            else if (!this.timerPreview1.IsLive)
            {
                //If no one is live then remove the presentation form
                if (this.ptsToolStrip.PresentForm != null)
                {
                    this.ptsToolStrip.PresentForm.Hide();
                }

                if (this.ptsToolStrip.LivePreviewForm != null)
                {
                    this.ptsToolStrip.LivePreviewForm.Hide();
                }
            }
            
            this.pcbLiveIndicator.Visible = this.timerPreview1.IsLive || this.timerPreview2.IsLive;
        }

        #endregion

        #endregion

        #region Presentation Tool Strip

        private void ptsToolStrip_PresetsLoaded(object sender, PresetEventArgs e)
        {
            if (e != null)
            {
                foreach (string name in e.Names)
                {
                    AddPresetsToPreviews(name);
                }
            }
        }

        private void ptsToolStrip_TimersSettingsOpened(object sender, PresetEventArgs e)
        {
            if (e.Names.Count > 2)
            {
                MessageBox.Show("You may only open 2 settings at a time. Only the first two will be opened");
            }

            this.timerPreview1.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[e.Names[0]]);
            if (e.Names.Count > 1)
            {
                this.timerPreview2.Settings = TimerViewSettings.ParseCsv(this.ptsToolStrip.PresetManager[e.Names[1]]);
            }
        }

        private void ptsToolStrip_TimersSettingsDeleted(object sender, PresetEventArgs e)
        {
            if (e.Names == null)
            {
                this.ClearPresetFromPreviews(null);
                return;
            }

            foreach (var setting in e.Names)
            {
                this.ClearPresetFromPreviews(setting);
            }
        }

        //private void ptsToolStrip_PresentFormRequired(object sender, EventArgs e)
        //{
        //    this.ptsToolStrip.PresentForm = new PresentationTimerForm(this.CreateTimerView());
        //}

        private void ptsToolStrip_PresentFormEventsRequired(object sender, EventArgs e)
        {
            this.HookPresentFormEvents();
        }

        //private void ptsToolStrip_PresentFormEventsRemoved(object sender, EventArgs e)
        //{
        //    this.UnHookPresentFormEvents();
        //}

        //private void ptsToolStrip_LivePreviewFormRequired(object sender, EventArgs e)
        //{
        //    this.ptsToolStrip.LivePreviewForm = new PresentationTimerForm(this.CreateTimerView());
        //    this.ptsToolStrip.LivePreviewForm.Text = "Live Preview";
        //    this.ptsToolStrip.LivePreviewForm.IsPreviewForm = true;
        //    this.ptsToolStrip.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        //}

        #endregion
    }
}
