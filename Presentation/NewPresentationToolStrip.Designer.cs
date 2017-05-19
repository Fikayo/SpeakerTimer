namespace SpeakerTimer.Presentation
{
    partial class NewPresentationToolStrip
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tslMainDisplay = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmShowDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLivePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepPreviewOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeDisplayScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshScreens = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaximizeDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveDisplayBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.tslTimers = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmOpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshList = new System.Windows.Forms.ToolStripMenuItem();
            this.tslMakeTimePlan = new System.Windows.Forms.ToolStripLabel();
            this.SuspendLayout();            
            // 
            // tsiMainDisplay
            // 
            this.tslMainDisplay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDisplay,
            this.tsmShowLivePreview,
            this.tsmKeepOnTop,
            this.tsmFullScreen,
            this.tsmChangeDisplayScreen,
            this.tsmMaximizeDisplay,
            this.tsmRemoveDisplayBorder});
            this.tslMainDisplay.Name = "tsiMainDisplay";
            this.tslMainDisplay.Size = new System.Drawing.Size(88, 27);
            this.tslMainDisplay.Text = "Main Display";
            // 
            // tsmShowDisplay
            // 
            this.tsmShowDisplay.Name = "tsmShowDisplay";
            this.tsmShowDisplay.Size = new System.Drawing.Size(228, 22);
            this.tsmShowDisplay.Text = "Show Display Window";
            this.tsmShowDisplay.Click += new System.EventHandler(this.tsmShowDisplay_Click);
            // 
            // tsmShowLivePreview
            // 
            this.tsmShowLivePreview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKeepPreviewOnTop});
            this.tsmShowLivePreview.Name = "tsmShowLivePreview";
            this.tsmShowLivePreview.Size = new System.Drawing.Size(228, 22);
            this.tsmShowLivePreview.Text = "Show Live Preview";
            this.tsmShowLivePreview.Click += new System.EventHandler(this.tsmShowLivePreview_Click);
            // 
            // tsmKeepPreviewOnTop
            // 
            this.tsmKeepPreviewOnTop.Name = "tsmKeepPreviewOnTop";
            this.tsmKeepPreviewOnTop.Size = new System.Drawing.Size(184, 22);
            this.tsmKeepPreviewOnTop.Text = "Keep Preview on Top";
            this.tsmKeepPreviewOnTop.Click += new System.EventHandler(this.tsmKeepPreviewOnTop_Click);
            // 
            // tsmKeepOnTop
            // 
            this.tsmKeepOnTop.Enabled = false;
            this.tsmKeepOnTop.Name = "tsmKeepOnTop";
            this.tsmKeepOnTop.Size = new System.Drawing.Size(228, 22);
            this.tsmKeepOnTop.Text = "Keep Display Window on Top";
            this.tsmKeepOnTop.Click += new System.EventHandler(this.tsmKeepOnTop_Click);
            // 
            // tsmFullScreen
            // 
            this.tsmFullScreen.Enabled = false;
            this.tsmFullScreen.Name = "tsmFullScreen";
            this.tsmFullScreen.Size = new System.Drawing.Size(228, 22);
            this.tsmFullScreen.Text = "Full Screen Display";
            this.tsmFullScreen.Click += new System.EventHandler(this.tsmFullScreen_Click);
            // 
            // tsmChangeDisplayScreen
            // 
            this.tsmChangeDisplayScreen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRefreshScreens});
            this.tsmChangeDisplayScreen.Enabled = false;
            this.tsmChangeDisplayScreen.Name = "tsmChangeDisplayScreen";
            this.tsmChangeDisplayScreen.Size = new System.Drawing.Size(228, 22);
            this.tsmChangeDisplayScreen.Text = "Change Display Screen";
            this.tsmChangeDisplayScreen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsmChangeDisplayScreen_DropDownItemClicked);
            // 
            // tsmRefreshScreens
            // 
            this.tsmRefreshScreens.Name = "tsmRefreshScreens";
            this.tsmRefreshScreens.Size = new System.Drawing.Size(156, 22);
            this.tsmRefreshScreens.Text = "Refresh Screens";
            this.tsmRefreshScreens.Click += new System.EventHandler(this.tsmRefreshScreens_Click);
            // 
            // tsmMaximizeDisplay
            // 
            this.tsmMaximizeDisplay.Enabled = false;
            this.tsmMaximizeDisplay.Name = "tsmMaximizeDisplay";
            this.tsmMaximizeDisplay.Size = new System.Drawing.Size(228, 22);
            this.tsmMaximizeDisplay.Text = "Maximize Display";
            this.tsmMaximizeDisplay.Click += new System.EventHandler(this.tsmMaximizeDisplay_Click);
            // 
            // tsmRemoveDisplayBorder
            // 
            this.tsmRemoveDisplayBorder.Enabled = false;
            this.tsmRemoveDisplayBorder.Name = "tsmRemoveDisplayBorder";
            this.tsmRemoveDisplayBorder.Size = new System.Drawing.Size(228, 22);
            this.tsmRemoveDisplayBorder.Text = "Remove Display Border";
            this.tsmRemoveDisplayBorder.Click += new System.EventHandler(this.tsmRemoveDisplayBorder_Click);
            // 
            // tslTimers
            // 
            this.tslTimers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenSettings,
            this.tsmClearAll,
            this.tsmRefreshList});
            this.tslTimers.Name = "tslTimers";
            this.tslTimers.Size = new System.Drawing.Size(56, 27);
            this.tslTimers.Text = "Timers";
            // 
            // tsmOpenSettings
            // 
            this.tsmOpenSettings.Name = "tsmOpenSettings";
            this.tsmOpenSettings.Size = new System.Drawing.Size(179, 22);
            this.tsmOpenSettings.Text = "Timer Settings";
            this.tsmOpenSettings.Click += new System.EventHandler(this.tsmOpenSettings_Click);
            // 
            // tsmClearAll
            // 
            this.tsmClearAll.Name = "tsmClearAll";
            this.tsmClearAll.Size = new System.Drawing.Size(179, 22);
            this.tsmClearAll.Text = "Clear All Settings";
            this.tsmClearAll.Click += new System.EventHandler(this.tsmClearAll_Click);
            // 
            // tsmRefreshList
            // 
            this.tsmRefreshList.Name = "tsmRefreshList";
            this.tsmRefreshList.Size = new System.Drawing.Size(179, 22);
            this.tsmRefreshList.Text = "Refresh Settings List";
            this.tsmRefreshList.Click += new System.EventHandler(this.tsmRefreshList_Click);
            // 
            // tslMakeTimePlan
            // 
            this.tslMakeTimePlan.Name = "tslMakeTimePlan";
            this.tslMakeTimePlan.Size = new System.Drawing.Size(92, 27);
            this.tslMakeTimePlan.Text = "Make Time Plan";
            this.tslMakeTimePlan.Click += new System.EventHandler(this.tslMakeTimePlan_Click);
            // 
            // NewPresetationToolStrip
            // 
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMainDisplay,
            this.tslTimers,
            this.tslMakeTimePlan});
            this.Name = "NewPresetationToolStrip";
            this.Size = new System.Drawing.Size(682, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripDropDownButton tslMainDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmShowDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLivePreview;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepPreviewOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmFullScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeDisplayScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshScreens;
        private System.Windows.Forms.ToolStripMenuItem tsmMaximizeDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveDisplayBorder;
        private System.Windows.Forms.ToolStripDropDownButton tslTimers;
        private System.Windows.Forms.ToolStripMenuItem tsmOpenSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshList;
        private System.Windows.Forms.ToolStripLabel tslMakeTimePlan;
    }
}
