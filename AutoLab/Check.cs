using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Git.Framework.DataTypes;
using Git.Framework.DataTypes.ExtensionMethods;

namespace AutoLab
{
    public partial class Check : Form
    {
        public Check()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filename = new OpenFileDialog();
            filename.InitialDirectory = Application.StartupPath;
            filename.Filter = "Edit Flow Design files(*.efd)|*.efd|Station Presettle File (*.spf)|*.spf";
            filename.FilterIndex = 2;
            filename.RestoreDirectory = true;
            if (filename.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = filename.FileName.ToString();
                StreamReader sr = new StreamReader(filename.FileName, Encoding.Default);
                textBox2.ScrollBars = ScrollBars.Vertical;
                textBox2.ReadOnly = true;
                textBox2.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
