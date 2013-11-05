using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace RevEdit
{
    public partial class ModDocForm : Form
    {
        private String mPath;
        private String mHMAC;
        private String mSHA1;
        private String mCurrentVersion;
        private String mPrevVersion;
        private String[] mRevisionLines;
        private StreamReader mInfile;
        private List<String> mSigFileData;
        private List<String> mRevisionData;

        public String[] RevisionLines
        {
            set
            {
                mRevisionLines = value;
            }
        }
        public String CurrentVersion
        {
            set
            {
                mCurrentVersion = value;
            }
        }
        public String PreviousVersion
        {
            set
            {
                mPrevVersion = value;
            }
        }

        public ModDocForm()
        {
            InitializeComponent();
            mPath = "";
            mHMAC = "";
            mSHA1 = "";
            mCurrentVersion = "";
            mPrevVersion = "N/A";
            mSigFileData = new List<string>();
            mRevisionData = new List<string>();
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (fbdBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mPath = fbdBrowser.SelectedPath;
                lSelectedFolder.Text = mPath;
                getSignatures();
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

        private void getSignatures()
        {
            String[] pathParts = mPath.Split('\\');
            String[] folderParts = pathParts[pathParts.Length - 1].Split();
            tbCurrentVersion.Text = folderParts[folderParts.Length - 2];
            String gameSigFile = mPath + "\\" + tbCurrentVersion.Text + ".txt";
            mSigFileData.Clear();
            try
            {
                this.mInfile = new System.IO.StreamReader(gameSigFile);
            }
            catch (Exception fileEx)
            {
                System.Windows.Forms.MessageBox.Show(fileEx.Message.ToString() + " :\n" + gameSigFile, "File error");
            }
            int zero = 0;
            while (this.mInfile.Peek() > zero)
            {
                mSigFileData.Add(mInfile.ReadLine());
            }
            if (mSigFileData.Count > 2)
            {
                if (mSigFileData[2].Length > 0)
                    mSHA1 = mSigFileData[2].Split(':').GetValue(1).ToString().Trim();
                else
                {
                    System.Windows.Forms.MessageBox.Show("The version data file did not contain a valid SHA1 hash value.", "File read error");
                    return;
                }
                if (mSigFileData[3].Length > 0)
                    mHMAC = mSigFileData[3].Split(':').GetValue(1).ToString().Trim();
                else
                {
                    System.Windows.Forms.MessageBox.Show("The version data file did not contain a valid HMAC-SHA1 hash value.", "File read error");
                    return;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("The version data file did not contain valid data.", "File read error");
                return;
            }
            mInfile.Close();
        }

        private void addRevisions()
        {
            // load mod doc data from revision.txt contents
            mRevisionData.Clear();

            if (mRevisionData.Count < 1)
            {
                foreach(String l in mRevisionLines)
                {
                    mRevisionData.Add(l);
                }
            }
            for (int i = 0; i < mRevisionData.Count; i++)
            {
                if ( mRevisionData[i] != null && (mRevisionData[i].StartsWith("//") || mRevisionData[i].StartsWith("Previous Version:", true, null)) )
                {
                    // this is a header block.  Lets see if we need to keep reading
                    if (!blockIsRelevant(mRevisionData[i], tbPrevVersion.Text))
                        break;
                    i += 6;
                }
                if ( i < mRevisionData.Count )
                    tbModDocPreview.AppendText(mRevisionData[i] + Environment.NewLine);
            }
        }

        private bool blockIsRelevant(String text, String targetVersion)
        {
            if (targetVersion == "None" || targetVersion == "N/A")
                return true;

            bool relevant = false;
            String[] textParts = text.Split(':');
            String ver = textParts[1].Trim();
            if (String.CompareOrdinal(ver, targetVersion) >= 0)
                relevant = true;
            return relevant;
        }

        private void writeFile()
        {
            if (!Directory.Exists(mPath + @"\Documentation\moddoc"))
                Directory.CreateDirectory(mPath + @"\Documentation\moddoc");
            using (StreamWriter outfile = new StreamWriter(mPath + @"\Documentation\moddoc\moddoc.txt", false))
            {
                foreach (String line in tbModDocPreview.Lines)
                    outfile.WriteLine(line.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDoc();
            addRevisions();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            writeFile();
        }

        private void ModDocForm_Shown(object sender, EventArgs e)
        {
            tbCurrentVersion.Text = mCurrentVersion;
            tbPrevVersion.Text = mPrevVersion;
        }
    }
}
