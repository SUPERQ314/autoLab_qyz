using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLab
{
    public partial class AutoLab : Form
    {
        public string UserMessage;
        public bool denglu = false;
        public AutoLab()
        {
            InitializeComponent();
        }
        
        public void RecieveU(string Value)
        {
            UserMessage = Value;
            denglu = true;
            User.Text = "你好，" + UserMessage;
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new UserManagement.Login();
            login.Show();
            login.sendMessage = RecieveU;
        }

        private void AutoLab_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            var register = new UserManagement.Register();
            register.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确定退出","退出",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                User.Text = "[提示：请先登录]";
            }
            else
            {

            }
        }

        private void EditFlow_Click(object sender, EventArgs e)
        {
            TrialEdit.EditFlow form = new TrialEdit.EditFlow(Station);
            checkedListBox1.SetSelected(1, true);
            bool? result = form.ShowDialog();
            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SetSelected(1, false);
            progressBar.Value = 50;
        }

        public string Types;
        public void Recieve(string value)
        {
            Types = value;
           // MessageBox.Show(Types);
        }
        public Data.Station Station;
        private void SetWorkStation_Click(object sender, EventArgs e)
        {
            TrialEdit.StationEdit form = new TrialEdit.StationEdit();
            checkedListBox1.SetSelected(0, true);
            bool? result = form.ShowDialog();
            Station = form.station;
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox1.SetSelected(0, false);
            progressBar.Value = 25;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLocalTime().ToString();
        }
    }
}
