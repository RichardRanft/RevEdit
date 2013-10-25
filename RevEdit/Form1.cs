using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Borland.StarTeam;
using Type = Borland.StarTeam.Type;

namespace RevEdit
{
    public partial class Form1 : Form
    {
        private String currentLine;
        private About aboutBox;
        private Settings settingsBox;
        private StarTeamServices serviceProvider;

        public Form1()
        {
            InitializeComponent();
            aboutBox = new About();
            settingsBox = new Settings();
            settingsBox.initializeSettings();
            serviceProvider = new StarTeamServices();
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
                lColumn.Text = lColumn.Text = currentLine.Length.ToString();
            }

            if (filterControlKeys(e.KeyCode))
                return;

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
    }
}
