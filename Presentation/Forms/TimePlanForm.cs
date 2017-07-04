namespace ChurchTimer.Presentation
{
    using System;
    using System.Windows.Forms;
    using ChurchTimer.Application;

    public partial class TimePlanForm : Form
    {
        public TimePlanForm()
        {
            InitializeComponent(SettingsManager.SequenceSettingsManager);

            this.Text = Util.GetFormName("Time Plan");

            this.timePlanControl.IsLive = false;

            this.displayToolStripItem.FetchTimerView = this.CreateTimerView;

            this.savedTimersTSDDButton.Init();
        }

        private TimeViewControl CreateTimerView()
        {
            return new ChurchTimer.Presentation.TimePlanView();
        }

        private void HookPresentFormEvents()
        {
            this.displayToolStripItem.PresentForm.FormClosed += presentForm_FormClosed;
        }

        private void UnHookPresentFormEvents()
        {
            this.displayToolStripItem.PresentForm.FormClosed -= presentForm_FormClosed;
        }

        #region Event Handlers
        
        private void displayToolStripItem_PresentFormEventsRequired(object sender, EventArgs e)
        {
            this.HookPresentFormEvents();
        }

        private void displayToolStripItem_PresentFormEventsRemoved(object sender, EventArgs e)
        {
            this.UnHookPresentFormEvents();
        }
        
        private void savedTimersTSDDButton_TimersSettingsOpened(object sender, PresetEventArgs<SequenceTimerSettings> e)
        {
            ////if (e != null && e.Pairs != null)
            ////{
            ////    this.timePlanControl.OpenTimerSettings(e.Pairs);
            ////}
        }

        private void timePlanControl_LiveStateChanged(object sender, EventArgs e)
        {
            if (this.timePlanControl.IsLive)
            {
                this.displayToolStripItem.EnsureDisplayFormActive();

                this.displayToolStripItem.PresentForm.CommandIssuer = this.timePlanControl.CommandIssuer;
                this.displayToolStripItem.LivePreviewForm.CommandIssuer = this.timePlanControl.CommandIssuer;
                this.displayToolStripItem.TogglePresentationForm(true);
            }
            else
            {
                // We aren't live, so remove the presentation form
                if (this.displayToolStripItem.PresentForm != null)
                {
                    this.displayToolStripItem.PresentForm.Hide();
                }

                if (this.displayToolStripItem.LivePreviewForm != null)
                {
                    this.displayToolStripItem.LivePreviewForm.Hide();
                }
            }
        }
        
        private void presentForm_FormClosed(object sender, EventArgs e)
        {
            this.timePlanControl.IsLive = false;
        }

        #endregion
    }
}
