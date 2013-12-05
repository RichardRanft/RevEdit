using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReleaseManager
{
    public partial class MainForm : Form
    {
        private Settings settingsBox;
        private SVNServices svnProvider;
        private ReleaseInfoManager mManager;
        private bool mIsConnected;

        public MainForm()
        {
            InitializeComponent();
            settingsBox = new Settings();
            svnProvider = new SVNServices();
            mManager = new ReleaseInfoManager();

            initialize();
        }

        private void initialize()
        {
            settingsBox.initializeSettings();
            mManager.Path = settingsBox.Path;

            if (settingsBox.AutoLogin)
            {
                login();
            }
        }

        private bool login()
        {
            if (!mIsConnected)
            {
                // log in to the Subversion server and get the releasedata.xml file
                if (svnProvider == null)
                {
                    svnProvider = new SVNServices();
                }
                svnProvider.UserName = settingsBox.User;
                svnProvider.Password = settingsBox.Password;
                svnProvider.LocalPath = settingsBox.Path;
                svnProvider.ParentForm = this;
                if (svnProvider.Login())
                {
                    if (svnProvider.Update())
                    {
                        mIsConnected = true;
                        connectToolStripMenuItem.Text = "Disconnect";
                        mManager.Read();
                        updateSoftwareData();
                        return true;
                    }
                }
            }
            return false;
        }

        private void logout()
        {
            if (mIsConnected)
            {
                mIsConnected = false;
                connectToolStripMenuItem.Text = "Connect";
                mManager.Write();
                svnProvider.Commit();
                svnProvider.Disconnect();
                System.IO.FileInfo file = new System.IO.FileInfo(settingsBox.Path + @"\releasedata.xml");
                if (file.Exists)
                    file.Delete();
            }
        }

        private void refreshTitles()
        {
            cbSoftwareName.Items.Clear();
            foreach (String title in mManager.GetAllTitles())
            {
                cbSoftwareName.Items.Add(title);
            }
        }

        private void updateSoftwareData()
        {
            cbMarket.Items.Clear();
            cbMarket.Text = "";
            cbPlatform.Items.Clear();
            cbPlatform.Text = "";
            foreach (String m in mManager.GetAllMarkets())
            {
                cbMarket.Items.Add(m);
            }
            foreach (String p in mManager.GetAllPlatforms())
            {
                cbPlatform.Items.Add(p);
            }
            foreach (String t in mManager.GetAllTitles())
            {
                cbSoftwareName.Items.Add(t);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logout();
            Application.Exit();
        }

        private void ckbIsPlatform_CheckedChanged(object sender, EventArgs e)
        {
            cbPlatform.Enabled = !ckbIsPlatform.Checked;
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsBox.ShowDialog();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connectToolStripMenuItem.Text == "Disconnect")
                logout();
            else
                login();
        }

        private void cbSoftwareName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMarket.Items.Clear();
            cbMarket.Text = "";
            cbPlatform.Items.Clear();
            cbPlatform.Text = "";
            cbSoftwareVersion.Items.Clear();
            cbSoftwareVersion.Text = "";
            foreach (String m in mManager.GetAllMarketsByGame(cbSoftwareName.Text))
            {
                cbMarket.Items.Add(m);
            }
            foreach (String p in mManager.GetAllPlatformsByGame(cbSoftwareName.Text))
            {
                cbPlatform.Items.Add(p);
            }
            foreach (String v in mManager.GetAllVersionsByTitle(cbSoftwareName.Text))
            {
                cbSoftwareVersion.Items.Add(v);
            }
            cbSoftwareVersion.SelectedIndex = 0;
            cbMarket.SelectedIndex = 0;
            cbPlatform.SelectedIndex = 0;
        }

        private void cbSoftwareVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMarket.Text != "")
            {
                ReleaseDataItem item = mManager.FindItem(cbSoftwareVersion.Text, cbMarket.Text);
                if (item == null)
                {
                    cbReleaseStatus.SelectedIndex = 0;
                    tbHMAC.Text = "";
                    tbSHA1.Text = "";
                    cbPlatform.SelectedIndex = 0;
                    ckbIsPlatform.Checked = false;
                    tbReleaseNotes.Text = "";
                    tbLabel.Text = "";
                    return;
                }
                cbReleaseStatus.SelectedIndex = item.GetStatus();
                tbHMAC.Text = item.HMAC;
                tbSHA1.Text = item.SHA1;
                cbPlatform.SelectedIndex = cbPlatform.FindString(item.Platform);
                ckbIsPlatform.Checked = item.IsPlatform;
                tbReleaseNotes.Text = item.Notes;
                tbLabel.Text = item.ReleaseLabel;
                dtpReleaseDate.Value = DateTime.Parse(item.ReleaseDate);
                return;
            }
            cbReleaseStatus.SelectedIndex = 0;
            tbHMAC.Text = "";
            tbSHA1.Text = "";
            cbPlatform.SelectedIndex = 0;
            ckbIsPlatform.Checked = false;
            tbReleaseNotes.Text = "";
            tbLabel.Text = "";
        }

        private void cbReleaseStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSoftwareVersion.Text != "")
            {
                ReleaseDataItem item = mManager.FindItem(cbSoftwareVersion.Text, cbMarket.Text);
                if (item == null)
                {
                    cbReleaseStatus.SelectedIndex = 0;
                    tbHMAC.Text = "";
                    tbSHA1.Text = "";
                    cbPlatform.SelectedIndex = 0;
                    ckbIsPlatform.Checked = false;
                    tbReleaseNotes.Text = "";
                    tbLabel.Text = "";
                    return;
                }
                cbReleaseStatus.SelectedIndex = item.GetStatus();
                tbHMAC.Text = item.HMAC;
                tbSHA1.Text = item.SHA1;
                cbPlatform.SelectedIndex = cbPlatform.FindString(item.Platform);
                ckbIsPlatform.Checked = item.IsPlatform;
                tbReleaseNotes.Text = item.Notes;
                tbLabel.Text = item.ReleaseLabel;
                dtpReleaseDate.Value = DateTime.Parse(item.ReleaseDate);
                return;
            }
            cbReleaseStatus.SelectedIndex = 0;
            tbHMAC.Text = "";
            tbSHA1.Text = "";
            cbPlatform.SelectedIndex = 0;
            ckbIsPlatform.Checked = false;
            tbReleaseNotes.Text = "";
            tbLabel.Text = "";
        }

        private void tbReleaseNotes_TextChanged(object sender, EventArgs e)
        {

        }

        private ReleaseStatus translateToStatus(int value)
        {
            ReleaseStatus status = ReleaseStatus.NONE;
            switch (cbReleaseStatus.SelectedIndex)
            {
                case 0:
                    status = ReleaseStatus.NONE;
                    break;
                case 1:
                    status = ReleaseStatus.DEVELOPMENT;
                    break;
                case 2:
                    status = ReleaseStatus.TESTING;
                    break;
                case 3:
                    status = ReleaseStatus.SUBMITTED;
                    break;
                case 4:
                    status = ReleaseStatus.APPROVED;
                    break;
            }
            return status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mIsConnected)
            {

                // If this is a platform release ensure that the platform text is the same as 
                // the software version.
                if (ckbIsPlatform.Checked)
                    cbPlatform.Text = cbSoftwareVersion.Text;

                if (mManager.Release(cbMarket.Text,
                    cbSoftwareName.Text,
                    cbSoftwareVersion.Text,
                    tbLabel.Text,
                    cbPlatform.Text,
                    dtpReleaseDate.Value.ToShortDateString(),
                    tbSHA1.Text,
                    tbHMAC.Text,
                    tbReleaseNotes.Text,
                    translateToStatus(cbReleaseStatus.SelectedIndex),
                    ckbIsPlatform.Checked))
                {
                    mManager.Write();
                    svnProvider.Commit();
                }
                updateSoftwareData();
                refreshTitles();
            }
        }
    }
}
