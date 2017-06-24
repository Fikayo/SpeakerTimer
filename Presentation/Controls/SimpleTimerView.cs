namespace SpeakerTimer.Presentation
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class SimpleTimerView : TimeViewControl
    {
        private const int PreviewFontSize = 30;
        private const int PreviewLabelSize = 10;

        private bool stopped;
        private Timer timer;
        private Timer messageTimer;

        private BlinkManager blinkManager;
        private TimeInputBox tibInput;
        private TimerViewerCommandIssuer commandIssuer;

        public SimpleTimerView()
        {
            InitializeComponent();

            this.blinkManager = new BlinkManager();
            this.blinkManager.Blink += BlinkManager_Blink;

            this.tibInput = new TimeInputBox();
            this.InitialiseTxtInput();

            this.timer = new Timer();
            this.timer.Interval = 1000;
            this.timer.Tick += Timer_Tick;

            this.messageTimer = new Timer();
            this.messageTimer.Tick += MessageTimer_Tick;

            this.ApplySettings(SimpleTimerSettings.Default);
            this.stopped = true;
            this.DisplayState = DisplayState.Timer;
            this.TimerState = TimerState.Stopped;

            this.SizeChanged += (_, __) => this.lblTimer.MaximumSize = new Size(this.Width, 0);
        }

        public SimpleTimerView(TimerViewerCommandIssuer commandIssuer)
            : this()
        {
            this.CommandIssuer = commandIssuer;
        }

        #region Events

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler TimeExpired;

        public event EventHandler DurationElapsed;

        public event EventHandler<DurationChangedEventArgs> DurationChanged;

        public event EventHandler MessageFinished;

        #endregion

        #region Properties

        public override TimerViewerCommandIssuer CommandIssuer
        {
            get { return this.commandIssuer; }

            set
            {
                this.UnHookCommandIssuerEventHandlers();
                this.commandIssuer = value;
                this.HookCommandIssuerEventHandlers();
            }
        }

        public new SimpleTimerSettings Settings { get; protected set; }

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
            get { return this.TimerLabel.ForeColor; }

            set
            {
                this.TimerLabel.ForeColor = value;
                this.lblTimerTitle.ForeColor = value;
            }
        }

        public Color BackgroundColor
        {
            get { return this.tlpOuterLayout.BackColor; }

            set { this.tlpOuterLayout.BackColor = value; }
        }

        public override bool IsPreviewMode
        {
            get { return this.TimerLabel.Cursor == Cursors.Hand; }

            set
            {
                var preview = value;
                this.TimerLabel.Cursor = preview ? Cursors.Hand : Cursors.Default;
            }
        }

        public int BlinkInterval
        {
            get { return this.blinkManager.Interval; }
            set { this.blinkManager.Interval = value; }
        }

        public bool ShowLabel
        {
            get { return this.lblTimerTitle.Visible; }
            set { this.lblTimerTitle.Visible = value; }
        }

        private Label TimerLabel
        {
            get
            {
                switch (this.DisplayState)
                {
                    case DisplayState.Message:
                        {
                            return this.lblMiniTimer;
                        }

                    default:
                    case DisplayState.Timer:
                        {

                            return this.lblTimer;
                        }
                }
            }
        }

        #endregion

        #region External Members

        public void StartTimer(bool forceCurrentTime = false)
        {
            if (this.stopped && !forceCurrentTime)
            {
                this.CurrentTime = this.Settings.TimerDuration.Duration;
                if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
                {
                    this.CurrentTime = 0;
                }
            }

            if (this.CurrentTime < 0 && this.Settings.BlinkOnExpired)
            {
                this.blinkManager.StartBlinking();
            }

            this.stopped = false;
            this.TimerState = TimerState.Running;
            this.DisplayTimeElapsed(this.CurrentTime);
            this.timer.Start();
            this.TimerColor = this.Settings.VisualSettings.RunningColor;
            this.OnTimeStarted();
        }

        public void PauseTimer()
        {
            this.blinkManager.StopBlinking();

            this.timer.Stop();
            this.TimerState = TimerState.Paused;
            this.TimerColor = this.Settings.VisualSettings.PausedColor;
            this.OnTimePaused();
        }

        public void StopTimer()
        {
            this.blinkManager.StopBlinking();

            this.timer.Stop();
            this.stopped = true;
            this.TimerState = TimerState.Stopped;
            this.TimerColor = this.Settings.VisualSettings.StoppedColor;
            this.OnTimeStopped();
        }

        public void ResetTimer()
        {
            this.timer.Stop();
            this.stopped = true;
            this.TimerState = TimerState.Stopped;
            this.DisplayTimeElapsed(this.Settings.TimerDuration.Duration);
        }

        public void DisplayTimeElapsed(double counter)
        {
            string display = string.Empty;

            switch (this.Settings.VisualSettings.DisplayMode)
            {
                case TimerVisualSettings.TimerDisplayMode.DisplayInSeconds:
                    display = ((int)(counter)).ToString();
                    break;

                case TimerVisualSettings.TimerDisplayMode.SuppressLeadingZeros:
                    display = TimeSpan.FromSeconds(counter).ToString().TrimStart(new char[] { '0', ':' });
                    display = display.Length == 0 ? "0" : display;
                    break;

                case TimerVisualSettings.TimerDisplayMode.FullWidth:
                default:
                    display = TimeSpan.FromSeconds(counter).ToString();
                    break;
            }

            this.TimerLabel.Text = display;
        }

        public void DisplayTimerMessage()
        {
            this.ShowLabel = false;
            this.lblTimer.Text = this.Settings.MessageSettings.TimerMessage;

            //var messageFont = new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, this.Settings.MessageSettings.MessageFontSize);
            //this.TimerFont = this.IsPreviewMode ? new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, TimerView.PreviewFontSize) : messageFont;
            
            if (this.IsPreviewMode)
            {
                this.TimerFont = new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, SimpleTimerView.PreviewFontSize);
            }
            else
            {
                this.TimerFont = this.Settings.VisualSettings.TimerFont;
                this.ScaleMessageFont(this.lblTimer);

            }

            this.lblMiniTimer.Visible = true;
            this.lblMiniTimer.ForeColor = this.Settings.VisualSettings.RunningColor;
            this.RefreshTimerDisplay(true);
        }

        #endregion

        #region Internal Members

        private void HookCommandIssuerEventHandlers()
        {
            if (this.commandIssuer != null)
            {
                this.commandIssuer.StartCommand += CommandIssuer_StartCommand;
                this.commandIssuer.PauseCommand += CommandIssuer_PauseCommand;
                this.commandIssuer.StopCommand += CommandIssuer_StopCommand;
                this.commandIssuer.ResetCommand += CommandIssuer_ResetCommand;
                this.commandIssuer.RefreshTimerDisplay += CommandIssuer_RefreshTimerDisplay;
                this.commandIssuer.TimerMessageChanged += CommandIssuer_TimerMessageChanged;
                this.commandIssuer.TimerMessageCancelled += CommandIssuer_TimerMessageCancelled;
                ////this.commandIssuer.SettingsChanged += CommandIssuer_SettingsChanged;
                this.commandIssuer.SettingsUpdated += CommandIssuer_SettingsUpdated;
            }
        }

        private void UnHookCommandIssuerEventHandlers()
        {
            if (this.commandIssuer != null)
            {
                this.commandIssuer.StartCommand -= CommandIssuer_StartCommand;
                this.commandIssuer.PauseCommand -= CommandIssuer_PauseCommand;
                this.commandIssuer.StopCommand -= CommandIssuer_StopCommand;
                this.commandIssuer.ResetCommand -= CommandIssuer_ResetCommand;
                this.commandIssuer.RefreshTimerDisplay -= CommandIssuer_RefreshTimerDisplay;
                this.commandIssuer.TimerMessageChanged -= CommandIssuer_TimerMessageChanged;
                this.commandIssuer.TimerMessageCancelled -= CommandIssuer_TimerMessageCancelled;
                ////this.commandIssuer.SettingsChanged -= CommandIssuer_SettingsChanged;
                this.commandIssuer.SettingsUpdated -= CommandIssuer_SettingsUpdated;
            }
        }

        private void InitialiseTxtInput()
        {
            this.tibInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tibInput.Enabled = false;
            this.tibInput.InputTime = 0D;
            this.tibInput.Size = new System.Drawing.Size(292, 85);
            this.tibInput.TabIndex = 1;
            this.tibInput.Text = "00:00:00";
            this.tibInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tibInput.Visible = false;
            this.tibInput.TimeChanged += this.txtInput_TimeChanged;
        }

        private void ApplySettings(SimpleTimerSettings settings)
        {
            this.TimerFont = this.IsPreviewMode ? new Font(settings.VisualSettings.TimerFont.FontFamily.Name, SimpleTimerView.PreviewFontSize) : settings.VisualSettings.TimerFont;
            int labelSize = this.IsPreviewMode ? SimpleTimerView.PreviewLabelSize : (int)Math.Max(settings.VisualSettings.TimerFont.Size / 3, 10);
            this.lblTimerTitle.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, labelSize);

            // Keep the mini timer the same size as the title
            this.lblMiniTimer.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, labelSize);

            this.BackgroundColor = settings.VisualSettings.BackgroundColor;
            this.TimerColor = settings.VisualSettings.RunningColor;

            this.Settings = settings;
            this.Settings.VisualSettings.SecondWarningColor = this.Settings.VisualSettings.MessageColor;

            if ((settings.BlinkOnExpired && this.Settings.TimerDuration.Duration >= 0) || (!settings.BlinkOnExpired && this.blinkManager.IsBlinking))
            {
                this.blinkManager.StopBlinking();
            }

            this.lblTimerTitle.Text = this.Settings.TimerDuration.Title;
            this.RefreshTimerDisplay();
        }

        private void ApplyMessageSettings(TimerMessageSettings messageSettings)
        {
            this.Settings.MessageSettings = messageSettings.Clone();
            if (this.DisplayState != DisplayState.Message)
            {
                this.DisplayState = DisplayState.Message;
                this.DisplayTimerMessage();

                if (!messageSettings.IsIndefiniteMessage)
                {
                    this.messageTimer.Interval = 1000;
                    this.messageTimer.Start();
                }
            }
        }

        private void CancelTimerMessage()
        {
            this.messageTimer.Stop();
            this.DisplayState = DisplayState.Timer;
            this.RefreshTimerDisplay(true);
            this.lblMiniTimer.Visible = false;
            this.ShowLabel = true;
            this.TimerFont = this.IsPreviewMode ? new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, SimpleTimerView.PreviewFontSize) : this.Settings.VisualSettings.TimerFont;

            this.OnMessageFinished();
        }

        private void ScaleMessageFont(Label lab)
        {
            this.SuspendLayout();

            ////Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            ////Graphics graphics = Graphics.FromImage(fakeImage);

            ////SizeF extent = graphics.MeasureString(lab.Text, lab.Font);

            int availableHeight = this.Height - this.lblMiniTimer.Height;
            while (lab.Height > availableHeight)
            {
                float ratio = lab.Height / availableHeight;
                if(ratio == 1)
                {
                    ratio = 1.1f;
                }
                
                float newSize = ratio != 0 ? (lab.Font.Size / ratio) : lab.Font.Size;

                lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
            }

            ////while (lab.Height > this.Height)
            ////{
            ////    lab.Font = new Font(lab.Font.FontFamily, lab.Font.Size - 2f, lab.Font.Style);
            ////}

            this.ResumeLayout();
        }

        private bool DisplayFinalMessage()
        {
            if (!string.IsNullOrEmpty(this.Settings.FinalMessage) && this.DisplayState == DisplayState.Timer)
            {
                this.TimerLabel.ForeColor = this.Settings.VisualSettings.MessageColor;
                this.TimerLabel.Text = this.Settings.FinalMessage;
                return true;
            }

            return false;
        }

        private void ShowInputBox()
        {
            this.TimerLabel.Visible = false;

            this.tibInput.Enabled = true;
            this.tibInput.Visible = true;
            this.tibInput.Font = this.TimerLabel.Font;
            if (this.Settings.VisualSettings.DisplayMode == TimerVisualSettings.TimerDisplayMode.FullWidth)
            {
                this.tibInput.Size = this.TimerLabel.Size;
            }

            this.tlpOuterLayout.Controls.Add(this.tibInput, 1, 2);

            this.tibInput.Focus();
        }

        private void HideInputBox()
        {
            this.tibInput.Enabled = false;
            this.tibInput.Visible = false;
            this.Settings.TimerDuration.Duration = this.tibInput.InputTime;

            this.TimerLabel.Visible = true;
            this.TimerLabel.Focus();
            this.tlpOuterLayout.Controls.Add(this.TimerLabel, 1, 2);
            this.DisplayTimeElapsed(this.Settings.TimerDuration.Duration);

            this.OnDurationChanged(this.Settings.TimerDuration.Duration);
        }

        private void RefreshTimerDisplay(bool forceCurrentTime = false)
        {
            var display = this.CurrentTime;
            if (this.stopped && !forceCurrentTime)
            {
                display = this.Settings.TimerDuration.Duration;
            }

            this.DisplayTimeElapsed(display);
        }

        private void FadeTimerColor(FadeItem init, FadeItem dest)
        {
            int fadeIndex = (int)(init.Time - this.CurrentTime);
            int steps = (int)(init.Time - dest.Time);
            if (fadeIndex < steps && steps > 1)
            {
                var oldR = init.Color.R;
                var oldG = init.Color.G;
                var oldB = init.Color.B;

                var newR = dest.Color.R;
                var newG = dest.Color.G;
                var newB = dest.Color.B;

                var r = oldR + ((fadeIndex * (newR - oldR)) / (steps - 1));
                var g = oldG + ((fadeIndex * (newG - oldG)) / (steps - 1));
                var b = oldB + ((fadeIndex * (newB - oldB)) / (steps - 1));

                this.TimerColor = Color.FromArgb(r, g, b);
            }
        }

        private void TimerTickState()
        {
            bool fade = false;
            FadeItem init = new FadeItem
            {
                Color = this.Settings.VisualSettings.RunningColor,
                Time = this.Settings.TimerDuration.Duration
            };

            FadeItem dest = new FadeItem
            {
                Color = default(Color),
                Time = default(int),
            };

            switch (this.TimerState)
            {
                case TimerState.Running:
                    {
                        if (this.Settings.TimerDuration.HasFirstWarning)
                        {
                            fade = true;
                            init.Color = this.Settings.VisualSettings.RunningColor;
                            init.Time = this.Settings.TimerDuration.Duration;
                            if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
                            {
                                init.Time = 0;
                            }

                            dest.Color = this.Settings.VisualSettings.WarningColor;
                            dest.Time = this.Settings.TimerDuration.WarningTime;
                        }

                        break;
                    }

                case TimerState.FirstWarning:
                    {

                        fade = true;
                        init.Color = this.Settings.VisualSettings.WarningColor;
                        init.Time = this.Settings.TimerDuration.WarningTime;

                        if (this.Settings.TimerDuration.HasSecondWarning)
                        {
                            dest.Color = this.Settings.VisualSettings.SecondWarningColor;
                            dest.Time = this.Settings.TimerDuration.SecondWarningTime;
                        }
                        else
                        {
                            dest.Color = this.Settings.VisualSettings.ExpiredColor;
                            dest.Time = 0;
                            if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
                            {
                                dest.Time = this.Settings.TimerDuration.Duration;
                            }
                        }

                        //					this.TimerColor = this.Settings.VisualSettings.WarningColor;
                        break;
                    }

                case TimerState.SecondWarning:
                    {
                        fade = true;
                        init.Color = this.Settings.VisualSettings.SecondWarningColor;
                        init.Time = this.Settings.TimerDuration.SecondWarningTime;

                        dest.Color = this.Settings.VisualSettings.ExpiredColor;
                        dest.Time = 0;
                        if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
                        {
                            dest.Time = this.Settings.TimerDuration.Duration;
                        }

                        //					this.TimerColor = this.Settings.VisualSettings.WarningColor;
                        break;
                    }

                case TimerState.Expired:
                    {
                        if (!this.Settings.BlinkOnExpired || !this.blinkManager.IsBlinking)
                        {
                            this.TimerColor = this.Settings.VisualSettings.ExpiredColor;
                        }

                        if (this.Settings.BlinkOnExpired)
                        {
                            if (!this.blinkManager.IsBlinking)
                            {
                                this.blinkManager.StartBlinking();
                                this.OnTimeExpired();
                            }
                        }
                        else
                        {
                            this.OnTimeExpired();
                        }

                        break;
                    }


                case TimerState.Stopped:
                    {
                        this.StopTimer();
                        if (!this.DisplayFinalMessage())
                        {
                            this.DisplayTimeElapsed(this.CurrentTime);
                        }

                        this.OnDurationElapsed();

                        break;
                    }

                default:
                    break;
            }

            if (fade)
            {
                this.FadeTimerColor(init, dest);
            }
        }

        #endregion

        #region Event Triggers

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

        private void OnDurationElapsed()
        {
            var handler = this.DurationElapsed;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnMessageFinished()
        {
            var handler = this.MessageFinished;
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
            if (this.IsPreviewMode && this.tibInput.Visible)
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

        private void CommandIssuer_TimerMessageChanged(object sender, SettingsChangedEventArgs e)
        {
            this.ApplyMessageSettings(e.MessageSettings);
        }

        private void CommandIssuer_TimerMessageCancelled(object sender, EventArgs e)
        {
            CancelTimerMessage();
        }

        private void CommandIssuer_SettingsChanged(object sender, SettingsChangedEventArgs e)
        {
            this.ApplySettings(e.Settings);
        }

        private void CommandIssuer_SettingsUpdated(object sender, SettingsUpdatedEventArgs e)
        {
            var timerSettings = SettingsManager<SimpleTimerSettings>.SimpleSettingsManager.Fetch(e.TimerId);
            this.ApplySettings(timerSettings);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //            this.TimerLabel.ForeColor = this.Settings.VisualSettings.RunningColor;
            //			this.FadeTimerColor ();
            this.TimerState = TimerState.Running;

            switch (this.Settings.VisualSettings.CounterMode)
            {
                case TimerVisualSettings.TimerCounterMode.CountUp:
                    this.CurrentTime++;
                    if (this.CurrentTime >= this.Settings.TimerDuration.Duration)
                    {
                        this.TimerState = TimerState.Stopped;
                    }

                    if (this.CurrentTime >= this.Settings.TimerDuration.WarningTime && this.Settings.TimerDuration.HasFirstWarning)
                    {
                        this.TimerState = TimerState.FirstWarning;
                    }

                    if (this.CurrentTime >= this.Settings.TimerDuration.SecondWarningTime && this.Settings.TimerDuration.HasSecondWarning)
                    {
                        this.TimerState = TimerState.SecondWarning;
                    }

                    break;

                case TimerVisualSettings.TimerCounterMode.CountDownToZero:
                    this.CurrentTime--;
                    if (this.CurrentTime <= 0)
                    {
                        this.TimerState = TimerState.Stopped;
                    }

                    if (this.CurrentTime <= this.Settings.TimerDuration.WarningTime && this.Settings.TimerDuration.HasFirstWarning)
                    {
                        this.TimerState = TimerState.FirstWarning;
                    }

                    if (this.CurrentTime <= this.Settings.TimerDuration.SecondWarningTime && this.Settings.TimerDuration.HasSecondWarning)
                    {
                        this.TimerState = TimerState.SecondWarning;
                    }

                    break;

                case TimerVisualSettings.TimerCounterMode.CountDownToMinus:
                default:
                    this.CurrentTime--;
                    if (this.CurrentTime <= this.Settings.TimerDuration.WarningTime && this.Settings.TimerDuration.HasFirstWarning)
                    {
                        this.TimerState = TimerState.FirstWarning;
                    }

                    if (this.CurrentTime <= this.Settings.TimerDuration.SecondWarningTime && this.Settings.TimerDuration.HasSecondWarning)
                    {
                        this.TimerState = TimerState.SecondWarning;
                    }

                    if (this.CurrentTime == 0)
                    {
                        this.OnDurationElapsed();
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

            this.TimerTickState();

            if (this.TimerState != TimerState.Stopped)
            {
                this.DisplayTimeElapsed(this.CurrentTime);
            }
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            this.Settings.MessageSettings.MessageDuration--;
            if (this.Settings.MessageSettings.MessageDuration <= 0)
            {
                CancelTimerMessage();
            }
        }

        private void BlinkManager_Blink(object sender, EventArgs e)
        {
            this.TimerLabel.ForeColor = this.blinkManager.BlinkOn ? this.Settings.VisualSettings.ExpiredColor : this.Settings.VisualSettings.BackgroundColor;
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
            if (this.IsPreviewMode && this.tibInput.Visible)
            {
                this.HideInputBox();
            }
        }

        private void txtInput_TimeChanged(object sender, EventArgs e)
        {
            if (this.IsPreviewMode && this.tibInput.Visible)
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

    public enum DisplayState
    {
        Timer, Message
    };
}
