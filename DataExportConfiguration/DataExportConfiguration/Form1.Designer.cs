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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_10 = new System.Windows.Forms.TextBox();
            this.chk_10 = new System.Windows.Forms.CheckBox();
            this.txt_9 = new System.Windows.Forms.TextBox();
            this.chk_9 = new System.Windows.Forms.CheckBox();
            this.txt_3 = new System.Windows.Forms.TextBox();
            this.txt_8 = new System.Windows.Forms.TextBox();
            this.chk_8 = new System.Windows.Forms.CheckBox();
            this.txt_7 = new System.Windows.Forms.TextBox();
            this.chk_7 = new System.Windows.Forms.CheckBox();
            this.txt_6 = new System.Windows.Forms.TextBox();
            this.chk_6 = new System.Windows.Forms.CheckBox();
            this.txt_5 = new System.Windows.Forms.TextBox();
            this.chk_5 = new System.Windows.Forms.CheckBox();
            this.txt_4 = new System.Windows.Forms.TextBox();
            this.chk_4 = new System.Windows.Forms.CheckBox();
            this.chk_3 = new System.Windows.Forms.CheckBox();
            this.txt_2 = new System.Windows.Forms.TextBox();
            this.chk_2 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_1 = new System.Windows.Forms.TextBox();
            this.chk_1 = new System.Windows.Forms.CheckBox();
            this.txt_0 = new System.Windows.Forms.TextBox();
            this.chk_0 = new System.Windows.Forms.CheckBox();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOtherPage = new System.Windows.Forms.TabPage();
            this.txtFields = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRules = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radText = new System.Windows.Forms.RadioButton();
            this.radSqlite = new System.Windows.Forms.RadioButton();
            this.radMdb = new System.Windows.Forms.RadioButton();
            this.btnExport = new System.Windows.Forms.Button();
            this.radSource = new System.Windows.Forms.RadioButton();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.groupExportSrc = new System.Windows.Forms.GroupBox();
            this.groupExportFormat = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIds = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReduceNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtReduceMb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSplitChar = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabTitlePage.SuspendLayout();
            this.tabOtherPage.SuspendLayout();
            this.groupExportSrc.SuspendLayout();
            this.groupExportFormat.SuspendLayout();
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
            "area_info",
            "class_info"});
            this.cbxTable.Location = new System.Drawing.Point(240, 20);
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
            this.tabControl1.Size = new System.Drawing.Size(969, 490);
            this.tabControl1.TabIndex = 1;
            // 
            // tabTitlePage
            // 
            this.tabTitlePage.Controls.Add(this.label5);
            this.tabTitlePage.Controls.Add(this.label4);
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
            this.tabTitlePage.Size = new System.Drawing.Size(961, 464);
            this.tabTitlePage.TabIndex = 0;
            this.tabTitlePage.Tag = "title_info";
            this.tabTitlePage.Text = "作品表配置";
            this.tabTitlePage.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 29;
            this.label5.Text = "文献类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "字段";
            // 
            // txt_10
            // 
            this.txt_10.Location = new System.Drawing.Point(111, 377);
            this.txt_10.Multiline = true;
            this.txt_10.Name = "txt_10";
            this.txt_10.Size = new System.Drawing.Size(295, 33);
            this.txt_10.TabIndex = 27;
            // 
            // chk_10
            // 
            this.chk_10.AutoSize = true;
            this.chk_10.Location = new System.Drawing.Point(22, 394);
            this.chk_10.Name = "chk_10";
            this.chk_10.Size = new System.Drawing.Size(72, 16);
            this.chk_10.TabIndex = 26;
            this.chk_10.Tag = "10";
            this.chk_10.Text = "政策法规";
            this.chk_10.UseVisualStyleBackColor = true;
            // 
            // txt_9
            // 
            this.txt_9.Location = new System.Drawing.Point(552, 318);
            this.txt_9.Multiline = true;
            this.txt_9.Name = "txt_9";
            this.txt_9.Size = new System.Drawing.Size(295, 32);
            this.txt_9.TabIndex = 25;
            // 
            // chk_9
            // 
            this.chk_9.AutoSize = true;
            this.chk_9.Location = new System.Drawing.Point(462, 320);
            this.chk_9.Name = "chk_9";
            this.chk_9.Size = new System.Drawing.Size(72, 16);
            this.chk_9.TabIndex = 24;
            this.chk_9.Tag = "9";
            this.chk_9.Text = "科技报告";
            this.chk_9.UseVisualStyleBackColor = true;
            // 
            // txt_3
            // 
            this.txt_3.Location = new System.Drawing.Point(552, 140);
            this.txt_3.Multiline = true;
            this.txt_3.Name = "txt_3";
            this.txt_3.Size = new System.Drawing.Size(295, 32);
            this.txt_3.TabIndex = 23;
            // 
            // txt_8
            // 
            this.txt_8.Location = new System.Drawing.Point(111, 317);
            this.txt_8.Multiline = true;
            this.txt_8.Name = "txt_8";
            this.txt_8.Size = new System.Drawing.Size(295, 33);
            this.txt_8.TabIndex = 21;
            // 
            // chk_8
            // 
            this.chk_8.AutoSize = true;
            this.chk_8.Location = new System.Drawing.Point(22, 334);
            this.chk_8.Name = "chk_8";
            this.chk_8.Size = new System.Drawing.Size(48, 16);
            this.chk_8.TabIndex = 20;
            this.chk_8.Tag = "8";
            this.chk_8.Text = "产品";
            this.chk_8.UseVisualStyleBackColor = true;
            // 
            // txt_7
            // 
            this.txt_7.Location = new System.Drawing.Point(552, 250);
            this.txt_7.Multiline = true;
            this.txt_7.Name = "txt_7";
            this.txt_7.Size = new System.Drawing.Size(295, 32);
            this.txt_7.TabIndex = 19;
            // 
            // chk_7
            // 
            this.chk_7.AutoSize = true;
            this.chk_7.Location = new System.Drawing.Point(465, 266);
            this.chk_7.Name = "chk_7";
            this.chk_7.Size = new System.Drawing.Size(48, 16);
            this.chk_7.TabIndex = 18;
            this.chk_7.Tag = "7";
            this.chk_7.Text = "专著";
            this.chk_7.UseVisualStyleBackColor = true;
            // 
            // txt_6
            // 
            this.txt_6.Location = new System.Drawing.Point(111, 249);
            this.txt_6.Multiline = true;
            this.txt_6.Name = "txt_6";
            this.txt_6.Size = new System.Drawing.Size(295, 33);
            this.txt_6.TabIndex = 17;
            // 
            // chk_6
            // 
            this.chk_6.AutoSize = true;
            this.chk_6.Location = new System.Drawing.Point(25, 266);
            this.chk_6.Name = "chk_6";
            this.chk_6.Size = new System.Drawing.Size(48, 16);
            this.chk_6.TabIndex = 16;
            this.chk_6.Tag = "6";
            this.chk_6.Text = "成果";
            this.chk_6.UseVisualStyleBackColor = true;
            // 
            // txt_5
            // 
            this.txt_5.Location = new System.Drawing.Point(552, 199);
            this.txt_5.Multiline = true;
            this.txt_5.Name = "txt_5";
            this.txt_5.Size = new System.Drawing.Size(295, 32);
            this.txt_5.TabIndex = 15;
            // 
            // chk_5
            // 
            this.chk_5.AutoSize = true;
            this.chk_5.Location = new System.Drawing.Point(465, 201);
            this.chk_5.Name = "chk_5";
            this.chk_5.Size = new System.Drawing.Size(48, 16);
            this.chk_5.TabIndex = 14;
            this.chk_5.Tag = "5";
            this.chk_5.Text = "标准";
            this.chk_5.UseVisualStyleBackColor = true;
            // 
            // txt_4
            // 
            this.txt_4.Location = new System.Drawing.Point(111, 196);
            this.txt_4.Multiline = true;
            this.txt_4.Name = "txt_4";
            this.txt_4.Size = new System.Drawing.Size(295, 35);
            this.txt_4.TabIndex = 13;
            // 
            // chk_4
            // 
            this.chk_4.AutoSize = true;
            this.chk_4.Location = new System.Drawing.Point(25, 201);
            this.chk_4.Name = "chk_4";
            this.chk_4.Size = new System.Drawing.Size(48, 16);
            this.chk_4.TabIndex = 12;
            this.chk_4.Tag = "4";
            this.chk_4.Text = "专利";
            this.chk_4.UseVisualStyleBackColor = true;
            // 
            // chk_3
            // 
            this.chk_3.AutoSize = true;
            this.chk_3.Location = new System.Drawing.Point(465, 146);
            this.chk_3.Name = "chk_3";
            this.chk_3.Size = new System.Drawing.Size(48, 16);
            this.chk_3.TabIndex = 10;
            this.chk_3.Tag = "3";
            this.chk_3.Text = "会议";
            this.chk_3.UseVisualStyleBackColor = true;
            // 
            // txt_2
            // 
            this.txt_2.Location = new System.Drawing.Point(111, 144);
            this.txt_2.Multiline = true;
            this.txt_2.Name = "txt_2";
            this.txt_2.Size = new System.Drawing.Size(295, 28);
            this.txt_2.TabIndex = 9;
            this.txt_2.Tag = "";
            // 
            // chk_2
            // 
            this.chk_2.AutoSize = true;
            this.chk_2.Location = new System.Drawing.Point(25, 146);
            this.chk_2.Name = "chk_2";
            this.chk_2.Size = new System.Drawing.Size(48, 16);
            this.chk_2.TabIndex = 8;
            this.chk_2.Tag = "2";
            this.chk_2.Text = "学位";
            this.chk_2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "文献类型";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(672, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "字段";
            // 
            // txt_1
            // 
            this.txt_1.Location = new System.Drawing.Point(552, 89);
            this.txt_1.Multiline = true;
            this.txt_1.Name = "txt_1";
            this.txt_1.Size = new System.Drawing.Size(295, 28);
            this.txt_1.TabIndex = 5;
            this.txt_1.Tag = "";
            // 
            // chk_1
            // 
            this.chk_1.AutoSize = true;
            this.chk_1.Location = new System.Drawing.Point(465, 95);
            this.chk_1.Name = "chk_1";
            this.chk_1.Size = new System.Drawing.Size(48, 16);
            this.chk_1.TabIndex = 4;
            this.chk_1.Tag = "1";
            this.chk_1.Text = "期刊";
            this.chk_1.UseVisualStyleBackColor = true;
            // 
            // txt_0
            // 
            this.txt_0.Location = new System.Drawing.Point(111, 89);
            this.txt_0.Multiline = true;
            this.txt_0.Name = "txt_0";
            this.txt_0.Size = new System.Drawing.Size(295, 32);
            this.txt_0.TabIndex = 3;
            // 
            // chk_0
            // 
            this.chk_0.AutoSize = true;
            this.chk_0.Location = new System.Drawing.Point(25, 95);
            this.chk_0.Name = "chk_0";
            this.chk_0.Size = new System.Drawing.Size(48, 16);
            this.chk_0.TabIndex = 2;
            this.chk_0.Tag = "0";
            this.chk_0.Text = "所有";
            this.chk_0.UseVisualStyleBackColor = true;
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(413, 14);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(100, 21);
            this.txtTable.TabIndex = 1;
            this.txtTable.Text = "title_info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "表名 ";
            // 
            // tabOtherPage
            // 
            this.tabOtherPage.Controls.Add(this.txtFields);
            this.tabOtherPage.Controls.Add(this.label9);
            this.tabOtherPage.Controls.Add(this.label8);
            this.tabOtherPage.Controls.Add(this.cbxTable);
            this.tabOtherPage.Location = new System.Drawing.Point(4, 22);
            this.tabOtherPage.Name = "tabOtherPage";
            this.tabOtherPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabOtherPage.Size = new System.Drawing.Size(961, 464);
            this.tabOtherPage.TabIndex = 1;
            this.tabOtherPage.Tag = "other";
            this.tabOtherPage.Text = "其它表配置";
            this.tabOtherPage.UseVisualStyleBackColor = true;
            // 
            // txtFields
            // 
            this.txtFields.Location = new System.Drawing.Point(240, 79);
            this.txtFields.Name = "txtFields";
            this.txtFields.Size = new System.Drawing.Size(121, 21);
            this.txtFields.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "导出字段";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "表名";
            // 
            // txtRules
            // 
            this.txtRules.Location = new System.Drawing.Point(217, 611);
            this.txtRules.Multiline = true;
            this.txtRules.Name = "txtRules";
            this.txtRules.Size = new System.Drawing.Size(274, 37);
            this.txtRules.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 625);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "判断规则";
            // 
            // radText
            // 
            this.radText.AutoSize = true;
            this.radText.Location = new System.Drawing.Point(138, 20);
            this.radText.Name = "radText";
            this.radText.Size = new System.Drawing.Size(47, 16);
            this.radText.TabIndex = 41;
            this.radText.Tag = "text";
            this.radText.Text = "文本";
            this.radText.UseVisualStyleBackColor = true;
            // 
            // radSqlite
            // 
            this.radSqlite.AutoSize = true;
            this.radSqlite.Location = new System.Drawing.Point(60, 20);
            this.radSqlite.Name = "radSqlite";
            this.radSqlite.Size = new System.Drawing.Size(59, 16);
            this.radSqlite.TabIndex = 40;
            this.radSqlite.Tag = "sqlite";
            this.radSqlite.Text = "sqlite";
            this.radSqlite.UseVisualStyleBackColor = true;
            // 
            // radMdb
            // 
            this.radMdb.AutoSize = true;
            this.radMdb.Checked = true;
            this.radMdb.Location = new System.Drawing.Point(6, 20);
            this.radMdb.Name = "radMdb";
            this.radMdb.Size = new System.Drawing.Size(41, 16);
            this.radMdb.TabIndex = 39;
            this.radMdb.TabStop = true;
            this.radMdb.Tag = "mdb";
            this.radMdb.Text = "mdb";
            this.radMdb.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(688, 515);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 37;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // radSource
            // 
            this.radSource.AutoSize = true;
            this.radSource.Checked = true;
            this.radSource.Location = new System.Drawing.Point(24, 20);
            this.radSource.Name = "radSource";
            this.radSource.Size = new System.Drawing.Size(41, 16);
            this.radSource.TabIndex = 45;
            this.radSource.TabStop = true;
            this.radSource.Tag = "vip";
            this.radSource.Text = "VIP";
            this.radSource.UseVisualStyleBackColor = true;
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(112, 20);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(47, 16);
            this.radAll.TabIndex = 46;
            this.radAll.Tag = "all";
            this.radAll.Text = "所有";
            this.radAll.UseVisualStyleBackColor = true;
            // 
            // groupExportSrc
            // 
            this.groupExportSrc.Controls.Add(this.radAll);
            this.groupExportSrc.Controls.Add(this.radSource);
            this.groupExportSrc.Location = new System.Drawing.Point(217, 560);
            this.groupExportSrc.Name = "groupExportSrc";
            this.groupExportSrc.Size = new System.Drawing.Size(200, 45);
            this.groupExportSrc.TabIndex = 47;
            this.groupExportSrc.TabStop = false;
            this.groupExportSrc.Text = "导出源";
            // 
            // groupExportFormat
            // 
            this.groupExportFormat.Controls.Add(this.radText);
            this.groupExportFormat.Controls.Add(this.radSqlite);
            this.groupExportFormat.Controls.Add(this.radMdb);
            this.groupExportFormat.Location = new System.Drawing.Point(217, 508);
            this.groupExportFormat.Name = "groupExportFormat";
            this.groupExportFormat.Size = new System.Drawing.Size(200, 47);
            this.groupExportFormat.TabIndex = 48;
            this.groupExportFormat.TabStop = false;
            this.groupExportFormat.Text = "导出格式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(447, 582);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 49;
            this.label6.Text = "查找机构ID串";
            // 
            // txtIds
            // 
            this.txtIds.Location = new System.Drawing.Point(530, 579);
            this.txtIds.Name = "txtIds";
            this.txtIds.Size = new System.Drawing.Size(100, 21);
            this.txtIds.TabIndex = 50;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(456, 515);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 51;
            this.label10.Text = "reduceNum";
            // 
            // txtReduceNum
            // 
            this.txtReduceNum.Location = new System.Drawing.Point(530, 512);
            this.txtReduceNum.Name = "txtReduceNum";
            this.txtReduceNum.Size = new System.Drawing.Size(100, 21);
            this.txtReduceNum.TabIndex = 52;
            this.txtReduceNum.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(458, 549);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 53;
            this.label11.Text = "ReduceMb";
            // 
            // txtReduceMb
            // 
            this.txtReduceMb.Location = new System.Drawing.Point(530, 549);
            this.txtReduceMb.Name = "txtReduceMb";
            this.txtReduceMb.Size = new System.Drawing.Size(100, 21);
            this.txtReduceMb.TabIndex = 54;
            this.txtReduceMb.Text = "4096";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(676, 583);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 55;
            this.label12.Text = "文本分隔符";
            // 
            // txtSplitChar
            // 
            this.txtSplitChar.Location = new System.Drawing.Point(747, 579);
            this.txtSplitChar.Name = "txtSplitChar";
            this.txtSplitChar.Size = new System.Drawing.Size(100, 21);
            this.txtSplitChar.TabIndex = 56;
            this.txtSplitChar.Text = "\\t";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 660);
            this.Controls.Add(this.txtSplitChar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtReduceMb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtReduceNum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtIds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupExportFormat);
            this.Controls.Add(this.groupExportSrc);
            this.Controls.Add(this.txtRules);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "导出配置";
            this.tabControl1.ResumeLayout(false);
            this.tabTitlePage.ResumeLayout(false);
            this.tabTitlePage.PerformLayout();
            this.tabOtherPage.ResumeLayout(false);
            this.tabOtherPage.PerformLayout();
            this.groupExportSrc.ResumeLayout(false);
            this.groupExportSrc.PerformLayout();
            this.groupExportFormat.ResumeLayout(false);
            this.groupExportFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRules;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radText;
        private System.Windows.Forms.RadioButton radSqlite;
        private System.Windows.Forms.RadioButton radMdb;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton radSource;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.GroupBox groupExportSrc;
        private System.Windows.Forms.GroupBox groupExportFormat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIds;
        private System.Windows.Forms.TextBox txtFields;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReduceNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtReduceMb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSplitChar;
    }
}

