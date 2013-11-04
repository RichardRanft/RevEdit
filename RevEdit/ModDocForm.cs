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
    public partial class ModDocForm : Form
    {
        private String mPath;
        private String mHMAC;
        private String mSHA1;

        public ModDocForm()
        {
            InitializeComponent();
            mPath = "";
            mHMAC = "";
            mSHA1 = "";
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (fbdBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mPath = fbdBrowser.SelectedPath;
                lSelectedFolder.Text = mPath;
            }
        }

        private void updateDoc()
        {
            tbModDocPreview.Text = "";
            tbModDocPreview.AppendText("GAME: " + tbName.Text + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("MACHINE: EGM Equinox" + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("CURRENT VERSION: " + Environment.NewLine + tbCurrentVersion.Text + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("PREVIOUS VERSION: " + Environment.NewLine + tbPrevVersion.Text + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("JURISDICTION: " + Environment.NewLine + "NGCB" + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("SOFTWARE COMPATIBILITY" + Environment.NewLine);
            tbModDocPreview.AppendText("Kernel:   " + tbCurrentPlatform.Text + Environment.NewLine);
            tbModDocPreview.AppendText("BIOS:     SBGEN024" + Environment.NewLine);
            tbModDocPreview.AppendText("RAMCLEAR: RCUSA06C" + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("HMACSHA1: " + mHMAC + Environment.NewLine);
            tbModDocPreview.AppendText("SHA1: " + mSHA1 + Environment.NewLine + Environment.NewLine);
            tbModDocPreview.AppendText("CHANGE OVERVIEW: " + Environment.NewLine + Environment.NewLine);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDoc();
        }
    }
}
