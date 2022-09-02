namespace AutoLab
{
    partial class serialport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ComList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DataBits = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Parity = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rbtnHex = new System.Windows.Forms.RadioButton();
            this.rbtnASCII = new System.Windows.Forms.RadioButton();
            this.rbtnUTF8 = new System.Windows.Forms.RadioButton();
            this.rbtnUnicode = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.txtShowData = new System.Windows.Forms.TextBox();
            this.lblRevCount = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.rbtnSendHex = new System.Windows.Forms.RadioButton();
            this.rbtnSendASCII = new System.Windows.Forms.RadioButton();
            this.rbtnSendUTF8 = new System.Windows.Forms.RadioButton();
            this.rbtnSendUnicode = new System.Windows.Forms.RadioButton();
            this.lblSendCount = new System.Windows.Forms.Label();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnClearRev = new System.Windows.Forms.Button();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(618, 421);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "手动发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "端口设置";
            // 
            // ComList
            // 
            this.ComList.FormattingEnabled = true;
            this.ComList.Location = new System.Drawing.Point(16, 41);
            this.ComList.Name = "ComList";
            this.ComList.Size = new System.Drawing.Size(103, 20);
            this.ComList.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(125, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "端口";
            // 
            // BaudRate
            // 
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Location = new System.Drawing.Point(16, 76);
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(103, 20);
            this.BaudRate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(126, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "波特率";
            // 
            // DataBits
            // 
            this.DataBits.FormattingEnabled = true;
            this.DataBits.Location = new System.Drawing.Point(16, 115);
            this.DataBits.Name = "DataBits";
            this.DataBits.Size = new System.Drawing.Size(103, 20);
            this.DataBits.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(127, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据位";
            // 
            // StopBits
            // 
            this.StopBits.FormattingEnabled = true;
            this.StopBits.Location = new System.Drawing.Point(16, 157);
            this.StopBits.Name = "StopBits";
            this.StopBits.Size = new System.Drawing.Size(103, 20);
            this.StopBits.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(126, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "停止位";
            // 
            // Parity
            // 
            this.Parity.FormattingEnabled = true;
            this.Parity.Location = new System.Drawing.Point(16, 194);
            this.Parity.Name = "Parity";
            this.Parity.Size = new System.Drawing.Size(103, 20);
            this.Parity.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(125, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "校验位";
            // 
            // rbtnHex
            // 
            this.rbtnHex.AutoSize = true;
            this.rbtnHex.Location = new System.Drawing.Point(3, 6);
            this.rbtnHex.Name = "rbtnHex";
            this.rbtnHex.Size = new System.Drawing.Size(41, 16);
            this.rbtnHex.TabIndex = 12;
            this.rbtnHex.Text = "Hex";
            this.rbtnHex.UseVisualStyleBackColor = true;
            // 
            // rbtnASCII
            // 
            this.rbtnASCII.AutoSize = true;
            this.rbtnASCII.Location = new System.Drawing.Point(50, 5);
            this.rbtnASCII.Name = "rbtnASCII";
            this.rbtnASCII.Size = new System.Drawing.Size(53, 16);
            this.rbtnASCII.TabIndex = 13;
            this.rbtnASCII.Text = "ASCII";
            this.rbtnASCII.UseVisualStyleBackColor = true;
            // 
            // rbtnUTF8
            // 
            this.rbtnUTF8.AutoSize = true;
            this.rbtnUTF8.Location = new System.Drawing.Point(120, 5);
            this.rbtnUTF8.Name = "rbtnUTF8";
            this.rbtnUTF8.Size = new System.Drawing.Size(53, 16);
            this.rbtnUTF8.TabIndex = 14;
            this.rbtnUTF8.Text = "UTF-8";
            this.rbtnUTF8.UseVisualStyleBackColor = true;
            // 
            // rbtnUnicode
            // 
            this.rbtnUnicode.AutoSize = true;
            this.rbtnUnicode.Location = new System.Drawing.Point(184, 4);
            this.rbtnUnicode.Name = "rbtnUnicode";
            this.rbtnUnicode.Size = new System.Drawing.Size(65, 16);
            this.rbtnUnicode.TabIndex = 15;
            this.rbtnUnicode.Text = "Unicode";
            this.rbtnUnicode.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(217, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "自动换行";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // txtShowData
            // 
            this.txtShowData.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtShowData.Location = new System.Drawing.Point(217, 65);
            this.txtShowData.Multiline = true;
            this.txtShowData.Name = "txtShowData";
            this.txtShowData.ReadOnly = true;
            this.txtShowData.Size = new System.Drawing.Size(463, 193);
            this.txtShowData.TabIndex = 17;
            // 
            // lblRevCount
            // 
            this.lblRevCount.AutoSize = true;
            this.lblRevCount.Location = new System.Drawing.Point(579, 44);
            this.lblRevCount.Name = "lblRevCount";
            this.lblRevCount.Size = new System.Drawing.Size(77, 12);
            this.lblRevCount.TabIndex = 18;
            this.lblRevCount.Text = "接收字节数：";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(44, 235);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 19;
            this.btnOpen.Text = "打开串口";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // rbtnSendHex
            // 
            this.rbtnSendHex.AutoSize = true;
            this.rbtnSendHex.Location = new System.Drawing.Point(3, 5);
            this.rbtnSendHex.Name = "rbtnSendHex";
            this.rbtnSendHex.Size = new System.Drawing.Size(41, 16);
            this.rbtnSendHex.TabIndex = 20;
            this.rbtnSendHex.TabStop = true;
            this.rbtnSendHex.Text = "Hex";
            this.rbtnSendHex.UseVisualStyleBackColor = true;
            // 
            // rbtnSendASCII
            // 
            this.rbtnSendASCII.AutoSize = true;
            this.rbtnSendASCII.Location = new System.Drawing.Point(50, 5);
            this.rbtnSendASCII.Name = "rbtnSendASCII";
            this.rbtnSendASCII.Size = new System.Drawing.Size(53, 16);
            this.rbtnSendASCII.TabIndex = 21;
            this.rbtnSendASCII.TabStop = true;
            this.rbtnSendASCII.Text = "ASCII";
            this.rbtnSendASCII.UseVisualStyleBackColor = true;
            // 
            // rbtnSendUTF8
            // 
            this.rbtnSendUTF8.AutoSize = true;
            this.rbtnSendUTF8.Location = new System.Drawing.Point(118, 5);
            this.rbtnSendUTF8.Name = "rbtnSendUTF8";
            this.rbtnSendUTF8.Size = new System.Drawing.Size(53, 16);
            this.rbtnSendUTF8.TabIndex = 22;
            this.rbtnSendUTF8.TabStop = true;
            this.rbtnSendUTF8.Text = "UTF-8";
            this.rbtnSendUTF8.UseVisualStyleBackColor = true;
            // 
            // rbtnSendUnicode
            // 
            this.rbtnSendUnicode.AutoSize = true;
            this.rbtnSendUnicode.Location = new System.Drawing.Point(186, 5);
            this.rbtnSendUnicode.Name = "rbtnSendUnicode";
            this.rbtnSendUnicode.Size = new System.Drawing.Size(65, 16);
            this.rbtnSendUnicode.TabIndex = 23;
            this.rbtnSendUnicode.TabStop = true;
            this.rbtnSendUnicode.Text = "Unicode";
            this.rbtnSendUnicode.UseVisualStyleBackColor = true;
            // 
            // lblSendCount
            // 
            this.lblSendCount.AutoSize = true;
            this.lblSendCount.Location = new System.Drawing.Point(497, 430);
            this.lblSendCount.Name = "lblSendCount";
            this.lblSendCount.Size = new System.Drawing.Size(77, 12);
            this.lblSendCount.TabIndex = 24;
            this.lblSendCount.Text = "发送字节数：";
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(217, 307);
            this.txtSendData.Multiline = true;
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(463, 108);
            this.txtSendData.TabIndex = 25;
            // 
            // btnClearRev
            // 
            this.btnClearRev.Location = new System.Drawing.Point(44, 296);
            this.btnClearRev.Name = "btnClearRev";
            this.btnClearRev.Size = new System.Drawing.Size(75, 23);
            this.btnClearRev.TabIndex = 26;
            this.btnClearRev.Text = "清空接收区";
            this.btnClearRev.UseVisualStyleBackColor = true;
            this.btnClearRev.Click += new System.EventHandler(this.btnClearRev_Click);
            // 
            // btnClearSend
            // 
            this.btnClearSend.Location = new System.Drawing.Point(44, 354);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(75, 23);
            this.btnClearSend.TabIndex = 27;
            this.btnClearSend.Text = "清空发送区";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(215, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "数据接收区";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(215, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "数据发送区";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnHex);
            this.panel1.Controls.Add(this.rbtnASCII);
            this.panel1.Controls.Add(this.rbtnUTF8);
            this.panel1.Controls.Add(this.rbtnUnicode);
            this.panel1.Location = new System.Drawing.Point(318, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 28);
            this.panel1.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbtnSendHex);
            this.panel2.Controls.Add(this.rbtnSendASCII);
            this.panel2.Controls.Add(this.rbtnSendUTF8);
            this.panel2.Controls.Add(this.rbtnSendUnicode);
            this.panel2.Location = new System.Drawing.Point(233, 421);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 26);
            this.panel2.TabIndex = 31;
            // 
            // chkAutoLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClearSend);
            this.Controls.Add(this.btnClearRev);
            this.Controls.Add(this.txtSendData);
            this.Controls.Add(this.lblSendCount);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblRevCount);
            this.Controls.Add(this.txtShowData);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Parity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.StopBits);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DataBits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BaudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ComList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Name = "chkAutoLine";
            this.Text = "serialport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ComList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox DataBits;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox StopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Parity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbtnHex;
        private System.Windows.Forms.RadioButton rbtnASCII;
        private System.Windows.Forms.RadioButton rbtnUTF8;
        private System.Windows.Forms.RadioButton rbtnUnicode;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txtShowData;
        private System.Windows.Forms.Label lblRevCount;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.RadioButton rbtnSendHex;
        private System.Windows.Forms.RadioButton rbtnSendASCII;
        private System.Windows.Forms.RadioButton rbtnSendUTF8;
        private System.Windows.Forms.RadioButton rbtnSendUnicode;
        private System.Windows.Forms.Label lblSendCount;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.Button btnClearRev;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}