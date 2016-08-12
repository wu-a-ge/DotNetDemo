using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 用于标注一个类是【服务类】的修饰属性
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public class MyServiceAttribute : Attribute
	{
		/// <summary>
		/// 要支持的Session模式
		/// </summary>
		public SessionMode SessionMode { get; set; }
	}


	/// <summary>
	/// 服务所支持的Session模式
	/// </summary>
	public enum SessionMode
	{
		/// <summary>
		/// 不支持
		/// </summary>
		NotSupport,
		/// <summary>
		/// 全支持
		/// </summary>
		Support,
		/// <summary>
		/// 仅支持读取
		/// </summary>
		ReadOnly
	}


	
}
