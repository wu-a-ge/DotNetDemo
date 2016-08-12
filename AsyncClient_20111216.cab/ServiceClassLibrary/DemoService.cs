using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySimpleServiceFramework;

namespace ServiceClassLibrary
{
	/// <summary>
	/// 要做为服务发布的服务类，其实就是一个普通的C#类，加了一些Attribute而已。
	/// 所有幕后的工作，全由服务框架来实现，关于服务框架请参考我的博客：
	/// 【用Asp.net写自己的服务框架】
	/// http://www.cnblogs.com/fish-li/archive/2011/09/05/2168073.html
	/// </summary>
	[MyService]
	public class DemoService
	{
		[MyServiceMethod]
		public static string ExtractNumber(string str)
		{
			// 延迟3秒，模拟一个长时间的调用操作，便于客户演示异步的效果。
			System.Threading.Thread.Sleep(3000);

			if( string.IsNullOrEmpty(str) )
				return "str IsNullOrEmpty.";

			return new string((from c in str where Char.IsDigit(c) orderby c select c).ToArray());
		}


		[MyServiceMethod]
		public static string CheckUserLogin(LoginInfo info)
		{
			System.Threading.Thread.Sleep(3000);

			if( string.IsNullOrEmpty(info.Username) || string.IsNullOrEmpty(info.Password) )
				return "用户名或密码不能为空。";

			if( info.Username == "error" )
				throw new ArgumentException("无效的用户名。");

			if( string.Compare(info.Username, "fish", true) != 0
				|| string.Compare(info.Password, "http://www.cnblogs.com/fish-li", true) != 0 )
				return "用户名或密码不正确。";
			
			return "OK";
		}
	}



	/// <summary>
	/// CheckUserLogin方法的传入参数类。
	/// 说明：为了简单就和服务一起放在这里了。
	/// </summary>
	public class LoginInfo
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}
