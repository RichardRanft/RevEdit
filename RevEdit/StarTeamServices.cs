using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Windows.Forms;

using StarTeam;
using StarTeam.Exceptions;
using Type = StarTeam.Type;

namespace RevEdit
{    
    class StarTeamServices
    {
        // Indicates that all item types should be displayed.
        public const string ALL_TYPES = "*";

        // Indicates that all views should be searched.
        public const string ALL_VIEWS = "*";

        private string m_strServer = "localhost";		// Server TCP/IP address
        private int m_nPort = 49201;					// Server port number
        private string m_strUser = "Administrator";		// Logon user name
        private string m_strPassword = "Administrator";	// Logon password
        private string m_strProject = null;				// Project name; null searches all projects
        private string m_strView = null;				// View name; null searches default view
        private string m_strFolder = null;				// Folder path; null searches the root folder
        private bool m_bRecursive = true;				// true if subfolders are searched recursively
        private String m_tempFilePath = Environment.CurrentDirectory;
        private String m_bnBuildID;

        // Item Type Names specified on the command line.
        private StringCollection m_strTypeNames = new StringCollection();

        // Resolved (Name, Type) pairs for Item Types to be searched.
        private SortedList m_stItemTypes = new SortedList();

        private DateTime m_cutoffDate = DateTime.Now;	// List items last modified since this date
        private bool m_bUseDateFilter = false;			// True to filter by m_cuttoffDate

        StarTeam.Server m_server;
        File m_revisionFile;
        File m_releaseDataFile;

        # region Accessors

        public DateTime CutoffDate
        {
            get
            {
                return m_cutoffDate;
            }
            set
            {
                m_cutoffDate = value;
            }
        }
        public bool UseDateFilter
        {
            get
            {
                return m_bUseDateFilter;
            }
            set
            {
                m_bUseDateFilter = value;
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
            }
        }
        public String SDKBuildNumber
        {
            get
            {
                if (m_bnBuildID == null || m_bnBuildID == "")
                    m_bnBuildID = StarTeam.BuildNumber.BuildString;
                return m_bnBuildID;
            }
        }
        public String TempFilePath
        {
            get
            {
                return m_tempFilePath;
            }
            set
            {
                m_tempFilePath = value;
            }
        }
        public bool Recursive
        {
            get
            {
                return m_bRecursive;
            }
            set
            {
                m_bRecursive = value;
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
            }
        }
        public String User
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
        public String Project
        {
            get
            {
                return m_strProject;
            }
            set
            {
                m_strProject = value;
            }
        }
        public String View
        {
            get
            {
                return m_strView;
            }
            set
            {
                m_strView = value;
            }
        }

        # endregion

        private StarTeam.ServerInfo SetServerInfo()
        {
            StarTeam.ServerInfo info = new ServerInfo();
            info.Host = m_strServer;
            info.Port = m_nPort;
            info.UserName = m_strUser;
            info.Password = m_strPassword;
            return info;
        }

        // Creates a StarTeam server object, connects to the server, and logs in.
        // Returns the resulting Server object.
        public Server GetServer()
        {
            // Simplest constructor, uses default encryption algorithm and compression level.
            m_bnBuildID = StarTeam.BuildNumber.BuildString;

            if (m_server == null)
            {
                try
                {
                    m_server = new Server(SetServerInfo());//new StarTeam.Server(SetServerInfo());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server Not Initialized");
                    return null;
                }
            }

            // Optional; logOn() connects if necessary.
            m_server.Connect();

            // Logon using specified user name and password.
            m_server.LogOn(m_strUser, m_strPassword);

            return (m_server);
        }

        public bool logIn()
        {
            // Create the Server object.
            m_bnBuildID = StarTeam.BuildNumber.BuildString;

            if (m_server == null)
            {
                try
                {
                    m_server = new Server(SetServerInfo());//new StarTeam.Server(SetServerInfo());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server Not Initialized");
                    return false;
                }
            }

            // LogOn to the server.
            try
            {
                m_server.LogOn(m_strUser, m_strPassword);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Problem");
                return false;
            }

            // Determine which Item Types to display.
            m_stItemTypes = ResolveItemTypes(m_server, m_strTypeNames);

            return true;
        }

        public void disconnect()
        {
            if (m_server != null)
                m_server.Disconnect();
        }

        public List<String> getProjectList()
        {
            List<String> projectList = new List<String>();
            // get a list of projects on the server
            // filter out anything that doesn't start with "PC4G"
            foreach (Project stProject in m_server.Projects)
            {
                int check = String.Compare("PC4G", 0, stProject.Name, 0, 4);
                if (check == 0)
                    projectList.Add(stProject.Name);
            }
            return projectList;
        }

