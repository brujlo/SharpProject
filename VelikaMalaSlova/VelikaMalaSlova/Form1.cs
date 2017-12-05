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

namespace VelikaMalaSlova
{
    public partial class Form1 : Form
    {
        private string fileNameAndPath;
        public Form1()
        {
            InitializeComponent();
            fileNameAndPath = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Bruno Brcković\n" + "Project startet: 04/12/2017", "Za C# projekt");
        }

        private void svaVelikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = textBox1.SelectedText.ToUpper();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "Find File";
            openFD.Filter = "Text Files (*txt)|*.txt|All files(*.*)|*.*";

            if (openFD.ShowDialog() == DialogResult.OK)
            {
                StreamReader myStreamR = new StreamReader(File.OpenRead(openFD.FileName));
                fileNameAndPath = openFD.FileName.ToString();

                textBox1.Text = myStreamR.ReadToEnd();
                myStreamR.Dispose();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem_Click(this, e);
            if (textBox1.TextLength > 0)
            {
                textBox1.Clear();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDF = new SaveFileDialog();
            saveDF.Title = "save File";
            saveDF.Filter = "Text Files (*txt)|*.txt|All files(*.*)|*.*";

            if (saveDF.ShowDialog() == DialogResult.OK)
            {
                StreamWriter myStreamW = new StreamWriter(File.Create(saveDF.FileName));

                myStreamW.Write(textBox1.Text);
                myStreamW.Dispose();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter myStreamW = new StreamWriter(fileNameAndPath);
            myStreamW.Write(textBox1.Text);

            myStreamW.Dispose();

        }
    }
}
