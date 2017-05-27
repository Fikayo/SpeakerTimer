namespace SpeakerTimer.Presentation
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class VisualSettingsForm : Form
    {
        public VisualSettingsForm(TimerVisualSettings visualSettings)
        {
            InitializeComponent();

            this.Text = Util.GetFormName("Visual Settings");

            this.VisualSettings = visualSettings;
            this.InitSettings();
        }

        public TimerVisualSettings VisualSettings { get; private set; }

        #region Internal Members

        private void InitSettings()
        {
            // Display Settings
            this.cmbDisplayMode.DataSource = Enum.GetValues(typeof(TimerVisualSettings.TimerDisplayMode));
            this.cmbCounterMode.DataSource = Enum.GetValues(typeof(TimerVisualSettings.TimerCounterMode));
            this.cmbDisplayMode.Text = this.VisualSettings.DisplayMode.ToString();
            this.cmbCounterMode.Text = this.VisualSettings.CounterMode.ToString();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                this.cmbFontFace.Items.Add(font.Name);
            }

            this.cmbFontFace.Text = this.VisualSettings.TimerFont.FontFamily.Name;
            this.numFontSize.Value = (decimal)this.VisualSettings.TimerFont.Size;

            // Colors
            this.btnRunningColor.BackColor = this.VisualSettings.RunningColor;
            this.btnPausedColor.BackColor = this.VisualSettings.PausedColor;
            this.btnWarningColor.BackColor = this.VisualSettings.WarningColor;
            this.btnExpiredColor.BackColor = this.VisualSettings.ExpiredColor;
            this.btnStoppedColor.BackColor = this.VisualSettings.StoppedColor;
            this.btnBackColor.BackColor = this.VisualSettings.BackgroundColor;
            this.btnMessageColor.BackColor = this.VisualSettings.SecondWarningColor;
        }
        
        private Color PickColor(Color defaultColor)
        {
            var result = this.colorDialog.ShowDialog();
            return result == DialogResult.OK ? this.colorDialog.Color : defaultColor;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void btnDefaultSettings_Click(object sender, EventArgs e)
        {
            this.VisualSettings = TimerVisualSettings.Default;
            this.InitSettings();
        }


        #region Display Settings Event Handlers

        private void cmbDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.VisualSettings.DisplayMode = Util.ToEnum<TimerVisualSettings.TimerDisplayMode>(this.cmbDisplayMode.SelectedItem.ToString());
            //if (!this.running)
            //{
            //    this.CommandIssuer.OnRefreshTimerDisplay();
            //}
        }

        private void cmbCounterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.VisualSettings.CounterMode = Util.ToEnum<TimerVisualSettings.TimerCounterMode>(this.cmbCounterMode.SelectedItem.ToString());
        }

        private void cmbFontFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.VisualSettings.SetFont(this.cmbFontFace.SelectedItem.ToString());
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            this.VisualSettings.SetFont(string.Empty, (int)this.numFontSize.Value);
        }

        #endregion

        #region Color Settings Event Handlers

        private void btnRunningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.RunningColor);
            this.btnRunningColor.BackColor = color;
            this.VisualSettings.RunningColor = color;
        }

        private void btnPausedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.PausedColor);
            this.btnPausedColor.BackColor = color;
            this.VisualSettings.PausedColor = color;
        }

        private void btnWarningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.WarningColor);
            this.btnWarningColor.BackColor = color;
            this.VisualSettings.WarningColor = color;
        }

        private void btnStoppedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.StoppedColor);
            this.btnStoppedColor.BackColor = color;
            this.VisualSettings.StoppedColor = color;
        }

        private void btnExpiredColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.ExpiredColor);
            this.btnExpiredColor.BackColor = color;
            this.VisualSettings.ExpiredColor = color;
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.BackgroundColor);
            this.btnBackColor.BackColor = color;
            this.VisualSettings.BackgroundColor = color;
        }

        private void btnMessageColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor(this.VisualSettings.MessageColor);
            this.btnMessageColor.BackColor = color;
            this.VisualSettings.MessageColor = color;
        }

        #endregion
    }
}
