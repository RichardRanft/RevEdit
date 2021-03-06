﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using Microsoft.Win32.SafeHandles;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace RevEdit
{
    public partial class ModDocForm : Form
    {
        private String mPath;
        private String mHMAC;
        private String mSHA1;
        private String mCurrentVersion;
        private String mPrevVersion;
        private String mLastLabel;
        private String[] mRevisionLines;
        private StreamReader mInfile;
        private List<String> mSigFileData;
        private List<String> mRevisionData;
        private ReleaseInfoManager mReleaseManager;
        private ReleaseForm mReleaseForm;

        #region Accessors

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
        public String LastLabel
        {
            set
            {
                mLastLabel = value;
            }
        }
        public String DataPath
        {
            set
            {
                mReleaseManager.Path = value;
                updateMarkets();
            }
        }

        #endregion

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword,
            int dwLogonType, int dwLogonProvider, out SafeTokenHandle phToken);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        public ModDocForm()
        {
            InitializeComponent();
            mPath = "";
            mHMAC = "";
            mSHA1 = "";
            mCurrentVersion = "";
            mPrevVersion = "N/A";
            mLastLabel = "";
            mSigFileData = new List<string>();
            mRevisionData = new List<string>();
            mReleaseManager = new ReleaseInfoManager();
            mReleaseForm = new ReleaseForm();
            mReleaseForm.DataManager = mReleaseManager;
        }

        private void bBrowse_Click(object sender, EventArgs e)
        {
            if (fbdBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                mPath = fbdBrowser.SelectedPath;
                lSelectedFolder.Text = mPath;
                getSignatures();
                bRelease.Enabled = true;
                bImport.Enabled = true;
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
            String[] pathParts = mPath.Split('\\');
            String gameFolder = pathParts[pathParts.Length - 1];
            String sharePath = @"\\LVSERVER2\Electronic Games\Engineering\Software\Release\EGM\PC4\NorthAmerica\";
            String docPath = System.IO.Path.Combine(sharePath, gameFolder);
            String docFolder = @"\Documentation\moddoc\";
            String targetPath = docPath + docFolder;
            String dirPath = docPath + docFolder;
            String fileName = "moddoc.txt";
            String txtFilePath = System.IO.Path.Combine(dirPath, fileName);
            try
            {
                SafeTokenHandle handle;
                const int LOGON32_PROVIDER_DEFAULT = 0;
                const int LOGON32_LOGON_INTERACTIVE = 2;

                bool loginSucceeded = LogonUser("S_BuildAgent", "SHUFFLE", "buildRD1!",
                    LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, out handle);
                if (!loginSucceeded)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }
                using (handle)
                {
                    using (WindowsIdentity newID = new WindowsIdentity(handle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonator = newID.Impersonate())
                        {
                            if (!Directory.Exists(targetPath))
                            {
                                Directory.CreateDirectory(targetPath);
                            }
                            using (StreamWriter outfile = new StreamWriter(txtFilePath, false))
                            {
                                foreach (String line in tbModDocPreview.Lines)
                                    outfile.WriteLine(line.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + dirPath, "Network Connection Failure", MessageBoxButtons.OK);
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
            bRelease.Enabled = false;
            bImport.Enabled = false;
            mReleaseManager.Read();
            updateMarkets();
        }

        private void updateMarkets()
        {
            cbMarket.Items.Clear();
            foreach (ReleaseDataItem item in mReleaseManager.Items)
            {
                bool itemFound = false;
                foreach (String entry in cbMarket.Items)
                {
                    if (item.Market == entry)
                    {
                        itemFound = true;
                        break;
                    }
                }
                if (!itemFound)
                    cbMarket.Items.Add(item.Market);
            }
        }

        private void updateMarkets(String gameName)
        {
            cbMarket.Items.Clear();
            foreach (ReleaseDataItem item in mReleaseManager.Items)
            {
                bool itemFound = false;
                foreach (String entry in cbMarket.Items)
                {
                    if (item.Market == entry && item.SoftwareName == gameName)
                    {
                        itemFound = true;
                        break;
                    }
                }
                if (!itemFound)
                    cbMarket.Items.Add(item.Market);
            }
        }

        private void bRelease_Click(object sender, EventArgs e)
        {
            tbReleaseVersion.Text = tbCurrentVersion.Text;
            lReleasedLabel.Text = mLastLabel;
            dtpReleaseDate.Value = DateTime.Now;

            mReleaseForm.GameName = tbName.Text;
            mReleaseForm.Platform = tbCurrentPlatform.Text;
            mReleaseForm.Version = tbCurrentVersion.Text;
            mReleaseForm.Market = cbMarket.Text;
            mReleaseForm.Label = mLastLabel;
            mReleaseForm.Date = dtpReleaseDate.Text;
            if (mReleaseForm.ShowDialog() == DialogResult.OK)
            {
                // if the release manager can't add the release data bail out.
                if (!mReleaseManager.Release(mReleaseForm.Market,
                    mReleaseForm.GameName,
                    mReleaseForm.Version,
                    mReleaseForm.Label,
                    mReleaseForm.Platform,
                    mReleaseForm.Date,
                    this.mSHA1,
                    this.mHMAC,
                    mReleaseForm.ReleaseNotes,
                    ReleaseStatus.TESTING,
                    false))
                return;
            }
            mReleaseManager.Write();
            updateMarkets();
            refreshReleaseData();
        }

        private void cbMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Find the latest submission of this title for the selected market and update the 
            // form fields with the release information.
            refreshReleaseData();
        }

        private void refreshReleaseData()
        {
            ReleaseDataItem item = mReleaseManager.GetLatestRevision(tbName.Text, cbMarket.Text);
            if (item != null)
            {
                tbReleaseVersion.Text = item.Version;
                lReleasedLabel.Text = item.ReleaseLabel;
                return;
            }
            tbReleaseVersion.Text = "";
            lReleasedLabel.Text = "";
        }
    }

    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }

        [DllImport("kernel32.dll")]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [SuppressUnmanagedCodeSecurity]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr handle);

        protected override bool ReleaseHandle()
        {
            return CloseHandle(handle);
        }
    }
}
