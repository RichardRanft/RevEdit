namespace RevEdit
{
    partial class ModDocForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbModDocPreview = new System.Windows.Forms.TextBox();
            this.bClose = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.tbCurrentVersion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPrevVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbCurrentPlatform = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lSelectedFolder = new System.Windows.Forms.Label();
            this.bBrowse = new System.Windows.Forms.Button();
            this.fbdBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.bImport = new System.Windows.Forms.Button();
            this.bRelease = new System.Windows.Forms.Button();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lReleasedLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbReleaseVersion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMarket = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full Game Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 30);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(197, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbModDocPreview
            // 
            this.tbModDocPreview.AcceptsTab = true;
            this.tbModDocPreview.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModDocPreview.Location = new System.Drawing.Point(12, 180);
            this.tbModDocPreview.MaxLength = 256000;
            this.tbModDocPreview.MinimumSize = new System.Drawing.Size(626, 404);
            this.tbModDocPreview.Multiline = true;
            this.tbModDocPreview.Name = "tbModDocPreview";
            this.tbModDocPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbModDocPreview.Size = new System.Drawing.Size(626, 457);
            this.tbModDocPreview.TabIndex = 7;
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(567, 643);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(71, 23);
            this.bClose.TabIndex = 9;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSave.Location = new System.Drawing.Point(481, 643);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(71, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbCurrentVersion
            // 
            this.tbCurrentVersion.Location = new System.Drawing.Point(12, 70);
            this.tbCurrentVersion.Name = "tbCurrentVersion";
            this.tbCurrentVersion.Size = new System.Drawing.Size(197, 20);
            this.tbCurrentVersion.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Version";
            // 
            // tbPrevVersion
            // 
            this.tbPrevVersion.Location = new System.Drawing.Point(221, 30);
            this.tbPrevVersion.Name = "tbPrevVersion";
            this.tbPrevVersion.Size = new System.Drawing.Size(174, 20);
            this.tbPrevVersion.TabIndex = 3;
            this.tbPrevVersion.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Previous Version";
            // 
            // tbCurrentPlatform
            // 
            this.tbCurrentPlatform.Location = new System.Drawing.Point(221, 70);
            this.tbCurrentPlatform.Name = "tbCurrentPlatform";
            this.tbCurrentPlatform.Size = new System.Drawing.Size(174, 20);
            this.tbCurrentPlatform.TabIndex = 4;
            this.tbCurrentPlatform.Text = "W4NAS07L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(221, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Platform";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Game Folder:";
            // 
            // lSelectedFolder
            // 
            this.lSelectedFolder.AutoSize = true;
            this.lSelectedFolder.Location = new System.Drawing.Point(88, 164);
            this.lSelectedFolder.Name = "lSelectedFolder";
            this.lSelectedFolder.Size = new System.Drawing.Size(98, 13);
            this.lSelectedFolder.TabIndex = 12;
            this.lSelectedFolder.Text = "No Folder Selected";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(12, 96);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(116, 23);
            this.bBrowse.TabIndex = 5;
            this.bBrowse.Text = "Select Game Folder";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // bImport
            // 
            this.bImport.Enabled = false;
            this.bImport.Location = new System.Drawing.Point(134, 96);
            this.bImport.Name = "bImport";
            this.bImport.Size = new System.Drawing.Size(75, 23);
            this.bImport.TabIndex = 6;
            this.bImport.Text = "Import";
            this.bImport.UseVisualStyleBackColor = true;
            this.bImport.Click += new System.EventHandler(this.button1_Click);
            // 
            // bRelease
            // 
            this.bRelease.Enabled = false;
            this.bRelease.Location = new System.Drawing.Point(563, 68);
            this.bRelease.Name = "bRelease";
            this.bRelease.Size = new System.Drawing.Size(75, 23);
            this.bRelease.TabIndex = 19;
            this.bRelease.Text = "Release";
            this.bRelease.UseVisualStyleBackColor = true;
            this.bRelease.Click += new System.EventHandler(this.bRelease_Click);
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(410, 127);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(228, 20);
            this.dtpReleaseDate.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(407, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Released Date";
            // 
            // lReleasedLabel
            // 
            this.lReleasedLabel.AutoSize = true;
            this.lReleasedLabel.Location = new System.Drawing.Point(497, 93);
            this.lReleasedLabel.Name = "lReleasedLabel";
            this.lReleasedLabel.Size = new System.Drawing.Size(41, 13);
            this.lReleasedLabel.TabIndex = 22;
            this.lReleasedLabel.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(407, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Released Label:";
            // 
            // tbReleaseVersion
            // 
            this.tbReleaseVersion.Location = new System.Drawing.Point(410, 70);
            this.tbReleaseVersion.Name = "tbReleaseVersion";
            this.tbReleaseVersion.Size = new System.Drawing.Size(142, 20);
            this.tbReleaseVersion.TabIndex = 15;
            this.tbReleaseVersion.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(407, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Released Version";
            // 
            // cbMarket
            // 
            this.cbMarket.FormattingEnabled = true;
            this.cbMarket.Location = new System.Drawing.Point(410, 29);
            this.cbMarket.Name = "cbMarket";
            this.cbMarket.Size = new System.Drawing.Size(228, 21);
            this.cbMarket.Sorted = true;
            this.cbMarket.TabIndex = 14;
            this.cbMarket.SelectedIndexChanged += new System.EventHandler(this.cbMarket_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Market";
            // 
            // ModDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 678);
            this.Controls.Add(this.lReleasedLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.bRelease);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbReleaseVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbMarket);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bImport);
            this.Controls.Add(this.bBrowse);
            this.Controls.Add(this.lSelectedFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCurrentPlatform);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbPrevVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCurrentVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tbModDocPreview);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModDocForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModDocForm";
            this.Shown += new System.EventHandler(this.ModDocForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbModDocPreview;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbCurrentVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPrevVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbCurrentPlatform;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lSelectedFolder;
        private System.Windows.Forms.Button bBrowse;
        private System.Windows.Forms.FolderBrowserDialog fbdBrowser;
        private System.Windows.Forms.Button bImport;
        private System.Windows.Forms.Button bRelease;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lReleasedLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbReleaseVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.Label label6;
    }
}