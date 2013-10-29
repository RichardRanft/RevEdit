using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Borland.StarTeam;
using Type = Borland.StarTeam.Type;

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

        // Item Type Names specified on the command line.
        private StringCollection m_strTypeNames = new StringCollection();

        // Resolved (Name, Type) pairs for Item Types to be searched.
        private SortedList m_stItemTypes = new SortedList();

        private DateTime m_cutoffDate = DateTime.Now;	// List items last modified since this date
        private bool m_bUseDateFilter = false;			// True to filter by m_cuttoffDate

        // Used when writing header information to output.
        Server m_server;
        File m_revisionFile;

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

        // Creates a StarTeam server object, connects to the server, and logs in.
        // Returns the resulting Server object.
        public Server GetServer()
        {
            // Simplest constructor, uses default encryption algorithm and compression level.
            if (m_server == null)
                m_server = new Server(m_strServer, m_nPort);

            // Optional; logOn() connects if necessary.
            m_server.Connect();

            // Logon using specified user name and password.
            m_server.LogOn(m_strUser, m_strPassword);

            return (m_server);
        }

        public bool logIn()
        {
            // Create the Server object.
            if (m_server == null)
                m_server = new Server(m_strServer, m_nPort);

            if (m_server == null)
                return false;

            // LogOn to the server.
            m_server.LogOn(m_strUser, m_strPassword);

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
            Project stProject = m_server.Projects.FindByName(project, true);
            Borland.StarTeam.ViewCollection projectViews = stProject.DefaultView.DerivedViews;

            // For each view ...
            foreach (Borland.StarTeam.View stView in projectViews)
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
            Project stProject = m_server.Projects.FindByName(project, true);
            Borland.StarTeam.View stView = stProject.Views.FindByName(view, true);
            Borland.StarTeam.Label[] labels = stView.FetchAllLabels();

            // For each view ...
            foreach (Borland.StarTeam.Label l in labels)
            {
                labelList.Add(l.Name);
            }
            return labelList;
        }

        private Borland.StarTeam.LabelCollection getLabelFromSubview(Borland.StarTeam.View stView, String viewName)
        {
            // get a list of labels
            LabelCollection Labels = new LabelCollection();
            if (stView.Name == viewName)
            {
                Labels = stView.Labels;
            }
            Borland.StarTeam.ViewCollection subViews = stView.DerivedViews;
            if (subViews.Count > 0)
            {
                // For each view ...
                foreach (Borland.StarTeam.View subView in subViews)
                {
                    if (subView.Name == viewName)
                    {
                        Labels = subView.Labels;
                    }
                }
            }
            return Labels;
        }

        private List<String> getSubviews(Borland.StarTeam.View stView)
        {
            List<String> list = new List<String>();
            if (stView.DerivedViews.Count > 0)
            {
                // For each Item Type ...
                foreach (Borland.StarTeam.View v in stView.DerivedViews)
                {
                    list.Add("  " + v.Name);
                    if (v.DerivedViews.Count > 0)
                    {
                        List<String> subList = new List<String>();
                        subList = getSubviews(v);
                    }
                }
            }
            return list;
        }

        public bool checkoutRevisionFile()
        {
            Borland.StarTeam.Item revFile;
            if (getRevisionFile(m_strProject, m_strView, out revFile))
            {
                m_revisionFile = (File)revFile;
                System.IO.FileInfo fileInfo = new System.IO.FileInfo(m_tempFilePath+"\\revision.txt");
                m_revisionFile.CheckoutTo(fileInfo, Item.LockType.UNCHANGED, false, true, true);
                return true;
            }
            return false;
        }

        public bool checkinRevisionFile(String revPath)
        {
            Project proj = m_server.Projects.FindByName(m_strProject, true);
            Borland.StarTeam.View view = proj.Views.FindByName(m_strView, true);
            CheckinOptions options = new CheckinOptions(view);
            if (m_revisionFile != null)
            {
                m_revisionFile.Checkin(options);
                return true;
            }
            Borland.StarTeam.Folder rootFolder = view.RootFolder;
            Borland.StarTeam.Folder docFolder = Borland.StarTeam.StarTeamFinder.FindFolder(rootFolder, "documents");
            Borland.StarTeam.CheckinManager manager = view.CreateCheckinManager();
            m_revisionFile = new File(docFolder);
            m_revisionFile.Name = "revision.txt";
            System.IO.FileInfo revFile = new System.IO.FileInfo(revPath);
            manager.CheckinFrom(m_revisionFile, revFile);

            return true;
        }

        public bool createLabel(String label)
        {
            Project proj = m_server.Projects.FindByName(m_strProject, true);
            Borland.StarTeam.View view = proj.Views.FindByName(m_strView, true);
            Borland.StarTeam.Label newLabel = view.CreateRevisionLabel(label, "", false);

            if (newLabel != null)
                return true;

            return false;
        }

        private bool getRevisionFile(String project, String view, out Borland.StarTeam.Item item)
        {
            if (project == "" || project == null)
            {
                item = null;
                return false;
            }
            Project stProject = m_server.Projects.FindByName(project, true);
            if ( view == "" || view == null)
            {
                item = null;
                return false;
            }
            Borland.StarTeam.View targetView = findView(stProject, view);
            if (targetView == null)
            {
                item = null;
                return false;
            }
            item = RunView(m_server, stProject, targetView);
            if (item != null)
                return true;
            return false;
        }

        private Borland.StarTeam.View findView(Project stProject, String viewName)
        {
            for (int i = 0; i < stProject.Views.Count; i++)
            {
                if (stProject.Views[i].Name == viewName)
                    return stProject.Views[i];
                foreach (Borland.StarTeam.View subView in stProject.Views[i].DerivedViews)
                {
                    if (subView.Name == viewName)
                        return subView;
                    else
                    {
                        Borland.StarTeam.View temp = findSubView(subView, viewName);
                        if (temp == null)
                            continue;
                        if (temp.Name == viewName)
                            return temp;
                    }
                }
            }
            return null;
        }

        private Borland.StarTeam.View findSubView(Borland.StarTeam.View stView, String viewName)
        {
            foreach (Borland.StarTeam.View subView in stView.DerivedViews)
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
            return s.Projects.FindByName(strName, false);
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
                typeNames.Add(s.TypeNames.FILE);
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
                if (stType.IsItemType)
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
            if (s.IsTypeSupported(strName))
            {
                Type stType = s.TypeForName(strName);
                if (stType.IsItemType)
                    return (stType);
            }
            return (null);
        }

        // ----------------------------------------------------------------------------
        // Searches the given view.
        // ----------------------------------------------------------------------------
        private Borland.StarTeam.Item RunView(Server stServer, Project stProject, Borland.StarTeam.View stView)
        {
            Borland.StarTeam.Item item = null;
            // For each Item Type ...
            foreach (DictionaryEntry e in m_stItemTypes)
            {
                Type stType = (Type)e.Value;
                item = RunType(stServer, stProject, stView, stType);
            }
            return item;
        }

        // ----------------------------------------------------------------------------
        // Searches the given view for all relevant items of the given type.
        // ----------------------------------------------------------------------------
        private Borland.StarTeam.Item RunType(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType)
        {
            Borland.StarTeam.Item item = null;
            // By default, start searching from the root folder.
            Folder stFolder = stView.RootFolder;

            // If a specfic path was specified, search for it.
            if (m_strFolder != null)
            {
                Folder stTempFolder = StarTeamFinder.FindFolder(stFolder, m_strFolder);
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

            // For performance reasons, it is important to pre-fetch all the
            // properties we'll need for all the items we'll be searching.

            // Get the PropertyNames object for this server.
            PropertyNames stPropertyNames = stServer.PropertyNames;

            // Build a collection of property names.
            StringCollection stPopulateNames = new StringCollection();

            // We always display the ItemID (OBJECT_ID).
            stPopulateNames.Add(stPropertyNames.OBJECT_ID);

            // If we're checking the last modified date,
            // we'll need MODIFIED_TIME, too.
            if (m_bUseDateFilter)
            {
                stPopulateNames.Add(stPropertyNames.MODIFIED_TIME);
            }

            // Does this item type have a primary descriptor?
            // If so, we'll need it.
            Property p1 = GetPrimaryDescriptor(stType);
            if (p1 != null)
            {
                stPopulateNames.Add(p1.Name);
            }

            // Does this item type have a secondary descriptor?
            // If so, we'll need it.
            Property p2 = GetSecondaryDescriptor(stType);
            if (p2 != null)
            {
                stPopulateNames.Add(p2.Name);
            }

            // Convert to an array.
            string[] names = new string[stPopulateNames.Count];
            stPopulateNames.CopyTo(names, 0);

            // Pre-fetch the item properties and cache them.
            int depth = (m_bRecursive ? -1 : 0);
            stFolder.PopulateNow(stType.Name, names, depth);

            // Now, search for items in the selected folder.
            item = RunFolder(stServer, stProject, stView, stType, stFolder);

            // Free up the memory used by the cached items.
            stFolder.DiscardItems(stType.Name, depth);

            return item;
        }

        // ----------------------------------------------------------------------------
        // Searches the given folder.
        // ----------------------------------------------------------------------------
        private Borland.StarTeam.Item RunFolder(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType, Folder stFolder)
        {
            Borland.StarTeam.Item item = null;
            // For each item of the appropriate type ...
            foreach (Item stItem in stFolder.GetItems(stType.Name))
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
        private Borland.StarTeam.Item RunItem(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType, Folder stFolder, Item stItem)
        {
            Borland.StarTeam.Item item = null;
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
            if (stProperty.TypeCode == Property.Types.TEXT)
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
