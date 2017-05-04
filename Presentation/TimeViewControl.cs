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

    public partial class TimeViewControl : UserControl
    {
        public TimeViewControl()
        {
            InitializeComponent();
        }

        public virtual TimerViewerCommandIssuer CommandIssuer { get; set; }

        public virtual bool IsPreviewMode { get; set; }
    }
}
