using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace RevEdit
{
    public enum ReleaseStatus
    {
        DEVELOPMENT,
        TESTING,
        SUBMITTED,
        APPROVED
    }

    public class ReleaseDataItem
    {
        private String mMarket;
        private String mVersion;
        private String mPlatform;
        private String mReleaseDate;
        private String mReleaseLabel;
        private String mGameName;
        private String mNotes;
        private ReleaseStatus mStatus;

        #region Accessors

        public ReleaseStatus Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                mStatus = value;
            }
        }
        public String Market
        {
            get
            {
                return mMarket;
            }
            set
            {
                mMarket = value;
            }
        }
        public String Version
        {
            get
            {
                return mVersion;
            }
            set
            {
                mVersion = value;
            }
        }
        public String Platform
        {
            get
            {
                return mPlatform;
            }
            set
            {
                mPlatform = value;
            }
        }
        public String ReleaseDate
        {
            get
            {
                return mReleaseDate;
            }
            set
            {
                mReleaseDate = value;
            }
        }
        public String ReleaseLabel
        {
            get
            {
                return mReleaseLabel;
            }
            set
            {
                mReleaseLabel = value;
            }
        }
        public String GameName
        {
            get
            {
                return mGameName;
            }
            set
            {
                mGameName = value;
            }
        }
        public String Notes
        {
            get
            {
                return mNotes;
            }
            set
            {
                mNotes = value;
            }
        }
        #endregion

        public ReleaseDataItem()
        {
            mMarket = "";
            mVersion = "";
            mPlatform = "";
            mReleaseDate = "";
            mReleaseLabel = "";
            mGameName = "";
            mNotes = "";
            mStatus = ReleaseStatus.DEVELOPMENT;
        }
    }

    public class ReleaseInfoManager
    {
        private String mFilePath;
        private List<ReleaseDataItem> mReleaseData;
        private bool mDataLoaded;

        #region Accessors

        public String Path
        {
            set
            {
                mFilePath = value + @"\releasedata.xml";
            }
            get
            {
                return mFilePath;
            }
        }

        public bool IsLoaded
        {
            get
            {
                return mDataLoaded;
            }
        }

        public List<ReleaseDataItem> Items
        {
            get
            {
                return mReleaseData;
            }
        }

        #endregion

        public ReleaseInfoManager()
        {
            mFilePath = null;
            mReleaseData = new List<ReleaseDataItem>();
            mDataLoaded = false;
        }
        
        public ReleaseInfoManager(String Path)
        {
            mFilePath = Path + @"\releasedata.xml";
            mReleaseData = new List<ReleaseDataItem>();
            mDataLoaded = Read();
        }

        public ReleaseDataItem GetLatestRevision(String name, String market)
        {
            ReleaseDataItem found = null;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.GameName == name && item.Market == market)
                {
                    if (found == null)
                    {
                        found = item;
                        continue;
                    }
                    if (String.Compare(item.Version, found.Version) > 0)
                        found = item;
                }
            }
            return found;
        }

        public bool Read()
        {
            if (mFilePath == null)
                return false;
            System.IO.Stream reader;
            XmlSerializer input;
            try
            {
                reader = new System.IO.FileStream(mFilePath, System.IO.FileMode.Open);
                input = new XmlSerializer(typeof(List<ReleaseDataItem>));
                mReleaseData = (List<ReleaseDataItem>)input.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "XML Read Error", MessageBoxButtons.OK);
                return false;
            }
            reader.Close();
            return true;
        }

        public bool Write()
        {
            if (mFilePath == null)
                return false;
            XmlSerializer writer;
            System.IO.StreamWriter file;
            try
            {
                writer = new XmlSerializer(typeof(List<ReleaseDataItem>));
                file = new System.IO.StreamWriter(mFilePath, false);
                writer.Serialize(file, mReleaseData);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Writing XML", MessageBoxButtons.OK);
                return false;
            }
            file.Close();
            return true;
        }

        public bool Release(String Market, String Name, String Version, String Label, String Platform, String Date, String Notes)
        {
            if (Market == "" || Name == "" || Version == "" || Label == "" || Platform == "" || Date == "")
            {
                MessageBox.Show("Missing Release information:" + Environment.NewLine +
                                "Market    : " + Market + Environment.NewLine +
                                "Game Name : " + Name + Environment.NewLine +
                                "Version   : " + Version + Environment.NewLine +
                                "Label     : " + Label + Environment.NewLine +
                                "Platform  : " + Platform + Environment.NewLine +
                                "Date      : " + Date + Environment.NewLine, "Release Data Incomplete", MessageBoxButtons.OK);
                return false;
            }
            // No matching release in the indicated market, add new release data to the list
            return AddRelease(Market, Name, Version, Label, Platform, Date, Notes);
        }

        private bool AddRelease(String Market, String Name, String Version, String Label, String Platform, String Date, String Notes)
        {
            if (mFilePath == null)
                return false;
            if (Market == "")
                return false;
            ReleaseDataItem node = new ReleaseDataItem();
            node.Market = Market;
            node.Version = Version;
            node.ReleaseLabel = Label;
            node.Platform = Platform;
            node.ReleaseDate = Date;
            node.GameName = Name;
            node.Notes = Notes;
            mReleaseData.Add(node);
            return true;
        }

        public ReleaseDataItem FindLastRelease(String Market)
        {
            // check to see if we've loaded the data.
            if (mFilePath == null)
                return null;

            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Market == Market)
                    return item;
            }
            // market not found.
            return null;
        }
    }
}
