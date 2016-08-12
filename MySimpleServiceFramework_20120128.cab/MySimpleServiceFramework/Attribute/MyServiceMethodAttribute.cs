using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 用于标注一个方法是【服务方法】的修饰属性
	/// </summary>
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
	public class MyServiceMethodAttribute : Attribute
	{

	}
}