        public List<String> getViewList(String project)
        {
            List<String> viewList = new List<String>();
            List<String> subViews = new List<String>();
            // get a list of views in this project
            Project stProject = m_server.FindProject(project);
            StarTeam.View[] projectViews = stProject.DefaultView.DerivedViews;

            // For each view ...
            foreach (StarTeam.View stView in projectViews)
            {
                viewList.Add(stView.Name);
                subViews = getSubviews(stView);
                if (subViews.Count > 0)
                {
                    foreach (String view in subViews)
                        viewList.Add(view);
                }
            }

            return viewList;
        }

        public List<String> getLabelList(String project, String view)
        {
            List<String> labelList = new List<String>();
            // get a list of labels
            Project stProject = m_server.FindProject(project);
            StarTeam.View stView = stProject.FindView(view);
            StarTeam.Label[] labels = stView.FetchAllLabels();

            // For each view ...
            foreach (StarTeam.Label l in labels)
            {
                labelList.Add(l.Name);
            }
            return labelList;
        }

        private StarTeam.Label[] getLabelFromSubview(StarTeam.View stView, String viewName)
        {
            // get a list of labels
            StarTeam.Label[] Labels = null;
            if (stView.Name == viewName)
            {
                Labels = stView.Labels;
            }
            StarTeam.View[] subViews = stView.DerivedViews;
            if (subViews.Length > 0)
            {
                // For each view ...
                foreach (StarTeam.View subView in subViews)
                {
                    if (subView.Name == viewName)
                    {
                        Labels = subView.Labels;
                    }
                }
            }
            return Labels;
        }

        private StarTeam.View getRootMarketView(Project stProject, StarTeam.View stView)
        {
            StarTeam.View temp = stView.ParentView;
            StarTeam.View last = stView;
            while (temp.Name != stProject.DefaultView.Name)
            {
                last = temp;
                temp = last.ParentView;
            }
                    
            return last;
        }

        private List<String> getSubviews(StarTeam.View stView)
        {
            List<String> list = new List<String>();
            if (stView.DerivedViews.Length > 0)
            {
                // For each Item Type ...
                foreach (StarTeam.View v in stView.DerivedViews)
                {
                    list.Add("  " + v.Name);
                    if (v.DerivedViews.Length > 0)
                    {
                        List<String> subList = new List<String>();
                        subList = getSubviews(v);
                    }
                }
            }
            return list;
        }

        private bool moveFileToView(StarTeam.Item file, StarTeam.View targetView)
        {
            StarTeam.Folder rootFolder = targetView.RootFolder;
            StarTeam.Folder docFolder = rootFolder.FindSubFolder("documents");
            file.MoveTo(docFolder);
            return false;
        }

