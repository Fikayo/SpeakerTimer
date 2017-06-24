﻿namespace SpeakerTimer.Presentation
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class TimerPreview : UserControl
    {
        private bool running;
        private bool showingMessage;
        private SimpleTimerSettings settings;

        public TimerPreview()
        {
            InitializeComponent();

            this.IsLive = false;
            this.CommandIssuer = new TimerViewerCommandIssuer();
            this.timerView.CommandIssuer = this.CommandIssuer;
            this.HookTimerViewEventHandlers();

            this.Settings = SimpleTimerSettings.Default;
        }

        public event EventHandler<SettingIOEventArgs> LoadRequested;
        public event EventHandler<SettingIOEventArgs> SaveRequested;
        public event EventHandler TimeElapsed;
        public event EventHandler LiveStateChanged;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SimpleTimerSettings Settings
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
            // Title
            this.txtTitle.Text = this.Settings.TimerDuration.Title;

            // Final Message
            this.txtFinalMessage.Text = this.Settings.FinalMessage;

            // Special Times
            this.tibWarningTime.SetTime(this.Settings.TimerDuration.WarningTime);
            this.tibSecondWarningTime.SetTime(this.Settings.TimerDuration.SecondWarningTime);

            // Blinking
            this.chbBlink.Checked = this.Settings.BlinkOnExpired;

            // Timer Message Font
            this.numMessageFont.Value = (decimal)this.Settings.MessageSettings.MessageFontSize;

            // Meta data
            this.running = false;
            this.showingMessage = false;
            this.grbPreviewBox.Text = this.Settings.Name;
            this.txtSettingsName.Text = this.Settings.Name;
            Util.SetWatermark(this.txtSettingsName, this.Settings.Name);

            this.SaveSettings();
        }

        private void HookTimerViewEventHandlers()
        {
            this.timerView.TimeStarted += (_, __) => this.ResetPausedButton();
            this.timerView.TimePaused += (_, __) => this.ResetPlayButton();
            this.timerView.TimeStopped += (_, __) => this.ResetPlayButton();
            this.timerView.DurationElapsed += (_, __) => this.OnTimeElapsed();

            this.timerView.MessageFinished += (_, __) =>
            {
                this.showingMessage = false;
                this.numMessageDuration.Enabled = true;
                this.chbIndefiniteMessageDuration.Enabled = true;
                this.numMessageFont.Enabled = true;
                this.txtShowMessage.Enabled = true;
                this.btnShowMessage.Text = "Show Message";
            };

            this.timerView.DurationChanged += (_, e) =>
            {
                ChangeTimerDuration(e.Duration);
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

        private void FreezeMessageInput()
        {
            const string cancelMessageText = "CANCEL";

            this.numMessageDuration.Enabled = false;
            this.chbIndefiniteMessageDuration.Enabled = false;
            this.numMessageFont.Enabled = false;
            this.txtShowMessage.Enabled = false;

            this.btnShowMessage.Text = cancelMessageText;
            this.showingMessage = true;
        }

        private void ChangeTimerDuration(double duration)
        {
            this.Settings.TimerDuration.Duration = duration;
            this.OnSettingsChanged();
            this.CommandIssuer.OnRefreshTimerDisplay(duration);
        }

        private Color PickColor(Color defaultColor)
        {
            var result = this.colorDialog.ShowDialog();
            return result == DialogResult.OK ? this.colorDialog.Color : defaultColor;
        }

        private void SaveSettings()
        {            
            this.OnSaveRequested(this.Settings);
            this.btnSave.BackgroundImage = ControlPanel.SaveImage;
        }

        #endregion

        #region Event Triggers

        private void OnLoadRequested(string name)
        {
            var handler = this.LoadRequested;
            if (handler != null)
            {
                handler.Invoke(this, new SettingIOEventArgs(name));
            }
        }

        private void OnSaveRequested(SimpleTimerSettings settings)
        {
            var handler = this.SaveRequested;
            if (handler != null)
            {
                handler.Invoke(this, new SettingIOEventArgs(settings.Name, settings));
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

        private void OnTimeElapsed()
        {
            var handler = this.TimeElapsed;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnSettingsChanged()
        {
            SettingsManager<SimpleTimerSettings>.SimpleSettingsManager.AddOrUpdate(this.Settings);

            this.CommandIssuer.OnSettingsUpdated(this.Settings.Id);
            ////this.CommandIssuer.OnSettingsChanged(this.Settings);
            this.grbPreviewBox.Text = this.settings.Name;
            this.btnSave.BackgroundImage = ControlPanel.SaveAsterisk;
        }

        #endregion

        #region Event Handlers

        private void TimerPreview_Load(object sender, EventArgs e)
        {
            this.DisplayName = this.settings.Name;
            Util.SetWatermark(this.txtFinalMessage, "Time Up");
        }
        
        #region Timer Message

        private void btnShowMessage_Click(object sender, EventArgs e)
        {
            if (this.showingMessage)
            {
                this.CommandIssuer.CancelTimerMessage();
            }
            else
            {
                this.Settings.MessageSettings.TimerMessage = this.txtShowMessage.Text;

                this.FreezeMessageInput();
                this.CommandIssuer.OnTimerMessageChanged(this.Settings.MessageSettings);
            }
        }

        private void numMessageDuration_ValueChanged(object sender, EventArgs e)
        {
            int messageDuration = (int)this.numMessageDuration.Value;
            this.chbIndefiniteMessageDuration.Checked = messageDuration <= 0;

            this.Settings.MessageSettings.MessageDuration = messageDuration; // seconds
        }

        private void numMessageFont_ValueChanged(object sender, EventArgs e)
        {
            this.Settings.MessageSettings.MessageFontSize = (int)this.numMessageFont.Value;
        }

        private void chbIndefiniteMessageDuration_CheckedChanged(object sender, EventArgs e)
        {
            this.Settings.MessageSettings.IsIndefiniteMessage = this.chbIndefiniteMessageDuration.Checked;
        }

        #endregion 

        #region Settings Event Handlers

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            this.Settings.TimerDuration.Title = this.txtTitle.Text;
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

            var wasDisplayingMessage = this.showingMessage;
            var messageSettings = TimerMessageSettings.Default;
            if(wasDisplayingMessage)
            {
                this.CommandIssuer.CancelTimerMessage();
                messageSettings = this.timerView.Settings.MessageSettings.Clone();
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

                if(!wasDisplayingMessage)
                {
                    // Stop any previously showing message on the screen
                    this.CommandIssuer.CancelTimerMessage();
                }

                this.CommandIssuer.OnRefreshTimerDisplay(this.timerView.CurrentTime);
            }

            if (wasRunning)
            {
                // Resume the paused timer from current time
                this.CommandIssuer.IssueStartCommand(this.timerView.CurrentTime);
            }

            if(wasDisplayingMessage)
            {
                this.FreezeMessageInput();

                // Use the settings of the timerview because it may have updated since it was set
                this.CommandIssuer.OnTimerMessageChanged(messageSettings);
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
        
        private void btnVisualSettings_Click(object sender, EventArgs e)
        {
            using (var form = new VisualSettingsForm(this.Settings.VisualSettings, this.Settings.Name))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.Settings.VisualSettings = form.VisualSettings;
                    this.OnSettingsChanged();
                }
            }
        }

        #endregion

        #region Functions Event Handlers

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.settings.TimerDuration.Duration == 0 && this.settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
            {
                this.ChangeTimerDuration(Util.MAX_INPUT_TIME_ALLOWED);
            }
            else if (this.settings.TimerDuration.Duration == 0)
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
                this.OnSettingsChanged();

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

        private void btnNewSetting_Click(object sender, EventArgs e)
        {
            this.Settings = SimpleTimerSettings.Default;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
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
            this.Settings.TimerDuration.WarningTime = this.tibWarningTime.InputTime;
            this.OnSettingsChanged();
        }

        private void txtAutoPauseTime_TimeChanged(object sender, EventArgs e)
        {
            this.Settings.TimerDuration.SecondWarningTime = this.tibSecondWarningTime.InputTime;
            this.OnSettingsChanged();
        }

        #endregion

        #endregion
    }
}