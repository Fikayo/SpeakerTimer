using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeakerTimer
{
    public class TimePlanCommandIssuer : TimerViewerCommandIssuer
    {
        public TimePlanCommandIssuer()
        {
            this.NextTimerCommandIssuer = new TimerViewerCommandIssuer();
            this.CurrentTimerCommandIssuer = new TimerViewerCommandIssuer();
        }

        public event EventHandler ContinueCommand;

        public event EventHandler AdvanceCommand;

        public event EventHandler ClearCommand;

        public event EventHandler<SettingsChangedEventArgs> TimerAdded;

        public TimerViewerCommandIssuer NextTimerCommandIssuer { get; private set; }
        public TimerViewerCommandIssuer CurrentTimerCommandIssuer { get; private set; }

        public void IssueContinueCommand()
        {
            var handler = this.ContinueCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void IssueAdvanceCommand()
        {
            var handler = this.AdvanceCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void IssueClearCommand()
        {
            var handler = this.ClearCommand;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        public void OnTimerAdded(TimerViewSettings timerSetting)
        {
            var handler = this.TimerAdded;
            if (handler != null)
            {
                handler.Invoke(this, new SettingsChangedEventArgs(timerSetting));
            }
        }
    }
}
