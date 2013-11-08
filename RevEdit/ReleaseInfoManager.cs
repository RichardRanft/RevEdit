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
        #endregion

        public ReleaseDataItem()
        {
            mMarket = "";
            mVersion = "";
            mPlatform = "";
            mReleaseDate = "";
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

        public bool AddRelease(String Market, String Version, String Platform, String Date)
        {
            if (mFilePath == null)
                return false;
            if (Market == "")
                return false;
            ReleaseDataItem node = new ReleaseDataItem();
            node.Market = Market;
            node.Version = Version;
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
