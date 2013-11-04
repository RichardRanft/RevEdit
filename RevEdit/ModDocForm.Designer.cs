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
            this.button1 = new System.Windows.Forms.Button();
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
            this.tbName.Size = new System.Drawing.Size(282, 20);
            this.tbName.TabIndex = 1;
            // 
            // tbModDocPreview
            // 
            this.tbModDocPreview.AcceptsTab = true;
            this.tbModDocPreview.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbModDocPreview.Location = new System.Drawing.Point(12, 138);
            this.tbModDocPreview.MaxLength = 256000;
            this.tbModDocPreview.MinimumSize = new System.Drawing.Size(626, 404);
            this.tbModDocPreview.Multiline = true;
            this.tbModDocPreview.Name = "tbModDocPreview";
            this.tbModDocPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbModDocPreview.Size = new System.Drawing.Size(626, 499);
            this.tbModDocPreview.TabIndex = 2;
            // 
            // bClose
            // 
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(567, 643);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(71, 23);
            this.bClose.TabIndex = 3;
            this.bClose.Text = "Close";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // bSave
            // 
            this.bSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bSave.Location = new System.Drawing.Point(481, 643);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(71, 23);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            // 
            // tbCurrentVersion
            // 
            this.tbCurrentVersion.Location = new System.Drawing.Point(12, 70);
            this.tbCurrentVersion.Name = "tbCurrentVersion";
            this.tbCurrentVersion.Size = new System.Drawing.Size(282, 20);
            this.tbCurrentVersion.TabIndex = 6;
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
            this.tbPrevVersion.Location = new System.Drawing.Point(309, 30);
            this.tbPrevVersion.Name = "tbPrevVersion";
            this.tbPrevVersion.Size = new System.Drawing.Size(282, 20);
            this.tbPrevVersion.TabIndex = 8;
            this.tbPrevVersion.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Previous Version";
            // 
            // tbCurrentPlatform
            // 
            this.tbCurrentPlatform.Location = new System.Drawing.Point(309, 70);
            this.tbCurrentPlatform.Name = "tbCurrentPlatform";
            this.tbCurrentPlatform.Size = new System.Drawing.Size(282, 20);
            this.tbCurrentPlatform.TabIndex = 10;
            this.tbCurrentPlatform.Text = "W4NAS07L";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current Platform";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Game Folder:";
            // 
            // lSelectedFolder
            // 
            this.lSelectedFolder.AutoSize = true;
            this.lSelectedFolder.Location = new System.Drawing.Point(88, 93);
            this.lSelectedFolder.Name = "lSelectedFolder";
            this.lSelectedFolder.Size = new System.Drawing.Size(98, 13);
            this.lSelectedFolder.TabIndex = 12;
            this.lSelectedFolder.Text = "No Folder Selected";
            // 
            // bBrowse
            // 
            this.bBrowse.Location = new System.Drawing.Point(12, 109);
            this.bBrowse.Name = "bBrowse";
            this.bBrowse.Size = new System.Drawing.Size(116, 23);
            this.bBrowse.TabIndex = 13;
            this.bBrowse.Text = "Select Game Folder";
            this.bBrowse.UseVisualStyleBackColor = true;
            this.bBrowse.Click += new System.EventHandler(this.bBrowse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ModDocForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 678);
            this.Controls.Add(this.button1);
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
            this.Name = "ModDocForm";
            this.Text = "ModDocForm";
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
        private System.Windows.Forms.Button button1;
    }
}