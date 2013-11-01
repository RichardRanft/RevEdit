﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Xml;
using System.IO;

using Borland.StarTeam;
using Type = Borland.StarTeam.Type;

namespace RevEdit
{
    public partial class Form1 : Form
    {
        private String currentLine;
        private About aboutBox;
        private Settings settingsBox;
        private CheckinForm checkinForm;
        private StarTeamServices serviceProvider;
        private List<String> mServerList;
        private List<String> mAddressList;
        private List<int> mPortList;

        public Form1()
        {
            InitializeComponent();

            aboutBox = new About();
            settingsBox = new Settings();
            checkinForm = new CheckinForm();
            serviceProvider = new StarTeamServices();
            mServerList = new List<String>();
            mAddressList = new List<String>();
            mPortList = new List<int>();

            initialize();
        }

        private void initialize()
        {
            toolStripStatusLabel1.Text = "Initializing...";
            toolStripStatusLabel2.Text = "";
            updateServerList();
            settingsBox.initializeSettings();

            if (settingsBox.AutoLogin)
            {
                toolStripStatusLabel1.Text = "Logging in to StarTeam...";
                login();
                toolStripStatusLabel1.Text = "Logged in.";
                toolStripStatusLabel2.Text = "No file loaded.";
            }
        }

        private bool login()
        {
            serviceProvider.User = settingsBox.User;
            serviceProvider.Password = settingsBox.Password;
            serviceProvider.TempFilePath = settingsBox.Path;
            int serverIndex = getServerByName("PC4 EGM");
            if (serverIndex >= 0)
            {
                serviceProvider.Server = mAddressList[serverIndex];
                serviceProvider.Port = mPortList[serverIndex];
            }
            else
                return false;
            if (!serviceProvider.logIn())
                return false;
            List<String> list = serviceProvider.getProjectList();
            list.Sort();
            foreach (String projectName in list)
            {
                cbProjectList.Items.Add(projectName);
            }
            cbProjectList.Refresh();
            cbProjectList.Enabled = true;
            cbViewList.Enabled = true;
            cbStartLabelList.Enabled = true;
            cbEndLabelList.Enabled = true;
            bSearch.Enabled = true;
            bCheckin.Enabled = true;
            bDisconnect.Enabled = true;
            bLogin.Enabled = false;
            toolStripStatusLabel1.Text = "Logged in.";
            return true;
        }

        private int getServerByName(String name)
        {
            for (int i = 0; i < mServerList.Count; i++)
            {
                if (mServerList[i] == name)
                    return i;
            }
            return -1;
        }

        private void updateServerList()
        {
            toolStripStatusLabel1.Text = "Reading server list...";
            XmlTextReader reader;
            try
            {
                reader = new XmlTextReader("starteam-servers.xml");
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            if (reader.Name == "server")
                            {
                                while (reader.MoveToNextAttribute()) // Read the attributes.
                                {
                                    if (reader.Name == "description")
                                        mServerList.Add(reader.Value);
                                    if (reader.Name == "host")
                                        mAddressList.Add(reader.Value);
                                    if (reader.Name == "endpoint")
                                    {
                                        int port = 0;
                                        try
                                        {
                                            port = Convert.ToInt32(reader.Value);
                                        }
                                        catch (Exception ex)
                                        {
                                            port = 0;
                                        }
                                        mPortList.Add(port);
                                    }
                                }
                            }
                            break;
                        case XmlNodeType.EndElement: //Display the end of the element.
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "XML Read Error", MessageBoxButtons.OK);
            }
            toolStripStatusLabel1.Text = "Ready.";
        }

        public IEnumerable<string> wrapText(string line, int length)
        {
            var s = line;
            while (s.Length > length)
            {
                var result = s.Substring(0, length);
                s = s.Substring(length);
                yield return result;
            }
            yield return s;
        }

        private bool filterControlKeys(Keys k)
        {
            if (k == Keys.Up)
                return true;
            if (k == Keys.Down)
                return true;
            if (k == Keys.Left)
                return true;
            if (k == Keys.Right)
                return true;
            if (k == Keys.Escape)
                return true;
            if (k == Keys.Back)
                return true;
            if (k == Keys.Home)
                return true;
            if (k == Keys.End)
                return true;
            if (k == Keys.Delete)
                return true;
            if (k == Keys.PageUp)
                return true;
            if (k == Keys.PageDown)
                return true;
            return false;
        }
        
        private void tbRevisionText_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int lineIndex = tbRevisionText.GetLineFromCharIndex(tbRevisionText.SelectionStart);
            lCharCount.Text = (tbRevisionText.TextLength + 1).ToString();
            if (lineIndex < tbRevisionText.Lines.Length)
            {
                currentLine = tbRevisionText.Lines[lineIndex].ToString();
                lColumn.Text = currentLine.Length.ToString();
            }

            if (filterControlKeys(e.KeyCode))
            {
                return;
            }

