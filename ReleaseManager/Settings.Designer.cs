namespace ReleaseManager
{
    partial class Settings
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbSVNAutoLogin = new System.Windows.Forms.CheckBox();
            this.tbSVNPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSVNUserName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbTempPath = new System.Windows.Forms.TextBox();
            this.bTempBrowse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.folderBrowseDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbSVNAutoLogin);
            this.groupBox4.Controls.Add(this.tbSVNPassword);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tbSVNUserName);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(225, 127);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Subversion";
            // 
            // cbSVNAutoLogin
            // 
            this.cbSVNAutoLogin.AutoSize = true;
            this.cbSVNAutoLogin.Checked = true;
            this.cbSVNAutoLogin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSVNAutoLogin.Location = new System.Drawing.Point(6, 19);
            this.cbSVNAutoLogin.Name = "cbSVNAutoLogin";
            this.cbSVNAutoLogin.Size = new System.Drawing.Size(119, 17);
            this.cbSVNAutoLogin.TabIndex = 0;
            this.cbSVNAutoLogin.Text = "Log in automatically";
            this.cbSVNAutoLogin.UseVisualStyleBackColor = true;
            // 
            // tbSVNPassword
            // 
            this.tbSVNPassword.Location = new System.Drawing.Point(6, 100);
            this.tbSVNPassword.Name = "tbSVNPassword";
            this.tbSVNPassword.Size = new System.Drawing.Size(213, 20);
            this.tbSVNPassword.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "User Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Password";
            // 
            // tbSVNUserName
            // 
            this.tbSVNUserName.Location = new System.Drawing.Point(6, 60);
            this.tbSVNUserName.Name = "tbSVNUserName";
            this.tbSVNUserName.Size = new System.Drawing.Size(213, 20);
            this.tbSVNUserName.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbTempPath);
            this.groupBox2.Controls.Add(this.bTempBrowse);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(243, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 127);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files";
            // 
            // tbTempPath
            // 
            this.tbTempPath.Location = new System.Drawing.Point(7, 36);
            this.tbTempPath.Name = "tbTempPath";
            this.tbTempPath.Size = new System.Drawing.Size(219, 20);
            this.tbTempPath.TabIndex = 2;
            // 
            // bTempBrowse
            // 
            this.bTempBrowse.Location = new System.Drawing.Point(151, 13);
            this.bTempBrowse.Name = "bTempBrowse";
            this.bTempBrowse.Size = new System.Drawing.Size(75, 19);
            this.bTempBrowse.TabIndex = 1;
            this.bTempBrowse.Text = "Browse";
            this.bTempBrowse.UseVisualStyleBackColor = true;
            this.bTempBrowse.Click += new System.EventHandler(this.bTempBrowse_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Temporary File Location";
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Location = new System.Drawing.Point(319, 144);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 11;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(400, 144);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 174);
            this.ControlBox = false;
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Text = "Settings";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbSVNAutoLogin;
        private System.Windows.Forms.TextBox tbSVNPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSVNUserName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbTempPath;
        private System.Windows.Forms.Button bTempBrowse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowseDlg;
    }
}