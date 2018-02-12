namespace ChurchTimer.Presentation.WPF.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using ChurchTimer.Application;
    using ChurchTimer.Application.Controllers;

    /// <summary>
    /// Interaction logic for BasicTimerView.xaml
    /// </summary>
    public partial class BasicTimerView : UserControl
    {
        private TimerViewController controller;

        public BasicTimerView(TimerViewController controller)
        {
            InitializeComponent();

            this.Controller = controller;

            this.ApplySettings(controller.Settings);
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
        
        public Brush TimerColor
        {
            get { return this.TimerLabel.Foreground; }

            set
            {
                this.TimerLabel.Foreground = value;
                this.lblTimerTitle.Foreground = value;
            }
        }

        public Brush BackgroundColor
        {
            get { return this.grdTimerBackground.Background; }

            set { this.grdTimerBackground.Background = value; }
        }
        
        public bool ShowLabel
        {
            get { return this.lblTimerTitle.IsVisible; }
            set { this.lblTimerTitle.Visibility = value ? Visibility.Visible : Visibility.Hidden; }
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

            this.TimerLabel.Content = display;
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
        
        private void ApplySettings(ChurchTimer.Application.SimpleTimerSettings settings)
        {
            this.Settings = settings;
            
            // Set fonts
            this.TimerLabel.FontFamily = new FontFamily(settings.VisualSettings.TimerFont.FontFamily.Name);
            this.TimerLabel.FontSize = settings.VisualSettings.TimerFont.Size;

            int labelSize = (int)Math.Max(settings.VisualSettings.TimerFont.Size / 3, 10);
            this.lblTimerTitle.FontFamily = new FontFamily(settings.VisualSettings.TimerFont.FontFamily.Name);
            this.lblTimerTitle.FontSize = labelSize;

            // Set background and forecround
            this.BackgroundColor = new SolidColorBrush(Util.ToMediaColor(settings.VisualSettings.BackgroundColor));
            this.TimerColor = new SolidColorBrush(Util.ToMediaColor(settings.VisualSettings.RunningColor));
                        
            // Set timer title
            this.lblTimerTitle.Content = this.Settings.TimerDuration.Title;
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
        

        ////private bool DisplayFinalMessage()
        ////{
        ////    if (!string.IsNullOrEmpty(this.Settings.FinalMessage))
        ////    {
        ////        this.TimerLabel.ForeColor = this.Settings.VisualSettings.MessageColor;
        ////        this.TimerLabel.Text = this.Settings.FinalMessage;
        ////        return true;
        ////    }

        ////    return false;
        ////}

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

        private void BasicTimerView_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(1000)));
            this.grdTimerBackground.BeginAnimation(OpacityProperty, doubleAnimation);
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
            if (this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(new Action(() => this.DisplayTimeElapsed(e.CurrentTime.Value)));
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
            if (this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(new Action(() => this.ApplySettings(e.Settings)));
                return;
            }

            this.ApplySettings(e.Settings);
        }

        #endregion
    }
}

