﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml;

namespace VS2010.ConsoleApp.Test
{
    internal  class VCubeClassTypeToXml
    {
        internal static void WriteXml()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CSIPub"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter("select * from ClassTypeInfo order by id", connectionString);
            DataSet ds = new DataSet("CSI");
            da.Fill(ds);
            ds.WriteXml("vcubeclasses1.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("vcubeclasses1.xml");
            XmlWriterSettings settings = new XmlWriterSettings() { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("VCubeClasses.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                var topNodes = xmlDoc.SelectNodes("/CSI/Table[ParentClassTypeID=0]");
                foreach (XmlElement topNode in topNodes)
                {
                    if (topNode.ChildNodes[0].InnerText == "9999") continue;
                    writer.WriteStartElement("level1");
                    writer.WriteStartAttribute("id");
                    writer.WriteString(topNode.ChildNodes[0].InnerText);
                    writer.WriteEndAttribute();
                    writer.WriteStartAttribute("name");
                    writer.WriteString(topNode.ChildNodes[2].InnerText);
                    writer.WriteEndAttribute();
                    //writer.WriteStartAttribute("level");
                    //writer.WriteString("1");
                    //writer.WriteEndAttribute();
                    //writer.WriteStartAttribute("pid");
                    //writer.WriteString("0");
                    //writer.WriteEndAttribute();
                    var subNodes = xmlDoc.SelectNodes(string.Format("/CSI/Table[ParentClassTypeID={0}]", topNode.FirstChild.InnerText));
                    foreach (XmlElement subNode in subNodes)
                    {
                        writer.WriteStartElement("level2");
                        writer.WriteStartAttribute("id");
                        writer.WriteString(subNode.ChildNodes[0].InnerText);
                        writer.WriteEndAttribute();
                        writer.WriteStartAttribute("name");
                        writer.WriteString(subNode.ChildNodes[2].InnerText);
                        writer.WriteEndAttribute();
                        //writer.WriteStartAttribute("level");
                        //writer.WriteString("2");
                        //writer.WriteEndAttribute();
                        //writer.WriteStartAttribute("pid");
                        //writer.WriteString(topNode.ChildNodes[0].InnerText);
                        //writer.WriteEndAttribute();
                        var threeNodes = xmlDoc.SelectNodes(string.Format("/CSI/Table[ParentClassTypeID={0}]", subNode.FirstChild.InnerText));
                        foreach (XmlElement threeNode in threeNodes)
                        {
                            writer.WriteStartElement("level3");
                            writer.WriteStartAttribute("id");
                            writer.WriteString(threeNode.ChildNodes[0].InnerText);
                            writer.WriteEndAttribute();
                            writer.WriteStartAttribute("name");
                            writer.WriteString(threeNode.ChildNodes[2].InnerText);
                            writer.WriteEndAttribute();
                            //writer.WriteStartAttribute("level");
                            //writer.WriteString("3");
                            //writer.WriteEndAttribute();
                            //writer.WriteStartAttribute("pid");
                            //writer.WriteString(subNode.ChildNodes[0].InnerText);
                            //writer.WriteEndAttribute();
                            writer.WriteEndElement();
                        }
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
