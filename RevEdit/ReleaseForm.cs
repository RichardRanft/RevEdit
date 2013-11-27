using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RevEdit
{
    public partial class ReleaseForm : Form
    {
        private ReleaseInfoManager mDataManager;

        #region Accessors

        public ReleaseInfoManager DataManager
        {
            get
            {
                return mDataManager;
            }
            set
            {
                mDataManager = value;
            }
        }

        public String GameName
        {
            get
            {
                return tbGameName.Text;
            }
            set
            {
                tbGameName.Text = value;
            }
        }

        public String Platform
        {
            get
            {
                return tbPlatform.Text;
            }
            set
            {
                tbPlatform.Text = value;
            }
        }

        public String ReleaseNotes
        {
            get
            {
                return tbReleaseNotes.Text;
            }
            set
            {
                tbReleaseNotes.Text = value;
            }
        }

        public String Market
        {
            get
            {
                return cbMarket.Text;
            }
            set
            {
                int index = cbMarket.FindString(value);
                if (index >= 0)
                    cbMarket.SelectedIndex = index;
                else
                {
                    cbMarket.SelectedIndex = cbMarket.Items.Add(value);
                }
            }
        }

        public String Version
        {
            get
            {
                return tbReleaseVersion.Text;
            }
            set
            {
                tbReleaseVersion.Text = value;
            }
        }

        public String Label
        {
            get
            {
                return lReleasedLabel.Text;
            }
            set
            {
                lReleasedLabel.Text = value;
            }
        }

        public String Date
        {
            get
            {
                return dtpReleaseDate.Value.ToShortDateString();
            }
            set
            {
                dtpReleaseDate.Value = DateTime.Parse(value);
            }
        }

        #endregion

        public ReleaseForm()
        {
            InitializeComponent();
            mDataManager = null;
        }
    }
}
