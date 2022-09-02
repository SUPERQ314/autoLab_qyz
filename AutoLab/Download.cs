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
using cn.bmob.tools;
using cn.bmob.json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace AutoLab
{
    public partial class Download : UserManagement.BmobBase
    {
        public string username;

        public Download(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void find_Click(object sender, EventArgs e)
        {
            find.Enabled = false;
            var query = new BmobQuery();
            query.WhereContainedIn<string>("Username", username);
            var future = Bmob.FindTaskAsync<Model.MyFileObject>("Files", query);
            object message = JsonConvert.DeserializeObject(JsonAdapter.JSON.ToDebugJsonString(future.Result));
            Newtonsoft.Json.Linq.JObject js = message as Newtonsoft.Json.Linq.JObject;
            JArray jarray = (JArray)js["results"];
            List<string> bodyList = new List<string>();
            for (int i = 0; i < jarray.Count; i++)
            {
                string listdata = jarray[i].ToString();
                Object obj1 = JsonConvert.DeserializeObject(listdata);
                Newtonsoft.Json.Linq.JObject js1 = obj1 as Newtonsoft.Json.Linq.JObject;
                string url = js1["URL"].ToString();
                bodyList.Add(url);
                comboBox1.Items.Add(url);
            }
        }
        string fileName;
        public static string HttpDownloadFile(string url, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }


        private void confirm_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            string foldPath = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath + @"\";
            }
            fileName = textBox1.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (HttpDownloadFile(comboBox1.SelectedItem.ToString(), fileName) != null)
            {
                MessageBox.Show("下载成功！");
            }
            else
            {
                MessageBox.Show("下载失败，请检查网络连接！");
            }
        }
    }
}