using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RevEdit
{
    public partial class CheckinForm : Form
    {
        private ToolTip mOKTip;

        public CheckinForm()
        {
            InitializeComponent();
        }

        private void tbLabelComment_TextChanged(object sender, EventArgs e)
        {
            if (tbLabelComment.TextLength > 0)
                bOK.Enabled = true;
            else
                bOK.Enabled = false;
        }

        public String Comment
        {
            get
            {
                return tbLabelComment.Text;
            }
        }

        private void CheckinForm_Load(object sender, EventArgs e)
        {
            mOKTip = new ToolTip();
            mOKTip.SetToolTip(this.bOK, "You must enter a comment when creating a label.");
        }

        private void bOK_MouseEnter(object sender, EventArgs e)
        {
            if(bOK.Enabled)
                mOKTip.SetToolTip(this.bOK, "Check in and create label with this comment?");
            else
                mOKTip.SetToolTip(this.bOK, "You must enter a comment when creating a label.");
        }
    }
}
