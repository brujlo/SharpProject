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
            String temp =  textBox1.SelectedText.ToLower();
            String[] obrada = Regex.Split(temp, @"(?<=[.?!\r\n])");

            for (int i = 0; i < obrada.Length; ++i)
            {
                obrada[i] = ProvjeriString(obrada[i]);
            }

            temp = "";
            foreach (string element in obrada)
            {
                temp += element; 
            }

            textBox1.SelectedText = temp;

        }

        private string ProvjeriString(string testiraj)
        {
            if (testiraj == "") return testiraj;

            StringBuilder charCmp = new StringBuilder(testiraj);

            if (Char.IsLetter(charCmp[0]))
                return testiraj.First().ToString().ToUpper() + testiraj.Substring(1);
            else if (Char.IsSeparator(charCmp[0]))
            {
                testiraj = testiraj.Trim();
                return " " + testiraj.First().ToString().ToUpper() + testiraj.Substring(1);
            }
            return testiraj;
        }
    }
}
