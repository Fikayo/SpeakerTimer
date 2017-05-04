namespace SpeakerTimer.Presentation
{
    using System;
    using System.Drawing;
	using System.Windows.Forms;
	using SpeakerTimer.Application;

    public partial class TimerView : TimeViewControl
    {
        private const int PreviewFontSize = 30;
        private const int PreviewLabelSize = 10;

        private bool stopped;
        private Timer timer;

        private BlinkManager blinkManager;
        private TimeInputBox txtInput;
        private TimerViewSettings settings;
        private TimerViewerCommandIssuer commandIssuer;

        public TimerView()
        {
            InitializeComponent();

            this.txtInput = new TimeInputBox();
            this.InitialiseTxtInput();

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;
            this.settings = TimerViewSettings.Default;
            this.stopped = true;
			this.TimerState = TimerState.Stopped;

            this.blinkManager = new BlinkManager();
            this.blinkManager.Blink += BlinkManager_Blink;
        }

        public TimerView(TimerViewerCommandIssuer commandIssuer)
            : this()
        {
            this.CommandIssuer = commandIssuer;
        }

        #region Events

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler TimeExpired;

        public event EventHandler<DurationChangedEventArgs> DurationChanged;

        #endregion

        #region Properties

        public override TimerViewerCommandIssuer CommandIssuer
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

            set
            {
                var newFont = value;
                //this.lblCurrentTimer.Font = new Font(this.lblCurrentTimer.Font.FontFamily, newFont.Size / 2);
                //this.lblCurrentTimer.Font = newFont;
                this.lblTimer.Font = newFont;
            }
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
				
		public TimerState TimerState { get; set; }

        public Color BackgroundColor
        {
            get { return this.tlpOuterLayout.BackColor; }

            set { this.tlpOuterLayout.BackColor = value; }
        }

        public override bool IsPreviewMode
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

        public bool ShowLabel
        {
            get { return this.lblCurrentTimer.Visible; }
            set { this.lblCurrentTimer.Visible = value; }
        }

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

            if (this.CurrentTime < 0)
            {
                this.blinkManager.StartBlinking();
            }

			this.stopped = false;
			this.TimerState = TimerState.Running;
            this.DisplayTimeElapsed(this.CurrentTime);
            this.timer.Start();
            this.TimerColor = this.settings.RunningColor;
            this.OnTimeStarted();
        }

        public void PauseTimer()
        {
            this.blinkManager.StopBlinking();

            this.timer.Stop();
			this.TimerState = TimerState.Paused;
            this.TimerColor = this.settings.PausedColor;
            this.OnTimePaused();
        }

        public void StopTimer()
        {
            this.blinkManager.StopBlinking();

            this.timer.Stop();
            this.stopped = true;
			this.TimerState = TimerState.Stopped;
            this.TimerColor = this.settings.StoppedColor;
            this.OnTimeStopped();
        }

        public void ResetTimer()
        {
            this.timer.Stop();
			this.stopped = true;
			this.TimerState = TimerState.Stopped;
            this.DisplayTimeElapsed(this.settings.Duration);
        }

        public void ApplySettings(TimerViewSettings settings)
        {
            this.TimerFont = this.IsPreviewMode ? new Font(settings.TimerFont.FontFamily.Name, TimerView.PreviewFontSize) : settings.TimerFont;
            int labelSize = this.IsPreviewMode ? TimerView.PreviewLabelSize : (int)Math.Max(settings.TimerFont.Size / 3, 10);
            this.lblCurrentTimer.Font = new Font(settings.TimerFont.FontFamily.Name, labelSize);

            this.BackgroundColor = settings.BackgroundColor;
            this.TimerColor = settings.RunningColor;

            this.settings = TimerViewSettings.ParseCsv(settings.SaveSettingsAsCsv());
			this.settings.SecondWarningColor = this.settings.MessageColor;

			if (!settings.BlinkOnExpired && this.blinkManager.IsBlinking)
			{
				this.blinkManager.StopBlinking();
			}

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

            this.tlpOuterLayout.Controls.Add(this.txtInput, 1, 2);

            this.txtInput.Focus();
        }

        private void HideInputBox()
        {
            this.txtInput.Enabled = false;
            this.txtInput.Visible = false;
            this.settings.Duration = this.txtInput.InputTime;

            this.lblTimer.Visible = true;
            this.lblTimer.Focus();
            this.tlpOuterLayout.Controls.Add(this.lblTimer, 1, 2);
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

		private void FadeTimerColor(FadeItem init, FadeItem dest)
		{
			int fadeIndex = (int)(init.Time - this.CurrentTime);
			int steps = (int)(init.Time - dest.Time);
			if (fadeIndex < steps && steps > 1) {
				var oldR = init.Color.R;
				var oldG = init.Color.G;
				var oldB = init.Color.B;

				var newR = dest.Color.R;
				var newG = dest.Color.G;
				var newB = dest.Color.B;

				var r = oldR + ((fadeIndex * (newR - oldR)) / (steps - 1));
				var g = oldG + ((fadeIndex * (newG - oldG)) / (steps - 1));
				var b = oldB + ((fadeIndex * (newB - oldB)) / (steps - 1));

				this.TimerColor = Color.FromArgb (r, g, b);
			}
		}

		private void TimerTickState()
		{
			bool fade = false;
			FadeItem init = new FadeItem {
				Color = this.settings.RunningColor,
				Time = this.settings.Duration
			};

			FadeItem dest = new FadeItem {
				Color = default(Color),
				Time = default(int),
			};

			switch (this.TimerState) {
			case TimerState.Running:
				{
					if (this.settings.HasFirstWarning) 
					{
						fade = true;
						init.Color = this.settings.RunningColor;
						init.Time = this.settings.Duration;
						if (this.settings.CounterMode == TimerViewSettings.TimerCounterMode.CountUp) {
							init.Time = 0;
						}

						dest.Color = this.settings.WarningColor;
						dest.Time = this.settings.WarningTime;
					}

					break;
				}

			case TimerState.FirstWarning:
				{
				
					fade = true;
					init.Color = this.settings.WarningColor;
					init.Time = this.settings.WarningTime;

					if (this.settings.HasSecondWarning) {
						dest.Color = this.settings.SecondWarningColor;
						dest.Time = this.settings.SecondWarningTime;
					} else {
						dest.Color = this.settings.ExpiredColor;
						dest.Time = 0;	
						if (this.settings.CounterMode == TimerViewSettings.TimerCounterMode.CountUp) {
							dest.Time = this.settings.Duration;
						}
					}

//					this.TimerColor = this.settings.WarningColor;
					break;
				}

			case TimerState.SecondWarning:
				{
					fade = true;
					init.Color = this.settings.SecondWarningColor;
					init.Time = this.settings.SecondWarningTime;

					dest.Color = this.settings.ExpiredColor;
					dest.Time = 0;	
					if (this.settings.CounterMode == TimerViewSettings.TimerCounterMode.CountUp) {
						dest.Time = this.settings.Duration;
					}
					
//					this.TimerColor = this.settings.WarningColor;
					break;
				}

			case TimerState.Expired:
				{
					this.TimerColor = this.settings.ExpiredColor;
					if (this.settings.BlinkOnExpired) {
						if (!this.blinkManager.IsBlinking) {
							this.blinkManager.StartBlinking ();
							this.OnTimeExpired ();
						}
					} else {
						this.OnTimeExpired ();
					}

					break;
				}

				
			case TimerState.Stopped:
				{
					this.StopTimer ();
					if (!this.DisplayFinalMessage ()) {
						this.DisplayTimeElapsed (this.CurrentTime);
					}

					break;
				}

			default:
				break;
			}

			if (fade) 
			{
				this.FadeTimerColor (init, dest);
			}
		}

		#region Event Signals

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

        private void OnTimeExpired()
        {
            var handler = this.TimeExpired;
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
//            this.lblTimer.ForeColor = this.settings.RunningColor;
//			this.FadeTimerColor ();
			this.TimerState = TimerState.Running;

            switch (this.settings.CounterMode)
            {
                case TimerViewSettings.TimerCounterMode.CountUp:
                    this.CurrentTime++;
                    if (this.CurrentTime >= this.settings.Duration)
                    {
						this.TimerState = TimerState.Stopped;
                    }

                    if (this.CurrentTime >= this.settings.WarningTime && this.settings.HasFirstWarning)
                    {
						this.TimerState = TimerState.FirstWarning;
                    }

					if (this.CurrentTime >= this.settings.SecondWarningTime && this.settings.HasSecondWarning)
					{					
						this.TimerState = TimerState.SecondWarning;
					}

                    break;

                case TimerViewSettings.TimerCounterMode.CountDownToZero:
                    this.CurrentTime--;
                    if (this.CurrentTime <= 0)
                    {
						this.TimerState = TimerState.Stopped;
                    }

                    if (this.CurrentTime <= this.settings.WarningTime && this.settings.HasFirstWarning)
                    {					
						this.TimerState = TimerState.FirstWarning;
                    }

					if (this.CurrentTime <= this.settings.SecondWarningTime && this.settings.HasSecondWarning)
					{					
						this.TimerState = TimerState.SecondWarning;
					}

                    break;

                case TimerViewSettings.TimerCounterMode.CountDownToMinus:
                default:
                    this.CurrentTime--;
                    if (this.CurrentTime <= this.settings.WarningTime && this.settings.HasFirstWarning)
                    {
						this.TimerState = TimerState.FirstWarning;
                    }

					if (this.CurrentTime <= this.settings.SecondWarningTime && this.settings.HasSecondWarning)
					{					
						this.TimerState = TimerState.SecondWarning;
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
						this.TimerState = TimerState.Expired;
                    }

                    break;
            }

			this.TimerTickState ();

			if(this.TimerState != TimerState.Stopped)
			{
            	this.DisplayTimeElapsed(this.CurrentTime);
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

	public class FadeItem
	{
		public Color Color { get; set; }
		public double Time { get; set; }
	}

	public enum TimerState 
	{ 
		Running, Paused, FirstWarning, SecondWarning, Expired, Stopped 
	};
}
