namespace ChurchTimer.Application
{
    using System;

    public class TimerViewerCommandIssuer
    {
        public event EventHandler<CurrentTimeEventArgs> StartCommand;

        public event EventHandler PauseCommand;

        public event EventHandler StopCommand;

        public event EventHandler ResetCommand;

        public event EventHandler<CurrentTimeEventArgs> RefreshTimerDisplay;

        public event EventHandler<SettingsChangedEventArgs> TimerMessageChanged;

        public event EventHandler TimerMessageCancelled;

        public event EventHandler<SettingsChangedEventArgs> SettingsChanged;

        public event EventHandler<SettingsUpdatedEventArgs> SettingsUpdated;

        public void IssueStartCommand(double? currentTime = null)
        {
            var handler = this.StartCommand;
            if (handler != null)
            {
                handler.Invoke(this, new CurrentTimeEventArgs(currentTime));
            }
        }

        public void IssuePauseCommand()
        {
            var handler = this.PauseCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void IssueStopCommand()
        {
            var handler = this.StopCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void IssueResetCommand()
        {
            var handler = this.ResetCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
        
        public void CancelTimerMessage()
        {
            var handler = this.TimerMessageCancelled;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }        

        public void OnRefreshTimerDisplay(double? currentTime = null)
        {
            var handler = this.RefreshTimerDisplay;
            if (handler != null)
            {
                handler.Invoke(this, new CurrentTimeEventArgs(currentTime));
            }
        }

        ////public void OnSettingsChanged(SimpleTimerSettings settings)
        ////{
        ////    var handler = this.SettingsChanged;
        ////    if (handler != null)
        ////    {
        ////        handler.Invoke(this, new SettingsChangedEventArgs(settings));
        ////    }
        ////}

        public void OnSettingsUpdated(int timerId)
        {
            var handler = this.SettingsUpdated;
            if (handler != null)
            {
                handler.Invoke(this, new SettingsUpdatedEventArgs(timerId));
            }
        }

        public void OnTimerMessageChanged(TimerMessageSettings settings)
        {
            var handler = this.TimerMessageChanged;
            if (handler != null)
            {
                handler.Invoke(this, new SettingsChangedEventArgs(settings));
            }
        }
    }
}
