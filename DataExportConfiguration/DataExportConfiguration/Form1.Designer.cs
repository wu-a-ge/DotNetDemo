namespace DataExportConfiguration
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
            this.cbxTable = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTitlePage = new System.Windows.Forms.TabPage();
            this.tabOtherPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.txt_0 = new System.Windows.Forms.TextBox();
            this.chk_0 = new System.Windows.Forms.CheckBox();
            this.chk_1 = new System.Windows.Forms.CheckBox();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.chk_2 = new System.Windows.Forms.CheckBox();
            this.chk_3 = new System.Windows.Forms.CheckBox();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.chk_4 = new System.Windows.Forms.CheckBox();
            this.txt_5 = new System.Windows.Forms.TextBox();
            this.chk_5 = new System.Windows.Forms.CheckBox();
            this.txt_6 = new System.Windows.Forms.TextBox();
            this.chk_6 = new System.Windows.Forms.CheckBox();
            this.txt_8 = new System.Windows.Forms.TextBox();
            this.chk_8 = new System.Windows.Forms.CheckBox();
            this.txt_7 = new System.Windows.Forms.TextBox();
            this.chk_7 = new System.Windows.Forms.CheckBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_10 = new System.Windows.Forms.TextBox();
            this.chk_10 = new System.Windows.Forms.CheckBox();
            this.txt_9 = new System.Windows.Forms.TextBox();
            this.chk_9 = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabTitlePage.SuspendLayout();
            this.tabOtherPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxTable
            // 
            this.cbxTable.FormattingEnabled = true;
            this.cbxTable.Items.AddRange(new object[] {
            "writer_info",
            "organ_info",
            "media_info",
            "subject_info",
            "fund_info",
            "area_info"});
            this.cbxTable.Location = new System.Drawing.Point(105, 15);
            this.cbxTable.Name = "cbxTable";
            this.cbxTable.Size = new System.Drawing.Size(121, 20);
            this.cbxTable.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTitlePage);
            this.tabControl1.Controls.Add(this.tabOtherPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(581, 636);
            this.tabControl1.TabIndex = 1;
            // 
            // tabTitlePage
            // 
            this.tabTitlePage.Controls.Add(this.txt_10);
            this.tabTitlePage.Controls.Add(this.chk_10);
            this.tabTitlePage.Controls.Add(this.txt_9);
            this.tabTitlePage.Controls.Add(this.chk_9);
            this.tabTitlePage.Controls.Add(this.txt_3);
            this.tabTitlePage.Controls.Add(this.txt_8);
            this.tabTitlePage.Controls.Add(this.chk_8);
            this.tabTitlePage.Controls.Add(this.txt_7);
            this.tabTitlePage.Controls.Add(this.chk_7);
            this.tabTitlePage.Controls.Add(this.txt_6);
            this.tabTitlePage.Controls.Add(this.chk_6);
            this.tabTitlePage.Controls.Add(this.txt_5);
            this.tabTitlePage.Controls.Add(this.chk_5);
            this.tabTitlePage.Controls.Add(this.txt_4);
            this.tabTitlePage.Controls.Add(this.chk_4);
            this.tabTitlePage.Controls.Add(this.chk_3);
            this.tabTitlePage.Controls.Add(this.txt_2);
            this.tabTitlePage.Controls.Add(this.chk_2);
            this.tabTitlePage.Controls.Add(this.label3);
            this.tabTitlePage.Controls.Add(this.label2);
            this.tabTitlePage.Controls.Add(this.txt_1);
            this.tabTitlePage.Controls.Add(this.chk_1);
            this.tabTitlePage.Controls.Add(this.txt_0);
            this.tabTitlePage.Controls.Add(this.chk_0);
            this.tabTitlePage.Controls.Add(this.txtTable);
            this.tabTitlePage.Controls.Add(this.label1);
            this.tabTitlePage.Location = new System.Drawing.Point(4, 22);
            this.tabTitlePage.Name = "tabTitlePage";
            this.tabTitlePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabTitlePage.Size = new System.Drawing.Size(573, 610);
            this.tabTitlePage.TabIndex = 0;
            this.tabTitlePage.Text = "作品表配置";
            this.tabTitlePage.UseVisualStyleBackColor = true;
            // 
            // tabOtherPage
            // 
            this.tabOtherPage.Controls.Add(this.cbxTable);
            this.tabOtherPage.Location = new System.Drawing.Point(4, 22);
            this.tabOtherPage.Name = "tabOtherPage";
            this.tabOtherPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabOtherPage.Size = new System.Drawing.Size(573, 610);
            this.tabOtherPage.TabIndex = 1;
            this.tabOtherPage.Text = "其它表配置";
            this.tabOtherPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "表名 ";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(276, 14);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 21);
            this.txtTable.TabIndex = 1;
            this.txtTable.Text = "title_info";
            // 
            // txt_0
            // 
            this.txt_0.Location = new System.Drawing.Point(188, 79);
            this.txt_0.Multiline = true;
            this.txt_0.Name = "txt_0";
            this.txt_0.Size = new System.Drawing.Size(295, 32);
            this.txt_0.TabIndex = 3;
            // 
            // chk_0
            // 
            this.chk_0.AutoSize = true;
            this.chk_0.Location = new System.Drawing.Point(76, 81);
            this.chk_0.Name = "chk_0";
            this.chk_0.Size = new System.Drawing.Size(48, 16);
            this.chk_0.TabIndex = 2;
            this.chk_0.Tag = "0";
            this.chk_0.Text = "所有";
            this.chk_0.UseVisualStyleBackColor = true;
            // 
            // chk_1
            // 
            this.chk_1.AutoSize = true;
            this.chk_1.Location = new System.Drawing.Point(76, 129);
            this.chk_1.Name = "chk_1";
            this.chk_1.Size = new System.Drawing.Size(48, 16);
            this.chk_1.TabIndex = 4;
            this.chk_1.Tag = "1";
            this.chk_1.Text = "期刊";
            this.chk_1.UseVisualStyleBackColor = true;
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(188, 127);
            this.txt_1.Multiline = true;
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(295, 28);
            this.txt_1.TabIndex = 5;
            this.txt_1.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字段";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文献类型";
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(188, 163);
            this.txt_2.Multiline = true;
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(295, 28);
            this.txt_2.TabIndex = 9;
            this.txt_2.Tag = "";
            // 
            // chk_2
            // 
            this.chk_2.AutoSize = true;
            this.chk_2.Location = new System.Drawing.Point(76, 175);
            this.chk_2.Name = "chk_2";
            this.chk_2.Size = new System.Drawing.Size(48, 16);
            this.chk_2.TabIndex = 8;
            this.chk_2.Tag = "2";
            this.chk_2.Text = "学位";
            this.chk_2.UseVisualStyleBackColor = true;
            // 
            // chk_3
            // 
            this.chk_3.AutoSize = true;
            this.chk_3.Location = new System.Drawing.Point(76, 224);
            this.chk_3.Name = "chk_3";
            this.chk_3.Size = new System.Drawing.Size(48, 16);
            this.chk_3.TabIndex = 10;
            this.chk_3.Tag = "3";
            this.chk_3.Text = "会议";
            this.chk_3.UseVisualStyleBackColor = true;
            // 
            // txt_4
            // 
            this.txt_4.Location = new System.Drawing.Point(188, 261);
            this.txt_4.Multiline = true;
            this.txt_4.Name = "txt_4";
            this.txt_4.Size = new System.Drawing.Size(295, 35);
            this.txt_4.TabIndex = 13;
            // 
            // chk_4
            // 
            this.chk_4.AutoSize = true;
            this.chk_4.Location = new System.Drawing.Point(76, 263);
            this.chk_4.Name = "chk_4";
            this.chk_4.Size = new System.Drawing.Size(48, 16);
            this.chk_4.TabIndex = 12;
            this.chk_4.Tag = "4";
            this.chk_4.Text = "专利";
            this.chk_4.UseVisualStyleBackColor = true;
            // 
            // txt_5
            // 
            this.txt_5.Location = new System.Drawing.Point(188, 302);
            this.txt_5.Multiline = true;
            this.txt_5.Name = "txt_5";
            this.txt_5.Size = new System.Drawing.Size(295, 32);
            this.txt_5.TabIndex = 15;
            // 
            // chk_5
            // 
            this.chk_5.AutoSize = true;
            this.chk_5.Location = new System.Drawing.Point(76, 318);
            this.chk_5.Name = "chk_5";
            this.chk_5.Size = new System.Drawing.Size(48, 16);
            this.chk_5.TabIndex = 14;
            this.chk_5.Tag = "5";
            this.chk_5.Text = "标准";
            this.chk_5.UseVisualStyleBackColor = true;
            // 
            // txt_6
            // 
            this.txt_6.Location = new System.Drawing.Point(188, 349);
            this.txt_6.Multiline = true;
            this.txt_6.Name = "txt_6";
            this.txt_6.Size = new System.Drawing.Size(295, 33);
            this.txt_6.TabIndex = 17;
            // 
            // chk_6
            // 
            this.chk_6.AutoSize = true;
            this.chk_6.Location = new System.Drawing.Point(76, 366);
            this.chk_6.Name = "chk_6";
            this.chk_6.Size = new System.Drawing.Size(48, 16);
            this.chk_6.TabIndex = 16;
            this.chk_6.Tag = "6";
            this.chk_6.Text = "成果";
            this.chk_6.UseVisualStyleBackColor = true;
            // 
            // txt_8
            // 
            this.txt_8.Location = new System.Drawing.Point(188, 445);
            this.txt_8.Multiline = true;
            this.txt_8.Name = "txt_8";
            this.txt_8.Size = new System.Drawing.Size(295, 33);
            this.txt_8.TabIndex = 21;
            // 
            // chk_8
            // 
            this.chk_8.AutoSize = true;
            this.chk_8.Location = new System.Drawing.Point(76, 447);
            this.chk_8.Name = "chk_8";
            this.chk_8.Size = new System.Drawing.Size(48, 16);
            this.chk_8.TabIndex = 20;
            this.chk_8.Tag = "8";
            this.chk_8.Text = "产品";
            this.chk_8.UseVisualStyleBackColor = true;
            // 
            // txt_7
            // 
            this.txt_7.Location = new System.Drawing.Point(188, 399);
            this.txt_7.Multiline = true;
            this.txt_7.Name = "txt_7";
            this.txt_7.Size = new System.Drawing.Size(295, 32);
            this.txt_7.TabIndex = 19;
            // 
            // chk_7
            // 
            this.chk_7.AutoSize = true;
            this.chk_7.Location = new System.Drawing.Point(76, 401);
            this.chk_7.Name = "chk_7";
            this.chk_7.Size = new System.Drawing.Size(48, 16);
            this.chk_7.TabIndex = 18;
            this.chk_7.Tag = "7";
            this.chk_7.Text = "专著";
            this.chk_7.UseVisualStyleBackColor = true;
            // 
            // txt_3
            // 
            this.txt_3.Location = new System.Drawing.Point(188, 208);
            this.txt_3.Multiline = true;
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(295, 32);
            this.txt_3.TabIndex = 23;
            // 
            // txt_10
            // 
            this.txt_10.Location = new System.Drawing.Point(188, 530);
            this.txt_10.Multiline = true;
            this.txt_10.Name = "txt_10";
            this.txt_10.Size = new System.Drawing.Size(295, 33);
            this.txt_10.TabIndex = 27;
            // 
            // chk_10
            // 
            this.chk_10.AutoSize = true;
            this.chk_10.Location = new System.Drawing.Point(76, 547);
            this.chk_10.Name = "chk_10";
            this.chk_10.Size = new System.Drawing.Size(72, 16);
            this.chk_10.TabIndex = 26;
            this.chk_10.Tag = "10";
            this.chk_10.Text = "政策法规";
            this.chk_10.UseVisualStyleBackColor = true;
            // 
            // txt_9
            // 
            this.txt_9.Location = new System.Drawing.Point(188, 484);
            this.txt_9.Multiline = true;
            this.txt_9.Name = "txt_9";
            this.txt_9.Size = new System.Drawing.Size(295, 32);
            this.txt_9.TabIndex = 25;
            // 
            // chk_9
            // 
            this.chk_9.AutoSize = true;
            this.chk_9.Location = new System.Drawing.Point(76, 486);
            this.chk_9.Name = "chk_9";
            this.chk_9.Size = new System.Drawing.Size(72, 16);
            this.chk_9.TabIndex = 24;
            this.chk_9.Tag = "9";
            this.chk_9.Text = "科技报告";
            this.chk_9.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 660);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "导出配置";
            this.tabControl1.ResumeLayout(false);
            this.tabTitlePage.ResumeLayout(false);
            this.tabTitlePage.PerformLayout();
            this.tabOtherPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxTable;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTitlePage;
        private System.Windows.Forms.TabPage tabOtherPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txt_0;
        private System.Windows.Forms.TextBox txt_1;
        private System.Windows.Forms.CheckBox chk_1;
        private System.Windows.Forms.CheckBox chk_0;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_8;
        private System.Windows.Forms.CheckBox chk_8;
        private System.Windows.Forms.TextBox txt_7;
        private System.Windows.Forms.CheckBox chk_7;
        private System.Windows.Forms.TextBox txt_6;
        private System.Windows.Forms.CheckBox chk_6;
        private System.Windows.Forms.TextBox txt_5;
        private System.Windows.Forms.CheckBox chk_5;
        private System.Windows.Forms.TextBox txt_4;
        private System.Windows.Forms.CheckBox chk_4;
        private System.Windows.Forms.CheckBox chk_3;
        private System.Windows.Forms.TextBox txt_2;
        private System.Windows.Forms.CheckBox chk_2;
        private System.Windows.Forms.TextBox txt_3;
        private System.Windows.Forms.TextBox txt_10;
        private System.Windows.Forms.CheckBox chk_10;
        private System.Windows.Forms.TextBox txt_9;
        private System.Windows.Forms.CheckBox chk_9;
    }
}

