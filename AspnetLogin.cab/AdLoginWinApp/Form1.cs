using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Management;


namespace AdLoginWinApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			if( txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0 ) {
				MessageBox.Show("用户名或者密码不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string ldapPath = "LDAP://" + GetDomainName();
			string domainAndUsername = Environment.UserDomainName + "\\" + txtUsername.Text;
			DirectoryEntry entry = new DirectoryEntry(ldapPath, domainAndUsername, txtPassword.Text);

			DirectorySearcher search = new DirectorySearcher(entry);

			try {
				SearchResult result = search.FindOne();

				MessageBox.Show("登录成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch( Exception ex ) {
				// 如果用户名或者密码不正确，也会抛出异常。
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private static string GetDomainName()
		{
			// 注意：这段代码需要在Windows XP及较新版本的操作系统中才能正常运行。
			SelectQuery query = new SelectQuery("Win32_ComputerSystem");
			using( ManagementObjectSearcher searcher = new ManagementObjectSearcher(query) ) {
				foreach( ManagementObject mo in searcher.Get() ) {
					if( (bool)mo["partofdomain"] )
						return mo["domain"].ToString();
				}
			}
			return null;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			txtUsername.Text = Environment.UserName;
			txtPassword.Focus();
		}


	}
}
