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
using cn.bmob.io;
using cn.bmob.api;
using cn.bmob.json;
using cn.bmob.tools;

namespace AutoLab.UserManagement
{
    public partial class BmobBase : Form
    {
        private BmobWindows bmob;
        public BmobBase():
            base()
        {
            InitializeComponent();
            bmob = new BmobWindows();
            Bmob.initialize("a9d9cec47d56cde6aa91589aede02314", "ae626757b2be3fbe84066835ef047810");
            BmobDebug.Register(msg => { Debug.WriteLine(msg); });
        }

        public BmobWindows Bmob
        {
            get { return bmob; }
        }

        public void FinishedCallback<T>(T data, TextBox text)
        {
            text.Text = JsonAdapter.JSON.ToDebugJsonString(data);
        }

        private void BmobBase_Load(object sender, EventArgs e)
        {

        }
    }
}
