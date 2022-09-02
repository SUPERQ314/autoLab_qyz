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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;

namespace AutoLab
{
    public partial class AutoLab : Form
    {
        public string UserMessage;
        public bool denglu = false;
        public bool settle = false;
        public bool edit = false;
        private SerialPort ComDevice = new SerialPort();
        public AutoLab()
        {
            InitializeComponent();
            InitralConfig();
        }
        private void InitralConfig()
        {
            comboBox1.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Text = "未检测到串口";
            }
            pictureBox3.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            //红色rgb 255，0，0 绿色rgb0，255，0 蓝色0，0，255
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            AddData(ReDatas);
        }
        public void AddData(byte[] data)
        {
            AddContent(new ASCIIEncoding().GetString(data));
        }
        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                switch(content)
                {
                case "Ready!":
                    {
                        byte[] sendData = null;
                        string info_S = file;
                        sendData = Encoding.ASCII.GetBytes(info_S);
                        SendData(sendData);
                        break;
                    }
                case "Start!":
                    {
                        button3.Enabled = false;
                        button4.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = true;
                        break;
                    }
                case "Stop!":
                    {
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button6.Enabled = true;
                        button7.Enabled = true;
                        break;
                    }
                case "Continue!":
                    {
                        button3.Enabled = false;
                        button4.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = true;
                        break;
                    }
                case "End!":
                    {
                        button3.Enabled = true;
                        button4.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "Error1":
                    {
                        System.Windows.Forms.MessageBox.Show("枪头堵塞!", "故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "Error2":
                    {
                        System.Windows.Forms.MessageBox.Show("无足够的耗材!", "故障", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        break;
                    }
                case "Recover!":
                    {
                        button3.Enabled = false;
                        button4.Enabled = true;
                        button6.Enabled = false;
                        button7.Enabled = true;
                        break;
                    }
                }
            
                textBox2.Text += content + '\n';
            }));
        }
        string file = "";
        private void shakehand()
        {
            byte[] sendData = null;
            string info_S = "Are you ready?\n";
            //法二
            //ComDevice.Write(info_S);
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
            UserManagement.Register register = new UserManagement.Register();
            register.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = System.Windows.Forms.MessageBox.Show("是否确定退出","退出",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(dr == DialogResult.OK)
            {
                User.Text = "[提示：请先登录]";
            }
            else
            {

            }
        }
        public double time = 0;
        public void recieveTime(double value)
        {
            time = value;
        }
        private void EditFlow_Click(object sender, EventArgs e)
        {
            if (settle)
            {
                TrialEdit.EditFlow form = new TrialEdit.EditFlow(Station,preset);
                checkedListBox1.SetSelected(1, true);
                form.sendMessage = recieveTime;
                bool? result = form.ShowDialog();
                Time form1 = new Time(time);
                form1.ShowDialog();
                checkedListBox1.SetItemChecked(1, true);
                checkedListBox1.SetItemChecked(2, true);
                checkedListBox1.SetSelected(1, false);
                progressBar.Value = 100;
                edit = true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请先配置工作站！","Info");
            }
        }

        public string Types="";
        public void Recieve(string value)
        {
            Types = value;
           // MessageBox.Show(Types);
        }

        public string preset="";
        public void RecieveP(string value)
        {
            preset = value;
        }
        public Data.Station Station;
        private void SetWorkStation_Click(object sender, EventArgs e)
        {
            if (denglu)
            {
                if (settle)
                {
                    System.Windows.Forms.MessageBox.Show("不可重复配置工作平台！");
                }
                else
                {
                    TrialEdit.StationEdit form = new TrialEdit.StationEdit();
                    checkedListBox1.SetSelected(0, true);
                    form.Preset = RecieveP;
                    Station = form.station;
                    bool? result = form.ShowDialog();
                    settle = true;
                    checkedListBox1.SetItemChecked(0, true);
                    checkedListBox1.SetSelected(0, false);
                    progressBar.Value = 33;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请先登录！");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time.Text = DateTime.Now.ToLocalTime().ToString();
        }

        private void CheckFlowDesign_Click(object sender, EventArgs e)
        {
            if (denglu)
            {
                Check check = new Check();
                check.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请先登录！");
            }
        }

        private void UpLoad_Click(object sender, EventArgs e)
        {
            if (denglu)
            {
                var upload = new upLoad(UserMessage);
                upload.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请先登录！");
            }
        }

        private void TimeConsuming_Click(object sender, EventArgs e)
        {
            /*if (edit)
            {
                checkedListBox1.SetSelected(3, true);
                Time form = new Time(time);
                form.ShowDialog();
                checkedListBox1.SetItemChecked(3, true);
                checkedListBox1.SetSelected(3, false);
                progressBar.Value = 100;
            }
            else
            {
                MessageBox.Show("请先编辑实验流程！");
            }*/
            checkedListBox1.SetSelected(3, true);
            var form = new serialport();
            form.ShowDialog();
            checkedListBox1.SetItemChecked(3, true);
            checkedListBox1.SetSelected(3, false);
            progressBar.Value = 100;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            string info_S = "Start?\n";
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            string info_S = "Stop?\n";
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count <= 0)
            {
                System.Windows.Forms.MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }
            if (ComDevice.IsOpen == false)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.DefaultExt = "efd";
                dlg.Filter = "ExperientFlowDesign file (*.efd)|*.efd";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dlg.FileName;
                    if (dlg.FileName == null)
                    {
                        return;
                    }
                }
                StreamReader sr = new StreamReader(textBox1.Text, System.Text.Encoding.Default);
                file = sr.ReadToEnd().TrimStart();
                sr.Close();
                ComDevice.PortName = comboBox1.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32("115200");
                ComDevice.Parity = (Parity)Convert.ToInt32("0");
                ComDevice.DataBits = Convert.ToInt32("8");
                ComDevice.StopBits = (StopBits)Convert.ToInt32("1");
                try
                {
                    ComDevice.Open();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button5.Text = "断开与工作站的连接";
                pictureBox3.BackColor = System.Drawing.Color.FromArgb(0, 255, 0);
                shakehand();
            }
            else
            {
                try
                {
                    ComDevice.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button5.Text = "选择要执行的文件";
                pictureBox3.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);
            }
            comboBox1.Enabled = !ComDevice.IsOpen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            string info_S = "Request?\n";
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            string info_S = "Continue?\n";
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            string info_S = "End?\n";
            sendData = Encoding.ASCII.GetBytes(info_S);
            SendData(sendData);
        }

        private void Infos_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("详见软件说明书！");
        }

        private void ContactUs_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("欢迎致电18962980078");
        }

        private void Download_Click(object sender, EventArgs e)
        {
            if (denglu)
            {
                var form = new Download(UserMessage);
                form.ShowDialog();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("请先登录！");
            }
        }
    }
}
