using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AutoLab
{
    partial class AutoLab
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoLab));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.StationManagements = new System.Windows.Forms.ToolStripMenuItem();
            this.SetWorkStation = new System.Windows.Forms.ToolStripMenuItem();
            this.EditFlow = new System.Windows.Forms.ToolStripMenuItem();
            this.TrialLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.UpLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckFlowDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.ToolStripMenuItem();
            this.UserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Register = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Help = new System.Windows.Forms.ToolStripMenuItem();
            this.Infos = new System.Windows.Forms.ToolStripMenuItem();
            this.ContactUs = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.User = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StationManagements,
            this.TrialLogs,
            this.UserManagement,
            this.Help});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // StationManagements
            // 
            this.StationManagements.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetWorkStation,
            this.EditFlow});
            resources.ApplyResources(this.StationManagements, "StationManagements");
            this.StationManagements.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.StationManagements.Name = "StationManagements";
            // 
            // SetWorkStation
            // 
            this.SetWorkStation.Name = "SetWorkStation";
            resources.ApplyResources(this.SetWorkStation, "SetWorkStation");
            this.SetWorkStation.Click += new System.EventHandler(this.SetWorkStation_Click);
            // 
            // EditFlow
            // 
            this.EditFlow.Name = "EditFlow";
            resources.ApplyResources(this.EditFlow, "EditFlow");
            this.EditFlow.Click += new System.EventHandler(this.EditFlow_Click);
            // 
            // TrialLogs
            // 
            this.TrialLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpLoad,
            this.CheckFlowDesign,
            this.Download});
            resources.ApplyResources(this.TrialLogs, "TrialLogs");
            this.TrialLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TrialLogs.Name = "TrialLogs";
            // 
            // UpLoad
            // 
            this.UpLoad.Name = "UpLoad";
            resources.ApplyResources(this.UpLoad, "UpLoad");
            this.UpLoad.Click += new System.EventHandler(this.UpLoad_Click);
            // 
            // CheckFlowDesign
            // 
            this.CheckFlowDesign.Name = "CheckFlowDesign";
            resources.ApplyResources(this.CheckFlowDesign, "CheckFlowDesign");
            this.CheckFlowDesign.Click += new System.EventHandler(this.CheckFlowDesign_Click);
            // 
            // Download
            // 
            this.Download.Name = "Download";
            resources.ApplyResources(this.Download, "Download");
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // UserManagement
            // 
            this.UserManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Login,
            this.Register,
            this.Exit});
            resources.ApplyResources(this.UserManagement, "UserManagement");
            this.UserManagement.ForeColor = System.Drawing.Color.Navy;
            this.UserManagement.Name = "UserManagement";
            // 
            // Login
            // 
            this.Login.Name = "Login";
            resources.ApplyResources(this.Login, "Login");
            this.Login.Click += new System.EventHandler(this.登录ToolStripMenuItem_Click);
            // 
            // Register
            // 
            this.Register.Name = "Register";
            resources.ApplyResources(this.Register, "Register");
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            resources.ApplyResources(this.Exit, "Exit");
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Help
            // 
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Infos,
            this.ContactUs});
            resources.ApplyResources(this.Help, "Help");
            this.Help.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Help.Name = "Help";
            // 
            // Infos
            // 
            this.Infos.Name = "Infos";
            resources.ApplyResources(this.Infos, "Infos");
            this.Infos.Click += new System.EventHandler(this.Infos_Click);
            // 
            // ContactUs
            // 
            this.ContactUs.Name = "ContactUs";
            resources.ApplyResources(this.ContactUs, "ContactUs");
            this.ContactUs.Click += new System.EventHandler(this.ContactUs_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Name = "label1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.progressBar);
            this.flowLayoutPanel1.Controls.Add(this.checkedListBox1);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Name = "label2";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.MarqueeAnimationSpeed = 1000;
            this.progressBar.Name = "progressBar";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.checkedListBox1, "checkedListBox1");
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            resources.GetString("checkedListBox1.Items"),
            resources.GetString("checkedListBox1.Items1"),
            resources.GetString("checkedListBox1.Items2")});
            this.checkedListBox1.Name = "checkedListBox1";
            // 
            // User
            // 
            resources.ApplyResources(this.User, "User");
            this.User.Name = "User";
            // 
            // Time
            // 
            resources.ApplyResources(this.Time, "Time");
            this.Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Time.Name = "Time";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBox1
            // 
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Name = "comboBox1";
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // pictureBox3
            // 
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button6
            // 
            resources.ApplyResources(this.button6, "button6");
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // AutoLab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.User);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AutoLab";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.AutoLab_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem UserManagement;
        private ToolStripMenuItem StationManagements;
        private ToolStripMenuItem Login;
        private ToolStripMenuItem TrialLogs;
        private ToolStripMenuItem Register;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem Help;
        private ToolStripMenuItem Infos;
        private ToolStripMenuItem ContactUs;
        private ToolStripMenuItem SetWorkStation;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private ProgressBar progressBar;
        private Label label2;
        private CheckedListBox checkedListBox1;
        private ToolStripMenuItem EditFlow;
        private ToolStripMenuItem UpLoad;
        private ToolStripMenuItem CheckFlowDesign;
        private Label User;
        private Label Time;
        private Timer timer1;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label7;
        private ComboBox comboBox1;
        private Button button5;
        private TextBox textBox1;
        private Label label8;
        private PictureBox pictureBox3;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button7;
        private TextBox textBox2;
        private Label label3;
        private ToolStripMenuItem Download;
    }
}

