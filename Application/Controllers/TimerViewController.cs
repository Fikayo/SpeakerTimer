namespace ChurchTimer.Application.Controllers
{
    using System;
    using System.Timers;

    public class TimerViewController
    {
        private Timer timer;
        private SimpleTimerSettings settings;
        private double currentTimeInSeconds;

        public TimerViewController()
        {
            this.timer = new Timer(1000);
            this.timer.Elapsed += Timer_Elapsed;

            this.TimerState = TimerState.Stopped;
        }

        #region Events

        public event EventHandler TimerSecondElapsed;

        public event EventHandler<CurrentTimeEventArgs> TimeUpdated;

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler TimeExpired;

        public event EventHandler<BroadcastReadyEventArgs> BroadcastReady;

        public event EventHandler<SettingsChangedEventArgs> SettingsUpdated;

        #endregion

        #region Properties

        public SimpleTimerSettings Settings {
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
            if(this.TimerState == TimerState.Stopped)
            {
                this.currentTimeInSeconds = this.Settings.TimerDuration.Duration;
                if (this.Settings.VisualSettings.CounterMode == TimerVisualSettings.TimerCounterMode.CountUp)
                {
                    this.currentTimeInSeconds = 0;
                }
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
        }

        public void StopTimer()
        {
            this.TimerState = TimerState.Stopped;

            this.timer.Stop();
            this.OnTimeStoppedAsync();
        }

        public void ResetTimer()
        {
            this.StopTimer();
        }

        public void GoLive()
        {
            // When live, pause the timer, update the settings and then resume the timer
            var currentTimerState = this.TimerState;

            this.PauseTimer();
            this.OnSettingsUpdated(this.settings);

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
            this.OnBroadcaseReadyAsync(message);
        }

        #endregion

        #region Internal Members
        
        #region Event Handlers

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.OnTimerSecondElapsed();
            var counterMode = this.Settings.VisualSettings.CounterMode;

            // Update the time
            if (counterMode == TimerVisualSettings.TimerCounterMode.CountUp)
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
            bool doneCountingUp = counterMode == TimerVisualSettings.TimerCounterMode.CountUp && this.currentTimeInSeconds >= this.Settings.TimerDuration.Duration;
            bool doneCountingDown = counterMode == TimerVisualSettings.TimerCounterMode.CountDownToMinus && this.currentTimeInSeconds <= 0;
            if (doneCountingUp || doneCountingDown)
            {
                this.StopTimer();
            }
        }
        
        #endregion

        #region Event Triggers

        private void OnTimerSecondElapsed()
        {
            var handler = TimerSecondElapsed;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, this.EndAsyncEvent, null);
            }
        }

        private void OnTimeUpdatedAsync(double time)
        {
            var handler = TimeUpdated;
            if (handler != null)
            {
                handler.BeginInvoke(this, new CurrentTimeEventArgs(time), null, null);
            }
        }

        private void OnTimeStartedAsync()
        {
            var handler = this.TimeStarted;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, this.EndAsyncEvent, null);
            }
        }

        private void OnTimePausedAsync()
        {
            var handler = this.TimePaused;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, this.EndAsyncEvent, null);
            }
        }

        private void OnTimeStoppedAsync()
        {
            var handler = this.TimeStopped;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, this.EndAsyncEvent, null);
            }
        }

        private void OnTimeExpiredAsync()
        {
            var handler = this.TimeExpired;
            if (handler != null)
            {
                handler.BeginInvoke(this, EventArgs.Empty, this.EndAsyncEvent, null);
            }
        }

        private void OnBroadcaseReadyAsync(TimerMessageSettings message)
        {
            var handler = this.BroadcastReady;
            if (handler != null)
            {
                handler.BeginInvoke(this, new BroadcastReadyEventArgs(message), null, null);
            }
        }

        private void OnSettingsUpdated(SimpleTimerSettings settings)
        {
            var handler = this.SettingsUpdated;
            if (handler != null)
            {
                handler.Invoke(this, new SettingsChangedEventArgs(settings));
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
