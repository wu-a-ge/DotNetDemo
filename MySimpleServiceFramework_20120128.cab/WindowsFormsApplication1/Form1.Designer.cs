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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLogout = new System.Windows.Forms.Button();
			this.btnLogin = new System.Windows.Forms.Button();
			this.cboUrl = new System.Windows.Forms.ComboBox();
			this.chkEnableGzip = new System.Windows.Forms.CheckBox();
			this.btnCall = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.fishliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ccToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.andyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnLogout);
			this.panel1.Controls.Add(this.btnLogin);
			this.panel1.Controls.Add(this.cboUrl);
			this.panel1.Controls.Add(this.chkEnableGzip);
			this.panel1.Controls.Add(this.btnCall);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(903, 42);
			this.panel1.TabIndex = 0;
			// 
			// btnLogout
			// 
			this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLogout.Location = new System.Drawing.Point(845, 8);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new System.Drawing.Size(55, 23);
			this.btnLogout.TabIndex = 6;
			this.btnLogout.Text = "注销";
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
			// 
			// btnLogin
			// 
			this.btnLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLogin.Location = new System.Drawing.Point(785, 8);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(55, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "登录";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// cboUrl
			// 
			this.cboUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cboUrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboUrl.FormattingEnabled = true;
			this.cboUrl.Location = new System.Drawing.Point(91, 11);
			this.cboUrl.MaxDropDownItems = 30;
			this.cboUrl.Name = "cboUrl";
			this.cboUrl.Size = new System.Drawing.Size(536, 20);
			this.cboUrl.TabIndex = 4;
			// 
			// chkEnableGzip
			// 
			this.chkEnableGzip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkEnableGzip.AutoSize = true;
			this.chkEnableGzip.Location = new System.Drawing.Point(639, 13);
			this.chkEnableGzip.Name = "chkEnableGzip";
			this.chkEnableGzip.Size = new System.Drawing.Size(72, 16);
			this.chkEnableGzip.TabIndex = 3;
			this.chkEnableGzip.Text = "启用gzip";
			this.chkEnableGzip.UseVisualStyleBackColor = true;
			// 
			// btnCall
			// 
			this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCall.Location = new System.Drawing.Point(721, 8);
			this.btnCall.Name = "btnCall";
			this.btnCall.Size = new System.Drawing.Size(55, 23);
			this.btnCall.TabIndex = 2;
			this.btnCall.Text = "Call";
			this.btnCall.UseVisualStyleBackColor = true;
			this.btnCall.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Service URL";
			// 
			// textBox2
			// 
			this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(0, 42);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox2.Size = new System.Drawing.Size(903, 435);
			this.textBox2.TabIndex = 1;
			this.textBox2.WordWrap = false;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fishliToolStripMenuItem,
            this.ccToolStripMenuItem,
            this.toolStripMenuItem1,
            this.andyToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(100, 76);
			// 
			// fishliToolStripMenuItem
			// 
			this.fishliToolStripMenuItem.Name = "fishliToolStripMenuItem";
			this.fishliToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.fishliToolStripMenuItem.Text = "fish-li";
			this.fishliToolStripMenuItem.Click += new System.EventHandler(this.UserLogin);
			// 
			// ccToolStripMenuItem
			// 
			this.ccToolStripMenuItem.Name = "ccToolStripMenuItem";
			this.ccToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.ccToolStripMenuItem.Text = "cc";
			this.ccToolStripMenuItem.Click += new System.EventHandler(this.UserLogin);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 6);
			// 
			// andyToolStripMenuItem
			// 
			this.andyToolStripMenuItem.Name = "andyToolStripMenuItem";
			this.andyToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
			this.andyToolStripMenuItem.Text = "Andy";
			this.andyToolStripMenuItem.Click += new System.EventHandler(this.UserLogin);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(903, 477);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Test QueryOrderService  - http://www.cnblogs.com/fish-li";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCall;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.CheckBox chkEnableGzip;
		private System.Windows.Forms.ComboBox cboUrl;
		private System.Windows.Forms.Button btnLogout;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fishliToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ccToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem andyToolStripMenuItem;
	}
}

