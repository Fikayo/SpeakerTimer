namespace SpeakerTimer.Presentation
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Text;
	using System.Windows.Forms;
	using SpeakerTimer.Application;

    public partial class TimePlanForm : Form
    {
        public TimePlanForm()
        {
            InitializeComponent();

            this.timePlanControl.IsLive = false;

            this.ptsToolStrip.ShowTimePlanMenu = false;
            this.ptsToolStrip.Init();
        }

        private TimeViewControl CreateTimerView()
        {
            return new SpeakerTimer.Presentation.TimePlanView();
        }

        private void HookPresentFormEvents()
        {
            //this.ptsToolStrip.PresentForm.WindowStateChanged += presentForm_WindowStateChanged;
            this.ptsToolStrip.PresentForm.FormClosed += presentForm_FormClosed;
        }

        #region Event Handlers

        private void ptsToolStrip_PresentFormRequired(object sender, EventArgs e)
        {
            this.ptsToolStrip.PresentForm = null;
            this.ptsToolStrip.PresentForm = new PresentationTimerForm(this.CreateTimerView());
        }
        
        private void ptsToolStrip_PresentFormEventsRequired(object sender, EventArgs e)
        {
            this.HookPresentFormEvents();
        }

        private void ptsToolStrip_LivePreviewFormRequired(object sender, EventArgs e)
        {
            this.ptsToolStrip.LivePreviewForm = null;
            this.ptsToolStrip.LivePreviewForm = new PresentationTimerForm(this.CreateTimerView());
            this.ptsToolStrip.LivePreviewForm.Text = "Live Preview";
            this.ptsToolStrip.LivePreviewForm.IsPreviewForm = true;
            this.ptsToolStrip.LivePreviewForm.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        private void ptsToolStrip_TimersSettingsOpened(object sender, PresetEventArgs e)
        {
            if (e != null && e.Names != null)
            {
                this.timePlanControl.OpenTimerSettings(e.Names);
            }
        }

        private void timePlanControl_LiveStateChanged(object sender, EventArgs e)
        {
            if (this.timePlanControl.IsLive)
            {
                this.ptsToolStrip.EnsureDisplayFormActive();

                this.ptsToolStrip.PresentForm.CommandIssuer = this.timePlanControl.CommandIssuer;
                this.ptsToolStrip.LivePreviewForm.CommandIssuer = this.timePlanControl.CommandIssuer;
                this.ptsToolStrip.TogglePresentationForm(true);
            }
            else
            {
                // We aren't live, so remove the presentation form
                if (this.ptsToolStrip.PresentForm != null)
                {
                    this.ptsToolStrip.PresentForm.Hide();
                }

                if (this.ptsToolStrip.LivePreviewForm != null)
                {
                    this.ptsToolStrip.LivePreviewForm.Hide();
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
