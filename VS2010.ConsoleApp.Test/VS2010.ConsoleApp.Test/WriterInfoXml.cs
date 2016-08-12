using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
namespace VS2010.ConsoleApp.Test
{
     class WriterInfoXml
    {
         private static readonly  Regex reg=new Regex(@"\d{3}");
         internal static void WriteXml()
         {
             XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
             using (XmlWriter writer = XmlWriter.Create("WriterInfo.xml", settings))
             {
                 writer.WriteStartDocument();
                 writer.WriteStartElement("root");
                 StreamReader reader = new StreamReader(File.Open("author_id.txt",FileMode.Open));
                 string result = null;
                 while ((result=reader.ReadLine()) != null)
                 {
                     
                     writer.WriteStartElement("writer");
                     //id
                     result = reader.ReadLine();
                     writer.WriteStartElement("id");
                     writer.WriteString(result);
                     writer.WriteEndElement();
                     //remark
                     result = reader.ReadLine();
                     result = reader.ReadLine();
                     writer.WriteStartElement("remark");
                     writer.WriteCData(result);
                     writer.WriteEndElement();
                     writer.WriteEndElement();
                     
                    
                 }
                 writer.WriteEndElement();
                 writer.WriteEndDocument();
             }
         }
    }
}
