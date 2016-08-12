namespace VS2012.WinForm.ValidateCode
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
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.radLocalImagePath = new System.Windows.Forms.RadioButton();
            this.radNetImagePath = new System.Windows.Forms.RadioButton();
            this.btnResolveImage = new System.Windows.Forms.Button();
            this.picGrayCode = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picOriginalCode = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayCode)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // txtImagePath
            // 
            this.txtImagePath.Location = new System.Drawing.Point(194, 12);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(545, 21);
            this.txtImagePath.TabIndex = 0;
            this.txtImagePath.Text = "http://passport.cnblogs.com/ValidCodeImage.aspx?id=DZPj7u7k%2fOE%3d";
            // 
            // radLocalImagePath
            // 
            this.radLocalImagePath.AutoSize = true;
            this.radLocalImagePath.Location = new System.Drawing.Point(12, 13);
            this.radLocalImagePath.Name = "radLocalImagePath";
            this.radLocalImagePath.Size = new System.Drawing.Size(71, 16);
            this.radLocalImagePath.TabIndex = 1;
            this.radLocalImagePath.TabStop = true;
            this.radLocalImagePath.Text = "本地图片";
            this.radLocalImagePath.UseVisualStyleBackColor = true;
            // 
            // radNetImagePath
            // 
            this.radNetImagePath.AutoSize = true;
            this.radNetImagePath.Checked = true;
            this.radNetImagePath.Location = new System.Drawing.Point(90, 13);
            this.radNetImagePath.Name = "radNetImagePath";
            this.radNetImagePath.Size = new System.Drawing.Size(71, 16);
            this.radNetImagePath.TabIndex = 2;
            this.radNetImagePath.TabStop = true;
            this.radNetImagePath.Text = "网络图片";
            this.radNetImagePath.UseVisualStyleBackColor = true;
            // 
            // btnResolveImage
            // 
            this.btnResolveImage.Location = new System.Drawing.Point(759, 12);
            this.btnResolveImage.Name = "btnResolveImage";
            this.btnResolveImage.Size = new System.Drawing.Size(75, 23);
            this.btnResolveImage.TabIndex = 3;
            this.btnResolveImage.Text = "开始解析";
            this.btnResolveImage.UseVisualStyleBackColor = true;
            this.btnResolveImage.Click += new System.EventHandler(this.btnResolveImage_Click);
            // 
            // picGrayCode
            // 
            this.picGrayCode.Location = new System.Drawing.Point(23, 147);
            this.picGrayCode.Name = "picGrayCode";
            this.picGrayCode.Size = new System.Drawing.Size(329, 117);
            this.picGrayCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGrayCode.TabIndex = 4;
            this.picGrayCode.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.picOriginalCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.picGrayCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 387);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作面板";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(212, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "原始验证码图:";
            // 
            // picOriginalCode
            // 
            this.picOriginalCode.Location = new System.Drawing.Point(214, 85);
            this.picOriginalCode.Name = "picOriginalCode";
            this.picOriginalCode.Size = new System.Drawing.Size(138, 50);
            this.picOriginalCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOriginalCode.TabIndex = 8;
            this.picOriginalCode.TabStop = false;
            this.picOriginalCode.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.picOriginalCode_LoadCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "手动输入验证码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 21);
            this.textBox1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "分割前放大图";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(451, 79);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(414, 372);
            this.textBox2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 299);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(87, 299);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 50);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(154, 299);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 50);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(228, 299);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 50);
            this.pictureBox4.TabIndex = 13;
            this.pictureBox4.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 463);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnResolveImage);
            this.Controls.Add(this.radNetImagePath);
            this.Controls.Add(this.radLocalImagePath);
            this.Controls.Add(this.txtImagePath);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picGrayCode)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginalCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.RadioButton radLocalImagePath;
        private System.Windows.Forms.RadioButton radNetImagePath;
        private System.Windows.Forms.Button btnResolveImage;
        private System.Windows.Forms.PictureBox picGrayCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picOriginalCode;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

