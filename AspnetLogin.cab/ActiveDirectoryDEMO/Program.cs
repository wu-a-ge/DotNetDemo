using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Management;

namespace ActiveDirectoryDEMO
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(GetDomainName());
			Console.WriteLine(Environment.UserDomainName);
			Console.WriteLine(Environment.UserName);
			Console.WriteLine("------------------------------------------------");

			//ShowUserInfo("fl45", GetDomainName());
			ShowUserInfo(Environment.UserName, GetDomainName());
		}

		#region AllProperties
		//private static string AllProperties = "name,givenName,samaccountname,mail";

		private static string AllProperties = @"
homemdb
distinguishedname
countrycode
cn
lastlogoff
mailnickname
dscorepropagationdata
msexchhomeservername
msexchmailboxsecuritydescriptor
msexchalobjectversion
usncreated
objectguid
whenchanged
memberof
msexchuseraccountcontrol
accountexpires
displayname
primarygroupid
badpwdcount
objectclass
instancetype
objectcategory
samaccounttype
whencreated
lastlogon
useraccountcontrol
physicaldeliveryofficename
samaccountname
usercertificate
givenname
mail
userparameters
adspath
homemta
msexchmailboxguid
pwdlastset
logoncount
codepage
name
usnchanged
legacyexchangedn
proxyaddresses
department
userprincipalname
badpasswordtime
objectsid
sn
mdbusedefaults
telephonenumber
showinaddressbook
msexchpoliciesincluded
textencodedoraddress
lastlogontimestamp
company
";
		#endregion

		public static void ShowUserInfo(string loginName, string domainName)
		{
			if( string.IsNullOrEmpty(loginName) || string.IsNullOrEmpty(domainName) )
				return;

			string[] properties = AllProperties.Split(new char[] { '\r', '\n', ',' }, StringSplitOptions.RemoveEmptyEntries);

			try {
				DirectoryEntry entry = new DirectoryEntry("LDAP://" + domainName);
				DirectorySearcher search = new DirectorySearcher(entry);
				search.Filter = "(samaccountname=" + loginName + ")";

				foreach( string p in properties )
					search.PropertiesToLoad.Add(p);

				SearchResult result = search.FindOne();

				if( result != null ) {
					//Console.WriteLine(result.Path);

					foreach( string p in properties ) {
						ResultPropertyValueCollection collection = result.Properties[p];
						for( int i = 0; i < collection.Count; i++ )
							Console.WriteLine(p + ": " + collection[i]);
					}
				}
			}
			catch( Exception ex ) {
				Console.WriteLine(ex.ToString());
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
	}
}


