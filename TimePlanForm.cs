using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SpeakerTimer
{
    public partial class TimePlanForm : Form
    {
        private PresetManager presetManager;

        public TimePlanForm()
        {
            InitializeComponent();

            this.presetManager = new PresetManager();
            var settings = this.presetManager.LoadAll();
            if (settings != null)
            {
                foreach (var name in settings)
                {
                    this.checkedListBox1.Items.Add(name);
                }

                return;
            }
            else
            {
                MessageBox.Show("There was an error when trying to load pre-saved settings.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.timePlanView1.StartPlan();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.timePlanView1.StopCurrentTime();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.CheckedItems.Count > 0)
            {
                foreach (var selection in this.checkedListBox1.CheckedItems)
                {
                    this.timePlanView1.TimePlan.AddTimer(this.presetManager.LoadSetting(selection.ToString()));
                }
            }
            else
            {
                MessageBox.Show("Please select at least one setting to open or delete.");
            }
        }
    }
}
