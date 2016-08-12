using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;

namespace MySimpleServiceFramework
{
	/// <summary>
	/// 包含要调用的服务类型名称和方法名称的一个值对。
	/// </summary>
	public class NamesPair
	{
		/// <summary>
		/// 要调用的服务类名
		/// </summary>
		public string ServiceName { get; set; }
		/// <summary>
		/// 要调用的服务方法名
		/// </summary>
		public string MethodName { get; set; }
	}


	internal class ServiceInfo
	{
		public ServiceInfo(NamesPair pair, InvokeInfo vkInfo)
		{
			if( pair == null )
				throw new ArgumentNullException("pair");
			if( vkInfo == null )
				throw new ArgumentNullException("vkInfo");

			this.NamesPair = pair;
			this.InvokeInfo = vkInfo;
		}

		public NamesPair NamesPair { get; private set; }
		public InvokeInfo InvokeInfo { get; private set; }
	}

	internal class InvokeInfo
	{
		public TypeAndAttrInfo ServiceTypeInfo { get; set; }
		public MethodAndAttrInfo MethodAttrInfo { get; set; }
		public object ServiceInstance { get; set; }

		internal bool AuthenticateRequest(HttpContext context)
		{
			// 验证请求规则：

			// 1. 如果服务类型与方法都没有指定AuthorizeAttribute，则默认为允许访问。

			// 2. 如果方法指定了AuthorizeAttribute，则以方法指定的AuthorizeAttribute为准，进行验证。

			// 3. 如果服务指定了AuthorizeAttribute，则以服务指定的AuthorizeAttribute为准，进行验证。

			if( ServiceTypeInfo.AuthorizeAttr == null && MethodAttrInfo.AuthorizeAttr == null )
				return true;

			if( MethodAttrInfo.AuthorizeAttr != null )
				return MethodAttrInfo.AuthorizeAttr.AuthenticateRequest(context);

			if( ServiceTypeInfo.AuthorizeAttr != null )
				return ServiceTypeInfo.AuthorizeAttr.AuthenticateRequest(context);

			return false;
		}
		
	}

	internal class TypeAndAttrInfo
	{
		public Type ServiceType { get; set; }
		public MyServiceAttribute Attr { get; set; }
		public AuthorizeAttribute AuthorizeAttr { get; set; }
	}

	internal class MethodAndAttrInfo
	{
		public MethodInfo MethodInfo { get; set; }
		public MyServiceMethodAttribute Attr { get; set; }
		public Type ParamType { get; set; }
		public string ParamName { get; set; }
		public AuthorizeAttribute AuthorizeAttr { get; set; }
	}

}
