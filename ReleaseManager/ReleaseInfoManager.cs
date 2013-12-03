using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace ReleaseManager
{
    public enum ReleaseStatus
    {
        NONE,
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
        private String mSoftwareName;
        private String mNotes;
        private String mSha1;
        private String mHMAC;
        private bool mIsPlatform;
        private ReleaseStatus mStatus;

        #region Accessors

        public String SHA1
        {
            get
            {
                return mSha1;
            }
            set
            {
                mSha1 = value;
            }
        }
        public String HMAC
        {
            get
            {
                return mHMAC;
            }
            set
            {
                mHMAC = value;
            }
        }
        public bool IsPlatform
        {
            get
            {
                return mIsPlatform;
            }
            set
            {
                mIsPlatform = value;
            }
        }
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
        public String SoftwareName
        {
            get
            {
                return mSoftwareName;
            }
            set
            {
                mSoftwareName = value;
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
            mSoftwareName = "";
            mNotes = "";
            mSha1 = "";
            mHMAC = "";
            mIsPlatform = false;
            mStatus = ReleaseStatus.NONE;
        }

        public int GetStatus()
        {
            int state = 0;
            switch (Status)
            {
                case ReleaseStatus.NONE:
                    state = 0;
                    break;
                case ReleaseStatus.DEVELOPMENT:
                    state = 1;
                    break;
                case ReleaseStatus.TESTING:
                    state = 2;
                    break;
                case ReleaseStatus.SUBMITTED:
                    state = 3;
                    break;
                case ReleaseStatus.APPROVED:
                    state = 4;
                    break;
            }
            return state;
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
                if (item.SoftwareName == name && item.Market == market)
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

        public List<String> GetAllPlatforms()
        {
            List<String> temp = new List<String>();
            String platform = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                found = false;
                platform = item.Platform;
                foreach (String p in temp)
                {
                    if (String.Compare(platform, p) == 0)
                        found = true;
                }
                if (!found)
                    temp.Add(platform);
            }
            return temp;
        }

        public List<String> GetAllPlatformsByGame(String name)
        {
            List<String> temp = new List<String>();
            String platform = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.SoftwareName == name)
                {
                    found = false;
                    platform = item.Platform;
                    foreach (String p in temp)
                    {
                        if (String.Compare(platform, p) == 0)
                            found = true;
                    }
                    if (!found)
                        temp.Add(platform);
                }
            }
            return temp;
        }

        public List<String> GetAllMarkets()
        {
            List<String> temp = new List<String>();
            String market = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                found = false;
                market = item.Market;
                foreach (String m in temp)
                {
                    if (String.Compare(market, m) == 0)
                        found = true;
                }
                if (!found)
                    temp.Add(market);
            }
            return temp;
        }

        public List<String> GetAllMarketsByGame(String name)
        {
            List<String> temp = new List<String>();
            String market = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.SoftwareName == name)
                {
                    found = false;
                    market = item.Market;
                    foreach (String m in temp)
                    {
                        if (String.Compare(market, m) == 0)
                            found = true;
                    }
                    if (!found)
                        temp.Add(market);
                }
            }
            return temp;
        }

        public List<String> GetAllTitles()
        {
            List<String> temp = new List<String>();
            String title = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                found = false;
                title = item.SoftwareName;
                foreach (String t in temp)
                {
                    if (String.Compare(title, t) == 0)
                        found = true;
                }
                if (!found)
                    temp.Add(title);
            }
            return temp;
        }

        public List<String> GetAllVersionsByTitle(String name)
        {
            List<String> temp = new List<String>();
            String version = "";
            bool found = false;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.SoftwareName == name)
                {
                    found = false;
                    version = item.Version;
                    foreach (String t in temp)
                    {
                        if (String.Compare(version, t) == 0)
                            found = true;
                    }
                    if (!found)
                        temp.Add(version);
                }
            }
            return temp;
        }

        public bool SoftwareIsApproved(String name, String version, String market)
        {
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.SoftwareName == name && item.Version == version && item.Market == market)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetSoftwareStatus(String version, String market)
        {
            int status = 0;
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Version == version && item.Market == market)
                {
                    switch (item.Status)
                    {
                        case ReleaseStatus.NONE:
                            status = 0;
                            break;
                        case ReleaseStatus.DEVELOPMENT:
                            status = 1;
                            break;
                        case ReleaseStatus.TESTING:
                            status = 2;
                            break;
                        case ReleaseStatus.SUBMITTED:
                            status = 3;
                            break;
                        case ReleaseStatus.APPROVED:
                            status = 4;
                            break;
                    }
                }
            }
            return status;
        }

        public String GetHMAC(String version, String market)
        {
            String temp = "";
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Version == version && item.Market == market)
                {
                    temp = item.HMAC;
                }
            }
            return temp;
        }

        public String GetSHA1(String version, String market)
        {
            String temp = "";
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Version == version && item.Market == market)
                {
                    temp = item.SHA1;
                }
            }
            return temp;
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

        public ReleaseDataItem FindItem(String Version, String Market)
        {
            // check to see if we've loaded the data.
            if (mFilePath == null)
                return null;

            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Market == Market && item.Version == Version)
                    return item;
            }
            // market not found.
            return null;
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

        public bool Release(String Market, String Name, String Version, String Label, String Platform, String Date, String sha1, String hmac, String Notes, ReleaseStatus Status, bool isPlatform)
        {
            if (Market == "" || Name == "" || Version == "" || Label == "" || Platform == "" || Date == "" || sha1 == "" || hmac == "")
            {
                MessageBox.Show("Missing Release information:" + Environment.NewLine +
                                "Market    : " + Market + Environment.NewLine +
                                "Game Name : " + Name + Environment.NewLine +
                                "Version   : " + Version + Environment.NewLine +
                                "Label     : " + Label + Environment.NewLine +
                                "Platform  : " + Platform + Environment.NewLine +
                                "SHA1      : " + sha1 + Environment.NewLine +
                                "HMAC      : " + hmac + Environment.NewLine +
                                "Date      : " + Date + Environment.NewLine, "Release Data Incomplete", MessageBoxButtons.OK);
                return false;
            }
            foreach (ReleaseDataItem item in mReleaseData)
            {
                if (item.Version == Version && item.Market == Market)
                {
                    // this is an update to an existing release.
                    item.ReleaseLabel = Label;
                    item.Platform = Platform;
                    item.ReleaseDate = Date;
                    item.SoftwareName = Name;
                    item.IsPlatform = isPlatform;
                    item.Status = Status;
                    item.SHA1 = sha1;
                    item.HMAC = hmac;
                    item.Notes = Notes;
                    return true;
                }
            }
            // No matching release in the indicated market, add new release data to the list
            return AddRelease(Market, Name, Version, Label, Platform, Date, sha1, hmac, Notes, Status, isPlatform);
        }

        private bool AddRelease(String Market, String Name, String Version, String Label, String Platform, String Date, String sha1, String hmac, String Notes, ReleaseStatus Status, bool isPlatform)
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
            node.SoftwareName = Name;
            node.IsPlatform = isPlatform;
            node.Status = Status;
            node.SHA1 = sha1;
            node.HMAC = hmac;
            node.Notes = Notes;
            mReleaseData.Add(node);
            return true;
        }
    }
}
