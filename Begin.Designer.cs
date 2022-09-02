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
            this.Confirm = new System.Windows.Forms.ToolStripMenuItem();
            this.TrialLogs = new System.Windows.Forms.ToolStripMenuItem();
            this.生成实验记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看实验记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            this.EditFlow,
            this.Confirm});
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
            // Confirm
            // 
            this.Confirm.Name = "Confirm";
            resources.ApplyResources(this.Confirm, "Confirm");
            // 
            // TrialLogs
            // 
            this.TrialLogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.生成实验记录ToolStripMenuItem,
            this.查看实验记录ToolStripMenuItem});
            resources.ApplyResources(this.TrialLogs, "TrialLogs");
            this.TrialLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.TrialLogs.Name = "TrialLogs";
            // 
            // 生成实验记录ToolStripMenuItem
            // 
            this.生成实验记录ToolStripMenuItem.Name = "生成实验记录ToolStripMenuItem";
            resources.ApplyResources(this.生成实验记录ToolStripMenuItem, "生成实验记录ToolStripMenuItem");
            // 
            // 查看实验记录ToolStripMenuItem
            // 
            this.查看实验记录ToolStripMenuItem.Name = "查看实验记录ToolStripMenuItem";
            resources.ApplyResources(this.查看实验记录ToolStripMenuItem, "查看实验记录ToolStripMenuItem");
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
            // 
            // ContactUs
            // 
            this.ContactUs.Name = "ContactUs";
            resources.ApplyResources(this.ContactUs, "ContactUs");
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
            resources.GetString("checkedListBox1.Items2"),
            resources.GetString("checkedListBox1.Items3")});
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
            // AutoLab
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.Load += new System.EventHandler(this.AutoLab_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private ToolStripMenuItem Confirm;
        private ToolStripMenuItem 生成实验记录ToolStripMenuItem;
        private ToolStripMenuItem 查看实验记录ToolStripMenuItem;
        private Label User;
        private Label Time;
        private Timer timer1;
        private PictureBox pictureBox1;
    }
}

