using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySimpleServiceFramework;

namespace ServiceLibrary
{
	[MyService(SessionMode=SessionMode.Support)]
	public class SessionDemoService 
	{
		[MyServiceMethod]
		public int Add(int a)
		{
			// 一个累加的方法，检验是否可以访问Session

			if( System.Web.HttpContext.Current.Session == null )
				throw new InvalidOperationException("Session没有开启。");

			object obj = System.Web.HttpContext.Current.Session["counter"];
			int counter = (obj == null ? 0 : (int)obj);
			counter += a;
			System.Web.HttpContext.Current.Session["counter"] = counter;
			return counter;
		}
	}


}
