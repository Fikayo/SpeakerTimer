using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer
{
    public partial class TimePlanView : UserControl
    {
        public TimerViewerCommandIssuer nextCommandIssuer;
        public TimerViewerCommandIssuer currentCommandIssuer;

        public TimePlanView()
        {
            this.InitializeComponent();

            this.TimePlan = new TimePlan();
            this.nextCommandIssuer = new TimerViewerCommandIssuer();
            this.currentCommandIssuer = new TimerViewerCommandIssuer();

            this.tmvCurrentTimer.CommandIssuer = this.currentCommandIssuer;
            this.tmvNextTimer.CommandIssuer = this.nextCommandIssuer;
            this.HookEventHandlers();
        }

        public TimePlan TimePlan { get; private set; }
        
        public void StartPlan()
        {
            this.TimePlan.Advance();

            this.currentCommandIssuer.OnSettingsChanged(this.TimePlan.CurrentTimer);
            this.currentCommandIssuer.OnRefreshTimerDisplay();

            this.nextCommandIssuer.OnSettingsChanged(this.TimePlan.NextTimer);
            this.nextCommandIssuer.OnRefreshTimerDisplay();
            
            this.currentCommandIssuer.IssueStartCommand();
        }

        public void StopCurrentTime()
        {
            this.currentCommandIssuer.IssueStopCommand();
            this.MoveToNextTimer();
        }

        private void HookEventHandlers()
        {
            this.tmvCurrentTimer.TimeExpired += tmvCurrentTimer_TimeExpired;
        }

        private void MoveToNextTimer()
        {
            this.TimePlan.Advance();

            // Pause next timer so we can perform the switch
            this.nextCommandIssuer.IssuePauseCommand();
            var ongoingTime =this.tmvNextTimer.CurrentTime;

            this.currentCommandIssuer.OnSettingsChanged(this.TimePlan.CurrentTimer);
            this.currentCommandIssuer.OnRefreshTimerDisplay(ongoingTime);
            this.currentCommandIssuer.IssueStartCommand(ongoingTime);

            this.nextCommandIssuer.OnSettingsChanged(this.TimePlan.NextTimer);
            this.nextCommandIssuer.OnRefreshTimerDisplay(this.TimePlan.NextTimer.Duration);
        }

        private void tmvCurrentTimer_TimeExpired(object sender, EventArgs e)
        {
            this.nextCommandIssuer.IssueStartCommand();
        }
    }
}
