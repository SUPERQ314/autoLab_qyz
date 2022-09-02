using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cn.bmob.api;
using cn.bmob.io;
using cn.bmob.json;
using cn.bmob.tools;
using System.Diagnostics;
using System.IO;
using System.Net;
using cn.bmob.exception;
using AutoLab.Model;

namespace AutoLab
{
    public partial class upLoad : UserManagement.BmobBase
    {
        public const String TABLE_NAME = "Files";
        private MyFileObject myfile = new Model.MyFileObject(TABLE_NAME);

        public string UserName;
        public upLoad(string username)
            : base()
        {
            UserName = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Edit Flow Design files(*.efd)|*.efd|Station Presettle File (*.spf)|*.spf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Filter = "Edit Flow Design files(*.efd)|*.efd";
                fileText.Text = openFileDialog1.FileName;
                var path = System.IO.Path.GetDirectoryName(openFileDialog1.FileName);
                var name = System.IO.Path.GetFileName(openFileDialog1.FileName);
                StreamReader sr = File.OpenText(openFileDialog1.FileName);
                uploadBtn.Enabled = true;
            }
        }
        byte[] postData;
        public void FileToByte(string fileUrl)
        {
            try
            {
                using (FileStream fs = new FileStream(fileUrl, FileMode.Open, FileAccess.Read))
                {
                    postData = new byte[fs.Length];
                    fs.Read(postData, 0, postData.Length);
                }
            }
            catch
            {

            }
        }
        public static string RequestData(byte[] postData)
        {
            string url = "https://api2.bmob.cn/2/files/fileName.txt";
            string method = "post";
            try
            {
                method = method.ToUpper();
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                request.ContentType = "text/plain";
                WebHeaderCollection headers = request.Headers;
                headers.Add("X-Bmob-Application-Id", "a9d9cec47d56cde6aa91589aede02314");
                headers.Add("X-Bmob-REST-API-Key", "ae626757b2be3fbe84066835ef047810");
                if (method == "POST")
                {
                    request.ContentLength = postData.Length;
                    Stream stream = request.GetRequestStream();
                    stream.Write(postData, 0, postData.Length);
                    stream.Close();
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                return retString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            FileToByte(fileText.Text);
            string Message = RequestData(postData);
            for (var i = 0; i < Message.Length; i++)
            {
                if (Message[i] == 'u')
                {
                    if (Message[i + 1] == 'r')
                    {
                        if (Message[i + 2] == 'l')
                        {
                            string url = Message.Substring(i + 6, Message.Length - 2 - (i + 6));
                            myfile.UserName = UserName;
                            myfile.URL = url;
                            var future = Bmob.CreateTaskAsync(myfile);
                            myfile.objectId = future.Result.objectId;
                            MessageBox.Show(future.Result.ToString());
                            break;
                        }
                    }
                }
            }
        }
    }
}