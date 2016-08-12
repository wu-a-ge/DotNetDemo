using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
namespace VS2010.WebForm.JQueryEasyUI.ajax
{
    /// <summary>
    /// menuconfig 的摘要说明
    /// </summary>
    public class menuconfig : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string path = context.Request.MapPath("/App_Data/menu.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            context.Response.Write(JsonConvert.SerializeXmlNode(doc));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}