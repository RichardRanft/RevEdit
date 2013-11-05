namespace RevEdit
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
            this.tbRevisionText = new System.Windows.Forms.TextBox();
            this.lColumn = new System.Windows.Forms.Label();
            this.lCharCount = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbViewList = new System.Windows.Forms.ComboBox();
            this.cbStartLabelList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEndLabelList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrevVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCurrVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bLogin = new System.Windows.Forms.Button();
            this.bDisconnect = new System.Windows.Forms.Button();
            this.cbProjectList = new System.Windows.Forms.ComboBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.bCheckin = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNewLabel = new System.Windows.Forms.TextBox();
            this.cbCreateLabel = new System.Windows.Forms.CheckBox();
            this.bWrapText = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudRevision = new System.Windows.Forms.NumericUpDown();
            this.bInsertHeader = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevision)).BeginInit();
            this.SuspendLayout();
            // 
            // tbRevisionText
            // 
            this.tbRevisionText.AcceptsTab = true;
            this.tbRevisionText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRevisionText.Location = new System.Drawing.Point(12, 253);
            this.tbRevisionText.MaxLength = 256000;
            this.tbRevisionText.MinimumSize = new System.Drawing.Size(626, 404);
            this.tbRevisionText.Multiline = true;
            this.tbRevisionText.Name = "tbRevisionText";
            this.tbRevisionText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRevisionText.Size = new System.Drawing.Size(626, 404);
            this.tbRevisionText.TabIndex = 0;
            this.tbRevisionText.TextChanged += new System.EventHandler(this.tbRevisionText_TextChanged);
            this.tbRevisionText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbRevisionText_PreviewKeyDown);
            // 
            // lColumn
            // 
            this.lColumn.Location = new System.Drawing.Point(591, 227);
            this.lColumn.Name = "lColumn";
            this.lColumn.Size = new System.Drawing.Size(48, 23);
            this.lColumn.TabIndex = 1;
            this.lColumn.Text = "0";
            this.lColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lColumn.Click += new System.EventHandler(this.lColumn_Click);
            // 
            // lCharCount
            // 
            this.lCharCount.Location = new System.Drawing.Point(556, 204);
            this.lCharCount.Name = "lCharCount";
            this.lCharCount.Size = new System.Drawing.Size(83, 23);
            this.lCharCount.TabIndex = 2;
            this.lCharCount.Text = "0";
            this.lCharCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lCharCount.Click += new System.EventHandler(this.lCharCount_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.modDocToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(651, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // modDocToolStripMenuItem
            // 
            this.modDocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.modDocToolStripMenuItem.Name = "modDocToolStripMenuItem";
            this.modDocToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.modDocToolStripMenuItem.Text = "Mod Doc";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createToolStripMenuItem.Text = "Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "&Preferences";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 668);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(651, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Game Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "View";
            // 
            // cbViewList
            // 
            this.cbViewList.Enabled = false;
            this.cbViewList.FormattingEnabled = true;
            this.cbViewList.Location = new System.Drawing.Point(13, 85);
            this.cbViewList.Name = "cbViewList";
            this.cbViewList.Size = new System.Drawing.Size(278, 21);
            this.cbViewList.TabIndex = 8;
            this.cbViewList.Text = "Select a view...";
            this.cbViewList.SelectedIndexChanged += new System.EventHandler(this.cbViewList_SelectedIndexChanged);
            // 
            // cbStartLabelList
            // 
            this.cbStartLabelList.Enabled = false;
            this.cbStartLabelList.FormattingEnabled = true;
            this.cbStartLabelList.Location = new System.Drawing.Point(13, 126);
            this.cbStartLabelList.Name = "cbStartLabelList";
            this.cbStartLabelList.Size = new System.Drawing.Size(278, 21);
            this.cbStartLabelList.TabIndex = 10;
            this.cbStartLabelList.Text = "Select the starting label...";
            this.cbStartLabelList.SelectedIndexChanged += new System.EventHandler(this.cbStartLabelList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start Label";
            // 
            // cbEndLabelList
            // 
            this.cbEndLabelList.Enabled = false;
            this.cbEndLabelList.FormattingEnabled = true;
            this.cbEndLabelList.Location = new System.Drawing.Point(13, 167);
            this.cbEndLabelList.Name = "cbEndLabelList";
            this.cbEndLabelList.Size = new System.Drawing.Size(278, 21);
            this.cbEndLabelList.TabIndex = 12;
            this.cbEndLabelList.SelectedIndexChanged += new System.EventHandler(this.cbEndLabelList_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "End Label";
            // 
            // tbPrevVersion
            // 
            this.tbPrevVersion.Location = new System.Drawing.Point(297, 126);
            this.tbPrevVersion.Name = "tbPrevVersion";
            this.tbPrevVersion.Size = new System.Drawing.Size(278, 20);
            this.tbPrevVersion.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Previous Version";
            // 
            // tbCurrVersion
            // 
            this.tbCurrVersion.Location = new System.Drawing.Point(297, 167);
            this.tbCurrVersion.Name = "tbCurrVersion";
            this.tbCurrVersion.Size = new System.Drawing.Size(278, 20);
            this.tbCurrVersion.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(297, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Current Version";
            // 
            // bLogin
            // 
            this.bLogin.Location = new System.Drawing.Point(297, 43);
            this.bLogin.Name = "bLogin";
            this.bLogin.Size = new System.Drawing.Size(75, 23);
            this.bLogin.TabIndex = 17;
            this.bLogin.Text = "Login";
            this.bLogin.UseVisualStyleBackColor = true;
            this.bLogin.Click += new System.EventHandler(this.bLogin_Click);
            // 
            // bDisconnect
            // 
            this.bDisconnect.Enabled = false;
            this.bDisconnect.Location = new System.Drawing.Point(378, 43);
            this.bDisconnect.Name = "bDisconnect";
            this.bDisconnect.Size = new System.Drawing.Size(75, 23);
            this.bDisconnect.TabIndex = 18;
            this.bDisconnect.Text = "Disconnect";
            this.bDisconnect.UseVisualStyleBackColor = true;
            this.bDisconnect.Click += new System.EventHandler(this.bDisconnect_Click);
            // 
            // cbProjectList
            // 
            this.cbProjectList.Enabled = false;
            this.cbProjectList.FormattingEnabled = true;
            this.cbProjectList.Location = new System.Drawing.Point(13, 45);
            this.cbProjectList.Name = "cbProjectList";
            this.cbProjectList.Size = new System.Drawing.Size(278, 21);
            this.cbProjectList.TabIndex = 19;
            this.cbProjectList.Text = "Select a game project...";
            this.cbProjectList.SelectedIndexChanged += new System.EventHandler(this.cbProjectList_SelectedIndexChanged);
            // 
            // bSearch
            // 
            this.bSearch.Enabled = false;
            this.bSearch.Location = new System.Drawing.Point(12, 195);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 20;
            this.bSearch.Text = "Search";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bCheckin
            // 
            this.bCheckin.Enabled = false;
            this.bCheckin.Location = new System.Drawing.Point(94, 195);
            this.bCheckin.Name = "bCheckin";
            this.bCheckin.Size = new System.Drawing.Size(75, 23);
            this.bCheckin.TabIndex = 21;
            this.bCheckin.Text = "Check In";
            this.bCheckin.UseVisualStyleBackColor = true;
            this.bCheckin.Click += new System.EventHandler(this.bCheckin_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(175, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "New Label:";
            // 
            // tbNewLabel
            // 
            this.tbNewLabel.Location = new System.Drawing.Point(178, 207);
            this.tbNewLabel.Name = "tbNewLabel";
            this.tbNewLabel.Size = new System.Drawing.Size(142, 20);
            this.tbNewLabel.TabIndex = 23;
            // 
            // cbCreateLabel
            // 
            this.cbCreateLabel.AutoSize = true;
            this.cbCreateLabel.Location = new System.Drawing.Point(386, 208);
            this.cbCreateLabel.Name = "cbCreateLabel";
            this.cbCreateLabel.Size = new System.Drawing.Size(107, 17);
            this.cbCreateLabel.TabIndex = 24;
            this.cbCreateLabel.Text = "Create this label?";
            this.cbCreateLabel.UseVisualStyleBackColor = true;
            this.cbCreateLabel.CheckedChanged += new System.EventHandler(this.cbCreateLabel_CheckedChanged);
            // 
            // bWrapText
            // 
            this.bWrapText.Location = new System.Drawing.Point(12, 224);
            this.bWrapText.Name = "bWrapText";
            this.bWrapText.Size = new System.Drawing.Size(75, 23);
            this.bWrapText.TabIndex = 25;
            this.bWrapText.Text = "Wrap Text";
            this.bWrapText.UseVisualStyleBackColor = true;
            this.bWrapText.Click += new System.EventHandler(this.bWrapText_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(324, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Revision";
            // 
            // nudRevision
            // 
            this.nudRevision.Location = new System.Drawing.Point(324, 207);
            this.nudRevision.Name = "nudRevision";
            this.nudRevision.Size = new System.Drawing.Size(56, 20);
            this.nudRevision.TabIndex = 28;
            this.nudRevision.ValueChanged += new System.EventHandler(this.nudRevision_ValueChanged);
            // 
            // bInsertHeader
            // 
            this.bInsertHeader.Location = new System.Drawing.Point(94, 224);
            this.bInsertHeader.Name = "bInsertHeader";
            this.bInsertHeader.Size = new System.Drawing.Size(75, 23);
            this.bInsertHeader.TabIndex = 29;
            this.bInsertHeader.Text = "Header";
            this.bInsertHeader.UseVisualStyleBackColor = true;
            this.bInsertHeader.Click += new System.EventHandler(this.bInsertHeader_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 690);
            this.Controls.Add(this.bInsertHeader);
            this.Controls.Add(this.nudRevision);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bWrapText);
            this.Controls.Add(this.cbCreateLabel);
            this.Controls.Add(this.tbNewLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bCheckin);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.cbProjectList);
            this.Controls.Add(this.bDisconnect);
            this.Controls.Add(this.bLogin);
            this.Controls.Add(this.tbCurrVersion);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrevVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbEndLabelList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbStartLabelList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbViewList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lCharCount);
            this.Controls.Add(this.lColumn);
            this.Controls.Add(this.tbRevisionText);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Revision Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRevision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbRevisionText;
        private System.Windows.Forms.Label lColumn;
        private System.Windows.Forms.Label lCharCount;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbViewList;
        private System.Windows.Forms.ComboBox cbStartLabelList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEndLabelList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrevVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCurrVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bLogin;
        private System.Windows.Forms.Button bDisconnect;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cbProjectList;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bCheckin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbNewLabel;
        private System.Windows.Forms.CheckBox cbCreateLabel;
        private System.Windows.Forms.Button bWrapText;
        private System.Windows.Forms.ToolStripMenuItem modDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudRevision;
        private System.Windows.Forms.Button bInsertHeader;
    }
}

