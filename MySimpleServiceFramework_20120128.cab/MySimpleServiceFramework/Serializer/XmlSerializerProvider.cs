﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Web;
using System.Reflection;

namespace MySimpleServiceFramework
{
	internal class XmlSerializerProvider : ISerializerProvider
	{
		public object Deserialize(Type destType, HttpRequest request)
		{
			XmlSerializer mySerializer = new XmlSerializer(destType);
			StreamReader sr = new StreamReader(request.InputStream, request.ContentEncoding);
			return mySerializer.Deserialize(sr);
		}

		public void Serializer(object obj, HttpResponse response)
		{
			if( obj == null )
				return;

			response.ContentType = "application/xml";

			XmlSerializer ser = new XmlSerializer(obj.GetType());
			ser.Serialize(response.OutputStream, obj);
		}


	}
}
