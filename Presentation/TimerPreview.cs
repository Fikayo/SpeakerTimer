namespace SpeakerTimer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using SpeakerTimer;

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
            // Final Message
            this.txtFinalMessage.Text = this.Settings.FinalMessage;

            // Special Times
            this.txtWarningTime.SetTime(this.Settings.WarningTime);
            this.txtSecondWarningTime.SetTime(this.Settings.SecondWarningTime);

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

            this.timerView.MessageFinished += (_, __) =>
            {
                this.numMessageDuration.Enabled = true;
                this.chbIndefiniteMessageDuration.Enabled = true;
                this.btnShowMessage.Text = "Show Message";
            };

            this.timerView.DurationChanged += (_, e) =>
            {
                this.Settings.Duration = e.Duration;
                this.OnSettingsChanged();
                this.CommandIssuer.OnRefreshTimerDisplay(e.Duration);
            };
        }

        private void ResetPlayButton()
        {
            //this.btnStart.Text = "Start";
            this.btnStart.Image = ControlPanel.PlayImage;
            //this.btnStart.ForeColor = Color.RoyalBlue;
            //this.btnStart.BackColor = Color.Silver;
            this.running = false;
        }

        private void ResetPausedButton()
        {
            //this.btnStart.Text = "Pause";
            this.btnStart.Image = ControlPanel.PauseImage;
            //this.btnStart.ForeColor = Color.Green;
            //this.btnStart.BackColor = Color.LightCyan;
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

            this.SaveSetting();
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
            //var duration = this.settings.Duration;
            //this.settings = TimerViewSettings.Default;
            //this.settings.Duration = duration;
            //this.InitSettings();
            //this.OnSettingsChanged();
            new SpeakerTimer.Presentation.VisualSettingsForm(TimerViewSettings.TimerVisualSettings.Default).Show();
        }

        private void btnVisualSettings_Click(object sender, EventArgs e)
        {
            using (var form = new SpeakerTimer.Presentation.VisualSettingsForm(this.Settings.VisualSettings))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.Settings.VisualSettings = form.VisualSettings;
                    this.OnSettingsChanged();
                }
            }
        }

        private void btnShowMessage_Click(object sender, EventArgs e)
        {
            const string cancelMessageText = "CANCEL";

            if (this.btnShowMessage.Text.Equals(cancelMessageText))
            {
                this.CommandIssuer.CancelTimerMessage();
            }
            else
            {
                this.Settings.MessageSettings.TimerMessage = this.txtShowMessage.Text;

                this.numMessageDuration.Enabled = false;
                this.chbIndefiniteMessageDuration.Enabled = false;
                this.btnShowMessage.Text = cancelMessageText;

                this.CommandIssuer.OnTimerMessageChanged(this.Settings.MessageSettings);
            }
        }

        private void numMessageDuration_ValueChanged(object sender, EventArgs e)
        {
            int messageDuration = (int)this.numMessageDuration.Value;
            this.chbIndefiniteMessageDuration.Checked = messageDuration <= 0;

            this.Settings.MessageSettings.MessageDuration = messageDuration * 1000; // seconds
        }

        private void chbIndefiniteMessageDuration_CheckedChanged(object sender, EventArgs e)
        {
            this.Settings.MessageSettings.IsIndefiniteMessage = this.chbIndefiniteMessageDuration.Checked;
        }

        #region Settings Event Handlers

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            this.Settings.Title = this.txtTitle.Text;
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
                this.CommandIssuer.CancelTimerMessage();

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
            this.OnSettingsChanged();
        }

        private void txtFinalMessage_TextChanged(object sender, EventArgs e)
        {
            this.Settings.FinalMessage = this.txtFinalMessage.Text;
            this.OnSettingsChanged();
        }

        #endregion

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

        #endregion

        #region IO Event Handlers

        private void txtSettingsName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.SaveSetting();
                e.Handled = true;
                this.txtSettingsName.Enabled = false;
                this.btnEditName.Enabled = true;
                return;
            }

            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            var handled = Array.Exists(invalidChars, x => x == e.KeyChar) && !char.IsControl(e.KeyChar);
            handled = handled || e.KeyChar == ',';
            e.Handled = handled;

            if (this.SavedTimers.Contains(this.txtSettingsName.Text))
            {
                this.txtSettingsName.BackColor = Color.LightPink;
                this.errorProvider.SetError(this.txtSettingsName, "Setting name already exists");
            }
            else
            {
                this.txtSettingsName.BackColor = Color.White;
                this.errorProvider.SetError(this.txtSettingsName, string.Empty);
            }
        }

        private void btnEditName_Click(object sender, EventArgs e)
        {
            this.txtSettingsName.Enabled = true;
            this.btnEditName.Enabled = false;
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

        #region Warning Event Handlers

        private void txtWarningTime_TimeChanged(object sender, EventArgs e)
        {
            this.Settings.WarningTime = this.txtWarningTime.InputTime;
            this.OnSettingsChanged();
        }

        private void txtAutoPauseTime_TimeChanged(object sender, EventArgs e)
        {
            this.Settings.SecondWarningTime = this.txtSecondWarningTime.InputTime;
            this.OnSettingsChanged();
        }

        #endregion

        #endregion
    }
}
