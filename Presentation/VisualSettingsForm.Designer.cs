namespace SpeakerTimer.Presentation
{
    partial class VisualSettingsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpOuterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grbDisplaySettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDisplayMode = new System.Windows.Forms.ComboBox();
            this.cmbCounterMode = new System.Windows.Forms.ComboBox();
            this.cmbFontFace = new System.Windows.Forms.ComboBox();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.lblDisplayMode = new System.Windows.Forms.Label();
            this.lblCounterMode = new System.Windows.Forms.Label();
            this.lblFontFace = new System.Windows.Forms.Label();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.btnDefaultSettings = new System.Windows.Forms.Button();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnExpiredColor = new System.Windows.Forms.Button();
            this.btnRunningColor = new System.Windows.Forms.Button();
            this.btnPausedColor = new System.Windows.Forms.Button();
            this.btnMessageColor = new System.Windows.Forms.Button();
            this.btnStoppedColor = new System.Windows.Forms.Button();
            this.btnWarningColor = new System.Windows.Forms.Button();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tlpOuterLayout.SuspendLayout();
            this.tlpButtonLayout.SuspendLayout();
            this.tlpMainLayout.SuspendLayout();
            this.grbDisplaySettings.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpOuterLayout
            // 
            this.tlpOuterLayout.ColumnCount = 3;
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpOuterLayout.Controls.Add(this.tlpMainLayout, 1, 1);
            this.tlpOuterLayout.Controls.Add(this.tlpButtonLayout, 1, 2);
            this.tlpOuterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOuterLayout.Location = new System.Drawing.Point(0, 0);
            this.tlpOuterLayout.Name = "tlpOuterLayout";
            this.tlpOuterLayout.RowCount = 4;
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOuterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tlpOuterLayout.Size = new System.Drawing.Size(406, 272);
            this.tlpOuterLayout.TabIndex = 0;
            // 
            // tlpButtonLayout
            // 
            this.tlpButtonLayout.AutoSize = true;
            this.tlpButtonLayout.ColumnCount = 3;
            this.tlpButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.65766F));
            this.tlpButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.34234F));
            this.tlpButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtonLayout.Controls.Add(this.btnCancel, 0, 0);
            this.tlpButtonLayout.Controls.Add(this.btnDefaultSettings, 2, 0);
            this.tlpButtonLayout.Controls.Add(this.btnOk, 0, 0);
            this.tlpButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtonLayout.Location = new System.Drawing.Point(8, 226);
            this.tlpButtonLayout.Name = "tlpButtonLayout";
            this.tlpButtonLayout.RowCount = 1;
            this.tlpButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonLayout.Size = new System.Drawing.Size(390, 38);
            this.tlpButtonLayout.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(106, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Location = new System.Drawing.Point(187, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 32);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tlpMainLayout
            // 
            this.tlpMainLayout.ColumnCount = 2;
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tlpMainLayout.Controls.Add(this.grbDisplaySettings, 0, 0);
            this.tlpMainLayout.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tlpMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainLayout.Location = new System.Drawing.Point(8, 8);
            this.tlpMainLayout.Name = "tlpMainLayout";
            this.tlpMainLayout.RowCount = 1;
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.tlpMainLayout.Size = new System.Drawing.Size(390, 212);
            this.tlpMainLayout.TabIndex = 3;
            // 
            // grbDisplaySettings
            // 
            this.grbDisplaySettings.Controls.Add(this.tableLayoutPanel9);
            this.grbDisplaySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbDisplaySettings.Location = new System.Drawing.Point(3, 3);
            this.grbDisplaySettings.Name = "grbDisplaySettings";
            this.grbDisplaySettings.Size = new System.Drawing.Size(269, 206);
            this.grbDisplaySettings.TabIndex = 0;
            this.grbDisplaySettings.TabStop = false;
            this.grbDisplaySettings.Text = "Display Settings";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.cmbDisplayMode, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.cmbCounterMode, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.cmbFontFace, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.numFontSize, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.lblDisplayMode, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblCounterMode, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblFontFace, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.lblFontSize, 0, 3);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 5;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(263, 187);
            this.tableLayoutPanel9.TabIndex = 0;
            // 
            // cmbDisplayMode
            // 
            this.cmbDisplayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDisplayMode.FormattingEnabled = true;
            this.cmbDisplayMode.Location = new System.Drawing.Point(134, 3);
            this.cmbDisplayMode.Name = "cmbDisplayMode";
            this.cmbDisplayMode.Size = new System.Drawing.Size(126, 21);
            this.cmbDisplayMode.TabIndex = 2;
            // 
            // cmbCounterMode
            // 
            this.cmbCounterMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCounterMode.FormattingEnabled = true;
            this.cmbCounterMode.Location = new System.Drawing.Point(134, 30);
            this.cmbCounterMode.Name = "cmbCounterMode";
            this.cmbCounterMode.Size = new System.Drawing.Size(126, 21);
            this.cmbCounterMode.TabIndex = 3;
            // 
            // cmbFontFace
            // 
            this.cmbFontFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFontFace.FormattingEnabled = true;
            this.cmbFontFace.Location = new System.Drawing.Point(134, 57);
            this.cmbFontFace.Name = "cmbFontFace";
            this.cmbFontFace.Size = new System.Drawing.Size(126, 21);
            this.cmbFontFace.TabIndex = 6;
            // 
            // numFontSize
            // 
            this.numFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.numFontSize.Location = new System.Drawing.Point(134, 84);
            this.numFontSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(126, 20);
            this.numFontSize.TabIndex = 8;
            // 
            // lblDisplayMode
            // 
            this.lblDisplayMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDisplayMode.AutoSize = true;
            this.lblDisplayMode.Location = new System.Drawing.Point(3, 7);
            this.lblDisplayMode.Name = "lblDisplayMode";
            this.lblDisplayMode.Size = new System.Drawing.Size(125, 13);
            this.lblDisplayMode.TabIndex = 11;
            this.lblDisplayMode.Text = "Display Mode";
            // 
            // lblCounterMode
            // 
            this.lblCounterMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCounterMode.AutoSize = true;
            this.lblCounterMode.Location = new System.Drawing.Point(3, 34);
            this.lblCounterMode.Name = "lblCounterMode";
            this.lblCounterMode.Size = new System.Drawing.Size(125, 13);
            this.lblCounterMode.TabIndex = 12;
            this.lblCounterMode.Text = "Counter Mode";
            // 
            // lblFontFace
            // 
            this.lblFontFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontFace.AutoSize = true;
            this.lblFontFace.Location = new System.Drawing.Point(3, 61);
            this.lblFontFace.Name = "lblFontFace";
            this.lblFontFace.Size = new System.Drawing.Size(125, 13);
            this.lblFontFace.TabIndex = 13;
            this.lblFontFace.Text = "Timer Font";
            // 
            // lblFontSize
            // 
            this.lblFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(3, 87);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(125, 13);
            this.lblFontSize.TabIndex = 14;
            this.lblFontSize.Text = "Font Size";
            // 
            // btnDefaultSettings
            // 
            this.btnDefaultSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefaultSettings.BackColor = System.Drawing.Color.Silver;
            this.btnDefaultSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefaultSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDefaultSettings.Location = new System.Drawing.Point(323, 3);
            this.btnDefaultSettings.Name = "btnDefaultSettings";
            this.btnDefaultSettings.Size = new System.Drawing.Size(64, 32);
            this.btnDefaultSettings.TabIndex = 1;
            this.btnDefaultSettings.Text = "Default";
            this.btnDefaultSettings.UseVisualStyleBackColor = false;
            this.btnDefaultSettings.Click += new System.EventHandler(this.btnDefaultSettings_Click);
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel10.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.btnExpiredColor, 1, 4);
            this.tableLayoutPanel10.Controls.Add(this.btnRunningColor, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.btnPausedColor, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.btnMessageColor, 1, 6);
            this.tableLayoutPanel10.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.btnStoppedColor, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.btnWarningColor, 1, 5);
            this.tableLayoutPanel10.Controls.Add(this.btnBackColor, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(278, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 8;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(109, 206);
            this.tableLayoutPanel10.TabIndex = 1;
            // 
            // btnExpiredColor
            // 
            this.btnExpiredColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpiredColor.Location = new System.Drawing.Point(74, 119);
            this.btnExpiredColor.Name = "btnExpiredColor";
            this.btnExpiredColor.Size = new System.Drawing.Size(32, 23);
            this.btnExpiredColor.TabIndex = 7;
            this.btnExpiredColor.UseVisualStyleBackColor = true;
            // 
            // btnRunningColor
            // 
            this.btnRunningColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunningColor.Location = new System.Drawing.Point(74, 3);
            this.btnRunningColor.Name = "btnRunningColor";
            this.btnRunningColor.Size = new System.Drawing.Size(32, 23);
            this.btnRunningColor.TabIndex = 2;
            this.btnRunningColor.UseVisualStyleBackColor = true;
            // 
            // btnPausedColor
            // 
            this.btnPausedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPausedColor.Location = new System.Drawing.Point(74, 32);
            this.btnPausedColor.Name = "btnPausedColor";
            this.btnPausedColor.Size = new System.Drawing.Size(32, 23);
            this.btnPausedColor.TabIndex = 5;
            this.btnPausedColor.UseVisualStyleBackColor = true;
            // 
            // btnMessageColor
            // 
            this.btnMessageColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMessageColor.Location = new System.Drawing.Point(74, 177);
            this.btnMessageColor.Name = "btnMessageColor";
            this.btnMessageColor.Size = new System.Drawing.Size(32, 23);
            this.btnMessageColor.TabIndex = 10;
            this.btnMessageColor.UseVisualStyleBackColor = true;
            // 
            // btnStoppedColor
            // 
            this.btnStoppedColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStoppedColor.Location = new System.Drawing.Point(74, 90);
            this.btnStoppedColor.Name = "btnStoppedColor";
            this.btnStoppedColor.Size = new System.Drawing.Size(32, 23);
            this.btnStoppedColor.TabIndex = 8;
            this.btnStoppedColor.UseVisualStyleBackColor = true;
            // 
            // btnWarningColor
            // 
            this.btnWarningColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWarningColor.Location = new System.Drawing.Point(74, 148);
            this.btnWarningColor.Name = "btnWarningColor";
            this.btnWarningColor.Size = new System.Drawing.Size(32, 23);
            this.btnWarningColor.TabIndex = 6;
            this.btnWarningColor.UseVisualStyleBackColor = true;
            // 
            // btnBackColor
            // 
            this.btnBackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackColor.Location = new System.Drawing.Point(74, 61);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(32, 23);
            this.btnBackColor.TabIndex = 9;
            this.btnBackColor.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Warning";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Background";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Expired";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Paused";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Running";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Stopped";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Warning 2";
            // 
            // VisualSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 272);
            this.Controls.Add(this.tlpOuterLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VisualSettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Visual Settings";
            this.tlpOuterLayout.ResumeLayout(false);
            this.tlpOuterLayout.PerformLayout();
            this.tlpButtonLayout.ResumeLayout(false);
            this.tlpMainLayout.ResumeLayout(false);
            this.tlpMainLayout.PerformLayout();
            this.grbDisplaySettings.ResumeLayout(false);
            this.grbDisplaySettings.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpOuterLayout;
        private System.Windows.Forms.TableLayoutPanel tlpButtonLayout;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TableLayoutPanel tlpMainLayout;
        private System.Windows.Forms.GroupBox grbDisplaySettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.ComboBox cmbDisplayMode;
        private System.Windows.Forms.ComboBox cmbCounterMode;
        private System.Windows.Forms.ComboBox cmbFontFace;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.Label lblDisplayMode;
        private System.Windows.Forms.Label lblCounterMode;
        private System.Windows.Forms.Label lblFontFace;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Button btnDefaultSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button btnExpiredColor;
        private System.Windows.Forms.Button btnRunningColor;
        private System.Windows.Forms.Button btnPausedColor;
        private System.Windows.Forms.Button btnMessageColor;
        private System.Windows.Forms.Button btnStoppedColor;
        private System.Windows.Forms.Button btnWarningColor;
        private System.Windows.Forms.Button btnBackColor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}