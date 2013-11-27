namespace RevEdit
{
    partial class ReleaseForm
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
            this.lReleasedLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.tbReleaseVersion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMarket = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbReleaseNotes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bCancel = new System.Windows.Forms.Button();
            this.bRelease = new System.Windows.Forms.Button();
            this.tbGameName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPlatform = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lReleasedLabel
            // 
            this.lReleasedLabel.AutoSize = true;
            this.lReleasedLabel.Location = new System.Drawing.Point(516, 32);
            this.lReleasedLabel.Name = "lReleasedLabel";
            this.lReleasedLabel.Size = new System.Drawing.Size(0, 13);
            this.lReleasedLabel.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Released Label:";
            // 
            // dtpReleaseDate
            // 
            this.dtpReleaseDate.Location = new System.Drawing.Point(429, 70);
            this.dtpReleaseDate.Name = "dtpReleaseDate";
            this.dtpReleaseDate.Size = new System.Drawing.Size(196, 20);
            this.dtpReleaseDate.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Released Date";
            // 
            // tbReleaseVersion
            // 
            this.tbReleaseVersion.Location = new System.Drawing.Point(278, 70);
            this.tbReleaseVersion.Name = "tbReleaseVersion";
            this.tbReleaseVersion.Size = new System.Drawing.Size(142, 20);
            this.tbReleaseVersion.TabIndex = 25;
            this.tbReleaseVersion.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(275, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Released Version";
            // 
            // cbMarket
            // 
            this.cbMarket.FormattingEnabled = true;
            this.cbMarket.Location = new System.Drawing.Point(278, 29);
            this.cbMarket.Name = "cbMarket";
            this.cbMarket.Size = new System.Drawing.Size(142, 21);
            this.cbMarket.Sorted = true;
            this.cbMarket.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(275, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Market";
            // 
            // tbReleaseNotes
            // 
            this.tbReleaseNotes.Location = new System.Drawing.Point(13, 109);
            this.tbReleaseNotes.Multiline = true;
            this.tbReleaseNotes.Name = "tbReleaseNotes";
            this.tbReleaseNotes.Size = new System.Drawing.Size(613, 204);
            this.tbReleaseNotes.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Release Notes:";
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(550, 320);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 33;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bRelease
            // 
            this.bRelease.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bRelease.Location = new System.Drawing.Point(469, 320);
            this.bRelease.Name = "bRelease";
            this.bRelease.Size = new System.Drawing.Size(75, 23);
            this.bRelease.TabIndex = 34;
            this.bRelease.Text = "Release";
            this.bRelease.UseVisualStyleBackColor = true;
            // 
            // tbGameName
            // 
            this.tbGameName.Location = new System.Drawing.Point(15, 30);
            this.tbGameName.Name = "tbGameName";
            this.tbGameName.Size = new System.Drawing.Size(257, 20);
            this.tbGameName.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Full Game Name";
            // 
            // tbPlatform
            // 
            this.tbPlatform.Location = new System.Drawing.Point(15, 70);
            this.tbPlatform.Name = "tbPlatform";
            this.tbPlatform.Size = new System.Drawing.Size(142, 20);
            this.tbPlatform.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Release on Platform";
            // 
            // ReleaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 349);
            this.Controls.Add(this.tbPlatform);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbGameName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bRelease);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReleaseNotes);
            this.Controls.Add(this.lReleasedLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpReleaseDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbReleaseVersion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbMarket);
            this.Controls.Add(this.label6);
            this.Name = "ReleaseForm";
            this.Text = "ReleaseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lReleasedLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpReleaseDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbReleaseVersion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMarket;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbReleaseNotes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bRelease;
        private System.Windows.Forms.TextBox tbGameName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPlatform;
        private System.Windows.Forms.Label label3;
    }
}