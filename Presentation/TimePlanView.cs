namespace SpeakerTimer.Presentation
{
    using System;
    using SpeakerTimer.Application;

    public partial class TimePlanView : TimeViewControl
    {
        private bool isPreview;
        private TimePlanCommandIssuer timePlanCommandIssuer;
        ////public TimerViewerCommandIssuer nextCommandIssuer;
        ////public TimerViewerCommandIssuer currentCommandIssuer;

        public TimePlanView()
        {
            this.InitializeComponent();

            this.TimePlan = new TimePlan();
            ////this.timePlanCommandIssuer.nextCommandIssuer = new TimerViewerCommandIssuer();
            ////this.timePlanCommandIssuer.currentCommandIssuer = new TimerViewerCommandIssuer();

            ////this.tmvCurrentTimer.CommandIssuer = this.timePlanCommandIssuer.currentCommandIssuer;
            ////this.tmvNextTimer.CommandIssuer = this.timePlanCommandIssuer.nextCommandIssuer;
            this.HookEventHandlers();
        }

        #region Properties

        public override TimerViewerCommandIssuer CommandIssuer
        {
            get { return this.timePlanCommandIssuer; }

            set
            {
                this.UnHookTimePlanCommandIssuerEventHandlers();
                this.timePlanCommandIssuer = value as TimePlanCommandIssuer;
                if (this.timePlanCommandIssuer != null)
                {
                    this.tmvCurrentTimer.CommandIssuer = this.timePlanCommandIssuer.CurrentTimerCommandIssuer;
                    this.tmvNextTimer.CommandIssuer = this.timePlanCommandIssuer.NextTimerCommandIssuer;
                    this.HookTimePlanCommandIssuerEventHandlers();
                }
            }
        }

        public override bool IsPreviewMode
        {
            get { return this.isPreview; }

            set
            {
                this.isPreview = value;
                this.tmvCurrentTimer.IsPreviewMode = isPreview;
                this.tmvNextTimer.IsPreviewMode = isPreview;
            }
        }

        public TimePlan TimePlan { get; private set; }

        public override TimerState TimerState { get { return this.tmvCurrentTimer.TimerState; } }

        public override double CurrentTime { get { return this.tmvCurrentTimer.CurrentTime; } }

        public override TimerViewSettings Settings { get { return this.tmvCurrentTimer.Settings; } }

        #endregion

        #region External Members

        public void StartPlan()
        {
            this.TimePlan.Advance();

            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.OnSettingsChanged(this.TimePlan.CurrentTimer);
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.OnRefreshTimerDisplay();

            var nextTimerSettings = this.TimePlan.NextTimer;
            if (nextTimerSettings != null)
            {
                this.timePlanCommandIssuer.NextTimerCommandIssuer.OnSettingsChanged(nextTimerSettings);
                this.timePlanCommandIssuer.NextTimerCommandIssuer.OnRefreshTimerDisplay();
            }

            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueStartCommand();
            this.LoadCurrentTimer();
        }

        public void AdvancePlan()
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueStopCommand();
            this.MoveToNextTimer();
            this.LoadCurrentTimer();
        }

        public void PausePlan()
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssuePauseCommand();
            this.timePlanCommandIssuer.NextTimerCommandIssuer.IssuePauseCommand();
        }

        public void ContinuePlan()
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueStartCommand();
            //this.timePlanCommandIssuer.currentCommandIssuer.IssueStartCommand();
        }

        public void StopPlan()
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueStopCommand();
            this.timePlanCommandIssuer.NextTimerCommandIssuer.IssueStopCommand();
        }

        public void ResetPlan()
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueResetCommand();
            this.timePlanCommandIssuer.NextTimerCommandIssuer.IssueResetCommand();
        }

        #endregion

        #region Internal Members

        private void HookEventHandlers()
        {
            this.tmvCurrentTimer.TimeExpired += tmvCurrentTimer_TimeExpired;
        }

        private void HookTimePlanCommandIssuerEventHandlers()
        {
            if (this.timePlanCommandIssuer != null)
            {
                this.timePlanCommandIssuer.StartCommand += TimePlanCommandIssuer_StartCommand;
                this.timePlanCommandIssuer.PauseCommand += TimePlanCommandIssuer_PauseCommand;
                this.timePlanCommandIssuer.ContinueCommand += TimePlanCommandIssuer_ContinueCommand;
                this.timePlanCommandIssuer.AdvanceCommand += TimePlanCommandIssuer_AdvanceCommand;
                this.timePlanCommandIssuer.StopCommand += TimePlanCommandIssuer_StopCommand;
                this.timePlanCommandIssuer.ResetCommand += TimePlanCommandIssuer_ResetCommand;
                this.timePlanCommandIssuer.ClearCommand += TimePlanCommandIssuer_ClearCommand;
                this.timePlanCommandIssuer.TimerAdded += TimePlanCommandIssuer_TimerAdded;
                this.timePlanCommandIssuer.SettingsChanged += TimePlanCommandIssuer_SettingsChanged;
            }
        }

        private void UnHookTimePlanCommandIssuerEventHandlers()
        {
            if (this.timePlanCommandIssuer != null)
            {
                this.timePlanCommandIssuer.StartCommand -= TimePlanCommandIssuer_StartCommand;
                this.timePlanCommandIssuer.PauseCommand -= TimePlanCommandIssuer_PauseCommand;
                this.timePlanCommandIssuer.ContinueCommand -= TimePlanCommandIssuer_ContinueCommand;
                this.timePlanCommandIssuer.AdvanceCommand -= TimePlanCommandIssuer_AdvanceCommand;
                this.timePlanCommandIssuer.StopCommand -= TimePlanCommandIssuer_StopCommand;
                this.timePlanCommandIssuer.ResetCommand -= TimePlanCommandIssuer_ResetCommand;
                this.timePlanCommandIssuer.ClearCommand -= TimePlanCommandIssuer_ClearCommand;
                this.timePlanCommandIssuer.TimerAdded -= TimePlanCommandIssuer_TimerAdded;
                this.timePlanCommandIssuer.SettingsChanged -= TimePlanCommandIssuer_SettingsChanged;
            }
        }

        private void MoveToNextTimer()
        {
            if (this.TimePlan.Advance())
            {
                // Pause next timer so we can perform the switch
                this.timePlanCommandIssuer.NextTimerCommandIssuer.IssuePauseCommand();
                var ongoingTime = this.tmvNextTimer.CurrentTime;

                this.timePlanCommandIssuer.CurrentTimerCommandIssuer.OnSettingsChanged(this.TimePlan.CurrentTimer);
                this.timePlanCommandIssuer.CurrentTimerCommandIssuer.OnRefreshTimerDisplay(ongoingTime);
                this.timePlanCommandIssuer.CurrentTimerCommandIssuer.IssueStartCommand(ongoingTime);

                var nextTimer = this.TimePlan.NextTimer;
                if (nextTimer != null)
                {
                    this.timePlanCommandIssuer.NextTimerCommandIssuer.OnSettingsChanged(nextTimer);
                    this.timePlanCommandIssuer.NextTimerCommandIssuer.OnRefreshTimerDisplay(nextTimer.Duration);
                }

                return;
            }
        }

        private void LoadCurrentTimer()
        {
            this.tlpOuterLayout.BackColor = this.TimePlan.CurrentTimer.VisualSettings.BackgroundColor;
        }

        #endregion

        #region Event Handlers

        private void tmvCurrentTimer_TimeExpired(object sender, EventArgs e)
        {
            this.timePlanCommandIssuer.NextTimerCommandIssuer.IssueStartCommand();
        }

        private void TimePlanCommandIssuer_StartCommand(object sender, CurrentTimeEventArgs e)
        {
            this.StartPlan();
        }

        private void TimePlanCommandIssuer_PauseCommand(object sender, EventArgs e)
        {
            this.PausePlan();
        }

        private void TimePlanCommandIssuer_ContinueCommand(object sender, EventArgs e)
        {
            this.ContinuePlan();
        }

        private void TimePlanCommandIssuer_AdvanceCommand(object sender, EventArgs e)
        {
            this.AdvancePlan();
        }

        private void TimePlanCommandIssuer_StopCommand(object sender, EventArgs e)
        {
            this.StopPlan();
        }

        private void TimePlanCommandIssuer_ResetCommand(object sender, EventArgs e)
        {
            this.ResetPlan();
        }

        private void TimePlanCommandIssuer_ClearCommand(object sender, EventArgs e)
        {
            this.TimePlan.ClearPlan();
        }

        private void TimePlanCommandIssuer_TimerAdded(object sender, SettingsChangedEventArgs e)
        {
            this.TimePlan.AddTimer(e.Settings);
        }

        private void TimePlanCommandIssuer_SettingsChanged(object sender, SettingsChangedEventArgs e)
        {
            this.timePlanCommandIssuer.CurrentTimerCommandIssuer.OnSettingsChanged(e.Settings);
            this.timePlanCommandIssuer.NextTimerCommandIssuer.OnSettingsChanged(e.Settings);
        }

        #endregion
    }
}
