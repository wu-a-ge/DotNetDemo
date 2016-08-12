using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
namespace VS2010.ConsoleApp.Test
{
    class DomainIds
    {
        public static string WriteIds()
        {
            JArray jarrays=new JArray();
            var  doc = XDocument.Load("VCubeClasses.xml");
            var  levels= doc.Root.Elements().OrderBy(y =>int.Parse(y.Attribute("order").Value));
            foreach (var xElement in levels)
            {
                JObject model=new JObject();
                model.Add("id", xElement.Attribute("id").Value);
                model.Add("name", xElement.Attribute("name").Value);
                jarrays.Add(model);
            }
            return  JsonConvert.SerializeObject(jarrays);
        }
    }
}
