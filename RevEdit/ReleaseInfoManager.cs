using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace RevEdit
{
    public class ReleaseDataItem
    {
        private String mMarket;
        private String mVersion;
        private String mPlatform;
        private String mReleaseDate;
        private String mReleaseLabel;

        #region Accessors

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
        #endregion

        public ReleaseDataItem()
        {
            mMarket = "";
            mVersion = "";
            mPlatform = "";
            mReleaseDate = "";
            mReleaseLabel = "";
        }
    }

    class ReleaseInfoManager
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

        public bool Release(String Market, String Version, String Label, String Platform, String Date)
        {
            if (Market == "" || Version == "" || Label == "" || Platform == "" || Date == "")
            {
                MessageBox.Show("Missing Release information:" + Environment.NewLine +
                                "Market   : " + Market + Environment.NewLine +
                                "Version  : " + Version + Environment.NewLine +
                                "Label  : " + Label + Environment.NewLine +
                                "Platform : " + Platform + Environment.NewLine +
                                "Date     : " + Date + Environment.NewLine, "Release Data Incomplete", MessageBoxButtons.OK);
                return false;
            }
            foreach (ReleaseDataItem item in mReleaseData)
            {
                // do we have a release of this version on this platform in this market?
                if (item.Market == Market && item.Version == Version && item.Platform == Platform)
                {
                    // apparently yes.
                    item.ReleaseLabel = Label;
                    item.ReleaseDate = Date;
                    return true;
                }
            }
            // No matching release in the indicated market, add new release data to the list
            return AddRelease(Market, Version, Label, Platform, Date);
        }

        public bool AddRelease(String Market, String Version, String Label, String Platform, String Date)
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
