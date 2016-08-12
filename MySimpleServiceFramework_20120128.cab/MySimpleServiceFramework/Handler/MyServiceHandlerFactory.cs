using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySimpleServiceFramework
{
	internal static class MyServiceHandlerFactory
	{
		public static MyServiceHandler GetHandler(InvokeInfo vkInfo)
		{
			if( vkInfo == null )
				throw new ArgumentNullException("vkInfo");

			switch( vkInfo.ServiceTypeInfo.Attr.SessionMode ) {
				case SessionMode.NotSupport:
					return new MyServiceHandler();

				case SessionMode.Support :
					return new RequiresSessionServiceHandler();

				case SessionMode.ReadOnly :
					return new ReadOnlySessionServiceHandler();

				default:
					throw new ArgumentOutOfRangeException("vkInfo.ServiceTypeInfo.Attr.SessionMode");
			}
		}
	}
}
