using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer.Presentation
{
    public partial class NewPresentationToolStrip : ToolStrip
    {
        private TimeViewControl previousimeViewControl;
        private TimerViewerCommandIssuer previousCommandIssuer;
        private Size previewFormSize;

        public NewPresentationToolStrip()
        {
            InitializeComponent();

            this.previewFormSize = new Size(365, 225);

            //this.EnsureDisplayFormActive();
            this.PresetManager = new PresetManager();

            //this.OnPresentFormEventsRequired();
            this.AddAllScreens();
        }
        
        #region Events

        //public event EventHandler PresentFormRequired;

        public event EventHandler PresentFormEventsRequired;

        //public event EventHandler PresentFormEventsRemoved;

        //public event EventHandler LivePreviewFormRequired;

        public event EventHandler LivePreviewFormEventsRequired;

        public event EventHandler LivePreviewFormEventsRemoved;

        public event EventHandler<PresetEventArgs> PresetsLoaded;

        public event EventHandler<PresetEventArgs> TimersSettingsOpened;

        public event EventHandler<PresetEventArgs> TimersSettingsDeleted;

        #endregion

        #region Properties

        internal PresetManager PresetManager { get; private set; }

        public PresentationTimerForm PresentForm { get; set; }

        public PresentationTimerForm LivePreviewForm { get; set; }

        public bool ShowDisplayMenu
        {
            get { return this.tslMainDisplay.Visible; }

            set { this.tslMainDisplay.Visible = value; }
        }

        public bool ShowTimerSettingsMenu
        {
            get { return this.tslTimers.Visible; }

            set { this.tslTimers.Visible = value; }
        }

        public bool ShowTimePlanMenu
        {
            get { return this.tslMakeTimePlan.Visible; }

            set { this.tslMakeTimePlan.Visible = value; }
        }

        public bool IsMainDisplayVisible { get { return this.tsmShowDisplay.Checked; } }

        public bool IsLivePreviewVisible { get { return this.tsmShowLivePreview.Checked; } }

        public Func<TimeViewControl> FetchTimerView { get; internal set; }

        #endregion

        #region External Members

        public void Init()
        {
            this.LoadSavedTimers();
        }

        public void EnsureDisplayFormActive()
        {
            if (this.PresentForm == null || this.PresentForm.IsDisposed)
            {
                this.PresentForm = null;
                this.PresentForm = new PresentationTimerForm(this.FetchTimerView());
                this.HookPresentFormEvents();
                //this.OnPresentFormRequired();
                this.OnPresentFormEventsRequired();
            }

            this.EnsureLivePreviewFormActive();
        }

        public void EnsureLivePreviewFormActive()
        {
            if (this.LivePreviewForm == null || this.LivePreviewForm.IsDisposed)
            {
                bool wasRunning = (this.PresentForm != null && !this.PresentForm.IsDisposed) && this.PresentForm.TimeViewControl.TimerState == TimerState.Running;
                if (wasRunning)
                {
                    // Pause an ongoing timer
                    this.PresentForm.CommandIssuer.IssuePauseCommand();
                }

                this.LivePreviewForm = null;
                //this.OnLivePreviewFormRequired();
                this.LivePreviewForm = new PresentationTimerForm(this.FetchTimerView());
                this.LivePreviewForm.Text = "Live Preview";
                this.LivePreviewForm.IsPreviewForm = true;
                this.LivePreviewForm.Size = this.previewFormSize;
                this.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                this.HookLivePreviewFormEvents();
                this.OnLivePreviewFormEventsRequired();

                if (this.IsMainDisplayVisible)
                {
                    this.LivePreviewForm.CommandIssuer = this.PresentForm.CommandIssuer;
                    this.LivePreviewForm.CommandIssuer.OnSettingsChanged(this.PresentForm.TimeViewControl.Settings);
                    if (!wasRunning)
                    {
                        // Stop any previously running timer on the live screen
                        this.LivePreviewForm.CommandIssuer.IssueStopCommand();
                    }

                    this.LivePreviewForm.CommandIssuer.OnRefreshTimerDisplay(this.PresentForm.TimeViewControl.CurrentTime);
                }

                if (wasRunning)
                {
                    // Resume the paused timer from current time
                    this.PresentForm.CommandIssuer.IssueStartCommand();
                }
            }
        }

        public void TogglePresentationForm(bool forceShow = false)
        {
            this.EnsureDisplayFormActive();

            this.tsmShowDisplay.Checked = forceShow || !this.tsmShowDisplay.Checked;
            if (this.tsmShowDisplay.Checked)
            {
                this.PresentForm.Show();
            }
            else
            {
                this.PresentForm.Hide();
            }

            var displayShown = this.tsmShowDisplay.Checked;
            foreach (ToolStripItem item in this.tslMainDisplay.DropDownItems)
            {
                item.Enabled = displayShown;
            }

            this.tsmShowDisplay.Enabled = true;
            //this.tsmChangeDisplayScreen.Enabled = displayShown;
            //this.tsmKeepOnTop.Enabled = displayShown;
            //this.tsmMaximizeDisplay.Enabled = displayShown;
            //this.tsmFullScreen.Enabled = displayShown;

            if (this.tsmShowLivePreview.Checked)
            {
                this.ToggleLivePreviewForm(forceShow);
            }
        }

        public void ToggleLivePreviewForm(bool forceShow = false)
        {
            this.EnsureLivePreviewFormActive();

            this.tsmShowLivePreview.Checked = forceShow || !this.tsmShowLivePreview.Checked;
            if (this.tsmShowLivePreview.Checked)
            {
                this.LivePreviewForm.Show();
            }
            else
            {
                this.LivePreviewForm.Hide();
            }

            var displayShown = this.tsmShowLivePreview.Checked;
            foreach (ToolStripItem item in this.tsmShowLivePreview.DropDownItems)
            {
                item.Enabled = displayShown;
            }
        }

        #endregion

        #region Internal Members

        #region Event Triggers

        //private void OnPresentFormRequired()
        //{
        //    var handler = this.PresentFormRequired;
        //    if (handler != null)
        //    {
        //        handler.Invoke(this, EventArgs.Empty);
        //    }
        //}

        private void OnPresentFormEventsRequired()
        {
            var handler = this.PresentFormEventsRequired;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        //private void OnPresentFormEventsRemoved()
        //{
        //    var handler = this.PresentFormEventsRemoved;
        //    if (handler != null)
        //    {
        //        handler.Invoke(this, EventArgs.Empty);
        //    }
        //}

        //private void OnLivePreviewFormRequired()
        //{
        //    var handler = this.LivePreviewFormRequired;
        //    if (handler != null)
        //    {
        //        handler.Invoke(this, EventArgs.Empty);
        //    }
        //}

        private void OnLivePreviewFormEventsRequired()
        {
            var handler = this.LivePreviewFormEventsRequired;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnUnhookLivePreviewFormEvents()
        {
            var handler = this.LivePreviewFormEventsRemoved;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        //private void OnLivePreviewFormEventsRemoved()
        //{
        //    var handler = this.LivePreviewFormEventsRemoved;
        //    if (handler != null)
        //    {
        //        handler.Invoke(this, EventArgs.Empty);
        //    }
        //}

        private void OnPresetsLoaded(List<string> names)
        {
            var handler = this.PresetsLoaded;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(names));
            }
        }

        private void OnTimersSettingsOpened(List<string> selections)
        {
            var handler = this.TimersSettingsOpened;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(selections));
            }
        }

        private void OnTimerSettingsDeleted(List<string> selections)
        {
            var handler = this.TimersSettingsDeleted;
            if (handler != null)
            {
                handler.Invoke(this, new PresetEventArgs(selections));
            }
        }

        #endregion

        private void HookPresentFormEvents()
        {
            this.PresentForm.WindowStateChanged += presentForm_WindowStateChanged;
            this.PresentForm.FormClosing += presentForm_FormClosing;
        }

        private void HookLivePreviewFormEvents()
        {
            this.LivePreviewForm.SizeChanged += (s, e) =>
            {
                this.previewFormSize = this.LivePreviewForm.Size;
            };

            this.LivePreviewForm.FormClosing += (s, e) =>
            {
                this.tsmShowLivePreview.Checked = false;
                this.OnUnhookLivePreviewFormEvents();
                this.previousimeViewControl = this.LivePreviewForm.TimeViewControl;
                this.previousCommandIssuer = this.LivePreviewForm.CommandIssuer;
            };
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
            var settings = this.PresetManager.LoadAll();
            if (settings != null)
            {
                this.OnPresetsLoaded(settings);
            }
            else
            {
                MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Event Handlers

        #region ToolStrip Menu Items Event Handlers

        private void tsmShowDisplay_Click(object sender, EventArgs e)
        {
            this.TogglePresentationForm();
        }

        private void tsmKeepPreviewOnTop_Click(object sender, EventArgs e)
        {
            this.EnsureLivePreviewFormActive();
            this.tsmKeepPreviewOnTop.Checked = !this.tsmKeepPreviewOnTop.Checked;
            this.LivePreviewForm.TopMost = this.tsmKeepPreviewOnTop.Checked;
        }

        private void tsmShowLivePreview_Click(object sender, EventArgs e)
        {
            this.ToggleLivePreviewForm();
        }

        private void tsmKeepOnTop_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;
            this.PresentForm.TopMost = this.tsmKeepOnTop.Checked;
        }

        private void tsmFullScreen_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.PresentForm.ToggleFullScreen();
        }

        private void tsmMaximizeDisplay_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmMaximizeDisplay.Checked = !this.tsmMaximizeDisplay.Checked;
            if (this.tsmMaximizeDisplay.Checked)
            {
                this.PresentForm.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.PresentForm.WindowState = FormWindowState.Normal;
            }
        }

        private void tsmRemoveDisplayBorder_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmRemoveDisplayBorder.Checked = !this.tsmRemoveDisplayBorder.Checked;
            if (this.tsmRemoveDisplayBorder.Checked)
            {
                this.PresentForm.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.PresentForm.FormBorderStyle = PresentationTimerForm.BorderStyle;
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
                if (this.PresentForm.WindowState == FormWindowState.Maximized)
                {
                    this.PresentForm.WindowState = FormWindowState.Normal;
                    this.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
                    this.PresentForm.WindowState = FormWindowState.Maximized;
                }

                newLocation.X += (newScreen.Width / 2) - (this.PresentForm.Size.Width / 2);
                newLocation.Y += (newScreen.Height / 2) - (this.PresentForm.Size.Height / 2);

                this.PresentForm.SetDesktopLocation(newLocation.X, newLocation.Y);
            }
        }

        private void tsmRefreshScreens_Click(object sender, EventArgs e)
        {
            this.AddAllScreens();
        }

        private void tsmOpenSettings_Click(object sender, EventArgs e)
        {
            using (var form = new TimerSettingsForm())
            {
                form.TimerSettings = this.PresetManager.SettingsNames;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var selections = form.TimerSettings;
                    switch (form.SelectedAction)
                    {

                        case TimerSettingsForm.Action.Open:
                            {
                                this.OnTimersSettingsOpened(selections as List<string>);
                                break;
                            }

                        case TimerSettingsForm.Action.Delete:
                            {
                                var result = MessageBox.Show("Are you sure you want to to delete selected timer settings?", Application.ProductName, MessageBoxButtons.YesNo);
                                if (result == System.Windows.Forms.DialogResult.Yes)
                                {
                                    this.PresetManager.DeleteSettings(selections as List<string>, false);
                                    this.OnTimerSettingsDeleted(selections as List<string>);

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

        private void tslMakeTimePlan_Click(object sender, EventArgs e)
        {
            using (var form = new TimePlanForm())
            {
                form.ShowDialog();
            }
        }

        #endregion

        #region Present Form Event Handlers

        private void presentForm_WindowStateChanged(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            this.tsmFullScreen.Checked = this.PresentForm.IsFullScreen;
            this.tsmMaximizeDisplay.Checked = this.PresentForm.IsFullScreen;
        }

        private void presentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.tsmShowDisplay.Checked = false;
            ////this.OnPresentFormEventsRemoved();
        }

        #endregion

        #endregion
    }
}
