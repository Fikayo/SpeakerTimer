namespace SpeakerTimer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class TimerSettingsForm : Form
    {
        private List<IdNamePair> selectedSettings;

        public TimerSettingsForm()
        {
            InitializeComponent();
            this.Text = Util.GetFormName("Timer Settings");

            this.selectedSettings = new List<IdNamePair>();
        }

        public Action SelectedAction { get; private set; }

        public IList<IdNamePair> TimerSettings
        {
            get { return this.selectedSettings; }

            set
            {
                this.clbTimerSettings.Items.Clear();
                IdNamePair[] array = new IdNamePair[value.Count];
                value.CopyTo(array, 0);
                this.clbTimerSettings.Items.AddRange(array);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.clbTimerSettings.CheckedItems.Count > 0)
            {
                foreach (var selection in this.clbTimerSettings.CheckedItems)
                {
                    this.selectedSettings.Add(selection as IdNamePair);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select at least one setting to open or delete.");
            }
        }

        private void rdbOpen_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectedAction = this.rdbOpen.Checked ? Action.Open : Action.Delete;
        }
        
        public enum Action
        {
            Open, Delete
        }
    }
}
