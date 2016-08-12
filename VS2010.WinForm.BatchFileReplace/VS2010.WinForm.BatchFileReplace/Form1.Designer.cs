namespace VS2010.WinForm.BatchFileReplace
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtSrcDirectoryPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesDirectoryPath = new System.Windows.Forms.TextBox();
            this.chkSubDirectoryReplace = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblShowResult = new System.Windows.Forms.Label();
            this.rtxtSearchContent = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtReplaceContent = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRegPatten = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(145, 324);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "源目录";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txtSrcDirectoryPath
            // 
            this.txtSrcDirectoryPath.Location = new System.Drawing.Point(112, 178);
            this.txtSrcDirectoryPath.Name = "txtSrcDirectoryPath";
            this.txtSrcDirectoryPath.Size = new System.Drawing.Size(295, 21);
            this.txtSrcDirectoryPath.TabIndex = 2;
            this.txtSrcDirectoryPath.Text = "E:\\VIP\\程序更新补丁\\网站版实时准备更新\\ccd1.cqvip.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 241);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换后的目录";
            // 
            // txtDesDirectoryPath
            // 
            this.txtDesDirectoryPath.Location = new System.Drawing.Point(112, 241);
            this.txtDesDirectoryPath.Name = "txtDesDirectoryPath";
            this.txtDesDirectoryPath.Size = new System.Drawing.Size(295, 21);
            this.txtDesDirectoryPath.TabIndex = 4;
            this.txtDesDirectoryPath.Text = "E:\\VIP\\程序更新补丁\\网站版实时准备更新\\ccd1.cqvip.com.replace";
            // 
            // chkSubDirectoryReplace
            // 
            this.chkSubDirectoryReplace.AutoSize = true;
            this.chkSubDirectoryReplace.Location = new System.Drawing.Point(112, 207);
            this.chkSubDirectoryReplace.Name = "chkSubDirectoryReplace";
            this.chkSubDirectoryReplace.Size = new System.Drawing.Size(108, 16);
            this.chkSubDirectoryReplace.TabIndex = 5;
            this.chkSubDirectoryReplace.Text = "替换子目录文件";
            this.chkSubDirectoryReplace.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "...浏览";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(425, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "...浏览";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(288, 324);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "停止";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(33, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(461, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // lblShowResult
            // 
            this.lblShowResult.AutoSize = true;
            this.lblShowResult.Location = new System.Drawing.Point(42, 308);
            this.lblShowResult.Name = "lblShowResult";
            this.lblShowResult.Size = new System.Drawing.Size(0, 12);
            this.lblShowResult.TabIndex = 10;
            // 
            // rtxtSearchContent
            // 
            this.rtxtSearchContent.Location = new System.Drawing.Point(112, 13);
            this.rtxtSearchContent.Name = "rtxtSearchContent";
            this.rtxtSearchContent.Size = new System.Drawing.Size(295, 47);
            this.rtxtSearchContent.TabIndex = 11;
            this.rtxtSearchContent.Text = "http://192.168.20.80:10001/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "搜索内容";
            // 
            // rtxtReplaceContent
            // 
            this.rtxtReplaceContent.Location = new System.Drawing.Point(112, 100);
            this.rtxtReplaceContent.Name = "rtxtReplaceContent";
            this.rtxtReplaceContent.Size = new System.Drawing.Size(295, 48);
            this.rtxtReplaceContent.TabIndex = 13;
            this.rtxtReplaceContent.Text = "http://libad.cqvip.com/";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "替换内容";
            // 
            // chkRegPatten
            // 
            this.chkRegPatten.AutoSize = true;
            this.chkRegPatten.Location = new System.Drawing.Point(112, 66);
            this.chkRegPatten.Name = "chkRegPatten";
            this.chkRegPatten.Size = new System.Drawing.Size(108, 16);
            this.chkRegPatten.TabIndex = 15;
            this.chkRegPatten.Text = "使用正则表达式";
            this.chkRegPatten.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 376);
            this.Controls.Add(this.chkRegPatten);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtxtReplaceContent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtxtSearchContent);
            this.Controls.Add(this.lblShowResult);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chkSubDirectoryReplace);
            this.Controls.Add(this.txtDesDirectoryPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSrcDirectoryPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtSrcDirectoryPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesDirectoryPath;
        private System.Windows.Forms.CheckBox chkSubDirectoryReplace;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblShowResult;
        private System.Windows.Forms.RichTextBox rtxtSearchContent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtReplaceContent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRegPatten;
    }
}

