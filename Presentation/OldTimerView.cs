namespace SpeakerTimer.Presentation
{
    using System;
    using System.Drawing;
	using System.Windows.Forms;
	using SpeakerTimer.Application;

    public class OldTimerView
    {
        private const int PreviewFontSize = 30;
        private const int PreviewLabelSize = 10;

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private System.Windows.Forms.Label lblCurrentTimer;

        private bool stopped;
        private Timer timer;

        private BlinkManager blinkManager;
        private TimeInputBox txtInput;
        private TimerViewSettings settings;
        private TimerViewerCommandIssuer commandIssuer;

        public OldTimerView()
        {
            //InitializeComponent();

            this.txtInput = new TimeInputBox();
            this.InitialiseTxtInput();

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;
            this.settings = TimerViewSettings.Default;
            this.stopped = true;

            this.blinkManager = new BlinkManager();
            this.blinkManager.Blink += BlinkManager_Blink;
        }

        public OldTimerView(TimerViewerCommandIssuer commandIssuer)
            : this()
        {
            this.CommandIssuer = commandIssuer;
        }

        #region Events

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler<DurationChangedEventArgs> DurationChanged;

        #endregion

        #region Properties

        public TimerViewerCommandIssuer CommandIssuer
        {
            get { return this.commandIssuer; }

            set
            {
                this.UnHookEventHandlers();
                this.commandIssuer = value;
                this.HookEventHandlers();
            }
        }

        public Font TimerFont
        {
            get { return this.lblTimer.Font; }

            set { this.lblTimer.Font = value; }
        }

        public Color TimerColor
        {
            get { return this.lblTimer.ForeColor; }

            set
            {
                this.lblTimer.ForeColor = value;
                this.lblCurrentTimer.ForeColor = value;
            }
        }

        public Color BackgroundColor
        {
            get { return this.tlpOuterLayout.BackColor; }

            set { this.tlpOuterLayout.BackColor = value; }
        }

        public bool IsPreviewMode
        {
            get { return this.lblTimer.Cursor == Cursors.IBeam; }

            set
            {
                var preview = value;
                this.lblTimer.Cursor = preview ? Cursors.IBeam : Cursors.Default;
            }
        }

        public int BlinkInterval
        {
            get { return this.blinkManager.Interval; }
            set { this.blinkManager.Interval = value; }
        }

        public double CurrentTime { get; private set; }

        #endregion

        #region External Members

        public void StartTimer(bool forceCurrentTime = false)
        {
            if (this.stopped && !forceCurrentTime)
            {
                this.CurrentTime = this.settings.Duration;
                if (this.settings.CounterMode == TimerViewSettings.TimerCounterMode.CountUp)
                {
                    this.CurrentTime = 0;
                }
            }

            this.stopped = false;
            this.DisplayTimeElapsed(this.CurrentTime);
            this.timer.Start();
            this.TimerColor = this.settings.RunningColor;
            this.OnTimeStarted();
        }

        public void PauseTimer()
        {
            this.timer.Stop();
            this.TimerColor = this.settings.PausedColor;
            this.OnTimePaused();
        }

        public void StopTimer()
        {
            this.blinkManager.StopBlinking();

            this.timer.Stop();
            this.stopped = true;
            this.TimerColor = this.settings.StoppedColor;
            this.OnTimeStopped();
        }

        public void ResetTimer()
        {
            this.timer.Stop();
            this.stopped = true;
            this.DisplayTimeElapsed(this.settings.Duration);
        }

        public void ApplySettings(TimerViewSettings settings)
        {
            this.TimerFont = this.IsPreviewMode ? new Font(settings.TimerFont.FontFamily.Name, OldTimerView.PreviewFontSize) : settings.TimerFont;
            int labelSize = this.IsPreviewMode ? OldTimerView.PreviewLabelSize : (int)Math.Max(settings.TimerFont.Size / 10, 10);
            this.lblCurrentTimer.Font = new Font(settings.TimerFont.FontFamily.Name, labelSize);

            this.BackgroundColor = settings.BackgroundColor;
            this.TimerColor = settings.RunningColor;

            this.settings = TimerViewSettings.ParseCsv(settings.SaveSettingsAsCsv());
            this.lblCurrentTimer.Text = this.settings.Name;
            this.RefreshTimerDisplay();
        }

        public void DisplayTimeElapsed(double counter)
        {
            string display = string.Empty;

            switch (this.settings.DisplayMode)
            {
                case TimerViewSettings.TimerDisplayMode.DisplayInSeconds:
                    display = ((int)(counter)).ToString();
                    break;

                case TimerViewSettings.TimerDisplayMode.SuppressLeadingZeros:
                    display = TimeSpan.FromSeconds(counter).ToString().TrimStart(new char[] { '0', ':' });
                    display = display.Length == 0 ? "0" : display;
                    break;

                case TimerViewSettings.TimerDisplayMode.FullWidth:
                default:
                    display = TimeSpan.FromSeconds(counter).ToString();
                    break;
            }

            this.lblTimer.Text = display;
        }

        #endregion

        #region Internal Members

        private void HookEventHandlers()
        {
            if (this.commandIssuer != null)
            {
                this.commandIssuer.StartCommand += CommandIssuer_StartCommand;
                this.commandIssuer.PauseCommand += CommandIssuer_PauseCommand;
                this.commandIssuer.StopCommand += CommandIssuer_StopCommand;
                this.commandIssuer.ResetCommand += CommandIssuer_ResetCommand;
                this.commandIssuer.RefreshTimerDisplay += CommandIssuer_RefreshTimerDisplay;
                this.commandIssuer.SettingsChanged += CommandIssuer_SettingsChanged;
            }
        }

        private void UnHookEventHandlers()
        {
            if (this.commandIssuer != null)
            {
                this.commandIssuer.StartCommand -= CommandIssuer_StartCommand;
                this.commandIssuer.PauseCommand -= CommandIssuer_PauseCommand;
                this.commandIssuer.StopCommand -= CommandIssuer_StopCommand;
                this.commandIssuer.ResetCommand -= CommandIssuer_ResetCommand;
                this.commandIssuer.RefreshTimerDisplay -= CommandIssuer_RefreshTimerDisplay;
                this.commandIssuer.SettingsChanged -= CommandIssuer_SettingsChanged;
            }
        }

        private void InitialiseTxtInput()
        {
            this.txtInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInput.Enabled = false;
            this.txtInput.InputTime = 0D;
            this.txtInput.Size = new System.Drawing.Size(292, 85);
            this.txtInput.TabIndex = 1;
            this.txtInput.Text = "00:00:00";
            this.txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInput.Visible = false;
            this.txtInput.TimeChanged += this.txtInput_TimeChanged;
        }

        private bool DisplayFinalMessage()
        {
            if (!string.IsNullOrEmpty(this.settings.FinalMessage))
            {
                this.lblTimer.ForeColor = this.settings.MessageColor;
                this.lblTimer.Text = this.settings.FinalMessage;
                return true;
            }

            return false;
        }

        private void ShowInputBox()
        {
            this.txtInput.Enabled = true;
            this.txtInput.Visible = true;
            this.txtInput.Font = this.lblTimer.Font;
            if (this.settings.DisplayMode == TimerViewSettings.TimerDisplayMode.FullWidth)
            {
                this.txtInput.Size = this.lblTimer.Size;
            }

            this.lblTimer.Visible = false;
            this.tlpOuterLayout.Controls.Add(this.txtInput, 1, 1);

            this.txtInput.Focus();
        }

        private void HideInputBox()
        {
            this.txtInput.Enabled = false;
            this.txtInput.Visible = false;
            this.settings.Duration = this.txtInput.InputTime;

            this.lblTimer.Visible = true;
            this.lblTimer.Focus();
            this.tlpOuterLayout.Controls.Add(this.lblTimer, 1, 1);
            this.DisplayTimeElapsed(this.settings.Duration);

            this.OnDurationChanged(this.settings.Duration);
        }

        private void RefreshTimerDisplay(bool forceCurrentTime = false)
        {
            var display = this.CurrentTime;
            if (this.stopped && !forceCurrentTime)
            {
                display = this.settings.Duration;
            }

            this.DisplayTimeElapsed(display);
        }

        private void OnTimeStarted()
        {
            var handler = this.TimeStarted;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnTimePaused()
        {
            var handler = this.TimePaused;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnTimeStopped()
        {
            var handler = this.TimeStopped;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnDurationChanged(double duration)
        {
            var handler = this.DurationChanged;
            if (handler != null)
            {
                handler.Invoke(this, new DurationChangedEventArgs(duration));
            }
        }

        #endregion

        #region Event Handlers

        private void TimerView_Leave(object sender, EventArgs e)
        {
            if (this.IsPreviewMode && this.txtInput.Visible)
            {
                this.HideInputBox();
            }
        }

        private void CommandIssuer_StartCommand(object sender, CurrentTimeEventArgs e)
        {
            this.CurrentTime = e.CurrentTime.HasValue ? e.CurrentTime.Value : this.CurrentTime;
            this.StartTimer(e.CurrentTime.HasValue);
        }

        private void CommandIssuer_PauseCommand(object sender, EventArgs e)
        {
            this.PauseTimer();
        }

        private void CommandIssuer_StopCommand(object sender, EventArgs e)
        {
            this.StopTimer();
        }

        private void CommandIssuer_ResetCommand(object sender, EventArgs e)
        {
            this.ResetTimer();
        }

        private void CommandIssuer_RefreshTimerDisplay(object sender, CurrentTimeEventArgs e)
        {
            this.CurrentTime = e.CurrentTime.HasValue ? e.CurrentTime.Value : this.CurrentTime;
            this.RefreshTimerDisplay(e.CurrentTime.HasValue);
        }

        private void CommandIssuer_SettingsChanged(object sender, SettingsChangedEventArgs e)
        {
            this.ApplySettings(e.Settings);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.lblTimer.ForeColor = this.settings.RunningColor;

            switch (this.settings.CounterMode)
            {
                case TimerViewSettings.TimerCounterMode.CountUp:
                    this.CurrentTime++;
                    if (this.CurrentTime >= this.settings.Duration)
                    {
                        this.StopTimer();
                        if (!this.DisplayFinalMessage())
                        {
                            this.DisplayTimeElapsed(this.CurrentTime);
                        }

                        return;
                    }

                    if (this.CurrentTime >= this.settings.WarningTime && this.settings.WarningTime > 0)
                    {
                        this.TimerColor = this.settings.WarningColor;
                    }

                    break;

                case TimerViewSettings.TimerCounterMode.CountDownToZero:
                    this.CurrentTime--;
                    if (this.CurrentTime <= 0)
                    {
                        this.StopTimer();
                        if (!this.DisplayFinalMessage())
                        {
                            this.DisplayTimeElapsed(this.CurrentTime);
                        }

                        return;
                    }

                    if (this.CurrentTime <= this.settings.WarningTime && this.settings.WarningTime > 0)
                    {
                        this.TimerColor = this.settings.WarningColor;
                    }

                    break;

                case TimerViewSettings.TimerCounterMode.CountDownToMinus:
                default:
                    this.CurrentTime--;
                    if (this.CurrentTime <= this.settings.WarningTime && this.settings.WarningTime > 0)
                    {
                        this.TimerColor = this.settings.WarningColor;
                    }

                    if (this.CurrentTime == 0)
                    {
                        if (this.DisplayFinalMessage())
                        {
                            return;
                        }
                    }

                    if (this.CurrentTime < 0)
                    {
                        this.lblTimer.ForeColor = this.settings.ExpiredColor;
                        if (!this.blinkManager.IsBlinking)
                        {
                            this.blinkManager.StartBlinking();
                        }
                    }

                    break;
            }

            this.DisplayTimeElapsed(this.CurrentTime);

            if (this.CurrentTime == this.settings.SecondWarningTime && this.CurrentTime > 0)
            {
                this.PauseTimer();
            }
        }

        private void BlinkManager_Blink(object sender, EventArgs e)
        {
            this.lblTimer.ForeColor = this.blinkManager.BlinkOn ? this.settings.ExpiredColor : this.settings.BackgroundColor;
        }

        private void lblTimer_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsPreviewMode && this.stopped)
            {
                this.ShowInputBox();
            }
        }

        private void tlpOuterLayout_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsPreviewMode && this.txtInput.Visible)
            {
                this.HideInputBox();
            }
        }

        private void txtInput_TimeChanged(object sender, EventArgs e)
        {
            if (this.IsPreviewMode && this.txtInput.Visible)
            {
                this.HideInputBox();
            }
        }

        #endregion
    }
}
