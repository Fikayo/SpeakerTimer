namespace SpeakerTimer.Presentation
{
    partial class SavedTimersTSDDButton
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
            this.tsmOpenSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshList = new System.Windows.Forms.ToolStripMenuItem();
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
            // SavedTimersTSDDButton
            // 
            this.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpenSettings,
            this.tsmClearAll,
            this.tsmRefreshList});
            this.Size = new System.Drawing.Size(56, 27);
            this.Text = "Timers";

        }

        #endregion
        
        private System.Windows.Forms.ToolStripMenuItem tsmOpenSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmClearAll;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshList;
    }
}
