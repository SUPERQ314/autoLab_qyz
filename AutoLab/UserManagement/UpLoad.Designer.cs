namespace AutoLab
{
    partial class upLoad
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileText = new System.Windows.Forms.TextBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.formstatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileText
            // 
            this.fileText.Location = new System.Drawing.Point(56, 51);
            this.fileText.Name = "fileText";
            this.fileText.Size = new System.Drawing.Size(208, 21);
            this.fileText.TabIndex = 0;
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(286, 51);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "选择文件";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // uploadBtn
            // 
            this.uploadBtn.Enabled = false;
            this.uploadBtn.Location = new System.Drawing.Point(162, 185);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(75, 23);
            this.uploadBtn.TabIndex = 2;
            this.uploadBtn.Text = "上传文件";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.uploadBtn_Click);
            // 
            // formstatus
            // 
            this.formstatus.AutoSize = true;
            this.formstatus.Location = new System.Drawing.Point(71, 89);
            this.formstatus.Name = "formstatus";
            this.formstatus.Size = new System.Drawing.Size(0, 12);
            this.formstatus.TabIndex = 3;
            // 
            // upLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 261);
            this.Controls.Add(this.formstatus);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.fileText);
            this.Name = "upLoad";
            this.Text = "UpLoad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox fileText;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label formstatus;
    }
}