            if (lineIndex < tbRevisionText.Lines.Length)
            {
                currentLine = tbRevisionText.Lines[lineIndex].ToString();
                if (currentLine.Length > 69)
                {
                    foreach (String s in wrapText(currentLine, 70))
                    {
                        if (lineIndex == tbRevisionText.Lines.Length - 1)
                            tbRevisionText.AppendText(Environment.NewLine);
                        else
                        {
                            int nextLine = lineIndex + 1;
                            int nextLineEnd = tbRevisionText.GetFirstCharIndexFromLine(nextLine) + tbRevisionText.Lines[nextLine].Length;
                            tbRevisionText.SelectionStart = nextLineEnd;
                            tbRevisionText.AppendText("");
                        }
                    }
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutBox.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingsBox.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cbProjectList.Enabled = false;
            cbViewList.Enabled = false;
            cbStartLabelList.Enabled = false;
            cbEndLabelList.Enabled = false;
            bSearch.Enabled = false;
            bCheckin.Enabled = false;
            bDisconnect.Enabled = false;
            bLogin.Enabled = true;

            serviceProvider.disconnect();
            toolStripStatusLabel1.Text = "Disconnected.";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serviceProvider.disconnect();
            System.IO.FileInfo info = new FileInfo(settingsBox.Path + @"\revision.txt");
            if (info.Exists)
                info.Delete();
        }

        private void cbProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            serviceProvider.clearRevisionFile();
            cbViewList.Items.Clear();
            cbViewList.Text = "Select a view...";
            serviceProvider.Project = cbProjectList.Text;
            List<String> list = serviceProvider.getViewList(cbProjectList.SelectedItem.ToString());
            foreach (String view in list)
            {
                cbViewList.Items.Add(view);
            }
            if (cbViewList.Items.Count > 0)
                cbViewList.Text = cbViewList.Items[0].ToString();
        }

        private void cbViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbStartLabelList.Items.Clear();
            cbStartLabelList.Text = "Select the starting label...";
            cbEndLabelList.Items.Clear();
            cbEndLabelList.Text = "";
            String viewName = cbViewList.SelectedItem.ToString().Trim();
            serviceProvider.View = viewName;
            List<String> list = serviceProvider.getLabelList(cbProjectList.SelectedItem.ToString(), viewName);
            foreach (String label in list)
            {
                cbStartLabelList.Items.Add(label);
                cbEndLabelList.Items.Add(label);
            }
            if (cbStartLabelList.Items.Count > 0)
                cbStartLabelList.Text = cbStartLabelList.Items[0].ToString();
            if (cbEndLabelList.Items.Count > 0)
                cbEndLabelList.Text = cbEndLabelList.Items[0].ToString();
        }

        private void cbStartLabelList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cbEndLabelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNewLabel.Text = suggestNewLabel();
        }

        private String suggestNewLabel()
        {
            String[] labelParts = cbEndLabelList.Text.Split('-');
            int rev = incrementLabel(labelParts[1]);
            String newLabel = labelParts[0] + "-";
            if (rev < 10)
                newLabel += "0";
            newLabel += rev.ToString();
            return newLabel;
        }

        private int incrementLabel(String verNum)
        {
            int version = 0;
            try
            {
                version = System.Convert.ToInt32(verNum);
            }
            catch (Exception ex)
            {
            }
            return ++version;
        }

        private void findRevisionFile()
        {
            tbRevisionText.Clear();
            if (serviceProvider.checkoutRevisionFile())
            {
                toolStripStatusLabel2.Text = "Revision.txt found";
                readFile();
            }
            else
            {
                toolStripStatusLabel2.Text = "Creating revision.txt";
            }
        }

        private void readFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(settingsBox.Path + @"\revision.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        tbRevisionText.Text += line + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Reading File");
            }
            wrapText();
        }

        private void writeFile()
        {
            using (StreamWriter outfile = new StreamWriter(settingsBox.Path + @"\revision.txt", false))
            {
                foreach(String line in tbRevisionText.Lines)
                    outfile.WriteLine(line.ToString());
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "Searching...";
            findRevisionFile();
            tbRevisionText.Focus();
        }

        private void bCheckin_Click(object sender, EventArgs e)
        {
            wrapText();
            writeFile();
            if (!serviceProvider.checkinRevisionFile(settingsBox.Path + @"\revision.txt"))
            {
                toolStripStatusLabel2.Text = "File not checked in.";
                return;
            }
            if (cbCreateLabel.Checked)
            {
                if (checkinForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    serviceProvider.createLabel(tbNewLabel.Text, checkinForm.Comment);
                    toolStripStatusLabel2.Text = "Checked in and label " + tbNewLabel.Text + " created.";
                }
                else
                {
                    toolStripStatusLabel2.Text = "File not checked in.";
                    return;
                }
            }
            else
                toolStripStatusLabel2.Text = "Checked in.";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void bLogin_Click(object sender, EventArgs e)
        {
            login();
        }

        private void wrapText()
        {
            tbRevisionText.TextChanged -= tbRevisionText_TextChanged;
            String[] temp = tbRevisionText.Lines;
            tbRevisionText.Text = "";
            for (int lineIndex = 0; lineIndex < temp.Length; lineIndex++)
            {
                String line = temp[lineIndex];
                if (line.Length > 70)
                {
                    String[] lineParts = line.Split(' ');
                    int currentPart = 0;
                    int lineStart = 0;
                    string tempLine = "";
                    while (currentPart < lineParts.Length)
                    {
                        tempLine += (lineParts[currentPart++] + " ");
                        if (tempLine.Length >= 69)
                        {
                            tempLine = "";
                            currentPart--;
                            for (int i = lineStart; i < currentPart; i++)
                            {
                                tempLine += (lineParts[i] + " ");
                            }
                            lineStart = currentPart;
                            tempLine += Environment.NewLine;
                            tbRevisionText.Text += tempLine;
                            tempLine = "";
                        }
                    }
                    tbRevisionText.Text += tempLine + Environment.NewLine;
                    continue;
                }
                else
                    tbRevisionText.Text += line + Environment.NewLine;
            }
            tbRevisionText.TextChanged += tbRevisionText_TextChanged;
            int start = tbRevisionText.TextLength - 1 >= 0 ? tbRevisionText.TextLength - 1 : 0;
            tbRevisionText.Select(start, 0);
        }

        private void tbRevisionText_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void lColumn_Click(object sender, EventArgs e)
        {

        }

        private void lCharCount_Click(object sender, EventArgs e)
        {

        }

        private void bWrapText_Click(object sender, EventArgs e)
        {
            wrapText();
        }
    }
}
