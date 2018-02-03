namespace ChurchTimer.Presentation
{
    using System;
    using System.Windows.Forms;
    using ChurchTimer.Application;

    public partial class PresentationTimerForm : Form
    {
        public const FormBorderStyle BorderStyle = FormBorderStyle.FixedSingle;

        public PresentationTimerForm() :
            this(new SimpleTimerView())
        {
        }

        public PresentationTimerForm(Control timeViewControl)
        {
            InitializeComponent();

            this.Text = Util.GetFormName("Display Window");

            this.TimeViewControl = timeViewControl;
            this.TimeViewControl.Dock = DockStyle.Fill;
            ////this.TimeViewControl.IsPreviewMode = false;
            this.TimeViewControl.Location = new System.Drawing.Point(0, 0);
            this.TimeViewControl.Name = "timerView";
            this.TimeViewControl.Size = new System.Drawing.Size(484, 249);
            this.TimeViewControl.TabIndex = 0;
            this.TimeViewControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timerView_KeyDown);
            this.Controls.Add(this.TimeViewControl);
        }

        public PresentationTimerForm(TimerViewerCommandIssuer commandIssuer)
            : this()
        {
            ////this.CommandIssuer = commandIssuer;
        }

        public event EventHandler WindowStateChanged;

        public bool IsFullScreen { get; private set; }

        public Control TimeViewControl { get; private set; }

        public TimerViewerCommandIssuer CommandIssuer
        {
            ////get { return this.TimeViewControl.CommandIssuer; }

            ////set { this.TimeViewControl.CommandIssuer = value; }

            get { return null; }
            set { }
        }

        public bool IsPreviewForm
        {
            get { return false; }
            ////get { return this.TimeViewControl.IsPreviewMode; }

            ////set
            ////{
            ////    this.TimeViewControl.IsPreviewMode = value;
            ////    this.MaximizeBox = !value;
            ////}
        }

        public void ToggleFullScreen()
        {
            if (this.IsFullScreen)
            {
                this.NormalWindowMode();
                return;
            }

            this.FullScreenWindow();
        }

        public void FullScreenWindow()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.IsFullScreen = true;
            this.OnWindowStateChanged();
        }

        public void NormalWindowMode()
        {
            this.FormBorderStyle = PresentationTimerForm.BorderStyle;
            this.WindowState = FormWindowState.Normal;
            this.IsFullScreen = false;
            this.OnWindowStateChanged();
        }

        public void CheckKeyPress(Keys key)
        {
            switch (key)
            {
                case Keys.Escape:
                    {
                        this.NormalWindowMode();
                        break;
                    }

                case Keys.F11:
                    {
                        this.ToggleFullScreen();
                        break;
                    }

                default:
                    break;
            }
        }

        private void OnWindowStateChanged()
        {
            var handler = this.WindowStateChanged;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }

        private void timerView_KeyDown(object sender, KeyEventArgs e)
        {
            if (!this.IsPreviewForm)
            {
                this.CheckKeyPress(e.KeyCode);
            }
        }
    }
}
