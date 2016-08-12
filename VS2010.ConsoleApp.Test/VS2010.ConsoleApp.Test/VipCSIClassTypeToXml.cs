using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using System.IO;
namespace VS2010.ConsoleApp.Test
{
    internal class VipCSIClassTypeToXml
    {
        internal static void WriteXml()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSIPub"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from ClassTypeInfo order by id", connectionString);
            DataSet ds = new DataSet("CSI");
            da.Fill(ds);
            ds.WriteXml("allclasses1.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("allclasses1.xml");
            XmlWriterSettings settings = new XmlWriterSettings() { Indent=true };
            using (XmlWriter writer = XmlWriter.Create("AllClasses.xml", settings))
            {
                writer.WriteStartDocument();
                    writer.WriteStartElement("CSI");
                    var topNodes=xmlDoc.SelectNodes("/CSI/Table[ParentClassTypeID=0]");
                    foreach (XmlElement topNode in topNodes)
                    {
                        writer.WriteStartElement("topClass");
                        writer.WriteStartAttribute("id");
                        writer.WriteString(topNode.ChildNodes[0].InnerText);
                        writer.WriteEndAttribute();
                        writer.WriteStartAttribute("name");
                        writer.WriteString(topNode.ChildNodes[2].InnerText);
                        writer.WriteEndAttribute();
                        var subNodes = xmlDoc.SelectNodes(string.Format("/CSI/Table[ParentClassTypeID={0}]", topNode.FirstChild.InnerText));
                        foreach (XmlElement subNode in subNodes)
                        {
                            writer.WriteStartElement("subClass");
                            writer.WriteStartAttribute("id");
                            writer.WriteString(subNode.ChildNodes[0].InnerText);
                            writer.WriteEndAttribute();
                            writer.WriteStartAttribute("name");
                            writer.WriteString(subNode.ChildNodes[2].InnerText.Substring(subNode.ChildNodes[2].InnerText.IndexOf('—') + 1));
                            writer.WriteEndAttribute();
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                writer.WriteEndDocument();
            }

             
        }
    }
}
