namespace ReleaseManager
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbReleaseNotes = new System.Windows.Forms.TextBox();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMarket = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPlatform = new System.Windows.Forms.ComboBox();
            this.ckbIsPlatform = new System.Windows.Forms.CheckBox();
            this.cbReleaseStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSoftwareName = new System.Windows.Forms.ComboBox();
            this.cbSoftwareVersion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbSHA1 = new System.Windows.Forms.TextBox();
            this.tbHMAC = new System.Windows.Forms.TextBox();
            this.tbLabel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userInformationToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // userInformationToolStripMenuItem
            // 
            this.userInformationToolStripMenuItem.Name = "userInformationToolStripMenuItem";
            this.userInformationToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.userInformationToolStripMenuItem.Text = "Settings";
            this.userInformationToolStripMenuItem.Click += new System.EventHandler(this.userInformationToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Release Platform Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Full Software Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Release Notes:";
            // 
            // tbReleaseNotes
            // 
            this.tbReleaseNotes.Location = new System.Drawing.Point(12, 220);
            this.tbReleaseNotes.Multiline = true;
            this.tbReleaseNotes.Name = "tbReleaseNotes";
            this.tbReleaseNotes.Size = new System.Drawing.Size(613, 204);
            this.tbReleaseNotes.TabIndex = 8;
            this.tbReleaseNotes.TextChanged += new System.EventHandler(this.tbReleaseNotes_TextChanged);
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(430, 95);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(196, 20);
            this.dtpReleaseDate.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Released Date";
            // 
            // cbMarket
            // 
            this.cbMarket.FormattingEnabled = true;
            this.cbMarket.Location = new System.Drawing.Point(278, 54);
            this.cbMarket.Name = "cbMarket";
            this.cbMarket.Size = new System.Drawing.Size(176, 21);
            this.cbMarket.Sorted = true;
            this.cbMarket.TabIndex = 2;
            this.cbMarket.SelectedIndexChanged += new System.EventHandler(this.cbMarket_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Market";
            // 
            // cbPlatform
            // 
            this.cbPlatform.FormattingEnabled = true;
            this.cbPlatform.Location = new System.Drawing.Point(294, 95);
            this.cbPlatform.Name = "cbPlatform";
            this.cbPlatform.Size = new System.Drawing.Size(130, 21);
            this.cbPlatform.Sorted = true;
            this.cbPlatform.TabIndex = 5;
            // 
            // ckbIsPlatform
            // 
            this.ckbIsPlatform.AutoSize = true;
            this.ckbIsPlatform.Location = new System.Drawing.Point(165, 97);
            this.ckbIsPlatform.Name = "ckbIsPlatform";
            this.ckbIsPlatform.Size = new System.Drawing.Size(124, 17);
            this.ckbIsPlatform.TabIndex = 4;
            this.ckbIsPlatform.Text = "Release is a platform";
            this.ckbIsPlatform.UseVisualStyleBackColor = true;
            this.ckbIsPlatform.CheckedChanged += new System.EventHandler(this.ckbIsPlatform_CheckedChanged);
            // 
            // cbReleaseStatus
            // 
            this.cbReleaseStatus.FormattingEnabled = true;
            this.cbReleaseStatus.Items.AddRange(new object[] {
            "NONE",
            "DEVELOPMENT",
            "TESTING",
            "SUBMITTED",
            "APPROVED"});
            this.cbReleaseStatus.Location = new System.Drawing.Point(460, 54);
            this.cbReleaseStatus.Name = "cbReleaseStatus";
            this.cbReleaseStatus.Size = new System.Drawing.Size(165, 21);
            this.cbReleaseStatus.TabIndex = 3;
            this.cbReleaseStatus.SelectedIndexChanged += new System.EventHandler(this.cbReleaseStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(457, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Status";
            // 
            // cbSoftwareName
            // 
            this.cbSoftwareName.FormattingEnabled = true;
            this.cbSoftwareName.Location = new System.Drawing.Point(12, 54);
            this.cbSoftwareName.Name = "cbSoftwareName";
            this.cbSoftwareName.Size = new System.Drawing.Size(260, 21);
            this.cbSoftwareName.Sorted = true;
            this.cbSoftwareName.TabIndex = 1;
            this.cbSoftwareName.SelectedIndexChanged += new System.EventHandler(this.cbSoftwareName_SelectedIndexChanged);
            // 
            // cbSoftwareVersion
            // 
            this.cbSoftwareVersion.FormattingEnabled = true;
            this.cbSoftwareVersion.Location = new System.Drawing.Point(13, 94);
            this.cbSoftwareVersion.Name = "cbSoftwareVersion";
            this.cbSoftwareVersion.Size = new System.Drawing.Size(146, 21);
            this.cbSoftwareVersion.Sorted = true;
            this.cbSoftwareVersion.TabIndex = 60;
            this.cbSoftwareVersion.SelectedIndexChanged += new System.EventHandler(this.cbSoftwareVersion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Version";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 62;
            this.label7.Text = "SHA1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "HMAC SHA1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(517, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "Release";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbSHA1
            // 
            this.tbSHA1.Location = new System.Drawing.Point(15, 139);
            this.tbSHA1.Name = "tbSHA1";
            this.tbSHA1.Size = new System.Drawing.Size(463, 20);
            this.tbSHA1.TabIndex = 67;
            // 
            // tbHMAC
            // 
            this.tbHMAC.Location = new System.Drawing.Point(15, 180);
            this.tbHMAC.Name = "tbHMAC";
            this.tbHMAC.Size = new System.Drawing.Size(463, 20);
            this.tbHMAC.TabIndex = 68;
            // 
            // tbLabel
            // 
            this.tbLabel.Location = new System.Drawing.Point(484, 139);
            this.tbLabel.Name = "tbLabel";
            this.tbLabel.Size = new System.Drawing.Size(143, 20);
            this.tbLabel.TabIndex = 70;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(484, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 69;
            this.label10.Text = "Released Label";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 439);
            this.Controls.Add(this.tbLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbHMAC);
            this.Controls.Add(this.tbSHA1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbSoftwareVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSoftwareName);
            this.Controls.Add(this.cbReleaseStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckbIsPlatform);
            this.Controls.Add(this.cbPlatform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReleaseNotes);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbMarket);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Software Release Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbReleaseNotes;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPlatform;
        private System.Windows.Forms.CheckBox ckbIsPlatform;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userInformationToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbReleaseStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSoftwareName;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbSoftwareVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbSHA1;
        private System.Windows.Forms.TextBox tbHMAC;
        private System.Windows.Forms.TextBox tbLabel;
        private System.Windows.Forms.Label label10;
    }
}

