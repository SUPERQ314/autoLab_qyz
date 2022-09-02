using BmobCSharpFileDemo.Model;
using cn.bmob.exception;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLab.UserManagement
{
    public partial class Login : BmobBase
    {
        public delegate void SendMessage(string value);
        public bool OK = false;
        public SendMessage sendMessage;
        public Login():
            base()
        {
            InitializeComponent();
        }

        private void OnLoginFinished(bool correct)
        {
            if(correct)
            {
                OK = !OK;
                MessageBox.Show("Login！");
            }
            else
            {
                MessageBox.Show("Unable to login:\nerror of username or password\nIf correct,please check network!");
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            BmobUser user = new BmobUser();
            user.username = username.Text;
            user.password = password.Text;
            BmobManager.GetInstance().LoginUser(user, OnLoginFinished);
            System.Threading.Thread.Sleep(1500);
            if(OK==true)
            {
                sendMessage(user.username);
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
