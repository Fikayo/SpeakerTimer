namespace SpeakerTimer
{
    partial class TimerPreview
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
            this.components = new System.ComponentModel.Container();
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpControlsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.flpIOayout = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpTimerNameLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTimerName = new System.Windows.Forms.Label();
            this.txtSettingsName = new System.Windows.Forms.TextBox();
            this.btnEditName = new System.Windows.Forms.Button();
            this.tlpTitleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tlpOpenLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbLoadTimer = new System.Windows.Forms.ComboBox();
            this.btnVisualSettings = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTimerControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tlpMessageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnShowMessage = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpMessageDurationLayout = new System.Windows.Forms.TableLayoutPanel();
            this.numMessageDuration = new System.Windows.Forms.NumericUpDown();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.chbIndefiniteMessageDuration = new System.Windows.Forms.CheckBox();
            this.txtShowMessage = new System.Windows.Forms.TextBox();
            this.lblMessageInfo = new System.Windows.Forms.Label();
            this.flpMainLeftLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.flpWarningTimesLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpFirstWarningLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtWarningTime = new SpeakerTimer.TimeInputBox();
            this.lblWarningTime = new System.Windows.Forms.Label();
            this.tlpSecondWarningLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecondWarningTime = new SpeakerTimer.TimeInputBox();
            this.tlpFinalMessageLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtFinalMessage = new System.Windows.Forms.TextBox();
            this.lblFinalMessage = new System.Windows.Forms.Label();
            this.tlpGoLiveLayout = new System.Windows.Forms.TableLayoutPanel();
            this.rdbLive = new System.Windows.Forms.RadioButton();
            this.pcbLiveIndicator = new System.Windows.Forms.PictureBox();
            this.chbBlink = new System.Windows.Forms.CheckBox();
            this.timerView = new SpeakerTimer.TimerView();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.grbPreviewBox = new System.Windows.Forms.GroupBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlpOuterLayout.SuspendLayout();
            this.tlpControlsLayout.SuspendLayout();
            this.flpIOayout.SuspendLayout();
            this.tlpTimerNameLayout.SuspendLayout();
            this.tlpTitleLayout.SuspendLayout();
            this.tlpOpenLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpMainLayout.SuspendLayout();
            this.tlpTimerControlLayout.SuspendLayout();
            this.tlpMessageLayout.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpMessageDurationLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMessageDuration)).BeginInit();
            this.flpMainLeftLayout.SuspendLayout();
            this.flpWarningTimesLayout.SuspendLayout();
            this.tlpFirstWarningLayout.SuspendLayout();
            this.tlpSecondWarningLayout.SuspendLayout();
            this.tlpFinalMessageLayout.SuspendLayout();
            this.tlpGoLiveLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLiveIndicator)).BeginInit();
            this.grbPreviewBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 2;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.Controls.Add(this.tlpControlsLayout, 1, 0);
            this.tlpOuterLayout.Controls.Add(this.timerView, 0, 0);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(3, 16);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 1;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(1005, 251);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // tlpControlsLayout
            // 
            this.tlpControlsLayout.AutoSize = true;
            this.tlpControlsLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpControlsLayout.ColumnCount = 1;
            this.tlpControlsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlsLayout.Controls.Add(this.flpIOayout, 0, 0);
            this.tlpControlsLayout.Controls.Add(this.tlpMainLayout, 0, 1);
            this.tlpControlsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpControlsLayout.Location = new System.Drawing.Point(278, 3);
            this.tlpControlsLayout.Name = "tlpControlsLayout";
            this.tlpControlsLayout.RowCount = 2;
            this.tlpControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpControlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpControlsLayout.Size = new System.Drawing.Size(724, 245);
            this.tlpControlsLayout.TabIndex = 1;
            // 
            // flpIOayout
            // 
            this.flpIOayout.AutoSize = true;
            this.flpIOayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpIOayout.Controls.Add(this.tlpTimerNameLayout);
            this.flpIOayout.Controls.Add(this.tlpTitleLayout);
            this.flpIOayout.Controls.Add(this.tlpOpenLayout);
            this.flpIOayout.Controls.Add(this.btnVisualSettings);
            this.flpIOayout.Controls.Add(this.btnSave);
            this.flpIOayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpIOayout.Location = new System.Drawing.Point(3, 3);
            this.flpIOayout.Name = "flpIOayout";
            this.flpIOayout.Size = new System.Drawing.Size(718, 65);
            this.flpIOayout.TabIndex = 4;
            // 
            // tlpTimerNameLayout
            // 
            this.tlpTimerNameLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTimerNameLayout.ColumnCount = 3;
            this.tlpTimerNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimerNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimerNameLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTimerNameLayout.Controls.Add(this.lblTimerName, 0, 0);
            this.tlpTimerNameLayout.Controls.Add(this.txtSettingsName, 1, 0);
            this.tlpTimerNameLayout.Controls.Add(this.btnEditName, 2, 0);
            this.tlpTimerNameLayout.Location = new System.Drawing.Point(3, 3);
            this.tlpTimerNameLayout.Name = "tlpTimerNameLayout";
            this.tlpTimerNameLayout.RowCount = 1;
            this.tlpTimerNameLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimerNameLayout.Size = new System.Drawing.Size(220, 28);
            this.tlpTimerNameLayout.TabIndex = 6;
            // 
            // lblTimerName
            // 
            this.lblTimerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerName.AutoSize = true;
            this.lblTimerName.Location = new System.Drawing.Point(3, 7);
            this.lblTimerName.Name = "lblTimerName";
            this.lblTimerName.Size = new System.Drawing.Size(35, 13);
            this.lblTimerName.TabIndex = 12;
            this.lblTimerName.Text = "Name";
            // 
            // txtSettingsName
            // 
            this.txtSettingsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsName.Enabled = false;
            this.txtSettingsName.Location = new System.Drawing.Point(44, 4);
            this.txtSettingsName.Name = "txtSettingsName";
            this.txtSettingsName.Size = new System.Drawing.Size(118, 20);
            this.txtSettingsName.TabIndex = 0;
            this.txtSettingsName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsName_KeyPress);
            // 
            // btnEditName
            // 
            this.btnEditName.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEditName.Location = new System.Drawing.Point(168, 3);
            this.btnEditName.Name = "btnEditName";
            this.btnEditName.Size = new System.Drawing.Size(49, 22);
            this.btnEditName.TabIndex = 13;
            this.btnEditName.Text = "Edit...";
            this.btnEditName.UseVisualStyleBackColor = false;
            this.btnEditName.Click += new System.EventHandler(this.btnEditName_Click);
            // 
            // tlpTitleLayout
            // 
            this.tlpTitleLayout.AutoSize = true;
            this.tlpTitleLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpTitleLayout.ColumnCount = 2;
            this.tlpTitleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTitleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitleLayout.Controls.Add(this.txtTitle, 1, 0);
            this.tlpTitleLayout.Controls.Add(this.lblTitle, 0, 0);
            this.tlpTitleLayout.Location = new System.Drawing.Point(229, 3);
            this.tlpTitleLayout.Name = "tlpTitleLayout";
            this.tlpTitleLayout.RowCount = 1;
            this.tlpTitleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTitleLayout.Size = new System.Drawing.Size(225, 26);
            this.tlpTitleLayout.TabIndex = 12;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(65, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(157, 20);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(56, 13);
            this.lblTitle.TabIndex = 15;
            this.lblTitle.Text = "Timer Title";
            // 
            // tlpOpenLayout
            // 
            this.tlpOpenLayout.AutoSize = true;
            this.tlpOpenLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpOpenLayout.ColumnCount = 2;
            this.tlpOpenLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpOpenLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOpenLayout.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpOpenLayout.Controls.Add(this.cmbLoadTimer, 1, 0);
            this.tlpOpenLayout.Location = new System.Drawing.Point(460, 3);
            this.tlpOpenLayout.Name = "tlpOpenLayout";
            this.tlpOpenLayout.RowCount = 1;
            this.tlpOpenLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOpenLayout.Size = new System.Drawing.Size(210, 28);
            this.tlpOpenLayout.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SpeakerTimer.Properties.Resources._1494315729_10_Folder;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // cmbLoadTimer
            // 
            this.cmbLoadTimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLoadTimer.FormattingEnabled = true;
            this.cmbLoadTimer.Location = new System.Drawing.Point(38, 3);
            this.cmbLoadTimer.Name = "cmbLoadTimer";
            this.cmbLoadTimer.Size = new System.Drawing.Size(169, 21);
            this.cmbLoadTimer.TabIndex = 1;
            this.cmbLoadTimer.SelectedIndexChanged += new System.EventHandler(this.cmbLoadTimer_SelectedIndexChanged);
            // 
            // btnVisualSettings
            // 
            this.btnVisualSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnVisualSettings.BackgroundImage = global::SpeakerTimer.Properties.Resources.settings;
            this.btnVisualSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnVisualSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisualSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVisualSettings.ForeColor = System.Drawing.SystemColors.Control;
            this.btnVisualSettings.Location = new System.Drawing.Point(676, 3);
            this.btnVisualSettings.Name = "btnVisualSettings";
            this.btnVisualSettings.Size = new System.Drawing.Size(33, 27);
            this.btnVisualSettings.TabIndex = 1;
            this.btnVisualSettings.UseVisualStyleBackColor = false;
            this.btnVisualSettings.Click += new System.EventHandler(this.btnVisualSettings_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.Location = new System.Drawing.Point(3, 37);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpMainLayout
            // 
            this.tlpMainLayout.AutoSize = true;
            this.tlpMainLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMainLayout.ColumnCount = 3;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMainLayout.Controls.Add(this.tlpTimerControlLayout, 0, 0);
            this.tlpMainLayout.Controls.Add(this.tlpMessageLayout, 2, 0);
            this.tlpMainLayout.Controls.Add(this.flpMainLeftLayout, 1, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(3, 74);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.Size = new System.Drawing.Size(718, 168);
            this.tlpMainLayout.TabIndex = 1;
            // 
            // tlpTimerControlLayout
            // 
            this.tlpTimerControlLayout.ColumnCount = 1;
            this.tlpTimerControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimerControlLayout.Controls.Add(this.btnStart, 0, 1);
            this.tlpTimerControlLayout.Controls.Add(this.btnStop, 0, 2);
            this.tlpTimerControlLayout.Controls.Add(this.btnReset, 0, 3);
            this.tlpTimerControlLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTimerControlLayout.Location = new System.Drawing.Point(3, 3);
            this.tlpTimerControlLayout.Name = "tlpTimerControlLayout";
            this.tlpTimerControlLayout.RowCount = 5;
            this.tlpTimerControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTimerControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimerControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimerControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpTimerControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTimerControlLayout.Size = new System.Drawing.Size(26, 162);
            this.tlpTimerControlLayout.TabIndex = 4;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStart.Image = global::SpeakerTimer.Properties.Resources.play;
            this.btnStart.Location = new System.Drawing.Point(3, 34);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(20, 27);
            this.btnStart.TabIndex = 1;
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStop.Image = global::SpeakerTimer.Properties.Resources.stop_sm1;
            this.btnStop.Location = new System.Drawing.Point(3, 67);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(20, 27);
            this.btnStop.TabIndex = 2;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Transparent;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.Control;
            this.btnReset.Image = global::SpeakerTimer.Properties.Resources.refresh;
            this.btnReset.Location = new System.Drawing.Point(3, 100);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(20, 27);
            this.btnReset.TabIndex = 3;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tlpMessageLayout
            // 
            this.tlpMessageLayout.ColumnCount = 3;
            this.tlpMessageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpMessageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpMessageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMessageLayout.Controls.Add(this.btnShowMessage, 2, 1);
            this.tlpMessageLayout.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tlpMessageLayout.Controls.Add(this.lblMessageInfo, 0, 1);
            this.tlpMessageLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMessageLayout.Location = new System.Drawing.Point(291, 3);
            this.tlpMessageLayout.Name = "tlpMessageLayout";
            this.tlpMessageLayout.RowCount = 3;
            this.tlpMessageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMessageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMessageLayout.Size = new System.Drawing.Size(424, 162);
            this.tlpMessageLayout.TabIndex = 3;
            // 
            // btnShowMessage
            // 
            this.btnShowMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowMessage.AutoSize = true;
            this.btnShowMessage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnShowMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMessage.Location = new System.Drawing.Point(328, 68);
            this.btnShowMessage.Name = "btnShowMessage";
            this.btnShowMessage.Size = new System.Drawing.Size(93, 25);
            this.btnShowMessage.TabIndex = 4;
            this.btnShowMessage.Text = "Show Message";
            this.btnShowMessage.UseVisualStyleBackColor = true;
            this.btnShowMessage.Click += new System.EventHandler(this.btnShowMessage_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tlpMessageDurationLayout, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtShowMessage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(100, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(222, 156);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tlpMessageDurationLayout
            // 
            this.tlpMessageDurationLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMessageDurationLayout.AutoSize = true;
            this.tlpMessageDurationLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpMessageDurationLayout.ColumnCount = 4;
            this.tlpMessageDurationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMessageDurationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMessageDurationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpMessageDurationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMessageDurationLayout.Controls.Add(this.numMessageDuration, 0, 0);
            this.tlpMessageDurationLayout.Controls.Add(this.lblSeconds, 1, 0);
            this.tlpMessageDurationLayout.Controls.Add(this.chbIndefiniteMessageDuration, 3, 0);
            this.tlpMessageDurationLayout.Location = new System.Drawing.Point(3, 131);
            this.tlpMessageDurationLayout.Name = "tlpMessageDurationLayout";
            this.tlpMessageDurationLayout.RowCount = 1;
            this.tlpMessageDurationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMessageDurationLayout.Size = new System.Drawing.Size(216, 22);
            this.tlpMessageDurationLayout.TabIndex = 10;
            // 
            // numMessageDuration
            // 
            this.numMessageDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numMessageDuration.Location = new System.Drawing.Point(3, 3);
            this.numMessageDuration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMessageDuration.Name = "numMessageDuration";
            this.numMessageDuration.Size = new System.Drawing.Size(34, 20);
            this.numMessageDuration.TabIndex = 9;
            this.numMessageDuration.ValueChanged += new System.EventHandler(this.numMessageDuration_ValueChanged);
            // 
            // lblSeconds
            // 
            this.lblSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Location = new System.Drawing.Point(43, 4);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(49, 13);
            this.lblSeconds.TabIndex = 10;
            this.lblSeconds.Text = "Seconds";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbIndefiniteMessageDuration
            // 
            this.chbIndefiniteMessageDuration.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbIndefiniteMessageDuration.AutoSize = true;
            this.chbIndefiniteMessageDuration.Checked = true;
            this.chbIndefiniteMessageDuration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIndefiniteMessageDuration.Location = new System.Drawing.Point(103, 3);
            this.chbIndefiniteMessageDuration.Name = "chbIndefiniteMessageDuration";
            this.chbIndefiniteMessageDuration.Size = new System.Drawing.Size(69, 16);
            this.chbIndefiniteMessageDuration.TabIndex = 9;
            this.chbIndefiniteMessageDuration.Text = "Indefinite";
            this.chbIndefiniteMessageDuration.UseVisualStyleBackColor = true;
            this.chbIndefiniteMessageDuration.CheckedChanged += new System.EventHandler(this.chbIndefiniteMessageDuration_CheckedChanged);
            // 
            // txtShowMessage
            // 
            this.txtShowMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowMessage.Location = new System.Drawing.Point(3, 3);
            this.txtShowMessage.Multiline = true;
            this.txtShowMessage.Name = "txtShowMessage";
            this.txtShowMessage.Size = new System.Drawing.Size(216, 122);
            this.txtShowMessage.TabIndex = 0;
            // 
            // lblMessageInfo
            // 
            this.lblMessageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblMessageInfo.AutoSize = true;
            this.lblMessageInfo.Location = new System.Drawing.Point(5, 0);
            this.lblMessageInfo.Name = "lblMessageInfo";
            this.lblMessageInfo.Size = new System.Drawing.Size(86, 162);
            this.lblMessageInfo.TabIndex = 5;
            this.lblMessageInfo.Text = "Enter a message to display on the screen for a brief or indefinite interval";
            this.lblMessageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpMainLeftLayout
            // 
            this.flpMainLeftLayout.AutoSize = true;
            this.flpMainLeftLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpMainLeftLayout.Controls.Add(this.flpWarningTimesLayout);
            this.flpMainLeftLayout.Controls.Add(this.tlpFinalMessageLayout);
            this.flpMainLeftLayout.Controls.Add(this.tlpGoLiveLayout);
            this.flpMainLeftLayout.Controls.Add(this.chbBlink);
            this.flpMainLeftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMainLeftLayout.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMainLeftLayout.Location = new System.Drawing.Point(35, 3);
            this.flpMainLeftLayout.Name = "flpMainLeftLayout";
            this.flpMainLeftLayout.Size = new System.Drawing.Size(250, 162);
            this.flpMainLeftLayout.TabIndex = 2;
            // 
            // flpWarningTimesLayout
            // 
            this.flpWarningTimesLayout.AutoSize = true;
            this.flpWarningTimesLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpWarningTimesLayout.Controls.Add(this.tlpFirstWarningLayout);
            this.flpWarningTimesLayout.Controls.Add(this.tlpSecondWarningLayout);
            this.flpWarningTimesLayout.Location = new System.Drawing.Point(3, 3);
            this.flpWarningTimesLayout.Name = "flpWarningTimesLayout";
            this.flpWarningTimesLayout.Size = new System.Drawing.Size(242, 55);
            this.flpWarningTimesLayout.TabIndex = 3;
            // 
            // tlpFirstWarningLayout
            // 
            this.tlpFirstWarningLayout.AutoSize = true;
            this.tlpFirstWarningLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpFirstWarningLayout.ColumnCount = 1;
            this.tlpFirstWarningLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFirstWarningLayout.Controls.Add(this.txtWarningTime, 0, 1);
            this.tlpFirstWarningLayout.Controls.Add(this.lblWarningTime, 0, 0);
            this.tlpFirstWarningLayout.Location = new System.Drawing.Point(3, 3);
            this.tlpFirstWarningLayout.Name = "tlpFirstWarningLayout";
            this.tlpFirstWarningLayout.RowCount = 2;
            this.tlpFirstWarningLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFirstWarningLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFirstWarningLayout.Size = new System.Drawing.Size(115, 49);
            this.tlpFirstWarningLayout.TabIndex = 3;
            // 
            // txtWarningTime
            // 
            this.txtWarningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarningTime.InputTime = 0D;
            this.txtWarningTime.Location = new System.Drawing.Point(3, 16);
            this.txtWarningTime.Name = "txtWarningTime";
            this.txtWarningTime.Size = new System.Drawing.Size(109, 30);
            this.txtWarningTime.TabIndex = 8;
            this.txtWarningTime.Text = "00:00:00";
            this.txtWarningTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtWarningTime.TimeChanged += new System.EventHandler(this.txtWarningTime_TimeChanged);
            // 
            // lblWarningTime
            // 
            this.lblWarningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningTime.AutoSize = true;
            this.lblWarningTime.Location = new System.Drawing.Point(3, 0);
            this.lblWarningTime.Name = "lblWarningTime";
            this.lblWarningTime.Size = new System.Drawing.Size(109, 13);
            this.lblWarningTime.TabIndex = 7;
            this.lblWarningTime.Text = "First Warning";
            this.lblWarningTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSecondWarningLayout
            // 
            this.tlpSecondWarningLayout.AutoSize = true;
            this.tlpSecondWarningLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpSecondWarningLayout.ColumnCount = 1;
            this.tlpSecondWarningLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSecondWarningLayout.Controls.Add(this.label2, 0, 0);
            this.tlpSecondWarningLayout.Controls.Add(this.txtSecondWarningTime, 0, 1);
            this.tlpSecondWarningLayout.Location = new System.Drawing.Point(124, 3);
            this.tlpSecondWarningLayout.Name = "tlpSecondWarningLayout";
            this.tlpSecondWarningLayout.RowCount = 2;
            this.tlpSecondWarningLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpSecondWarningLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSecondWarningLayout.Size = new System.Drawing.Size(115, 49);
            this.tlpSecondWarningLayout.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Second Warning";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSecondWarningTime
            // 
            this.txtSecondWarningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecondWarningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSecondWarningTime.InputTime = 0D;
            this.txtSecondWarningTime.Location = new System.Drawing.Point(3, 16);
            this.txtSecondWarningTime.Name = "txtSecondWarningTime";
            this.txtSecondWarningTime.Size = new System.Drawing.Size(109, 30);
            this.txtSecondWarningTime.TabIndex = 8;
            this.txtSecondWarningTime.Text = "00:00:00";
            this.txtSecondWarningTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSecondWarningTime.TimeChanged += new System.EventHandler(this.txtAutoPauseTime_TimeChanged);
            // 
            // tlpFinalMessageLayout
            // 
            this.tlpFinalMessageLayout.AutoSize = true;
            this.tlpFinalMessageLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpFinalMessageLayout.ColumnCount = 2;
            this.tlpFinalMessageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpFinalMessageLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinalMessageLayout.Controls.Add(this.txtFinalMessage, 1, 0);
            this.tlpFinalMessageLayout.Controls.Add(this.lblFinalMessage, 0, 0);
            this.tlpFinalMessageLayout.Location = new System.Drawing.Point(3, 64);
            this.tlpFinalMessageLayout.Name = "tlpFinalMessageLayout";
            this.tlpFinalMessageLayout.RowCount = 1;
            this.tlpFinalMessageLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFinalMessageLayout.Size = new System.Drawing.Size(244, 26);
            this.tlpFinalMessageLayout.TabIndex = 11;
            // 
            // txtFinalMessage
            // 
            this.txtFinalMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinalMessage.Location = new System.Drawing.Point(84, 3);
            this.txtFinalMessage.Name = "txtFinalMessage";
            this.txtFinalMessage.Size = new System.Drawing.Size(157, 20);
            this.txtFinalMessage.TabIndex = 10;
            this.txtFinalMessage.TextChanged += new System.EventHandler(this.txtFinalMessage_TextChanged);
            // 
            // lblFinalMessage
            // 
            this.lblFinalMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFinalMessage.AutoSize = true;
            this.lblFinalMessage.Location = new System.Drawing.Point(3, 6);
            this.lblFinalMessage.Name = "lblFinalMessage";
            this.lblFinalMessage.Size = new System.Drawing.Size(75, 13);
            this.lblFinalMessage.TabIndex = 15;
            this.lblFinalMessage.Text = "Final Message";
            // 
            // tlpGoLiveLayout
            // 
            this.tlpGoLiveLayout.AutoSize = true;
            this.tlpGoLiveLayout.ColumnCount = 2;
            this.tlpGoLiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpGoLiveLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpGoLiveLayout.Controls.Add(this.rdbLive, 0, 0);
            this.tlpGoLiveLayout.Controls.Add(this.pcbLiveIndicator, 1, 0);
            this.tlpGoLiveLayout.Location = new System.Drawing.Point(3, 96);
            this.tlpGoLiveLayout.Name = "tlpGoLiveLayout";
            this.tlpGoLiveLayout.RowCount = 1;
            this.tlpGoLiveLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGoLiveLayout.Size = new System.Drawing.Size(99, 23);
            this.tlpGoLiveLayout.TabIndex = 7;
            // 
            // rdbLive
            // 
            this.rdbLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbLive.AutoSize = true;
            this.rdbLive.Location = new System.Drawing.Point(3, 3);
            this.rdbLive.Name = "rdbLive";
            this.rdbLive.Size = new System.Drawing.Size(48, 17);
            this.rdbLive.TabIndex = 6;
            this.rdbLive.TabStop = true;
            this.rdbLive.Text = "LIVE";
            this.rdbLive.UseVisualStyleBackColor = true;
            this.rdbLive.Click += new System.EventHandler(this.rdbLive_Click);
            // 
            // pcbLiveIndicator
            // 
            this.pcbLiveIndicator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcbLiveIndicator.Image = global::SpeakerTimer.Properties.Resources.wpid_gfgffh;
            this.pcbLiveIndicator.Location = new System.Drawing.Point(57, 3);
            this.pcbLiveIndicator.Name = "pcbLiveIndicator";
            this.pcbLiveIndicator.Size = new System.Drawing.Size(39, 17);
            this.pcbLiveIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbLiveIndicator.TabIndex = 7;
            this.pcbLiveIndicator.TabStop = false;
            // 
            // chbBlink
            // 
            this.chbBlink.AutoSize = true;
            this.chbBlink.Enabled = false;
            this.chbBlink.Location = new System.Drawing.Point(3, 125);
            this.chbBlink.Name = "chbBlink";
            this.chbBlink.Size = new System.Drawing.Size(115, 17);
            this.chbBlink.TabIndex = 8;
            this.chbBlink.Text = "Blink when expired";
            this.chbBlink.UseVisualStyleBackColor = true;
            this.chbBlink.CheckedChanged += new System.EventHandler(this.chbBlink_CheckedChanged);
            // 
            // timerView
            // 
            this.timerView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.timerView.BlinkInterval = 700;
            this.timerView.CommandIssuer = null;
            this.timerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timerView.IsPreviewMode = true;
            this.timerView.Location = new System.Drawing.Point(3, 3);
            this.timerView.Name = "timerView";
            this.timerView.ShowLabel = true;
            this.timerView.Size = new System.Drawing.Size(269, 245);
            this.timerView.TabIndex = 2;
            this.timerView.TimerColor = System.Drawing.SystemColors.ControlText;
            this.timerView.TimerFont = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerView.TimerState = SpeakerTimer.TimerState.Stopped;
            // 
            // grbPreviewBox
            // 
            this.grbPreviewBox.Controls.Add(this.tlpOuterLayout);
            this.grbPreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPreviewBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPreviewBox.Location = new System.Drawing.Point(0, 0);
            this.grbPreviewBox.Name = "grbPreviewBox";
            this.grbPreviewBox.Size = new System.Drawing.Size(1011, 270);
            this.grbPreviewBox.TabIndex = 1;
            this.grbPreviewBox.TabStop = false;
            this.grbPreviewBox.Text = "groupBox2";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // TimerPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbPreviewBox);
            this.MinimumSize = new System.Drawing.Size(0, 195);
            this.Name = "TimerPreview";
            this.Size = new System.Drawing.Size(1011, 270);
            this.Load += new System.EventHandler(this.TimerPreview_Load);
            this.tlpOuterLayout.ResumeLayout(false);
            this.tlpOuterLayout.PerformLayout();
            this.tlpControlsLayout.ResumeLayout(false);
            this.tlpControlsLayout.PerformLayout();
            this.flpIOayout.ResumeLayout(false);
            this.flpIOayout.PerformLayout();
            this.tlpTimerNameLayout.ResumeLayout(false);
            this.tlpTimerNameLayout.PerformLayout();
            this.tlpTitleLayout.ResumeLayout(false);
            this.tlpTitleLayout.PerformLayout();
            this.tlpOpenLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpMainLayout.ResumeLayout(false);
            this.tlpMainLayout.PerformLayout();
            this.tlpTimerControlLayout.ResumeLayout(false);
            this.tlpMessageLayout.ResumeLayout(false);
            this.tlpMessageLayout.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpMessageDurationLayout.ResumeLayout(false);
            this.tlpMessageDurationLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMessageDuration)).EndInit();
            this.flpMainLeftLayout.ResumeLayout(false);
            this.flpMainLeftLayout.PerformLayout();
            this.flpWarningTimesLayout.ResumeLayout(false);
            this.flpWarningTimesLayout.PerformLayout();
            this.tlpFirstWarningLayout.ResumeLayout(false);
            this.tlpFirstWarningLayout.PerformLayout();
            this.tlpSecondWarningLayout.ResumeLayout(false);
            this.tlpSecondWarningLayout.PerformLayout();
            this.tlpFinalMessageLayout.ResumeLayout(false);
            this.tlpFinalMessageLayout.PerformLayout();
            this.tlpGoLiveLayout.ResumeLayout(false);
            this.tlpGoLiveLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLiveIndicator)).EndInit();
            this.grbPreviewBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;
        private System.Windows.Forms.TextBox txtSettingsName;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWarningTime;
        private TimeInputBox txtSecondWarningTime;
        private TimeInputBox txtWarningTime;
        private System.Windows.Forms.ComboBox cmbLoadTimer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpControlsLayout;
        private System.Windows.Forms.TextBox txtFinalMessage;
        private System.Windows.Forms.Label lblFinalMessage;
        private System.Windows.Forms.TableLayoutPanel tlpGoLiveLayout;
        private System.Windows.Forms.RadioButton rdbLive;
        private TimerView timerView;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.GroupBox grbPreviewBox;
        private System.Windows.Forms.PictureBox pcbLiveIndicator;
        private System.Windows.Forms.CheckBox chbBlink;
        private System.Windows.Forms.FlowLayoutPanel flpIOayout;
        private System.Windows.Forms.TableLayoutPanel tlpOpenLayout;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tlpTimerNameLayout;
        private System.Windows.Forms.Label lblTimerName;
        private System.Windows.Forms.TableLayoutPanel tlpTimerControlLayout;
        private System.Windows.Forms.TableLayoutPanel tlpFirstWarningLayout;
        private System.Windows.Forms.TableLayoutPanel tlpSecondWarningLayout;
        private System.Windows.Forms.FlowLayoutPanel flpWarningTimesLayout;
        private System.Windows.Forms.TableLayoutPanel tlpFinalMessageLayout;
        private System.Windows.Forms.Button btnEditName;
        private System.Windows.Forms.TextBox txtShowMessage;
        private System.Windows.Forms.Button btnVisualSettings;
        private System.Windows.Forms.TableLayoutPanel tlpTitleLayout;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpMessageLayout;
        private System.Windows.Forms.Button btnShowMessage;
        private System.Windows.Forms.Label lblMessageInfo;
        private System.Windows.Forms.NumericUpDown numMessageDuration;
        private System.Windows.Forms.TableLayoutPanel tlpMessageDurationLayout;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.CheckBox chbIndefiniteMessageDuration;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.FlowLayoutPanel flpMainLeftLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
