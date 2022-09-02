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
    public partial class Register : BmobBase
    {
        public Register():
            base()
        {
            InitializeComponent();
        }
        private void OnRegisterFinished(string strResult)
        {
            MessageBox.Show(strResult);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BmobUser user = new BmobUser();
            user.username = username.Text;
            if (password1.Text.Length < 8)
            {
                MessageBox.Show("密码长度必须大于8位！");
            }
            else if (password1.Text == password2.Text)
            {
                user.password = password1.Text;
                user.email = email.Text;
                BmobManager.GetInstance().RegisterUser(user, OnRegisterFinished);
            }
            else
            {
                MessageBox.Show("两次密码输入不一致，请重试！");
            }
            /*//注册用户
            MyUserObject user = new MyUserObject();
            user.username = username.Text;
           // if(password1.Text==password2.Text){
            user.password=password1.Text;
            user.email = email.Text;
            var future = Bmob.CreateTaskAsync<MyUserObject>(user);
            try
            {
                MessageBox.Show("注册成功，请登录！");
                this.Close();
                //FinishedCallback(future.Result, result);
            }
            catch
            {
                MessageBox.Show("注册失败，原因：" + future.Exception.InnerException.ToString());
            }
            //}
            //else
            //{
              //  MessageBox.Show("两次输入密码不一致！");
            //}*/
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }
    }
}
