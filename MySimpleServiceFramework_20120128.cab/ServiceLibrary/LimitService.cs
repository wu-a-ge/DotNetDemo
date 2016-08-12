using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySimpleServiceFramework;
using System.Security.Cryptography;

namespace ServiceLibrary
{
	// 这是一个访问受限的服务类，只允许某些用户调用。
	[Authorize]
	[MyService]
	public static class LimitService
	{
		[Authorize(Users="fish-li, cc")]
		[MyServiceMethod]
		public static string CalcPassword(string pwd)
		{
			// 这个方法只能由 fish-li, cc 二个用户来调用

			if( pwd == null )
				pwd = string.Empty;

			byte[] buffer = (new MD5CryptoServiceProvider()).ComputeHash(Encoding.Default.GetBytes(pwd));
			return BitConverter.ToString(buffer).Replace("-", "");
		}

		[MyServiceMethod]
		public static string CalcBase64(string str)
		{
			// 这个方法只能由已登录用户调用。

			if( string.IsNullOrEmpty(str) )
				return string.Empty;

			return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
		}
	}
}
