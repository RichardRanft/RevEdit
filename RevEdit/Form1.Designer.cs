namespace RevEdit
{
    partial class Form1
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
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbViewList = new System.Windows.Forms.ComboBox();
            this.cbStartLabelList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEndLabelList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrevVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCurrVersion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbProjectList = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbRevisionText
            // 
            this.tbRevisionText.Location = new System.Drawing.Point(12, 216);
            this.tbRevisionText.Multiline = true;
            this.tbRevisionText.Name = "tbRevisionText";
            this.tbRevisionText.Size = new System.Drawing.Size(626, 412);
            this.tbRevisionText.TabIndex = 0;
            this.tbRevisionText.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tbRevisionText_PreviewKeyDown);
            // 
            // lColumn
            // 
            this.lColumn.Location = new System.Drawing.Point(591, 190);
            this.lColumn.Name = "lColumn";
            this.lColumn.Size = new System.Drawing.Size(48, 23);
            this.lColumn.TabIndex = 1;
            this.lColumn.Text = "0";
            this.lColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCharCount
            // 
            this.lCharCount.Location = new System.Drawing.Point(556, 167);
            this.lCharCount.Name = "lCharCount";
            this.lCharCount.Size = new System.Drawing.Size(83, 23);
            this.lCharCount.TabIndex = 2;
            this.lCharCount.Text = "0";
            this.lCharCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 631);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(651, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
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
            this.cbStartLabelList.FormattingEnabled = true;
            this.cbStartLabelList.Location = new System.Drawing.Point(13, 126);
            this.cbStartLabelList.Name = "cbStartLabelList";
            this.cbStartLabelList.Size = new System.Drawing.Size(278, 21);
            this.cbStartLabelList.TabIndex = 10;
            this.cbStartLabelList.Text = "Select the starting label...";
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
            this.cbEndLabelList.FormattingEnabled = true;
            this.cbEndLabelList.Location = new System.Drawing.Point(13, 167);
            this.cbEndLabelList.Name = "cbEndLabelList";
            this.cbEndLabelList.Size = new System.Drawing.Size(278, 21);
            this.cbEndLabelList.TabIndex = 12;
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
            // cbCurrVersion
            // 
            this.cbCurrVersion.Location = new System.Drawing.Point(297, 167);
            this.cbCurrVersion.Name = "cbCurrVersion";
            this.cbCurrVersion.Size = new System.Drawing.Size(278, 20);
            this.cbCurrVersion.TabIndex = 16;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(297, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // cbProjectList
            // 
            this.cbProjectList.FormattingEnabled = true;
            this.cbProjectList.Location = new System.Drawing.Point(13, 45);
            this.cbProjectList.Name = "cbProjectList";
            this.cbProjectList.Size = new System.Drawing.Size(278, 21);
            this.cbProjectList.TabIndex = 19;
            this.cbProjectList.Text = "Select a game project...";
            this.cbProjectList.SelectedIndexChanged += new System.EventHandler(this.cbProjectList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 653);
            this.Controls.Add(this.cbProjectList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbCurrVersion);
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
            this.Name = "Form1";
            this.Text = "Revision Text Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.TextBox cbCurrVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ComboBox cbProjectList;
    }
}

