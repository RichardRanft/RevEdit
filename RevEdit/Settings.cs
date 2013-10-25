using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private bool m_boolAutoLogin;
        private RegistryKey m_keyCurrentUser;

        # region Accessors

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
                    this.m_keyCurrentUser = Registry.CurrentUser;
            }
            catch (Exception rException)
            {
                System.Windows.Forms.MessageBox.Show("Error code:\n" + rException.Message.ToString(), "Error Accessing Registry", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            validateKey();
            if (m_keyCurrentUser.GetValue("TempFolder") != null)
            {
                tbTempPath.Text = m_keyCurrentUser.GetValue("TempFolder").ToString();
                m_strTempPath = tbTempPath.Text;
            }
            if (m_keyCurrentUser.GetValue("UserName") != null)
            {
                tbUserName.Text = m_keyCurrentUser.GetValue("UserName").ToString();
                m_strUser = tbUserName.Text;
            }
            if (m_keyCurrentUser.GetValue("Password") != null)
            {
                tbPassword.Text = m_keyCurrentUser.GetValue("Password").ToString();
                m_strPassword = tbPassword.Text;
            }
            if (m_keyCurrentUser.GetValue("AutoLogin") != null)
            {
                cbAutoLogin.Checked = Convert.ToBoolean(m_keyCurrentUser.GetValue("AutoLogin").ToString());
                m_boolAutoLogin = cbAutoLogin.Checked;
            }
        }

        private void validateKey()
        {
            String[] names = m_keyCurrentUser.GetSubKeyNames();
            bool found = false;
            foreach (String s in names)
            {
                if (s == "Software\\Microsoft\\SHFL\\Applications\\RevEdit")
                    found = true;
            }
            if (!found)
            {
                m_keyCurrentUser.CreateSubKey("Software\\Microsoft\\SHFL\\Applications\\RevEdit", RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            m_keyCurrentUser.SetValue("TempFolder", tbTempPath.Text);
            m_strTempPath = tbTempPath.Text;
            m_keyCurrentUser.SetValue("UserName", tbUserName.Text);
            m_strUser = tbUserName.Text;
            m_keyCurrentUser.SetValue("Password", tbPassword.Text);
            m_strPassword = tbPassword.Text;
            m_keyCurrentUser.SetValue("AutoLogin", cbAutoLogin.Checked.ToString());
            m_boolAutoLogin = cbAutoLogin.Checked;
        }
    }
}
