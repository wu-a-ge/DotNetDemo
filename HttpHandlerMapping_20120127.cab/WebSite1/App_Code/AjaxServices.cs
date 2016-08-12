using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using MySimpleServiceFramework;


[MyService]
public class AjaxServices
{
	[MyServiceMethod]
	public string GetMd5(string str)
	{
		if( str == null )
			str = string.Empty;

		byte[] bb = (new MD5CryptoServiceProvider()).ComputeHash(Encoding.Default.GetBytes(str));
		return BitConverter.ToString(bb).Replace("-", "");
	}
}
