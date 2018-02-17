namespace TheLiveTimer.Client
{
     using System;
    using Xamarin.Forms;

    internal class TimerPageViewModel : BaseViewModel
    {
        private string timer;
        private string message;
        private float timerTitleFontSize;
        private float messageFontSize;
        public bool isTimerVisible;
        public bool isTimerTitleVisible;
        public bool isBroadcastingMessage;
        public bool isBlinking;
        private Color timerColor;
        private ClientTimerController controller;

        private SimpleTimerSettings.SettingsMetaData settingsMeta;
        private TimerDurationSettings durationSettings;
        private TimerVisualSettings visualSettings;

        public TimerPageViewModel()
        {
            this.Settings = new SimpleTimerSettings();
            this.IsTimerVisible = true;
            this.IsBroadcastingMessage = false;
            this.DisplayTimeElapsed(0);
        }

        public TimerPageViewModel(ClientTimerController controller) : this()
        {
            this.Controller = controller;
        }

        #region Properties

        public SimpleTimerSettings.SettingsMetaData SettingsMetadata
        {
            get { return this.settingsMeta; }

            set
            {
                if (this.settingsMeta == null || !this.settingsMeta.Equals(value))
                {
                    this.settingsMeta = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public TimerDurationSettings DurationSettings
        {
            get { return this.durationSettings; }

            set
            {
                if (this.durationSettings == null || !this.durationSettings.Equals(value))
                {
                    this.durationSettings = value;
                    Console.WriteLine("value.FirstWarningTime: {0}; this.FirstWArning: {1}", value.FirstWarningTime, this.durationSettings.FirstWarningTime);
                    this.OnPropertyChanged();
                }
            }
        }

        public TimerVisualSettings VisualSettings
        {
            get { return visualSettings; }

            set
            {
                if (this.visualSettings == null || !this.visualSettings.Equals(value))
                {
                    this.visualSettings = value;

                    // Set what needs to be set
                    this.TimerColor = this.VisualSettings.RunningColor;
                    this.IsTimerTitleVisible = this.VisualSettings.ShowTimerTitle;
                    this.TimerTitleFontSize = Math.Max(this.VisualSettings.TimerFontSize / 3, 10);

                    this.OnPropertyChanged();
                }
            }
        }

        private SimpleTimerSettings Settings
        {
            set
            {
                if (value != null)
                {
                    this.SettingsMetadata = value.Metadata;
                    this.DurationSettings = value.DurationSettings;
                    this.VisualSettings = value.VisualSettings;
                }
                else
                {
                    this.SettingsMetadata = null;
                    this.DurationSettings = null;
                    this.VisualSettings = null;
                }
            }
        }

        public string Timer
        {
            get { return this.timer; }

            private set
            {
                if (this.timer != value)
                {
                    this.timer = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public string Message
        {
            get { return this.message; }

            set
            {
                if (this.message != value)
                {
                    this.message = value;
                    this.IsBroadcastingMessage = !string.IsNullOrEmpty(value);
                    this.OnPropertyChanged();
                }
            }
        }

        public float TimerTitleFontSize
        {
            get { return this.timerTitleFontSize; }

            set
            {
                if (this.timerTitleFontSize != value)
                {
                    this.timerTitleFontSize = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public float MessageFontSize
        {
            get { return this.messageFontSize; }

            set
            {
                if (this.messageFontSize != value)
                {
                    this.messageFontSize = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsBroadcastingMessage
        {
            get { return this.isBroadcastingMessage; }

            set
            {
                if (this.isBroadcastingMessage != value)
                {
                    this.isBroadcastingMessage = value;
                    this.IsTimerVisible = !this.IsBroadcastingMessage;
                    if (this.VisualSettings.ShowTimerTitle)
                    {
                        this.IsTimerTitleVisible = !this.isBroadcastingMessage;
                    }

                    Console.WriteLine("Broadcasting: {0}; timervisible: {1}", this.isBroadcastingMessage, this.isTimerVisible);

                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsTimerVisible
        {
            get { return this.isTimerVisible; }

            set
            {
                if (this.isTimerVisible != value)
                {
                    this.isTimerVisible = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsTimerTitleVisible
        {
            get
            {
                if (!this.VisualSettings.ShowTimerTitle)
                {
                    return false;
                }

                // If settings say to show, but the timer isn't visible - don't show
                if (!this.IsTimerVisible)
                {
                    return false;
                }

                // Otherwise use what you have
                return this.isTimerTitleVisible;
            }

            set
            {
                if (this.isTimerTitleVisible != value)
                {
                    this.isTimerTitleVisible = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public Color TimerColor
        {
            get { return this.timerColor; }

            set
            {
                if (this.timerColor != value)
                {
                    this.timerColor = value;
                    this.OnPropertyChanged();
                }
            }
        }

        public bool IsBlinking
        {
            get { return this.isBlinking; }

            set
            {
                if (this.isBlinking != value)
                {
                    this.isBlinking = value;
                    Console.WriteLine("is blinking: {0}", this.isBlinking);
                    OnPropertyChanged();
                }
            }
        }

        public ClientTimerController Controller
        {
            get { return this.controller; }

            set
            {
                this.UnHookControllerEventHandlers();
                this.controller = value;
                this.HookControllerEventHandlers();
            }
        }

        #endregion

        public void DisplayTimeElapsed(double counter)
        {
            string display = string.Empty;

            switch (this.VisualSettings.DisplayMode)
            {
                case TimerDisplayMode.DisplayInSeconds:
                    display = ((int)(counter)).ToString();
                    break;

                case TimerDisplayMode.SuppressLeadingZeros:
                    display = TimeSpan.FromSeconds(counter).ToString().TrimStart(new char[] { '0', ':' });
                    display = display.Length == 0 ? "0" : display;
                    break;

                case TimerDisplayMode.FullWidth:
                default:
                    display = TimeSpan.FromSeconds(counter).ToString();
                    break;
            }

            this.Timer = display;
        }

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
                this.controller.BroadcastOver += Controller_BroadcastOver;
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
                this.controller.StartBlinking -= Controller_StartBlinking;
                this.controller.StopBlinking -= Controller_StopBlinking;
                this.controller.BroadcastReady -= Controller_BroadcastReady;
                this.controller.BroadcastOver -= Controller_BroadcastOver;
            }
        }

        #region Event Handlers

        private void Controller_TimeStarted(object sender, EventArgs e)
        {
            // Indicate timer has started visually
            this.TimerColor = this.VisualSettings.RunningColor;
        }

        private void Controller_TimePaused(object sender, EventArgs e)
        {
            // Indicate timer is paused visually
            this.TimerColor = this.VisualSettings.PausedColor;
        }

        private void Controller_TimeStopped(object sender, EventArgs e)
        {
            // Indicate timer has stopped visually
            this.TimerColor = this.VisualSettings.StoppedColor;
        }

        private void Controller_StartBlinking(object sender, EventArgs e)
        {
            this.IsBlinking = true;
        }

        private void Controller_StopBlinking(object sender, EventArgs e)
        {
            this.IsBlinking = false;
        }

        private void Controller_TimeUpdated(object sender, CurrentTimeEventArgs e)
        {
            var time = e.CurrentTime.Value;
            this.DisplayTimeElapsed(time);

            if (this.DurationSettings.HasFirstWarning && time == this.DurationSettings.FirstWarningTime)
            {
                this.TimerColor = this.VisualSettings.FirstWarningColor;
            }

            if (this.DurationSettings.HasSecondWarning && time == this.DurationSettings.SecondWarningTime)
            {
                this.TimerColor = this.VisualSettings.SecondWarningColor;
            }

            if (time < 0)
            {
                this.TimerColor = this.VisualSettings.ExpiredColor;
            }
        }

        private void Controller_BroadcastReady(object sender, BroadcastReadyEventArgs e)
        {
            this.Message = e.Message.TimerMessage;
            this.MessageFontSize = e.Message.MessageFontSize;
        }

        private void Controller_BroadcastOver(object sender, EventArgs e)
        {
            this.Message = string.Empty;
        }

        #endregion
    }
}
