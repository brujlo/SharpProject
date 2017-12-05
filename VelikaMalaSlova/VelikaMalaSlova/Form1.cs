﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VelikaMalaSlova
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();

            if (fileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string strFileName = fileDialog1.FileName;
                MessageBox.Show(strFileName);
            }
        }
    }
}
