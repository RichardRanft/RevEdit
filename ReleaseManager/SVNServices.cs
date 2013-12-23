using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;
using SharpSvn.UI;
using System.Windows.Forms;

namespace ReleaseManager
{
    class SVNServices
    {
        private SharpSvn.SvnClient m_client;

        private String m_strUser;
        private String m_strPassword;
        private String m_strRepository;
        private String m_strServer;
        private int m_nPort;
        private SvnUriTarget m_uriRepository;
        private String m_strCheckoutPath;
        private bool m_initialized;
        private bool m_loggedIn;
        private MainForm main;

        #region Accessors
        
        public String UserName
        {
            get
            {
                return m_strUser;
            }
            set
            {
                m_strUser = value;
            }
        }

        public String Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value;
            }
        }

        public String Repository
        {
            get
            {
                return m_strRepository;
            }
            set
            {
                m_strRepository = value;
                m_uriRepository = new Uri(GetURLString());
            }
        }

        public int Port
        {
            get
            {
                return m_nPort;
            }
            set
            {
                m_nPort = value;
                m_uriRepository = new Uri(GetURLString());
            }
        }

        public String Server
        {
            get
            {
                return m_strServer;
            }
            set
            {
                m_strServer = value;
                m_uriRepository = new Uri(GetURLString());
            }
        }

        public String LocalPath
        {
            get
            {
                return m_strCheckoutPath;
            }
            set
            {
                m_strCheckoutPath = value;
            }
        }

        public String URI
        {
            get
            {
                return m_uriRepository.ToString();
            }
        }

        public bool Initialized
        {
            get
            {
                return m_initialized;
            }
        }

        public bool Connected
        {
            get
            {
                return m_loggedIn;
            }
        }

        public MainForm ParentForm
        {
            set
            {
                main = value;
            }
            get
            {
                return main;
            }
        }

        #endregion

        public SVNServices()
        {
            m_client = null;
            m_strUser = "";
            m_strPassword = "";
            m_strServer = "http://192.168.4.148";
            m_strRepository = "/svn/ReleaseData/trunk";
            m_strCheckoutPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            m_nPort = 18080;
            m_initialized = false;
            m_loggedIn = false;
        }

        public SVNServices(String userName, String password, String repository, String checkoutPath)
        {
            m_strUser = userName;
            m_strPassword = password;
            m_strServer = "http://192.168.4.148";
            m_strRepository = repository;
            m_nPort = 18080;
            m_strCheckoutPath = checkoutPath;
            m_initialized = true;
            m_loggedIn = false;
        }

        private String GetURLString()
        {
            return (m_strServer + ":" + m_nPort.ToString() + m_strRepository);
        }

        private bool Initialize(String user, String password)
        {
            if (m_strUser == "" && m_strPassword == "")
                return false;
            m_uriRepository = new SvnUriTarget(GetURLString());
            m_initialized = true;
            return true;
        }

        public bool Login()
        {
            Initialize(m_strUser, m_strPassword);
            if (m_initialized)
            {
                using (m_client = new SvnClient())
                {
                    m_client.Authentication.Clear();
                    m_client.Authentication.DefaultCredentials = new System.Net.NetworkCredential(m_strUser, m_strPassword);
                    m_client.Authentication.SslServerTrustHandlers += delegate(object sender, SharpSvn.Security.SvnSslServerTrustEventArgs e)
                    {
                        e.AcceptedFailures = e.Failures;
                        e.Save = true; // save acceptance to authentication store
                    };
                    System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
                    SvnLogArgs logArgs = new SvnLogArgs();
                    logArgs.Limit = 1;
                    try
                    {
                        m_client.GetLog(m_uriRepository.Uri, logArgs, out logEntries);
                        m_loggedIn = true;
                    }
                    catch (SvnException ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message, "SVN Connect Error", System.Windows.Forms.MessageBoxButtons.OK);
                        m_loggedIn = false;
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public bool Update()
        {
            if (m_loggedIn)
            {
                if (m_client == null || m_client.IsDisposed)
                    m_client = new SvnClient();
                if (m_strCheckoutPath == "")
                    return false;
                try
                {
                    SvnCheckOutArgs args = new SvnCheckOutArgs();
                    args.Depth = SvnDepth.Files;
                    args.IgnoreExternals = true;
                    m_client.CheckOut(m_uriRepository, m_strCheckoutPath, args);
                }
                catch (SvnException ex)
                {
                    String Msg = ex.Message + Environment.NewLine + Environment.NewLine +
                        "Host: " + m_uriRepository.Uri.Host + Environment.NewLine +
                        "Port: " + m_uriRepository.Uri.Port + Environment.NewLine +
                        "Path: " + m_uriRepository.Uri.AbsolutePath;
                        
                    System.Windows.Forms.MessageBox.Show(Msg, "SVN Login Error", System.Windows.Forms.MessageBoxButtons.OK);
                    m_loggedIn = false;
                    return false;
                }
                try
                {
                    m_client.Update(m_strCheckoutPath);
                }
                catch (SvnException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "SVN Update Error", System.Windows.Forms.MessageBoxButtons.OK);
                    m_loggedIn = false;
                    return false;
                }
                return true;
            }
            return false;
        }

        public bool Commit()
        {
            if (!m_loggedIn)
                return false;
            using (m_client = new SvnClient())
            {
                m_client.Authentication.Clear();
                m_client.Authentication.DefaultCredentials = new System.Net.NetworkCredential(m_strUser, m_strPassword);
                m_client.Authentication.SslServerTrustHandlers += delegate(object sender, SharpSvn.Security.SvnSslServerTrustEventArgs e)
                {
                    e.AcceptedFailures = e.Failures;
                    e.Save = true; // save acceptance to authentication store
                };
                System.Collections.ObjectModel.Collection<SvnLogEventArgs> logEntries;
                SvnLogArgs logArgs = new SvnLogArgs();
                logArgs.Limit = 1;
                try
                {
                    m_client.GetLog(m_uriRepository.Uri, logArgs, out logEntries);
                    m_loggedIn = true;
                }
                catch (SvnException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "SVN Connect Error", System.Windows.Forms.MessageBoxButtons.OK);
                    m_loggedIn = false;
                    return false;
                }
                try
                {
                    SvnCommitArgs args = new SvnCommitArgs();
                    args.LogMessage = "Update release data " + DateTime.Now.ToString();
                    args.Depth = SvnDepth.Infinity;
                    return m_client.Commit(m_client.GetWorkingCopyRoot(m_strCheckoutPath), args);
                }
                catch (SvnException ex)
                {
                    String msg = ex.Message + Environment.NewLine + Environment.NewLine +
                        ex.StackTrace.ToString();
                    System.Windows.Forms.MessageBox.Show(ex.Message, "SVN Commit Error", System.Windows.Forms.MessageBoxButtons.OK);
                    return false;
                }
            }
        }

        public bool Disconnect()
        {
            if (!m_loggedIn)
                return true;
            using (m_client = new SvnClient())
            {
                try
                {
                    m_client.CleanUp(m_strCheckoutPath);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "SVN Disconnect Error", System.Windows.Forms.MessageBoxButtons.OK);
                    m_loggedIn = false;
                    return false;
                }
                m_client.Authentication.Clear();
            }
            return true;
        }
    }
}
