using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLab
{
    public partial class Time : Form
    {
        public Time(double time)
        {
            InitializeComponent();
            int hour = (int)time / 3600;
            int min = ((int)time - hour * 3600) / 60;
            int sec = (int)time % 60;
            label1.Text = hour.ToString();
            label3.Text = min.ToString();
            label5.Text = sec.ToString();
        }
    }
}
