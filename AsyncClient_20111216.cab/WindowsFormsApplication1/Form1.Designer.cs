namespace WindowsFormsApplication1
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
			if( disposing && (components != null) ) {
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
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.btnCall = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton8);
			this.groupBox1.Controls.Add(this.radioButton7);
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.linkLabel1);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.btnCall);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtInput);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(5, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(760, 90);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "调用参数";
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(546, 55);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(14, 13);
			this.radioButton8.TabIndex = 17;
			this.radioButton8.Tag = "CallViaIAsyncResult2";
			this.toolTip1.SetToolTip(this.radioButton8, "使用自已包装的IAsyncResult接口");
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(521, 55);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(14, 13);
			this.radioButton7.TabIndex = 16;
			this.radioButton7.Tag = "UseBackgroundWorker";
			this.toolTip1.SetToolTip(this.radioButton7, "使用BackgroundWorker实现异步调用");
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(496, 55);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(14, 13);
			this.radioButton6.TabIndex = 15;
			this.radioButton6.Tag = "SyncCallService";
			this.toolTip1.SetToolTip(this.radioButton6, "同步调用服务，此时界面应该会【卡住】。");
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(471, 55);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(14, 13);
			this.radioButton5.TabIndex = 14;
			this.radioButton5.Tag = "UseThreadPool";
			this.toolTip1.SetToolTip(this.radioButton5, "直接使用线程池的异步方式");
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(446, 55);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(14, 13);
			this.radioButton4.TabIndex = 13;
			this.radioButton4.Tag = "CreateThread";
			this.toolTip1.SetToolTip(this.radioButton4, "创建新线程的异步方式");
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel1.Location = new System.Drawing.Point(589, 27);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(101, 12);
			this.linkLabel1.TabIndex = 12;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "随机生成输入参数";
			this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(315, 55);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(95, 16);
			this.radioButton3.TabIndex = 11;
			this.radioButton3.Tag = "CallViaEvent";
			this.radioButton3.Text = "事件异步模式";
			this.toolTip1.SetToolTip(this.radioButton3, "基于事件的异步模式");
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(188, 55);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(119, 16);
			this.radioButton2.TabIndex = 10;
			this.radioButton2.Tag = "CallViaIAsyncResult";
			this.radioButton2.Text = "IAsyncResult接口";
			this.toolTip1.SetToolTip(this.radioButton2, "使用IAsyncResult接口实现异步调用");
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(78, 55);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(95, 16);
			this.radioButton1.TabIndex = 9;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "CallViaDelegate";
			this.radioButton1.Text = "委托异步调用";
			this.toolTip1.SetToolTip(this.radioButton1, "委托异步调用");
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// btnCall
			// 
			this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCall.Location = new System.Drawing.Point(591, 48);
			this.btnCall.Name = "btnCall";
			this.btnCall.Size = new System.Drawing.Size(149, 23);
			this.btnCall.TabIndex = 5;
			this.btnCall.Text = "开始异步调用服务";
			this.btnCall.UseVisualStyleBackColor = true;
			this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 57);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 12);
			this.label2.TabIndex = 3;
			this.label2.Text = "调用方式";
			// 
			// txtInput
			// 
			this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtInput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtInput.Location = new System.Drawing.Point(77, 22);
			this.txtInput.Name = "txtInput";
			this.txtInput.Size = new System.Drawing.Size(502, 21);
			this.txtInput.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "输入参数";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.linkLabel3);
			this.groupBox2.Controls.Add(this.linkLabel2);
			this.groupBox2.Controls.Add(this.txtOutput);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(5, 95);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(760, 372);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "调用输出结果";
			// 
			// linkLabel3
			// 
			this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel3.Location = new System.Drawing.Point(625, 0);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(113, 12);
			this.linkLabel3.TabIndex = 17;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "异步获取数据库列表";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabel2.Location = new System.Drawing.Point(89, 0);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(53, 12);
			this.linkLabel2.TabIndex = 16;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "清除输出";
			this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutput.Location = new System.Drawing.Point(3, 17);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(754, 352);
			this.txtOutput.TabIndex = 0;
			this.txtOutput.WordWrap = false;
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(770, 472);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.Text = "AsyncClient DEMO  - http://www.cnblogs.com/fish-li";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCall;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.RadioButton radioButton8;
	}
}

