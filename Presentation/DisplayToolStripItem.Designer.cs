namespace SpeakerTimer.Presentation
{
    partial class DisplayToolStripItem
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
            this.tsmShowDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmShowLivePreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepPreviewOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKeepOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmChangeDisplayScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshScreens = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMaximizeDisplay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemoveDisplayBorder = new System.Windows.Forms.ToolStripMenuItem();
            // 
            // tsmShowDisplay
            // 
            this.tsmShowDisplay.Name = "tsmShowDisplay";
            this.tsmShowDisplay.Size = new System.Drawing.Size(229, 22);
            this.tsmShowDisplay.Text = "Show Display Window";
            this.tsmShowDisplay.Click += new System.EventHandler(this.tsmShowDisplay_Click);
            // 
            // tsmShowLivePreview
            // 
            this.tsmShowLivePreview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKeepPreviewOnTop});
            this.tsmShowLivePreview.Name = "tsmShowLivePreview";
            this.tsmShowLivePreview.Size = new System.Drawing.Size(229, 22);
            this.tsmShowLivePreview.Text = "Show Live Preview";
            this.tsmShowLivePreview.Click += new System.EventHandler(this.tsmShowLivePreview_Click);
            // 
            // tsmKeepPreviewOnTop
            // 
            this.tsmKeepPreviewOnTop.Name = "tsmKeepPreviewOnTop";
            this.tsmKeepPreviewOnTop.Size = new System.Drawing.Size(185, 22);
            this.tsmKeepPreviewOnTop.Text = "Keep Preview on Top";
            this.tsmKeepPreviewOnTop.Click += new System.EventHandler(this.tsmKeepPreviewOnTop_Click);
            // 
            // tsmKeepOnTop
            // 
            this.tsmKeepOnTop.Enabled = false;
            this.tsmKeepOnTop.Name = "tsmKeepOnTop";
            this.tsmKeepOnTop.Size = new System.Drawing.Size(229, 22);
            this.tsmKeepOnTop.Text = "Keep Display Window on Top";
            this.tsmKeepOnTop.Click += new System.EventHandler(this.tsmKeepOnTop_Click);
            // 
            // tsmFullScreen
            // 
            this.tsmFullScreen.Enabled = false;
            this.tsmFullScreen.Name = "tsmFullScreen";
            this.tsmFullScreen.Size = new System.Drawing.Size(229, 22);
            this.tsmFullScreen.Text = "Full Screen Display";
            this.tsmFullScreen.Click += new System.EventHandler(this.tsmFullScreen_Click);
            // 
            // tsmChangeDisplayScreen
            // 
            this.tsmChangeDisplayScreen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmRefreshScreens});
            this.tsmChangeDisplayScreen.Enabled = false;
            this.tsmChangeDisplayScreen.Name = "tsmChangeDisplayScreen";
            this.tsmChangeDisplayScreen.Size = new System.Drawing.Size(229, 22);
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
            this.tsmMaximizeDisplay.Size = new System.Drawing.Size(229, 22);
            this.tsmMaximizeDisplay.Text = "Maximize Display";
            this.tsmMaximizeDisplay.Click += new System.EventHandler(this.tsmMaximizeDisplay_Click);
            // 
            // tsmRemoveDisplayBorder
            // 
            this.tsmRemoveDisplayBorder.Enabled = false;
            this.tsmRemoveDisplayBorder.Name = "tsmRemoveDisplayBorder";
            this.tsmRemoveDisplayBorder.Size = new System.Drawing.Size(229, 22);
            this.tsmRemoveDisplayBorder.Text = "Remove Display Border";
            this.tsmRemoveDisplayBorder.Click += new System.EventHandler(this.tsmRemoveDisplayBorder_Click);
            // 
            // DisplayToolStripItem
            // 
            this.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmShowDisplay,
            this.tsmShowLivePreview,
            this.tsmKeepOnTop,
            this.tsmFullScreen,
            this.tsmChangeDisplayScreen,
            this.tsmMaximizeDisplay,
            this.tsmRemoveDisplayBorder});
            this.Size = new System.Drawing.Size(88, 27);
            this.Text = "Main Display";

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmShowDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmShowLivePreview;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepPreviewOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmKeepOnTop;
        private System.Windows.Forms.ToolStripMenuItem tsmFullScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmChangeDisplayScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshScreens;
        private System.Windows.Forms.ToolStripMenuItem tsmMaximizeDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmRemoveDisplayBorder;
    }
}
