namespace TheLiveTimer.Client
{ 
    using System;

    internal class ClientTimerController
    {
        private double currentTime;

        public ClientTimerController()
        {
            this.TimerState = TimerState.Stopped;
        }

        #region Events

        public event EventHandler TimerSecondElapsed;

        public event EventHandler<CurrentTimeEventArgs> TimeUpdated;

        public event EventHandler TimeStarted;

        public event EventHandler TimePaused;

        public event EventHandler TimeStopped;

        public event EventHandler TimeReset;

        public event EventHandler TimeExpired;

        public event EventHandler StartBlinking;

        public event EventHandler StopBlinking;

        public event EventHandler<BroadcastReadyEventArgs> BroadcastReady;

        public event EventHandler BroadcastOver;

        public event EventHandler<SettingsChangedEventArgs> SettingsUpdated;

        #endregion

        #region Properties
        
        public TimerState TimerState { get; private set; }

        #endregion

        #region External Members

        public void StartTimer()
        {
            this.TimerState = TimerState.Running;
            this.OnTimeStartedAsync();
        }

        public void PauseTimer()
        {
            this.TimerState = TimerState.Paused;
            this.OnTimePausedAsync();
        }

        public void StopTimer()
        {
            this.TimerState = TimerState.Stopped;
            this.OnTimeStoppedAsync();
        }

        public void ResetTimer()
        {
            this.StopTimer();
            this.OnTimeResetAsync();
        }

        public void UpdateTime(double time)
        {
            this.currentTime = time;
            this.OnTimeUpdatedAsync(time);
        }
        
        public void ExpireTime()
        {
            this.OnTimeExpiredAsync();
        }

        public void UpdateSettings(SimpleTimerSettings settings)
        {
            this.OnSettingsUpdated(settings);
        }

        public void BroadcastMessage(string message)
        {
            this.OnBroadcastReadyAsync(message);
        }

        public void ClearBroadcast()
        {
            this.OnBroadcastOverAsync();
        }

        #endregion

        #region Internal Members

        #region Event Triggers

        private void OnTimerSecondElapsed()
        {
            var handler = TimerSecondElapsed;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnTimeUpdatedAsync(double time)
        {
            var handler = TimeUpdated;
            if (handler != null)
            {
                this.InvokeAsync(handler, new CurrentTimeEventArgs(time), null);
            }
        }

        private void OnTimeStartedAsync()
        {
            var handler = this.TimeStarted;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnTimePausedAsync()
        {
            var handler = this.TimePaused;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnTimeStoppedAsync()
        {
            var handler = this.TimeStopped;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnTimeResetAsync()
        {
            var handler = this.TimeReset;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnTimeExpiredAsync()
        {
            var handler = this.TimeExpired;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnBlinkingStartedAsync()
        {
            var handler = this.StartBlinking;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnBlinkingStoppedAsync()
        {
            var handler = this.StopBlinking;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty, null);
            }
        }

        private void OnBroadcastReadyAsync(string message)
        {
            var handler = this.BroadcastReady;
            if (handler != null)
            {
                this.InvokeAsync(handler, new BroadcastReadyEventArgs(message), null);
            }
        }

        private void OnBroadcastOverAsync()
        {
            var handler = this.BroadcastOver;
            if (handler != null)
            {
                this.InvokeAsync(handler, EventArgs.Empty);
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

        #endregion

        #endregion
    }
        
    public enum TimerState
    {
        Running, Paused, Stopped
    }
}
