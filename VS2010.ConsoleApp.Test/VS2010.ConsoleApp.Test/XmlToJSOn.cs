using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using Newtonsoft.Json;

namespace VS2010.ConsoleApp.Test
{
    public class XmlToJSON
    {
        public static void WriteXmlToJSON()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("vcubeclasses.xml");
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            File.WriteAllText("json.txt", jsonText);
            //Console.WriteLine(jsonText);

        }
    }
}
