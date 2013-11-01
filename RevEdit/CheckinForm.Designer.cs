namespace RevEdit
{
    partial class CheckinForm
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
            this.tbLabelComment = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Label Comment";
            // 
            // tbLabelComment
            // 
            this.tbLabelComment.Location = new System.Drawing.Point(13, 30);
            this.tbLabelComment.Multiline = true;
            this.tbLabelComment.Name = "tbLabelComment";
            this.tbLabelComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLabelComment.Size = new System.Drawing.Size(609, 139);
            this.tbLabelComment.TabIndex = 1;
            this.tbLabelComment.TextChanged += new System.EventHandler(this.tbLabelComment_TextChanged);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(547, 175);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 2;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            // 
            // bOK
            // 
            this.bOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bOK.Enabled = false;
            this.bOK.Location = new System.Drawing.Point(466, 175);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(75, 23);
            this.bOK.TabIndex = 3;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.MouseEnter += new System.EventHandler(this.bOK_MouseEnter);
            // 
            // CheckinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 210);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbLabelComment);
            this.Controls.Add(this.label1);
            this.Name = "CheckinForm";
            this.Text = "Check in";
            this.Load += new System.EventHandler(this.CheckinForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbLabelComment;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bOK;
    }
}