namespace SpeakerTimer.Presentation
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

   /*internal class STimer
    {
        private bool stopped;
        private Timer timer;

        private BlinkManager blinkManager;
        private TimerViewSettings settings;
        private TimerViewerCommandIssuer currentCommandIssuer;

        public STimer()
        {
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

        public STimer(TimerViewerCommandIssuer currentCommandIssuer) : this()
        {
            this.currentCommandIssuer = currentCommandIssuer;
        }

        #region Events

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler<DurationChangedEventArgs> DurationChanged;

        #endregion

        #region Properties

        public TimerViewerCommandIssuer currentCommandIssuer
        {
            get { return this.currentCommandIssuer; }

            set
            {
                this.UnHookEventHandlers();
                this.currentCommandIssuer = value;
                this.HookEventHandlers();
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
            this.timer.Start();
        }

        public void PauseTimer()
        {
            this.timer.Stop();
        }

        public void StopTimer()
        {
            this.timer.Stop();
            this.stopped = true;
        }

        public void ResetTimer()
        {
            this.timer.Stop();
            this.stopped = true;
        }

        public void ApplySettings(TimerViewSettings settings)
        {
            this.TimerFont = this.IsPreviewMode ? new Font(settings.TimerFont.FontFamily.Name, TimerView.PreviewFontSize) : settings.TimerFont;
            int labelSize = this.IsPreviewMode ? TimerView.PreviewLabelSize : (int)Math.Max(settings.TimerFont.Size / 10, 10);
            this.lblCurrentTimer.Font = new Font(settings.TimerFont.FontFamily.Name, labelSize);

            this.BackgroundColor = settings.BackgroundColor;
            this.TimerColor = settings.RunningColor;

            this.settings = TimerViewSettings.ParseCsv(settings.SaveSettingsAsCsv());
            this.lblCurrentTimer.Text = this.settings.Name;
            this.RefreshTimerDisplay();
        }
       
        #endregion

        #region Internal Members

        private void HookEventHandlers()
        {
            if (this.currentCommandIssuer != null)
            {
                this.currentCommandIssuer.StartCommand += CommandIssuer_StartCommand;
                this.currentCommandIssuer.PauseCommand += CommandIssuer_PauseCommand;
                this.currentCommandIssuer.StopCommand += CommandIssuer_StopCommand;
                this.currentCommandIssuer.ResetCommand += CommandIssuer_ResetCommand;
                this.currentCommandIssuer.RefreshTimerDisplay += CommandIssuer_RefreshTimerDisplay;
                this.currentCommandIssuer.SettingsChanged += CommandIssuer_SettingsChanged;
            }
        }

        private void UnHookEventHandlers()
        {
            if (this.currentCommandIssuer != null)
            {
                this.currentCommandIssuer.StartCommand -= CommandIssuer_StartCommand;
                this.currentCommandIssuer.PauseCommand -= CommandIssuer_PauseCommand;
                this.currentCommandIssuer.StopCommand -= CommandIssuer_StopCommand;
                this.currentCommandIssuer.ResetCommand -= CommandIssuer_ResetCommand;
                this.currentCommandIssuer.RefreshTimerDisplay -= CommandIssuer_RefreshTimerDisplay;
                this.currentCommandIssuer.SettingsChanged -= CommandIssuer_SettingsChanged;
            }
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

            if (this.CurrentTime == this.settings.AutoPauseTime && this.CurrentTime > 0)
            {
                this.PauseTimer();
            }
        }

        private void BlinkManager_Blink(object sender, EventArgs e)
        {
            this.lblTimer.ForeColor = this.blinkManager.BlinkOn ? this.settings.ExpiredColor : this.settings.BackgroundColor;
        }

        #endregion
    }*/
}
