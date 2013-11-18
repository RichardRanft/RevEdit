using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RevEdit
{
    public partial class Settings : Form
    {
        private String m_strUser;
        private String m_strPassword;
        private String m_strTempPath;
        private String m_strAuthor;
        private bool m_boolAutoLogin;
        private RegistryKey m_keyCurrentUser;
        private RegistryKey m_keySettings;

        # region Accessors

        public String Author
        {
            get
            {
                return m_strAuthor;
            }
        }
        public String User
        {
            get
            {
                return m_strUser;
            }
        }
        public String Password
        {
            get
            {
                return m_strPassword;
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
                return m_boolAutoLogin;
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
                        if (key == "Software\\SHFL\\Applications\\RevEdit")
                            found = true;
                    }
                    if (found)
                    {
                        m_keySettings = m_keyCurrentUser.OpenSubKey("Software\\SHFL\\Applications\\RevEdit");
                    }
                    else
                    {
                        m_keySettings = m_keyCurrentUser.CreateSubKey("Software\\SHFL\\Applications\\RevEdit", RegistryKeyPermissionCheck.ReadWriteSubTree);
                    }
                }
            }
            catch (Exception rException)
            {
                System.Windows.Forms.MessageBox.Show("Error code:\n" + rException.Message.ToString(), "Error Accessing Registry", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            if (m_keySettings.GetValue("Author") != null)
            {
                tbAuthor.Text = m_keySettings.GetValue("Author").ToString();
                m_strAuthor = tbAuthor.Text;
            }
            if (m_keySettings.GetValue("TempFolder") != null)
            {
                tbTempPath.Text = m_keySettings.GetValue("TempFolder").ToString();
                m_strTempPath = tbTempPath.Text;
            }
            if (m_keySettings.GetValue("UserName") != null)
            {
                tbUserName.Text = m_keySettings.GetValue("UserName").ToString();
                m_strUser = tbUserName.Text;
            }
            if (m_keySettings.GetValue("Password") != null)
            {
                tbPassword.Text = m_keySettings.GetValue("Password").ToString();
                m_strPassword = tbPassword.Text;
            }
            if (m_keySettings.GetValue("AutoLogin") != null)
            {
                cbAutoLogin.Checked = Convert.ToBoolean(m_keySettings.GetValue("AutoLogin").ToString());
                m_boolAutoLogin = cbAutoLogin.Checked;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            m_keySettings.SetValue("Author", tbAuthor.Text);
            m_strAuthor = tbAuthor.Text;
            m_keySettings.SetValue("TempFolder", tbTempPath.Text);
            m_strTempPath = tbTempPath.Text;
            m_keySettings.SetValue("UserName", tbUserName.Text);
            m_strUser = tbUserName.Text;
            m_keySettings.SetValue("Password", tbPassword.Text);
            m_strPassword = tbPassword.Text;
            m_keySettings.SetValue("AutoLogin", cbAutoLogin.Checked.ToString());
            m_boolAutoLogin = cbAutoLogin.Checked;
        }
    }
}
