namespace SpeakerTimer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class TimerPreview : UserControl
    {
        private bool running;
        private TimerViewSettings settings;

        public TimerPreview()
        {
            InitializeComponent();

            this.IsLive = false;
            this.settings = TimerViewSettings.Default;
            this.CommandIssuer = new TimerViewerCommandIssuer();
            this.timerView.CommandIssuer = this.CommandIssuer;
            this.HookEventHandlers();

            this.InitSettings();
            Util.SetWatermark(this.txtSettingsName, this.settings.Name);
            this.grbPreviewBox.Text = this.settings.Name;
        }

        public event EventHandler<SettingIOEventArgs> LoadRequested;
        public event EventHandler<SettingIOEventArgs> SaveRequested;
        public event EventHandler LiveStateChanged;

        public TimerViewSettings Settings
        {
            get { return this.settings; }

            set
            {
                this.settings = value;
                this.OnSettingsChanged();
                this.InitSettings();
            }
        }

        public bool IsLive
        {
            get
            {
                return this.pcbLiveIndicator.Visible;
            }

            set
            {
                bool islive = value;
                this.pcbLiveIndicator.Visible = islive;
                this.rdbLive.Checked = islive;
                this.rdbLive.ForeColor = islive ? Color.Red : Color.Black;
            }
        }

        public string DisplayName
        {
            get { return this.grbPreviewBox.Text; }
            set
            {
                this.grbPreviewBox.Text = value;
                Util.SetWatermark(this.txtSettingsName, value);
            }
        }
        
        public ComboBox.ObjectCollection SavedTimers
        {
            get { return this.cmbLoadTimer.Items; }
        }

        public TimerViewerCommandIssuer CommandIssuer { get; private set; }

        #region Internal Members

        private void InitSettings()
        {
            // Display Settings
            this.cmbDisplayMode.DataSource = Enum.GetValues(typeof(TimerViewSettings.TimerDisplayMode));
            this.cmbCounterMode.DataSource = Enum.GetValues(typeof(TimerViewSettings.TimerCounterMode));
            this.cmbDisplayMode.Text = this.Settings.DisplayMode.ToString();
            this.cmbCounterMode.Text = this.Settings.CounterMode.ToString();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                this.cmbFontFace.Items.Add(font.Name);
            }

            this.cmbFontFace.Text = this.Settings.TimerFont.FontFamily.Name;
            this.numFontSize.Value = (decimal)this.Settings.TimerFont.Size;
            this.txtFinalMessage.Text = this.Settings.FinalMessage;

            // Colors
            this.btnRunningColor.BackColor = this.Settings.RunningColor;
            this.btnPausedColor.BackColor = this.Settings.PausedColor;
            this.btnWarningColor.BackColor = this.Settings.WarningColor;
            this.btnExpiredColor.BackColor = this.Settings.ExpiredColor;
            this.btnStoppedColor.BackColor = this.Settings.StoppedColor;
            this.btnBackColor.BackColor = this.Settings.BackgroundColor;
            this.btnMessageColor.BackColor = this.Settings.MessageColor;

            // Special Times
            this.txtWarningTime.SetTime(this.Settings.WarningTime);
            this.txtAutoPauseTime.SetTime(this.Settings.SecondWarningTime);

			// Blinking
			this.chbBlink.Checked = this.settings.BlinkOnExpired;

            // Meta data
            this.running = false;
            this.grbPreviewBox.Text = this.settings.Name;
            this.txtSettingsName.Text = this.settings.Name;
            Util.SetWatermark(this.txtSettingsName, this.settings.Name);
        }

        private void HookEventHandlers()
        {
            this.timerView.TimeStarted += (_, __) => this.ResetPausedButton();
            this.timerView.TimePaused += (_, __) => this.ResetPlayButton();
            this.timerView.TimeStopped += (_, __) => this.ResetPlayButton();
            this.timerView.DurationChanged += (_, e) =>
            {
                this.Settings.Duration = e.Duration;
                this.OnSettingsChanged();
                this.CommandIssuer.OnRefreshTimerDisplay(e.Duration);
            };
        }

        private void ResetPlayButton()
        {
            this.btnStart.Text = "Start";
            this.btnStart.Image = ControlPanel.PlayImage;
            this.btnStart.ForeColor = Color.RoyalBlue;
            this.btnStart.BackColor = Color.Silver;
            this.running = false;
        }

        private void ResetPausedButton()
        {
            this.btnStart.Text = "Pause";
            this.btnStart.Image = ControlPanel.PauseImage;
            this.btnStart.ForeColor = Color.Green;
            this.btnStart.BackColor = Color.LightCyan;
            this.running = true;
        }

        private Color PickColor(Color defaultColor)
        {
            var result = this.colorDialog.ShowDialog();
            return result == DialogResult.OK ? this.colorDialog.Color : defaultColor;
        }

        private void SaveSetting()
        {
            var name = this.txtSettingsName.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("The entered name cannot be null");
                return;
            }

            if (name.Contains(","))
            {
                MessageBox.Show("Then entered name must not contain a comma ','");
                return;
            }

            foreach (var c in System.IO.Path.GetInvalidFileNameChars())
            {
                if (name.Contains(c.ToString()))
                {
                    MessageBox.Show("The entered name contains an invalid character: " + c);
                    return;
                }
            }

            this.Settings.Name = name;
            this.OnSaveRequested(name, this.Settings);
        }

        private void OnLoadRequested(string name)
        {
            var handler = this.LoadRequested;
            if (handler != null)
            {
                handler.Invoke(this, new SettingIOEventArgs(name));
            }
        }

        private void OnSaveRequested(string name, TimerViewSettings settings)
        {
            var handler = this.SaveRequested;
            if (handler != null)
            {
                handler.Invoke(this, new SettingIOEventArgs(name, settings));
            }
        }

        private void OnLiveStateChanged()
        {
            var handler = this.LiveStateChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnSettingsChanged()
        {
            this.CommandIssuer.OnSettingsChanged(this.Settings);
            this.grbPreviewBox.Text = this.settings.Name + "*";
        }

        #endregion

        #region Event Handlers

        private void TimerPreview_Load(object sender, EventArgs e)
        {
            this.DisplayName = this.settings.Name;
            Util.SetWatermark(this.txtFinalMessage, "Time Up");
        }

        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            var duration = this.settings.Duration;
            this.settings = TimerViewSettings.Default;
            this.settings.Duration = duration;
            this.InitSettings();
            this.OnSettingsChanged();
        }

        #region Functions Event Handlers

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.settings.Duration == 0)
            {
                MessageBox.Show("Please enter a non-zero duration.\r\n" +
                    "(Double click on the preview timer to set the timer duration).",
                    "Invalid Duration",
                    MessageBoxButtons.OK);

                return;
            }

            if (this.running)
            {
                this.ResetPlayButton();
                this.CommandIssuer.IssuePauseCommand();
            }
            else
            {
                this.ResetPausedButton();
                this.CommandIssuer.IssueStartCommand();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.ResetPlayButton();
            this.CommandIssuer.IssueStopCommand();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ResetPlayButton();
            this.CommandIssuer.IssueResetCommand();
        }

        private void txtWarningTime_TimeChanged(object sender, EventArgs e)
        {
            this.Settings.WarningTime = this.txtWarningTime.InputTime;
            this.OnSettingsChanged();
        }

        private void txtAutoPauseTime_TimeChanged(object sender, EventArgs e)
        {
            this.Settings.SecondWarningTime = this.txtAutoPauseTime.InputTime;
            this.OnSettingsChanged();
        }

        private void rdbLive_Click(object sender, EventArgs e)
        {
            this.IsLive = !this.IsLive;

            var wasRunning = this.running;
            if (wasRunning)
            {
                // Pause an ongoing timer
                this.CommandIssuer.IssuePauseCommand();
            }

            this.OnLiveStateChanged();

            if (this.IsLive)
            {
                this.OnSettingsChanged();
                if (!wasRunning)
                {
                    // Stop any previously running timer on the live screen
                    this.CommandIssuer.IssueStopCommand();
                }

                this.CommandIssuer.OnRefreshTimerDisplay(this.timerView.CurrentTime);
            }

            if (wasRunning)
            {
                // Resume the paused timer from current time
                this.CommandIssuer.IssueStartCommand(this.timerView.CurrentTime);
            }
        }

        private void chbBlink_CheckedChanged(object sender, EventArgs e)
        {
			this.settings.BlinkOnExpired = this.chbBlink.Checked;
			this.OnSettingsChanged ();
        }

        private void txtSettingsName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.SaveSetting();
                e.Handled = true;
                return;
            }

            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            var handled = Array.Exists(invalidChars, x => x == e.KeyChar) && !char.IsControl(e.KeyChar);
            handled = handled || e.KeyChar == ',';
            e.Handled = handled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveSetting();
        }

        private void cmbLoadTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ResetPlayButton();
            this.CommandIssuer.IssueStopCommand();
            this.running = false;

            this.OnLoadRequested(this.cmbLoadTimer.SelectedItem.ToString());
        }

        #endregion

        #region Display Settings Event Handlers

        private void cmbDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Settings.DisplayMode = Util.ToEnum<TimerViewSettings.TimerDisplayMode>(this.cmbDisplayMode.SelectedItem.ToString());
            if (!this.running)
            {
                this.CommandIssuer.OnRefreshTimerDisplay();
            }

            this.OnSettingsChanged();
        }

        private void cmbCounterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Settings.CounterMode = Util.ToEnum<TimerViewSettings.TimerCounterMode>(this.cmbCounterMode.SelectedItem.ToString());
            this.OnSettingsChanged();
        }

        private void cmbFontFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Settings.SetFont(this.cmbFontFace.SelectedItem.ToString());
            this.OnSettingsChanged();
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.SetFont(string.Empty, (int)this.numFontSize.Value);
            this.OnSettingsChanged();
        }

        private void txtFinalMessage_TextChanged(object sender, EventArgs e)
        {
            this.Settings.FinalMessage = this.txtFinalMessage.Text;
            this.OnSettingsChanged();
        }

        #endregion

        #region Color Settings Event Handlers

        private void btnRunningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.RunningColor);
            this.btnRunningColor.BackColor = color;
            this.Settings.RunningColor = color;
            this.OnSettingsChanged();
        }

        private void btnPausedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.PausedColor);
            this.btnPausedColor.BackColor = color;
            this.Settings.PausedColor = color;
            this.OnSettingsChanged();
        }

        private void btnWarningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.WarningColor);
            this.btnWarningColor.BackColor = color;
            this.Settings.WarningColor = color;
            this.OnSettingsChanged();
        }

        private void btnStoppedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.StoppedColor);
            this.btnStoppedColor.BackColor = color;
            this.Settings.StoppedColor = color;
            this.OnSettingsChanged();
        }

        private void btnExpiredColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.ExpiredColor);
            this.btnExpiredColor.BackColor = color;
            this.Settings.ExpiredColor = color;
            this.OnSettingsChanged();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.BackgroundColor);
            this.btnBackColor.BackColor = color;
            this.Settings.BackgroundColor = color;
            this.OnSettingsChanged();
        }

        private void btnMessageColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.Settings.MessageColor);
            this.btnMessageColor.BackColor = color;
            this.Settings.MessageColor = color;
            this.OnSettingsChanged();
        }

        #endregion

        #endregion
    }
}
