namespace ChurchTimer.Presentation
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ChurchTimer.Application;

    public partial class DisplayToolStripItem : ToolStripDropDownButton
    {
        private TimeViewControl previousimeViewControl;
        private TimerViewerCommandIssuer previousCommandIssuer;
        private Size previewFormSize;

        public DisplayToolStripItem()
        {
            InitializeComponent();

            this.previewFormSize = new Size(365, 225);

            //this.EnsureDisplayFormActive();

            //this.OnPresentFormEventsRequired();
            this.AddAllScreens();

            this.ToggleDisplayOnTop();
            this.TogglePreviewOnTop();
        }

        #region Events


        public event EventHandler PresentFormEventsRequired;

        public event EventHandler PresentFormEventsRemoved;

        public event EventHandler LivePreviewFormEventsRequired;

        public event EventHandler LivePreviewFormEventsRemoved;

        #endregion

        #region Properties

        public PresentationTimerForm PresentForm { get; set; }

        public PresentationTimerForm LivePreviewForm { get; set; }

        public bool IsMainDisplayVisible { get { return this.tsmShowDisplay.Checked; } }

        public bool IsLivePreviewVisible { get { return this.tsmShowLivePreview.Checked; } }

        public Func<TimeViewControl> FetchTimerView { get; internal set; }

        #endregion

        #region External Members

        public void EnsureDisplayFormActive()
        {
            if (this.PresentForm == null || this.PresentForm.IsDisposed)
            {
                this.PresentForm = null;
                this.PresentForm = new PresentationTimerForm(this.FetchTimerView());
                this.PresentForm.TopMost = this.tsmKeepOnTop.Checked;
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
                this.LivePreviewForm.Text = Util.GetFormName("Live Preview");
                this.LivePreviewForm.IsPreviewForm = true;
                this.LivePreviewForm.Size = this.previewFormSize;
                this.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                this.LivePreviewForm.TopMost = this.tsmKeepPreviewOnTop.Checked;
                this.HookLivePreviewFormEvents();
                this.OnLivePreviewFormEventsRequired();

                if (this.IsMainDisplayVisible)
                {
                    this.LivePreviewForm.CommandIssuer = this.PresentForm.CommandIssuer;
                    this.LivePreviewForm.CommandIssuer.OnSettingsUpdated(this.PresentForm.TimeViewControl.Settings.Id);
                    ////this.LivePreviewForm.CommandIssuer.OnSettingsChanged(this.PresentForm.TimeViewControl.Settings);
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
            foreach (ToolStripItem item in this.DropDownItems)
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

        private void ToggleDisplayOnTop()
        {
            this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;

            var displayTopMost = this.tsmKeepOnTop.Checked;
            if (this.PresentForm != null && !this.PresentForm.IsDisposed)
            {
                this.PresentForm.TopMost = displayTopMost;
            }
        }

        private void TogglePreviewOnTop()
        {
            this.tsmKeepPreviewOnTop.Checked = !this.tsmKeepPreviewOnTop.Checked;

            var previewTopMost = this.tsmKeepPreviewOnTop.Checked;
            if (this.LivePreviewForm != null && !this.LivePreviewForm.IsDisposed)
            {
                this.LivePreviewForm.TopMost = previewTopMost;
            }
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

        #endregion

        #region Event Triggers

        private void OnPresentFormEventsRequired()
        {
            var handler = this.PresentFormEventsRequired;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnPresentFormEventsRemoved()
        {
            var handler = this.PresentFormEventsRemoved;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

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

        #endregion

        #region ToolStrip Menu Items Event Handlers

        private void tsmShowDisplay_Click(object sender, EventArgs e)
        {
            this.TogglePresentationForm();
        }

        private void tsmShowLivePreview_Click(object sender, EventArgs e)
        {
            this.ToggleLivePreviewForm();
        }

        private void tsmKeepOnTop_Click(object sender, EventArgs e)
        {
            this.EnsureDisplayFormActive();
            ////this.tsmKeepOnTop.Checked = !this.tsmKeepOnTop.Checked;
            ////this.PresentForm.TopMost = this.tsmKeepOnTop.Checked;

            this.ToggleDisplayOnTop();
        }

        private void tsmKeepPreviewOnTop_Click(object sender, EventArgs e)
        {
            this.EnsureLivePreviewFormActive();
            ////this.tsmKeepPreviewOnTop.Checked = !this.tsmKeepPreviewOnTop.Checked;
            ////this.LivePreviewForm.TopMost = this.tsmKeepPreviewOnTop.Checked;

            this.TogglePreviewOnTop();
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
            this.OnPresentFormEventsRemoved();
        }

        #endregion

    }
}
