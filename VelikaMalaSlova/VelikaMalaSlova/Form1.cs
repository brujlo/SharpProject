using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace VelikaMalaSlova
{
    public partial class Form1 : Form //public partial class Form1 : Form
    {
        private string fileNameAndPath;
        private string stringBuffer;
        private string FileNameAndPath { get => fileNameAndPath; set => fileNameAndPath = value; }

        public Form1()
        {
            InitializeComponent();
            FileNameAndPath = "";
            CultureInfo currentCu = CultureInfo.CurrentCulture;
            if (!currentCu.Name.Equals("hr-HR")) CultureInfo.CurrentCulture = new CultureInfo("hr_HR");
            this.label2.Text = ("CultureInfo: " + currentCu.Name);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.Compare(stringBuffer, textBox1.Text) != 0)
                SaveAsToolStripMenuItem_Click(this, e);
            Application.Exit();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Bruno Brcković\n" + "Project startet: 04/12/2017", "Za C# projekt");
        }

        private void SvaVelikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = textBox1.SelectedText.ToUpper();
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog
            {
                Title = "Find File",
                Filter = "Text Files (*txt)|*.txt|All files(*.*)|*.*"
            };

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                StreamReader myStreamR = new StreamReader(File.OpenRead(openFD.FileName));
                FileNameAndPath = openFD.FileName.ToString();

                textBox1.Text = myStreamR.ReadToEnd();
                stringBuffer = textBox1.Text;
                myStreamR.Dispose();
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0)
            {
                if (string.Compare(stringBuffer, textBox1.Text) != 0)
                    SaveAsToolStripMenuItem_Click(this, e);
            }
            if (textBox1.TextLength > 0)
            {
                textBox1.Clear();
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDF = new SaveFileDialog
            {
                Title = "save File",
                Filter = "Text Files (*txt)|*.txt|All files(*.*)|*.*"
            };

            if (saveDF.ShowDialog() == DialogResult.OK)
            {
                StreamWriter myStreamW = new StreamWriter(File.Create(saveDF.FileName));

                myStreamW.Write(textBox1.Text);
                myStreamW.Dispose();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStreamW = new StreamWriter(FileNameAndPath);
            myStreamW.Write(textBox1.Text);

            myStreamW.Dispose();

        }

        private void PremaPravopisuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = ProvjeriString(textBox1.SelectedText.ToLower());
        }

        private string ProvjeriString(string testiraj)
        {
            int separatorFlag = 0;
            String[] obrada = Regex.Split(testiraj, @"(?<=[.?!\r\n])");

            testiraj = "";

            for (int i = 0; i < obrada.Length; ++i)
            {
                if (obrada[i] == "") continue;

                StringBuilder charCmp = new StringBuilder(obrada[i]);

                if (Char.IsLetter(charCmp[0]) && separatorFlag == 1)
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsLetter(charCmp[0]))
                    obrada[i] = obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                else if (Char.IsSeparator(charCmp[0]))
                {
                    obrada[i] = obrada[i].Trim();
                    obrada[i] = " " + obrada[i].First().ToString().ToUpper() + obrada[i].Substring(1);
                }

                if (obrada[i].EndsWith("!") || obrada[i].EndsWith("?") || obrada[i].EndsWith("."))
                    separatorFlag = 1;
                else
                    separatorFlag = 0;
            }

            foreach (string element in obrada)
            {
                testiraj += element;
            }

            return testiraj;

        }
    }
}
