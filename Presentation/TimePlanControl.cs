namespace SpeakerTimer.Presentation
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	using SpeakerTimer.Application;

    public partial class TimePlanControl : UserControl
    {
        private const string FinalTimerButtonText = "Finish Plan";
        private const string NextTimerButtonText = "Next Timer";

        private bool running;
        private bool timePlanOver = true;
        private PresetManager presetManager;

        public TimePlanControl()
        {
            InitializeComponent();

            this.IsLive = false;
            this.btnNext.Text = TimePlanControl.NextTimerButtonText;
            this.CommandIssuer = new TimePlanCommandIssuer();
            this.TimePlanView.CommandIssuer = this.CommandIssuer;

            this.presetManager = new PresetManager();
            var settings = this.presetManager.LoadAll();
            if (settings != null)
            {
                foreach (var name in settings)
                {
                    this.clbAllTimers.Items.Add(name);
                }

                return;
            }
            else
            {
                MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public event EventHandler LiveStateChanged;

        public bool IsLive
        {
            get
            {
                return this.pcbLiveIndicator.Visible;
            }

            set
            {
                bool islive = value;
                this.pcbLiveIndicator.Visible = islive;
                this.rdbLive.Checked = islive;
                this.rdbLive.ForeColor = islive ? Color.Red : Color.Black;
            }
        }

        public TimePlanView TimePlanView
        {
            get { return this.tpvTimer; }
        }

        public TimePlanCommandIssuer CommandIssuer { get; private set; }

        public void OpenTimerSettings(List<string> timers)
        {
            for(int i = 0; i < this.clbAllTimers.Items.Count; i++)
            {
                this.clbAllTimers.SetItemChecked(0, false);
            }

            foreach(string timer in timers)
            {
                if (this.clbAllTimers.Items.Contains(timer))
                {
                    var index = this.clbAllTimers.FindStringExact(timer);
                    this.clbAllTimers.SetItemChecked(index, true);
                    this.AddTimer(timer);
                }
            }
        }

        #region Internal Members

        private void ResetPlayButton()
        {
            this.btnStart.Text = "Start";
            this.btnStart.Image = ControlPanel.PlayImage;
            this.btnStart.ForeColor = Color.RoyalBlue;
            this.btnStart.BackColor = Color.Silver;
            this.running = false;
        }

        private void ResetPausedButton()
        {
            this.btnStart.Text = "Pause";
            this.btnStart.Image = ControlPanel.PauseImage;
            this.btnStart.ForeColor = Color.Green;
            this.btnStart.BackColor = Color.LightCyan;
            this.running = true;
        }

        private void OnLiveStateChanged()
        {
            var handler = this.LiveStateChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void AddTimer(string timer)
        {
            ////this.TimePlanView.TimePlan.AddTimer(this.presetManager.LoadSetting(timer));
            this.CommandIssuer.OnTimerAdded(this.presetManager.LoadSetting(timer));
        }

        #endregion

        #region Event Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.timePlanOver)
            {
                ////this.TimePlanView.TimePlan.ClearPlan();
                this.CommandIssuer.IssueClearCommand();
            }

            if (this.clbAllTimers.CheckedItems.Count > 0)
            {
                foreach (var selection in this.clbAllTimers.CheckedItems)
                {
                    //this.TimePlanView.TimePlan.AddTimer(this.presetManager.LoadSetting(selection.ToString()));
                    this.AddTimer(selection.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select at least one setting to open or delete.");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.TimePlanView.TimePlan.PlanLength <= 0)
            {
                MessageBox.Show("Please add at least one timer to the time plan");
                return;
            }

            if (timePlanOver)
            {
                ////this.TimePlanView.StartPlan();
                this.CommandIssuer.IssueStartCommand();
                this.ResetPausedButton();
                timePlanOver = false;
                return;
            }

            if (this.running)
            {
                this.ResetPlayButton();
                ////this.TimePlanView.PausePlan();
                this.CommandIssuer.IssuePauseCommand();
            }
            else
            {
                this.ResetPausedButton();
                ////this.TimePlanView.ContinuePlan();
                this.CommandIssuer.IssueContinueCommand();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ////this.TimePlanView.AdvancePlan();
            this.CommandIssuer.IssueAdvanceCommand();
            if (this.TimePlanView.TimePlan.AtLastTimer)
            {
                this.btnNext.Text = FinalTimerButtonText;
                timePlanOver = true;
            }
            else
            {
                this.btnNext.Text = NextTimerButtonText;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.ResetPlayButton();
            this.CommandIssuer.IssueStopCommand();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.ResetPlayButton();
            this.CommandIssuer.IssueResetCommand();
        }

        private void rdbLive_Click(object sender, EventArgs e)
        {
            this.IsLive = !this.IsLive;

            var wasRunning = this.running;
            if (wasRunning)
            {
                // Pause an ongoing timer
                ////this.TimePlanView.PausePlan();
                this.CommandIssuer.IssuePauseCommand();
            }

            this.OnLiveStateChanged();
            if (this.IsLive)
            {
                ////this.OnSettingsChanged();
                if (!wasRunning)
                {
                    // Stop any previously running timer on the live screen
                    this.CommandIssuer.IssueStopCommand();
                }

                ////this.CommandIssuer.OnRefreshTimerDisplay(this.TimePlanView.TimePlan.CurrentTime);
            }

            if (wasRunning)
            {
                ////this.TimePlanView.ContinuePlan();
                this.CommandIssuer.IssueContinueCommand();
            }
        }

        #endregion
    }
}
