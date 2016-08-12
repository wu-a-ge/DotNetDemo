﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Reflection;
using System.IO;
using System.Web;

namespace MySimpleServiceFramework
{
	internal class JsonSerializerProvider : ISerializerProvider
	{
		private static readonly MethodInfo s_JSSDeserializeMI
									= typeof(JavaScriptSerializer).GetMethod("Deserialize");

		JavaScriptSerializer jss = new JavaScriptSerializer();

		public object Deserialize(Type destType, HttpRequest request)
		{
			StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding);
			string input = sr.ReadToEnd();

			MethodInfo deserialize = s_JSSDeserializeMI.MakeGenericMethod(destType);

			return deserialize.Invoke(jss, new object[] { input });
		}

		public void Serializer(object obj, HttpResponse response)
		{
			if( obj == null )
				return;

			response.ContentType = "application/json";

			response.Write(jss.Serialize(obj));
		}


	}
}
