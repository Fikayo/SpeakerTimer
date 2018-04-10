namespace ChurchTimer.Application.Controllers
{
    using System;
    using System.Timers;
    using ChurchTimer.Application.Settings;
    using TheLiveTimer.Network;
    using TheLiveTimer.Server.Network;

    public class TimerViewController
    {
        private Timer timer;
        private Timer messageTimer;
        private bool blinkingEnabled;
        private SimpleTimerSettings settings;
        private double currentTimeInSeconds;

        private NetworkCommunicator commnicator;

        internal TimerViewController(NetworkCommunicator communicator)
        {
            this.commnicator = communicator;

            this.timer = new Timer(1000);
            this.timer.Elapsed += Timer_Elapsed;

            this.messageTimer = new Timer();
            this.messageTimer.Elapsed += MessageTimer_Elapsed;
            this.TimerState = TimerState.Stopped;
            this.Settings = new SimpleTimerSettings();
        }

        #region Events

        public event EventHandler TimerSecondElapsed;

        public event EventHandler<CurrentTimeEventArgs> TimeUpdated;

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler TimeExpired;

        public event EventHandler StartBlinking;

        public event EventHandler StopBlinking;

        public event EventHandler<BroadcastReadyEventArgs> BroadcastReady;

        public event EventHandler BroadcastOver;

        public event EventHandler<SettingsChangedEventArgs> SettingsUpdated;

        #endregion

        #region Properties

        public SimpleTimerSettings Settings
        {
            get { return this.settings; }

            set
            {
                this.settings = value;
                this.OnSettingsUpdated(this.settings);
            }
        }

        public TimerState TimerState { get; private set; }

        #endregion

        #region External Members

        public void StartTimer()
        {
            if (this.TimerState == TimerState.Stopped)
            {
                this.ResetTimer();
            }

            this.TimerState = TimerState.Running;

            this.timer.Start();
            this.OnTimeStartedAsync();
        }

        public void PauseTimer()
        {
            this.TimerState = TimerState.Paused;

            this.timer.Stop();
            this.OnTimePausedAsync();

            this.OnBlinkingStoppedAsync();
        }

        public void StopTimer()
        {
            this.TimerState = TimerState.Stopped;

            this.timer.Stop();
            Console.WriteLine("Time stopped. Timer.Enabled: {0}", this.timer.Enabled);
            this.OnTimeStoppedAsync();

            this.OnBlinkingStoppedAsync();
        }

        public void ResetTimer()
        {
            this.currentTimeInSeconds = this.Settings.DurationSettings.Duration;
            if (this.Settings.VisualSettings.CounterMode == TimerCounterMode.CountUp)
            {
                this.currentTimeInSeconds = 0;
            }

            this.OnTimeUpdatedAsync(this.currentTimeInSeconds);
        }

        public void PublishSettings()
        {
            this.OnSettingsUpdated(this.settings);
        }

        public void EnabledBlinking()
        {
            this.blinkingEnabled = true;
        }

        public void DisableBlinking()
        {
            this.blinkingEnabled = false;
            this.OnBlinkingStoppedAsync();
        }

        public void GoLive()
        {
            // When live, pause the timer, update the settings and then resume the timer
            var currentTimerState = this.TimerState;

            if (currentTimerState == TimerState.Running)
            {
                this.PauseTimer();
            }

            this.PublishSettings();

            if (currentTimerState == TimerState.Running)
            {
                this.StartTimer();
            }
            else if (currentTimerState == TimerState.Stopped)
            {
                this.StopTimer();
            }
        }
        
        public void BroadcastMessage(TimerMessageSettings message)
        {
            this.OnBroadcastReadyAsync(message);
            if (!message.IsIndefiniteMessage)
            {
                this.messageTimer.Interval += message.MessageDuration;
                this.messageTimer.Start();
            }
        }

        public void CancelMessage()
        {
            this.OnBroadcastOverAsync();
        }

        #endregion

        #region Internal Members

        #region Event Handlers

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.OnTimerSecondElapsed();
            var counterMode = this.Settings.VisualSettings.CounterMode;

            // Update the time
            if (counterMode == TimerCounterMode.CountUp)
            {
                this.currentTimeInSeconds++;
            }
            else
            {
                this.currentTimeInSeconds--;
            }

            Console.WriteLine("Time: {0}", this.currentTimeInSeconds);
            this.OnTimeUpdatedAsync(this.currentTimeInSeconds);

            // Check if time is up
            bool doneCountingUp = counterMode == TimerCounterMode.CountUp && this.currentTimeInSeconds >= this.Settings.DurationSettings.Duration;
            bool doneCountingDown = counterMode == TimerCounterMode.CountDownToZero && this.currentTimeInSeconds <= 0;
            if (doneCountingUp || doneCountingDown)
            {
                this.StopTimer();
            }

            if (this.currentTimeInSeconds < 0 && this.blinkingEnabled && this.settings.Metadata.BlinkingWhenExpired)
            {
                this.OnBlinkingStartedAsync();
            }
        }

        private void MessageTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.messageTimer.Stop();
            this.OnBroadcastOverAsync();
        }

        #endregion

        #region Event Triggers

        private void OnTimerSecondElapsed()
        {
            var handler = TimerSecondElapsed;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }
        }

        private void OnTimeUpdatedAsync(double time)
        {
            var handler = TimeUpdated;
            if (handler != null)
            {
                this.InvokeAsync(handler, new CurrentTimeEventArgs(time), null);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.TimeUpdated, time);
        }

        private void OnTimeStartedAsync()
        {
            var handler = this.TimeStarted;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.TimeStarted);
        }

        private void OnTimePausedAsync()
        {
            var handler = this.TimePaused;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.TimePaused);
        }

        private void OnTimeStoppedAsync()
        {
            var handler = this.TimeStopped;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.TimeStopped);
        }

        private void OnTimeExpiredAsync()
        {
            var handler = this.TimeExpired;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.TimeExpired);
        }

        private void OnBlinkingStartedAsync()
        {
            var handler = this.StartBlinking;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.StartBlinking);
        }

        private void OnBlinkingStoppedAsync()
        {
            var handler = this.StopBlinking;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, this.EndAsyncEvent);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.StopBlinking);
        }

        private void OnBroadcastReadyAsync(TimerMessageSettings message)
        {
            var handler = this.BroadcastReady;
            if (handler != null)
            {
                this.InvokeAsync(handler, new BroadcastReadyEventArgs(message), null);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.BroadcastReady, NetworkUtils.ObjectToByteArray(message.TimerMessage));
        }

        private void OnBroadcastOverAsync()
        {
            var handler = this.BroadcastOver;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty);
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.BroadcastOver);
        }

        private void OnSettingsUpdated(SimpleTimerSettings settings)
        {
            var handler = this.SettingsUpdated;
            if (handler != null)
            {
                handler.Invoke(this, new SettingsChangedEventArgs(settings));
            }

            this.commnicator.BroadcastCommand(TimerNetworkCommand.SettingsUpdated, NetworkUtils.ObjectToByteArray(settings.ToTransportString()));
        }

        private void InvokeAsync(EventHandler handler, EventArgs args, AsyncCallback callback = null)
        {
            var targets = handler.GetInvocationList();
            foreach (EventHandler h in targets)
            {
                h.BeginInvoke(this, args, callback, null);
            }
        }

        private void InvokeAsync<T>(EventHandler<T> handler, T args, AsyncCallback callback = null) where T : EventArgs
        {
            var targets = handler.GetInvocationList();
            foreach (EventHandler<T> h in targets)
            {
                h.BeginInvoke(this, args, callback, null);
            }
        }

        private void EndAsyncEvent(IAsyncResult iar)
        {
            var ar = (System.Runtime.Remoting.Messaging.AsyncResult)iar;
            var invokedMethod = (EventHandler)ar.AsyncDelegate;

            try
            {
                invokedMethod.EndInvoke(iar);
            }
            catch
            {
                // Handle any exceptions that were thrown by the invoked method
                Console.WriteLine("An event listener went kaboom!");
            }
        }

        #endregion

        #endregion
    }
}
