namespace ChurchTimer.Presentation
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Data;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
    using ChurchTimer.Application;

    public partial class TimeViewControl : UserControl
    {
        public TimeViewControl()
        {
            InitializeComponent();
        }

        public virtual TimerState TimerState { get; set; }

        protected virtual DisplayState DisplayState { get; set; }

        public virtual TimerViewerCommandIssuer CommandIssuer { get; set; }

        public virtual bool IsPreviewMode { get; set; }

        public virtual double CurrentTime { get; protected set; }

        public virtual TimerSettings Settings { get; protected set; }
    }
}
