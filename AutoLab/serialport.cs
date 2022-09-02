using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Timers;

namespace AutoLab
{
    public partial class serialport : Form
    {
        public serialport()
        {
            InitializeComponent();
            init();
        }

        public SerialPort ComDevice = new SerialPort();
        public string receiveData;
        public void init()
        {
            txtShowData.ScrollBars = ScrollBars.Vertical;
            BaudRate.Items.Add("1200");
            BaudRate.Items.Add("2400");
            BaudRate.Items.Add("4800");
            BaudRate.Items.Add("9600");
            BaudRate.Items.Add("19200");
            BaudRate.Items.Add("38400");
            BaudRate.Items.Add("43000");
            BaudRate.Items.Add("56000");
            BaudRate.Items.Add("57600");
            BaudRate.Items.Add("115200");
            BaudRate.Items.Add("117600");
            BaudRate.Items.Add("240000");
            StopBits.Items.Add("0");
            StopBits.Items.Add("1");
            StopBits.Items.Add("1.5");
            StopBits.Items.Add("2");
            DataBits.Items.Add("8");
            DataBits.Items.Add("7");
            DataBits.Items.Add("6");
            DataBits.Items.Add("5");
            Parity.Items.Add("无");
            Parity.Items.Add("奇校验");
            Parity.Items.Add("偶校验");
            btnSend.Enabled = false;
            ComList.Items.AddRange(SerialPort.GetPortNames());
            if (ComList.Items.Count > 0)
            {
                ComList.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("未检测到设备！");
            }
            BaudRate.SelectedIndex = 0;
            DataBits.SelectedIndex = 0;
            Parity.SelectedIndex = 0;
            StopBits.SelectedIndex = 0;
        }
        private void Com_DataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            AddData(ReDatas);
        }
        public void AddData(byte[] data)
        {
            if (rbtnHex.Checked)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
            else if (rbtnASCII.Checked)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
            else if (rbtnUTF8.Checked)
            {
                AddContent(new UTF8Encoding().GetString(data));
            }
            else if (rbtnUnicode.Checked)
            {
                AddContent(new UnicodeEncoding().GetString(data));
            }
            else { }
            lblRevCount.Invoke(new MethodInvoker(delegate
            {
                lblRevCount.Text = (int.Parse(lblRevCount.Text) + data.Length).ToString();
            }));
        }
        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                /*if (txtShowData.Text.Length > 0 && checkBox1.Checked)
                {
                    txtShowData.AppendText("\r\n");
                }*/
                receiveData += (content+"\n");
                txtShowData.Text = receiveData;
            }));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (ComList.Items.Count <= 0)
            {
                MessageBox.Show("没有发现串口，请检查连接！");
                return;
            }
            if (ComDevice.IsOpen == false)
            {
                ComDevice.PortName = ComList.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(BaudRate.SelectedItem.ToString());
                ComDevice.Parity = (Parity)Convert.ToInt32(Parity.SelectedIndex.ToString());
                ComDevice.DataBits = Convert.ToInt32(DataBits.SelectedItem.ToString());
                ComDevice.StopBits = (StopBits)Convert.ToInt32(StopBits.SelectedItem.ToString());
                ComDevice.ReadTimeout = 1000;
                ComDevice.ReceivedBytesThreshold = 1;
                try
                {
                    ComDevice.Open();
                    ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataRecieved);
                    btnSend.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                btnOpen.Text = "关闭串口";
            }
            else
            {
                try
                {
                    ComDevice.Close();
                    btnSend.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                btnOpen.Text = "打开串口";
            }
            ComList.Enabled = !ComDevice.IsOpen;
            BaudRate.Enabled = !ComDevice.IsOpen;
            Parity.Enabled = !ComDevice.IsOpen;
            DataBits.Enabled = !ComDevice.IsOpen;
            StopBits.Enabled = !ComDevice.IsOpen;
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
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            byte[] sendData = null;
            if (rbtnSendHex.Checked)
            {
                sendData = strToHexByte(txtShowData.Text.Trim());
            }
            else if (rbtnSendASCII.Checked)
            {
                sendData = Encoding.ASCII.GetBytes(txtShowData.Text.Trim());
            }
            else if (rbtnSendUTF8.Checked)
            {
                sendData = Encoding.UTF8.GetBytes(txtShowData.Text.Trim());
            }
            else if (rbtnSendUnicode.Checked)
            {
                sendData = Encoding.Unicode.GetBytes(txtShowData.Text.Trim());
            }
            else
            {
                sendData = Encoding.ASCII.GetBytes(txtShowData.Text.Trim());
            }
            if (this.SendData(sendData))
            {
                lblSendCount.Invoke(new MethodInvoker(delegate
                {
                    lblSendCount.Text = (int.Parse(lblSendCount.Text) + txtSendData.Text.Length).ToString();
                }));
            }
            else
            {

            }
        }
        private byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0) hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Replace(" ", ""), 16);
            return returnBytes;
        }

        private void btnClearRev_Click(object sender, EventArgs e)
        {
            txtShowData.Clear();
        }

        private void btnClearSend_Click(object sender, EventArgs e)
        {
            txtSendData.Clear();
        }
    }
}
