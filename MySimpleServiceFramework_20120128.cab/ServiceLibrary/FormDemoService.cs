using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySimpleServiceFramework;
using ClassLibrary1;
using System.Web.Script.Serialization;

namespace ServiceLibrary
{
	[MyService]
	public class FormDemoService
	{
		[MyServiceMethod]
		public string ShowOrderDetail(OrderDetail detail)
		{
			JavaScriptSerializer jss = new JavaScriptSerializer();
			return jss.Serialize(detail);
		}

		[MyServiceMethod]
		public string ShowUrlInfo(int a)
		{
			System.Web.HttpRequest request = System.Web.HttpContext.Current.Request;

			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.AppendFormat("Path: {0}\r\n", request.Path);			
			sb.AppendFormat("RawUrl: {0}\r\n", request.RawUrl);
			sb.AppendFormat("Url.PathAndQuery: {0}\r\n", request.Url.PathAndQuery);

			return sb.ToString();
		}

	}
}
