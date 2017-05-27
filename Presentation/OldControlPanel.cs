namespace SpeakerTimer.Presentation
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Resources;
	using System.Windows.Forms;
    using SpeakerTimer.Application;

    public partial class OldControlPanel : Form
    {
        private const string SavedTimersPath = @"..\..\SavedTimers\presets.csv";
        private static readonly ResourceManager rm = SpeakerTimer.Properties.Resources.ResourceManager;
        private static readonly Image PlayImage = (Bitmap)rm.GetObject("02_play-20");
        private static readonly Image PauseImage = (Bitmap)rm.GetObject("02_pause-20");

        private string warningInput;
        private string autoPauseInput;

        private bool running;
        private PresentationTimerForm timerForm;
        private TimerViewSettings settings;
        private TimerViewerCommandIssuer commandIssuer;

        private Dictionary<string, TimerViewSettings> savedSettings;

        public OldControlPanel()
        {
            InitializeComponent();
            new ControlPanel().Show();
            this.timerView.IsPreviewMode = true;

            this.settings = TimerViewSettings.Default;
            this.commandIssuer = new TimerViewerCommandIssuer();
            this.timerForm = new PresentationTimerForm(this.commandIssuer);
            this.timerView.CommandIssuer = this.commandIssuer;
            this.timerView.DurationChanged += (_, e) =>
            {
                this.settings.TimerDuration.Duration = e.Duration;
                this.OnSettingsChanged();
                this.commandIssuer.OnRefreshTimerDisplay();
            };

            this.Init();
            this.savedSettings = new Dictionary<string, TimerViewSettings>();
            this.LoadSavedTimers();
        }

        #region Internal Members

        private void Init()
        {
            this.running = false;
            this.cmbDisplayMode.DataSource = Enum.GetValues(typeof(TimerVisualSettings.TimerDisplayMode));
            this.cmbCounterMode.DataSource = Enum.GetValues(typeof(TimerVisualSettings.TimerCounterMode));
            this.cmbDisplayMode.Text = this.settings.VisualSettings.DisplayMode.ToString();
            this.cmbCounterMode.Text = this.settings.VisualSettings.CounterMode.ToString();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                this.cmbFontFace.Items.Add(font.Name);
            }

            this.cmbFontFace.Text = this.settings.VisualSettings.TimerFont.FontFamily.Name;
            this.numFontSize.Value = (decimal)this.settings.VisualSettings.TimerFont.Size;
            
            // Colors
            this.btnRunningColor.BackColor = this.settings.VisualSettings.RunningColor;
            this.btnPausedColor.BackColor = this.settings.VisualSettings.PausedColor;
            this.btnWarningColor.BackColor = this.settings.VisualSettings.WarningColor;
            this.btnExpiredColor.BackColor = this.settings.VisualSettings.ExpiredColor;
            this.btnStoppedColor.BackColor = this.settings.VisualSettings.StoppedColor;
            this.btnBackColor.BackColor = this.settings.VisualSettings.BackgroundColor;
            this.btnMessageColor.BackColor = this.settings.VisualSettings.MessageColor;

            // Special Times
            this.txtWarningTime.Text = TimeSpan.FromSeconds(this.settings.TimerDuration.WarningTime).ToString();
            this.txtAutoPauseTime.Text = TimeSpan.FromSeconds(this.settings.TimerDuration.SecondWarningTime).ToString();
        }

        private void SetPlayButton()
        {
            this.btnStart.Text = "Start";
            this.btnStart.Image = OldControlPanel.PlayImage;
            this.btnStart.ForeColor = Color.RoyalBlue;
            this.btnStart.BackColor = Color.Silver;
        }

        private Color PickColor()
        {
            this.colorDialog.ShowDialog();
            return this.colorDialog.Color;
        }

        private void LoadSavedTimers()
        {
            if (System.IO.File.Exists(OldControlPanel.SavedTimersPath))
            {
                var lines = System.IO.File.ReadAllLines(OldControlPanel.SavedTimersPath);

                foreach (var line in lines)
                {
                    var comma = line.IndexOf(',');
                    var name = line.Substring(0, comma);
                    var setting = line.Substring(comma + 1);
                    this.savedSettings.Add(name, TimerViewSettings.ParseCsv(setting));
                    this.cmbLoadTimer.Items.Add(name);
                }
            }
        }

        private void OnSettingsChanged()
        {
            this.commandIssuer.OnSettingsChanged(this.settings);
        }

        #endregion

        #region Event Handlers

        private void cmbDisplayMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settings.VisualSettings.DisplayMode = Util.ToEnum<TimerVisualSettings.TimerDisplayMode>(this.cmbDisplayMode.SelectedItem.ToString());
            if (!this.running)
            {
                this.commandIssuer.OnRefreshTimerDisplay();
            }

            this.OnSettingsChanged();
        }

        private void cmbCounterMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settings.VisualSettings.CounterMode = Util.ToEnum<TimerVisualSettings.TimerCounterMode>(this.cmbCounterMode.SelectedItem.ToString());
        }

        private void cmbFontFace_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.settings.SetFont(this.cmbFontFace.SelectedItem.ToString());
            this.OnSettingsChanged();
        }

        private void numFontSize_ValueChanged(object sender, EventArgs e)
        {
            this.settings.SetFont(string.Empty, (int)this.numFontSize.Value);
            this.OnSettingsChanged();
        }

        private void chkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.timerForm.TopMost = this.chkTopMost.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.running)
            {
                this.SetPlayButton();
                this.commandIssuer.IssuePauseCommand();
            }
            else
            {
                this.btnStart.Text = "Pause";
                this.btnStart.Image = OldControlPanel.PauseImage;
                this.btnStart.ForeColor = Color.Green;
                this.btnStart.BackColor = Color.LightCyan;
                this.commandIssuer.IssueStartCommand();
            }

            this.running = !this.running;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            this.SetPlayButton();
            this.commandIssuer.IssueStopCommand();
            this.running = false;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.commandIssuer.IssueResetCommand();
        }

        private void chkOpenViewForm_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOpenViewForm.Checked)
            {
                this.timerForm.Show();
            }
            else
            {
                this.timerForm.Hide();
            }
        }

        private void TxtFinalMessage_TextChanged(object sender, EventArgs e)
        {
            this.settings.FinalMessage = this.txtFinalMessage.Text;
            this.OnSettingsChanged();
        }

        private void btnRunningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnRunningColor.BackColor = color;
            this.settings.VisualSettings.RunningColor = color;
            this.OnSettingsChanged();
        }

        private void btnPausedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnPausedColor.BackColor = color;
            this.settings.VisualSettings.PausedColor = color;
            this.OnSettingsChanged();
        }

        private void btnWarningColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnWarningColor.BackColor = color;
            this.settings.VisualSettings.WarningColor = color;
            this.OnSettingsChanged();
        }

        private void btnExpiredColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnExpiredColor.BackColor = color;
            this.settings.VisualSettings.ExpiredColor = color;
            this.OnSettingsChanged();
        }

        private void btnStoppedColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnStoppedColor.BackColor = color;
            this.settings.VisualSettings.StoppedColor = color;
            this.OnSettingsChanged();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnBackColor.BackColor = color;
            this.settings.VisualSettings.BackgroundColor = color;
            this.OnSettingsChanged();
        }

        private void btnMessageColor_Click(object sender, EventArgs e)
        {
            var color = this.PickColor();
            this.btnMessageColor.BackColor = color;
            this.settings.VisualSettings.MessageColor = color;
            this.OnSettingsChanged();
        }

        private void txtWarningTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            // Only digits at this newLocation
            if (!char.IsControl(e.KeyChar))
            {
                warningInput = warningInput.TrimStart(new char[] { '0' });
                warningInput += e.KeyChar;
                warningInput = warningInput.PadLeft(6, '0');
                var dt = DateTime.ParseExact(string.Format("{0}:{1}:{2}", warningInput.Substring(0, 2), warningInput.Substring(2, 2), warningInput.Substring(4, 2)), "HH:mm:ss", CultureInfo.InvariantCulture);
                this.txtWarningTime.Text = dt.ToString("HH:mm:ss");
                e.Handled = true;
            }
        }

        private void txtAutoPauseTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsDigit(e.KeyChar) || char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;
                return;
            }

            // Only digits at this newLocation
            if (!char.IsControl(e.KeyChar))
            {
                autoPauseInput = autoPauseInput.TrimStart(new char[] { '0' });
                autoPauseInput += e.KeyChar;
                autoPauseInput = autoPauseInput.PadLeft(6, '0');
                var dt = DateTime.ParseExact(string.Format("{0}:{1}:{2}", autoPauseInput.Substring(0, 2), autoPauseInput.Substring(2, 2), autoPauseInput.Substring(4, 2)), "HH:mm:ss", CultureInfo.InvariantCulture);
                this.txtAutoPauseTime.Text = dt.ToString("HH:mm:ss");
                e.Handled = true;
            }
        }

        private void txtWarningTime_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.warningInput))
            {
                var dt = DateTime.ParseExact(this.txtWarningTime.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                this.settings.TimerDuration.WarningTime = dt.TimeOfDay.TotalSeconds;
            }
        }

        private void txtAutoPauseTime_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.autoPauseInput))
            {
                var dt = DateTime.ParseExact(this.txtAutoPauseTime.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
                this.settings.TimerDuration.SecondWarningTime = dt.TimeOfDay.TotalSeconds;
            }
        }

        private void txtWarningTime_Enter(object sender, EventArgs e)
        {
            this.warningInput = string.Empty;
        }

        private void txtAutoPauseTime_Enter(object sender, EventArgs e)
        {
            this.autoPauseInput = string.Empty;
        }

        private void cmbLoadTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetPlayButton();
            this.commandIssuer.IssueStopCommand();
            this.running = false;

            TimerViewSettings settings;
            if (this.savedSettings.TryGetValue(this.cmbLoadTimer.SelectedItem.ToString(), out settings))
            {
                this.settings = settings;
                this.OnSettingsChanged();
                this.Init();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
          

        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            this.settings = TimerViewSettings.Default;
            this.OnSettingsChanged();
            this.Init();
        }

        private void timeInputBox1_TimeChanged(object sender, EventArgs e)
        {
            this.label3.Text = this.timeInputBox1.InputTime.ToString();
        }

        #endregion

    }
}
