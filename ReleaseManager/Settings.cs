using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ReleaseManager
{
    public partial class Settings : Form
    {
        private String m_strSvnUser;
        private String m_strSvnPassword;
        private String m_strTempPath;
        private bool m_boolSVNAutoLogin;
        private RegistryKey m_keyCurrentUser;
        private RegistryKey m_keySettings;

        # region Accessors

        public String User
        {
            get
            {
                return m_strSvnUser;
            }
        }
        public String Password
        {
            get
            {
                return m_strSvnPassword;
            }
        }
        public String Path
        {
            get
            {
                return m_strTempPath;
            }
        }
        public bool AutoLogin
        {
            get
            {
                return m_boolSVNAutoLogin;
            }
        }

        # endregion

        public Settings()
        {
            InitializeComponent();
        }

        private void bTempBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowseDlg.ShowDialog() == DialogResult.OK)
            {
                tbTempPath.Text = folderBrowseDlg.SelectedPath;
                m_keyCurrentUser.SetValue("TempFolder", tbTempPath.Text);
            }
        }

        public void initializeSettings()
        {
            try
            {
                if (Registry.CurrentUser != null)
                {
                    this.m_keyCurrentUser = Registry.CurrentUser;
                    String[] subKeys = m_keyCurrentUser.GetSubKeyNames();
                    bool found = false;
                    foreach (String key in subKeys)
                    {
                        if (key == "Software\\SHFL\\Applications\\ReleaseManager")
                            found = true;
                    }
                    if (found)
                    {
                        m_keySettings = m_keyCurrentUser.OpenSubKey("Software\\SHFL\\Applications\\ReleaseManager");
                    }
                    else
                    {
                        m_keySettings = m_keyCurrentUser.CreateSubKey("Software\\SHFL\\Applications\\ReleaseManager", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    }
                }
            }
            catch (Exception rException)
            {
                System.Windows.Forms.MessageBox.Show("Error code:\n" + rException.Message.ToString(), "Error Accessing Registry", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            if (m_keySettings.GetValue("TempFolder") != null)
            {
                tbTempPath.Text = m_keySettings.GetValue("TempFolder").ToString();
                m_strTempPath = tbTempPath.Text;
            }
            if (m_keySettings.GetValue("SVNUserName") != null)
            {
                tbSVNUserName.Text = m_keySettings.GetValue("SVNUserName").ToString();
                m_strSvnUser = tbSVNUserName.Text;
            }
            if (m_keySettings.GetValue("SVNPassword") != null)
            {
                tbSVNPassword.Text = m_keySettings.GetValue("SVNPassword").ToString();
                m_strSvnPassword = tbSVNPassword.Text;
            }
            if (m_keySettings.GetValue("SVNAutoLogin") != null)
            {
                cbSVNAutoLogin.Checked = Convert.ToBoolean(m_keySettings.GetValue("SVNAutoLogin").ToString());
                m_boolSVNAutoLogin = cbSVNAutoLogin.Checked;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            m_keySettings.SetValue("TempFolder", tbTempPath.Text);
            m_strTempPath = tbTempPath.Text;
            m_keySettings.SetValue("SVNUserName", tbSVNUserName.Text);
            m_strSvnUser = tbSVNUserName.Text;
            m_keySettings.SetValue("SVNPassword", tbSVNPassword.Text);
            m_strSvnPassword = tbSVNPassword.Text;
            m_keySettings.SetValue("SVNAutoLogin", cbSVNAutoLogin.Checked.ToString());
            m_boolSVNAutoLogin = cbSVNAutoLogin.Checked;
        }

        private void bTempBrowse_Click_1(object sender, EventArgs e)
        {
            if (folderBrowseDlg.ShowDialog() == DialogResult.OK)
            {
                tbTempPath.Text = folderBrowseDlg.SelectedPath;
            }
        }
    }
}