        public bool checkoutRevisionFile()
        {
            StarTeam.Item revFile;
            if (getRevisionFile(m_strProject, m_strView, out revFile))
            {
                Project proj = null;
                try
                {
                    proj = m_server.FindProject(m_strProject);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "StarTeam Connection Error", MessageBoxButtons.OK);
                    return false;
                }
                StarTeam.View currentView = proj.FindView(m_strView);
                StarTeam.View view = getRootMarketView(proj, currentView);
                StarTeam.Folder rootFolder = view.RootFolder;
                StarTeam.Folder docFolder = rootFolder.FindSubFolder("documents");
                StarTeam.CheckoutManager coManager = view.CreateCheckoutManager();
                m_revisionFile = (File)revFile;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_tempFilePath + @"\revision.txt");
                coManager.CheckoutTo(m_revisionFile, fileInfo);
                return true;
            }
            return false;
        }

        public bool checkoutReleaseDataFile()
        {
            StarTeam.Item revFile;
            if (getReleaseDataFile(m_strProject, m_strView, out revFile))
            {
                Project proj = null;
                try
                {
                    proj = m_server.FindProject(m_strProject);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "StarTeam Connection Error", MessageBoxButtons.OK);
                    return false;
                }
                StarTeam.View currentView = proj.FindView(m_strView);
                StarTeam.View view = getRootMarketView(proj, currentView);
                StarTeam.Folder rootFolder = view.RootFolder;
                StarTeam.Folder docFolder = rootFolder.FindSubFolder("documents");
                StarTeam.CheckoutManager coManager = view.CreateCheckoutManager();
                m_releaseDataFile = (File)revFile;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_tempFilePath + @"\releasedata.xml");
                coManager.CheckoutTo(m_releaseDataFile, fileInfo);
                return true;
            }
            return false;
        }

        public void clearRevisionFile()
        {
            m_revisionFile = null;
        }

        public void clearReleaseDataFile()
        {
            m_releaseDataFile = null;
        }

        public bool checkinRevisionFile(String revPath)
        {
            Project proj = null;
            try
            {
                proj = m_server.FindProject(m_strProject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "StarTeam Connection Error", MessageBoxButtons.OK);
                return false;
            }
            StarTeam.View currentView = proj.FindView(m_strView);
            StarTeam.View view = getRootMarketView(proj, currentView);
            StarTeam.Folder rootFolder = view.RootFolder;
            StarTeam.Folder docFolder = rootFolder.FindSubFolder("documents");
            StarTeam.CheckinManager manager = view.CreateCheckinManager();
            if (m_revisionFile == null)
            {
                m_revisionFile = File.Create(docFolder);
                m_revisionFile.Name = "revision.txt";
            }
            System.IO.FileInfo revFile = new System.IO.FileInfo(revPath);
            try
            {
                manager.CheckinFrom(m_revisionFile, revFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "StarTeam Checkin Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        public bool checkinReleaseDataFile(String revPath)
        {
            Project proj = null;
            try
            {
                proj = m_server.FindProject(m_strProject);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "StarTeam Connection Error", MessageBoxButtons.OK);
                return false;
            }
            StarTeam.View currentView = proj.FindView(m_strView);
            StarTeam.View view = getRootMarketView(proj, currentView);
            StarTeam.Folder rootFolder = view.RootFolder;
            StarTeam.Folder docFolder = rootFolder.FindSubFolder("documents");
            StarTeam.CheckinManager manager = view.CreateCheckinManager();
            if (m_releaseDataFile == null)
            {
                m_releaseDataFile = File.Create(docFolder);
                m_releaseDataFile.Name = "releasedata.xml";
            }
            System.IO.FileInfo revFile = new System.IO.FileInfo(revPath);
            try
            {
                manager.CheckinFrom(m_releaseDataFile, revFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "StarTeam Checkin Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }

        public bool createLabel(String label, String comment)
        {
            Project proj = m_server.FindProject(m_strProject);
            StarTeam.View view = proj.FindView(m_strView);
            StarTeam.Label newLabel = view.CreateRevisionLabel(label, comment, false);

            if (newLabel != null)
                return true;

            return false;
        }

        private bool getRevisionFile(String project, String view, out StarTeam.Item item)
        {
            if (project == "" || project == null)
            {
                item = null;
                return false;
            }
            Project stProject = m_server.FindProject(project);
            if ( view == "" || view == null)
            {
                item = null;
                return false;
            }
            StarTeam.View targetView = findView(stProject, view);
            if (targetView == null)
            {
                item = null;
                return false;
            }
            item = FindInView(m_server, stProject, targetView, "revision.txt");
            if (item != null)
                return true;
            return false;
        }

        private StarTeam.Item FindInView(Server stServer, Project stProject, StarTeam.View stView, String fileName)
        {
            StarTeam.Item item = null;
            // For each Item Type ...
            foreach (DictionaryEntry e in m_stItemTypes)
            {
                Item.Type stType = (Item.Type)e.Value;
                item = FindInType(stServer, stProject, stView, stType, fileName);
            }
            return item;
        }

        private StarTeam.Item FindInFolder(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType, Folder stFolder, String fileName)
        {
            StarTeam.Item item = null;
            // For each item of the appropriate type ...
            foreach (Item stItem in stFolder.GetItems(stType))
            {
                item = FindItem(stServer, stProject, stView, stType, stFolder, stItem, fileName);
                if (item != null)
                    return item;
            }

            if (m_bRecursive)
            {
                // For each subfolder ...
                foreach (Folder stSubFolder in stFolder.SubFolders)
                {
                    item = FindInFolder(stServer, stProject, stView, stType, stSubFolder, fileName);
                    if (item != null && item.ToString() == fileName)
                        return item;
                }
            }
            return item;
        }

        private StarTeam.Item FindInType(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType, String fileName)
        {
            StarTeam.Item item = null;
            // By default, start searching from the root folder.
            Folder stFolder = stView.RootFolder;

            // If a specfic path was specified, search for it.
            if (m_strFolder != null)
            {
                Folder stTempFolder = stFolder.FindSubFolder(m_strFolder);
                if (stTempFolder == null)
                {
                    string strMessage = "Folder \"";
                    strMessage += m_strFolder;
                    strMessage += "\" not found in view \"";
                    strMessage += stView.Name;
                    strMessage += "\" of project \"";
                    strMessage += stProject.Name;
                    strMessage += "\".";
                    System.Windows.Forms.MessageBox.Show(strMessage, "Folder Not Found", MessageBoxButtons.OK);
                    return null;
                }
                stFolder = stTempFolder;
            }

            // Pre-fetch the item properties and cache them.
            int depth = (m_bRecursive ? -1 : 0);
            stFolder.Populate(stType, depth);

            // Now, search for items in the selected folder.
            item = FindInFolder(stServer, stProject, stView, stType, stFolder, fileName);
            //RunFolder(stServer, stProject, stView, stType, stFolder);
		
            // Free up the memory used by the cached items.
            stFolder.DiscardItems(stType, depth);

            return item;
        }

        private StarTeam.Item FindItem(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType, Folder stFolder, Item stItem, String fileName)
        {
            StarTeam.Item item = null;
            File temp = (File)stItem;
            if (temp.Name == fileName)
                item = stItem;
            if (stItem.ToString() == fileName)
                item = stItem;
            return item;
        }

        private bool getReleaseDataFile(String project, String view, out StarTeam.Item item)
        {
            if (project == "" || project == null)
            {
                item = null;
                return false;
            }
            Project stProject = m_server.FindProject(project);
            if (view == "" || view == null)
            {
                item = null;
                return false;
            }
            StarTeam.View targetView = findView(stProject, view);
            if (targetView == null)
            {
                item = null;
                return false;
            }
            item = FindInView(m_server, stProject, targetView, "releasedata.xml");
            if (item != null)
                return true;
            return false;
        }

        private StarTeam.View findView(Project stProject, String viewName)
        {
            for (int i = 0; i < stProject.Views.Length; i++)
            {
                if (stProject.Views[i].Name == viewName)
                    return stProject.Views[i];
                foreach (StarTeam.View subView in stProject.Views[i].DerivedViews)
                {
                    if (subView.Name == viewName)
                        return subView;
                    else
                    {
                        StarTeam.View temp = findSubView(subView, viewName);
                        if (temp == null)
                            continue;
                        if (temp.Name == viewName)
                            return temp;
                    }
                }
            }
            return null;
        }

        private StarTeam.View findSubView(StarTeam.View stView, String viewName)
        {
            foreach (StarTeam.View subView in stView.DerivedViews)
            {
                if (subView.Name == viewName)
                    return subView;
                return findSubView(subView, viewName);
            }
            return null;
        }

        // Finds the test project.
        public Project GetProject(Server s, String strName)
        {
            return s.FindProject(strName);
        }

        // ----------------------------------------------------------------------------
        // Determines the list of desired item types.
        // Returns a sorted list of (Name, Type) pairs.
        // ----------------------------------------------------------------------------
        SortedList ResolveItemTypes(Server s, StringCollection typeNames)
        {
            // If no types were specified, search only "File" by default.
            if (typeNames.Count == 0)
            {
                typeNames.Add(s.Types.FILE.Name);
            }

                // If "*" was specified, we'll search all item types.
            else if (typeNames[0] == ALL_TYPES)
            {
                // Copies them into m_strTypeNames.
                return (GetAllItemTypes(s));
            }

            SortedList dict = new SortedList();

            // Determine which of the listed types are actually Item types.
            foreach (string strType in typeNames)
            {
                Type stType = GetItemType(s, strType);
                if (stType != null)
                {
                    dict.Add(strType, stType);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("\"" + strType + "\" is not a valid item type for this server; ignored.", "Invalid Type Error", MessageBoxButtons.OK);
                }
            }

            return (dict);
        }

        // ----------------------------------------------------------------------------
        // Returns a sorted list of (Name, Type) pairs for all Item types
        // that are available on the given server. 
        // ----------------------------------------------------------------------------
        SortedList GetAllItemTypes(Server s)
        {
            SortedList dict = new SortedList();

            // For each type ...
            foreach (Type stType in s.Types)
            {
                if (stType.IsComponentType)
                {
                    dict.Add(stType.Name, stType);
                }
            }

            return (dict);
        }

        // ----------------------------------------------------------------------------
        // Returns the Type whose name is strName, if strName is a valid
        // Item Type for the given server, or null otherwise.
        // ----------------------------------------------------------------------------
        Type GetItemType(Server s, string strName)
        {
            if (s.Types.Find(strName) != null)
            {
                Type stType = s.Types.Find(strName);
                if (stType is Item.Type)
                    return (stType);
            }
            return (null);
        }

        // ----------------------------------------------------------------------------
        // Searches the given view.
        // ----------------------------------------------------------------------------
        private StarTeam.Item RunView(Server stServer, Project stProject, StarTeam.View stView)
        {
            StarTeam.Item item = null;
            // For each Item Type ...
            foreach (DictionaryEntry e in m_stItemTypes)
            {
                Item.Type stType = (Item.Type)e.Value;
                item = RunType(stServer, stProject, stView, stType);
            }
            return item;
        }

        // ----------------------------------------------------------------------------
        // Searches the given view for all relevant items of the given type.
        // ----------------------------------------------------------------------------
        private StarTeam.Item RunType(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType)
        {
            StarTeam.Item item = null;
            // By default, start searching from the root folder.
            Folder stFolder = stView.RootFolder;

            // If a specfic path was specified, search for it.
            if (m_strFolder != null)
            {
                Folder stTempFolder = stFolder.FindSubFolder(m_strFolder);
                if (stTempFolder == null)
                {
                    string strMessage = "Folder \"";
                    strMessage += m_strFolder;
                    strMessage += "\" not found in view \"";
                    strMessage += stView.Name;
                    strMessage += "\" of project \"";
                    strMessage += stProject.Name;
                    strMessage += "\".";
                    System.Windows.Forms.MessageBox.Show(strMessage, "Folder Not Found", MessageBoxButtons.OK);
                    return null;
                }
                stFolder = stTempFolder;
            }

            // Pre-fetch the item properties and cache them.
            int depth = (m_bRecursive ? -1 : 0);
            stFolder.Populate(stType, depth);

            // Now, search for items in the selected folder.
            RunFolder(stServer, stProject, stView, stType, stFolder);

            // Free up the memory used by the cached items.
            stFolder.DiscardItems(stType, depth);
            // Now, search for items in the selected folder.
            item = RunFolder(stServer, stProject, stView, stType, stFolder);

            // Free up the memory used by the cached items.
            stFolder.DiscardItems(stType, depth);

            return item;
        }

        // ----------------------------------------------------------------------------
        // Searches the given folder.
        // ----------------------------------------------------------------------------
        private StarTeam.Item RunFolder(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType, Folder stFolder)
        {
            StarTeam.Item item = null;
            // For each item of the appropriate type ...
            foreach (Item stItem in stFolder.GetItems(stType))
            {
                item = RunItem(stServer, stProject, stView, stType, stFolder, stItem);
                if (item != null)
                    return item;
            }

            if (m_bRecursive)
            {
                // For each subfolder ...
                foreach (Folder stSubFolder in stFolder.SubFolders)
                {
                    item = RunFolder(stServer, stProject, stView, stType, stSubFolder);
                    if (item != null && item.ToString() == "revision.txt")
                        return item;
                }
            }
            return item;
        }

        // ----------------------------------------------------------------------------
        // Processes the given Item.
        // ----------------------------------------------------------------------------
        private StarTeam.Item RunItem(Server stServer, Project stProject, StarTeam.View stView, Item.Type stType, Folder stFolder, Item stItem)
        {
            StarTeam.Item item = null;
            File temp = (File)stItem;
            if (temp.Name == "revision.txt")
                item = stItem;
            if (stItem.ToString() == "revision.txt")
                item = stItem;
            return item;
        }

        // ----------------------------------------------------------------------------
        // Get the primary descriptor of the given item type.
        // Returns null if there isn't one.
        // In practice, all item types have a primary descriptor.
        // ----------------------------------------------------------------------------
        Property GetPrimaryDescriptor(Type stType)
        {
            foreach (Property p in stType.Properties)
            {
                if (p.IsPrimaryDescriptor)
                    return (p);
            }
            return (null);
        }

        // ----------------------------------------------------------------------------
        // Get the secondary descriptor of the given item type.
        // Returns null if there isn't one.
        // ----------------------------------------------------------------------------
        Property GetSecondaryDescriptor(Type stType)
        {
            foreach (Property p in stType.Properties)
            {
                if (p.IsDescriptor && !p.IsPrimaryDescriptor)
                    return (p);
            }
            return (null);
        }

        // ----------------------------------------------------------------------------
        // Formats a property value for display to the user.
        // ----------------------------------------------------------------------------
        string FormatForDisplay(Property stProperty, object val)
        {
            string str = stProperty.GetDisplayValue(val);

            // Text-valued properties.
            if (stProperty is TextProperty)
            {
                if (str.Length > 32)
                {
                    str = str.Substring(0, 32) + "...";
                }

                return ("\"" + str + "\"");
            }
            else
            {
                return (val.ToString());
            }
        }
    }
}
