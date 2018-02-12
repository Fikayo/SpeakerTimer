namespace ChurchTimer.Presentation
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using ChurchTimer.Application;
    using ChurchTimer.Application.Controllers;

    public partial class BasicTimerView : UserControl
    {
        private const int PreviewFontSize = 30;
        private const int PreviewLabelSize = 10;

        private bool stopped;
        private Timer messageTimer;

        private BlinkManager blinkManager;
        private TimeInputBox tibInput;
        private TimerViewController controller;

        public BasicTimerView(TimerViewController controller)
        {
            InitializeComponent();

            this.Controller = controller;
            this.blinkManager = new BlinkManager();
            this.blinkManager.Blink += BlinkManager_Blink;

            this.tibInput = new TimeInputBox();
            this.InitialiseTxtInput();

            this.messageTimer = new Timer();
            this.messageTimer.Tick += MessageTimer_Tick;

            this.stopped = true;
            this.ApplySettings(controller.Settings);
            this.SizeChanged += (_, __) => this.lblTimer.MaximumSize = new Size(this.Width - 30, 0);
        }
        
        #region Properties

        public TimerViewController Controller
        {
            get { return this.controller; }

            set
            {
                this.UnHookControllerEventHandlers();
                this.controller = value;
                this.HookControllerEventHandlers();
            }
        }

        public SimpleTimerSettings Settings { get; protected set; }

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
                return this.lblTimer;
            }
        }

        private bool IsPreviewMode { get { return false; } }

        #endregion

        #region External Members           

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

        #endregion

        #region Internal Members

        private void HookControllerEventHandlers()
        {
            if (this.controller != null)
            {
                this.controller.TimeStarted += Controller_TimeStarted;
                this.controller.TimePaused += Controller_TimePaused;
                this.controller.TimeStopped += Controller_TimeStopped;
                this.controller.TimeUpdated += Controller_TimeUpdated;
                this.controller.StartBlinking += Controller_StartBlinking;
                this.controller.StopBlinking += Controller_StopBlinking;
                this.controller.BroadcastReady += Controller_BroadcastReady;
                this.controller.SettingsUpdated += Controller_SettingsUpdated;
            }
        }

        private void UnHookControllerEventHandlers()
        {
            if (this.controller != null)
            {
                this.controller.TimeStarted -= Controller_TimeStarted;
                this.controller.TimePaused -= Controller_TimePaused;
                this.controller.TimeStopped -= Controller_TimeStopped;
                this.controller.TimeUpdated -= Controller_TimeUpdated;
                this.controller.BroadcastReady -= Controller_BroadcastReady;
                this.controller.SettingsUpdated -= Controller_SettingsUpdated;
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

        private void ApplySettings(ChurchTimer.Application.SimpleTimerSettings settings)
        {
            this.Settings = settings;

            this.SetFonts();

            ////this.TimerFont = this.IsPreviewMode ? new Font(settings.VisualSettings.TimerFont.FontFamily.Name, SimpleTimerView.PreviewFontSize) : settings.VisualSettings.TimerFont;
            ////int labelSize = this.IsPreviewMode ? SimpleTimerView.PreviewLabelSize : (int)Math.Max(settings.VisualSettings.TimerFont.Size / 3, 10);
            ////this.lblTimerTitle.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, labelSize);

            ////// Keep the mini timer the same size as the title
            ////this.lblMiniTimer.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, labelSize);

            this.BackgroundColor = settings.VisualSettings.BackgroundColor;
            this.TimerColor = settings.VisualSettings.RunningColor;

            this.Settings.VisualSettings.SecondWarningColor = this.Settings.VisualSettings.SecondWarningColor;

            if ((settings.BlinkOnExpired && this.Settings.TimerDuration.Duration >= 0) || (!settings.BlinkOnExpired && this.blinkManager.IsBlinking))
            {
                this.blinkManager.StopBlinking();
            }

            this.lblTimerTitle.Text = this.Settings.TimerDuration.Title;
        }
        
        private void SetFonts()
        {
            var settings = this.Settings;

            if (this.IsPreviewMode)
            {
                this.TimerFont = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, BasicTimerView.PreviewFontSize);
                this.lblTimerTitle.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, BasicTimerView.PreviewLabelSize);
            }
            else
            {
                this.TimerFont = settings.VisualSettings.TimerFont;

                int labelSize = (int)Math.Max(settings.VisualSettings.TimerFont.Size / 3, 10);
                this.lblTimerTitle.Font = new Font(settings.VisualSettings.TimerFont.FontFamily.Name, labelSize);
            }

            // Keep the mini timer the same size as the title
            this.lblMiniTimer.Font = this.lblTimerTitle.Font;
        }

        ////private void DisplayTimerMessage()
        ////{
        ////    this.ShowLabel = false;
        ////    this.lblTimer.Text = this.Settings.MessageSettings.TimerMessage;
        ////    this.lblTimer.ForeColor = this.Settings.VisualSettings.RunningColor;

        ////    //var messageFont = new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, this.Settings.MessageSettings.MessageFontSize);
        ////    //this.TimerFont = this.IsPreviewMode ? new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, TimerView.PreviewFontSize) : messageFont;

        ////    this.SetFonts();
        ////    if (!this.IsPreviewMode)
        ////    {
        ////        this.ScaleMessageFont(this.lblTimer);
        ////    }

        ////    this.lblMiniTimer.Visible = true;
        ////    this.lblMiniTimer.ForeColor = this.Settings.VisualSettings.RunningColor;
        ////    this.RefreshTimerDisplay(true);
        ////}

        ////private void CancelTimerMessage()
        ////{
        ////    this.messageTimer.Stop();
        ////    this.DisplayState = DisplayState.Timer;
        ////    this.RefreshTimerDisplay(true);
        ////    this.lblMiniTimer.Visible = false;
        ////    this.ShowLabel = true;
        ////    ////this.TimerFont = this.IsPreviewMode ? new Font(this.Settings.VisualSettings.TimerFont.FontFamily.Name, SimpleTimerView.PreviewFontSize) : this.Settings.VisualSettings.TimerFont;
        ////    this.lblTimer.ForeColor = this.TimerColor;
        ////    this.SetFonts();

        ////    this.OnMessageFinished();
        ////}

        private void ScaleMessageFont(Label lab)
        {
            this.SuspendLayout();

            ////Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            ////Graphics graphics = Graphics.FromImage(fakeImage);

            ////SizeF extent = graphics.MeasureString(lab.Text, lab.Font);

            int padding = 10;
            int availableHeight = this.Height - this.lblMiniTimer.Height - padding;
            while (lab.Height > availableHeight)
            {
                float ratio = lab.Height / availableHeight;
                if (ratio == 1)
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
            if (!string.IsNullOrEmpty(this.Settings.FinalMessage))
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

            ////this.OnDurationChanged(this.Settings.TimerDuration.Duration);
        }

        ////private void RefreshTimerDisplay(bool forceCurrentTime = false)
        ////{
        ////    var display = this.CurrentTime;
        ////    if (this.stopped && !forceCurrentTime)
        ////    {
        ////        display = this.Settings.TimerDuration.Duration;
        ////    }

        ////    this.DisplayTimeElapsed(display);
        ////}

        ////private void FadeTimerColor(FadeItem init, FadeItem dest)
        ////{
        ////    var current = new FadeItem() { Time = this.CurrentTime, Color = this.TimerColor };
        ////    ////this.TimerColor = ColorFader.Linear(init, dest, current);
        ////    this.TimerColor = ColorFader.BoundedExponential(init, dest, current);
        ////}

        private void TimerTickState()
        {
            ////bool fade = false;
            ////FadeItem init = new FadeItem
            ////{
            ////    Color = this.Settings.VisualSettings.RunningColor,
            ////    Time = this.Settings.TimerDuration.Duration
            ////};

            ////FadeItem dest = new FadeItem
            ////{
            ////    Color = default(Color),
            ////    Time = default(int),
            ////};

            ////switch (this.TimerState)
            ////{
            ////    case TimerState.Running:
            ////        {
            ////            if (this.Settings.TimerDuration.HasFirstWarning)
            ////            {
            ////                fade = true;
            ////                init.Color = this.Settings.VisualSettings.RunningColor;
            ////                init.Time = this.Settings.TimerDuration.Duration;
            ////                if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
            ////                {
            ////                    init.Time = 0;
            ////                }

            ////                dest.Color = this.Settings.VisualSettings.WarningColor;
            ////                dest.Time = this.Settings.TimerDuration.WarningTime;
            ////            }

            ////            break;
            ////        }

            ////    case TimerState.FirstWarning:
            ////        {

            ////            fade = true;
            ////            init.Color = this.Settings.VisualSettings.WarningColor;
            ////            init.Time = this.Settings.TimerDuration.WarningTime;

            ////            if (this.Settings.TimerDuration.HasSecondWarning)
            ////            {
            ////                dest.Color = this.Settings.VisualSettings.SecondWarningColor;
            ////                dest.Time = this.Settings.TimerDuration.SecondWarningTime;
            ////            }
            ////            else
            ////            {
            ////                dest.Color = this.Settings.VisualSettings.ExpiredColor;
            ////                dest.Time = 0;
            ////                if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
            ////                {
            ////                    dest.Time = this.Settings.TimerDuration.Duration;
            ////                }
            ////            }

            ////            //					this.TimerColor = this.Settings.VisualSettings.WarningColor;
            ////            break;
            ////        }

            ////    case TimerState.SecondWarning:
            ////        {
            ////            fade = true;
            ////            init.Color = this.Settings.VisualSettings.SecondWarningColor;
            ////            init.Time = this.Settings.TimerDuration.SecondWarningTime;

            ////            dest.Color = this.Settings.VisualSettings.ExpiredColor;
            ////            dest.Time = 0;
            ////            if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
            ////            {
            ////                dest.Time = this.Settings.TimerDuration.Duration;
            ////            }

            ////            //					this.TimerColor = this.Settings.VisualSettings.WarningColor;
            ////            break;
            ////        }

            ////    case TimerState.Expired:
            ////        {
            ////            if (!this.Settings.BlinkOnExpired || !this.blinkManager.IsBlinking)
            ////            {
            ////                this.TimerColor = this.Settings.VisualSettings.ExpiredColor;
            ////            }

            ////            if (this.Settings.BlinkOnExpired)
            ////            {
            ////                if (!this.blinkManager.IsBlinking)
            ////                {
            ////                    this.blinkManager.StartBlinking();
            ////                    this.OnTimeExpired();
            ////                }
            ////            }
            ////            else
            ////            {
            ////                this.OnTimeExpired();
            ////            }

            ////            break;
            ////        }


            ////    case TimerState.Stopped:
            ////        {
            ////            this.StopTimer();
            ////            if (!this.DisplayFinalMessage())
            ////            {
            ////                this.DisplayTimeElapsed(this.CurrentTime);
            ////            }

            ////            this.OnDurationElapsed();

            ////            break;
            ////        }

            ////    default:
            ////        break;
            ////}

            ////if (fade)
            ////{
            ////    this.FadeTimerColor(init, dest);
            ////}
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

        private void Controller_TimeStarted(object sender, EventArgs e)
        {
            // Indicate timer has started visually
        }

        private void Controller_TimePaused(object sender, EventArgs e)
        {
            // Indicate timer is paused visually
        }

        private void Controller_TimeStopped(object sender, EventArgs e)
        {
            // Indicate timer has stopped visually
        }

        private void Controller_StartBlinking(object sender, EventArgs e)
        {
        }

        private void Controller_StopBlinking(object sender, EventArgs e)
        {
        }

        private void Controller_TimeUpdated(object sender, ChurchTimer.Application.CurrentTimeEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.DisplayTimeElapsed(e.CurrentTime.Value)));
                return;
            }

            this.DisplayTimeElapsed(e.CurrentTime.Value);
        }

        private void Controller_BroadcastReady(object sender, ChurchTimer.Application.Controllers.BroadcastReadyEventArgs e)
        {
            //var timerSettings = SettingsManager.SimpleSettingsManager.Fetch(e.TimerId);
            //this.ApplySettings(timerSettings);
        }

        private void Controller_SettingsUpdated(object sender, ChurchTimer.Application.SettingsChangedEventArgs e)
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => this.ApplySettings(e.Settings)));
                return;
            }

            this.ApplySettings(e.Settings);
        }
        
        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            ////this.Settings.MessageSettings.MessageDuration--;
            ////if (this.Settings.MessageSettings.MessageDuration <= 0)
            ////{
            ////    CancelTimerMessage();
            ////}
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
}
