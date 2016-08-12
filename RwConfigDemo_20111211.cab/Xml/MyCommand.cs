using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;


namespace RwConfigDemo
{
    public class MyCommand
    {
		[XmlAttribute("Name")]
		public string CommandName;

		[XmlAttribute]
		public string Database;

		[XmlArrayItem("Parameter")]
		public List<MyCommandParameter> Parameters = new List<MyCommandParameter>();

		[XmlElement]
		public MyCDATA CommandText;
		//public string CommandText;
    }
	
	public class MyCommandParameter
	{
		[XmlAttribute("Name")]
		public string ParamName;

		[XmlAttribute("Type")]
		public string ParamType;
	}
}
