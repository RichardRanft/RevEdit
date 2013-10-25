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

        // Item Type Names specified on the command line.
        private StringCollection m_strTypeNames = new StringCollection();

        // Resolved (Name, Type) pairs for Item Types to be searched.
        private SortedList m_stItemTypes = new SortedList();

        private DateTime m_cutoffDate = DateTime.Now;	// List items last modified since this date
        private bool m_bUseDateFilter = false;			// True to filter by m_cuttoffDate

        private bool m_bVerbose = false;				// true for verbose output

        // Used when writing header information to output.
        private int m_prevProjectID = -1;
        private int m_prevViewID = -1;
        private int m_prevTypeID = -1;
        private int m_prevFolderID = -1;
        private bool m_bShowHeader = true;
        private System.Windows.Forms.Label m_status;
        private TreeView m_output;

        Server m_server;

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
        public System.Windows.Forms.Label Status
        {
            get
            {
                return m_status;
            }
            set
            {
                m_status = value;
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
        public TreeView Output
        {
            get
            {
                return m_output;
            }
            set
            {
                m_output = value;
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
            return false;
        }

        public List<String> getProjectList()
        {
            List<String> projectList = new List<String>();
            // get a list of projects on the server
            // filter out anything that doesn't start with "PC4G"
            return projectList;
        }

        public List<String> getViewList()
        {
            List<String> viewList = new List<String>();
            // get a list of views in this project
            return viewList;
        }

        public List<String> getLabelList()
        {
            List<String> labelList = new List<String>();
            // get a list of labels
            return labelList;
        }

        // Finds the test project.
        public Project GetProject(Server s, String strName)
        {
            return s.Projects.FindByName(strName, false);
        }

        // Does all the real work for the sample application.
        public void Run()
        {
            // Create the Server object.
            if (m_server == null)
                m_server = new Server(m_strServer, m_nPort);
            if (m_output.Nodes.Count > 0)
                m_output.Nodes.Clear();

            // LogOn to the server.
            m_server.LogOn(m_strUser, m_strPassword);

            // Determine which Item Types to display.
            m_stItemTypes = ResolveItemTypes(m_server, m_strTypeNames);

            // Search this Server for relevant Items.
            RunServer(m_server);

            // Disconnect.
            m_server.Disconnect();
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
        // Searches the given Server for relevant Items.
        // ----------------------------------------------------------------------------
        public void RunServer(Server stServer)
        {
            m_status.Text = "";
            m_status.Text = "Working...";
            // Take the opportunity to display key input parameters.
            Console.Write("\nType Names: ");
            bool bComma = false;
            foreach (DictionaryEntry e in m_stItemTypes)
            {
                Type stType = (Type)e.Value;
                if (bComma) Console.Write(", ");
                Console.Write("\"" + stType.Name + "\"");
                bComma = true;
            }
            Console.WriteLine("");

            if (m_bUseDateFilter)
            {
                Console.WriteLine("Last Modified: >= " + m_cutoffDate.ToString());
            }

            bool bFound = false;

            // For each project on this server ...
            foreach (Project stProject in stServer.Projects)
            {
                // If no project name was specified, search all projects.
                if (m_strProject == null)
                {
                    RunProject(stServer, stProject);
                }

                    // Otherwise, only search if the name matches.
                else if (m_strProject == stProject.Name)
                {
                    RunProject(stServer, stProject);
                    bFound = true;
                    break;
                }
            }

            // If a specific project name was specified,
            // make sure we found it in the collection.
            if ((m_strProject != null) && !bFound)
            {
                string strMessage = "Project \"";
                strMessage += m_strProject;
                strMessage += "\" not found.";
                System.Windows.Forms.MessageBox.Show(strMessage, "Project Not Found", MessageBoxButtons.OK);
            }
            m_status.Text = "";
            m_status.Text = "Idle";
        }

        // ----------------------------------------------------------------------------
        // Searches the given project.
        // ----------------------------------------------------------------------------
        void RunProject(Server stServer, Project stProject)
        {
            // If no view name was specified, search only the default view.
            if (m_strView == null)
            {
                TreeNode projectNode = new TreeNode(stProject.Name);
                m_output.Nodes.Add(projectNode);

                Borland.StarTeam.ViewCollection projectViews = stProject.DefaultView.DerivedViews;
                for (int i = 0; i < projectViews.Count; i++)
                {
                    TreeNode node = new TreeNode(projectViews[i].Name);
                    projectNode.Nodes.Add(node);
                }
            }
            else
            {
                Borland.StarTeam.ViewCollection projectViews = stProject.DefaultView.DerivedViews;
                TreeNode projectNode = new TreeNode(stProject.Name);
                m_output.Nodes.Add(projectNode);

                //// Use "*" to search all views.
                bool bAllViews = (m_strView == ALL_VIEWS);
                bool bFound = false;

                // For each view ...
                foreach (Borland.StarTeam.View stView in projectViews)
                {
                    // Are we searching all views?
                    if (bAllViews)
                    {
                        TreeNode node = new TreeNode(stView.Name);
                        projectNode.Nodes.Add(node);
                        RunView(stServer, stProject, stView, node);
                    }

                        // Otherwise, only search if the name matches.
                    else
                    {
                        if (m_strView == stView.Name)
                        {
                            TreeNode node = new TreeNode(stView.Name);
                            projectNode.Nodes.Add(node);
                            RunView(stServer, stProject, stView, node);
                            bFound = true;
                            break;
                        }
                    }
                }

                // If a specific view name was specified,
                // make sure we found it in the collection.
                if (!bAllViews && !bFound)
                {
                    string strMessage = "View \"";
                    strMessage += m_strView;
                    strMessage += "\" not found in Project \"";
                    strMessage += m_strProject;
                    strMessage += "\".";

                    System.Windows.Forms.MessageBox.Show(strMessage, "View Not Found", MessageBoxButtons.OK);
                }
            }
            m_status.Text = "";
            m_status.Text = "Idle";
        }

        // ----------------------------------------------------------------------------
        // Searches the given view.
        // ----------------------------------------------------------------------------
        void RunView(Server stServer, Project stProject, Borland.StarTeam.View stView, TreeNode node)
        {
            if (stView.DerivedViews.Count > 0)
            {
                // For each Item Type ...
                foreach (Borland.StarTeam.View v in stView.DerivedViews)
                {
                    TreeNode newNode = new TreeNode(v.Name);
                    node.Nodes.Add(newNode);
                    if (v.DerivedViews.Count > 0)
                    {
                        RunView(stServer, stProject, v, newNode);
                    }
                    Borland.StarTeam.LabelCollection labels = stView.FetchAllLabelsFromView(stProject.ID, stView.ID);
                    if (labels.Count > 0)
                    {
                        foreach (Borland.StarTeam.Label l in labels)
                        {
                            TreeNode labelNode = new TreeNode(l.Name);
                            newNode.Nodes.Add(labelNode);
                        }
                    }
                }
            }
            else
            {
                Borland.StarTeam.LabelCollection labels = stView.FetchAllLabelsFromView(stProject.ID, stView.ID);
                if (labels.Count > 0)
                {
                    foreach (Borland.StarTeam.Label l in labels)
                    {
                        TreeNode labelNode = new TreeNode(l.Name);
                        node.Nodes.Add(labelNode);
                    }
                }
            }
        }

        // ----------------------------------------------------------------------------
        // Searches the given view.
        // ----------------------------------------------------------------------------
        void RunView(Server stServer, Project stProject, Borland.StarTeam.View stView)
        {
            // For each Item Type ...
            foreach (DictionaryEntry e in m_stItemTypes)
            {
                Type stType = (Type)e.Value;
                RunType(stServer, stProject, stView, stType);
            }
        }

        // ----------------------------------------------------------------------------
        // Searches the given view for all relevant items of the given type.
        // ----------------------------------------------------------------------------
        void RunType(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType)
        {
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
                    return;
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
            RunFolder(stServer, stProject, stView, stType, stFolder);

            // Free up the memory used by the cached items.
            stFolder.DiscardItems(stType.Name, depth);
        }

        // ----------------------------------------------------------------------------
        // Searches the given folder.
        // ----------------------------------------------------------------------------
        void RunFolder(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType, Folder stFolder)
        {
            // In verbose mode, ensure that the folder is displayed.
            if (m_bVerbose)
            {
                RunItem(stServer, stProject, stView, stType, stFolder, null);
            }

            // For each item of the appropriate type ...
            foreach (Item stItem in stFolder.GetItems(stType.Name))
            {
                RunItem(stServer, stProject, stView, stType, stFolder, stItem);
            }

            if (m_bRecursive)
            {
                // For each subfolder ...
                foreach (Folder stSubFolder in stFolder.SubFolders)
                {
                    RunFolder(stServer, stProject, stView, stType, stSubFolder);
                }
            }
        }

        // ----------------------------------------------------------------------------
        // Processes the given Item.
        // ----------------------------------------------------------------------------
        void RunItem(Server stServer, Project stProject, Borland.StarTeam.View stView, Type stType, Folder stFolder, Item stItem)
        {
            // If we're filtering based on last modified date,
            // see if this item qualifies.
            //TreeNode projectNode = new TreeNode(stProject.Name);
            //m_output.Nodes.Add(projectNode);
            //if (m_bUseDateFilter && (stItem != null))
            //{
            //    if (stItem.ModifiedTime.ToLocalTime() < m_cutoffDate)
            //        return;
            //}
            //Borland.StarTeam.ViewCollection projectViews = stProject.DefaultView.DerivedViews;
            //for (int i = 0; i < projectViews.Count; i++)
            //{
            //    TreeNode node = new TreeNode(projectViews[i].Name);
            //    projectNode.Nodes.Add(node);
            //}
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
