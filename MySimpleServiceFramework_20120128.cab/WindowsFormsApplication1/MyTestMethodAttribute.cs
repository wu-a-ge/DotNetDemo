using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace WindowsFormsApplication1
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
	class MyTestMethodAttribute : Attribute
	{
		public MyTestMethodAttribute(string url)
		{
			this.Url = url;
		}

		public string Url { get; private set; }
	}


	class MyTestMethodItem
	{
		public string Url { get; set; }

		public MethodInfo MethodInfo { get; set; }

		public override string ToString()
		{
			return Url;
		}
	}
}
