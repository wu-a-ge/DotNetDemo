using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;


namespace VS2010.WebForm.Test
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [return: System.Xml.Serialization.XmlElementAttribute("out", IsNullable = true)]
        public DataSet GetTitles()
        {
            string connect = WebConfigurationManager.ConnectionStrings
                ["NorthwindConnectionString"].ConnectionString;
            SqlDataAdapter adapter = new SqlDataAdapter
                ("SELECT * from Products", connect);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        [WebMethod]
        public string GetXML()
        {
            return "GetXML";
        }
        [WebMethod]
        //[ScriptMethod(UseHttpGet = true)]
        public string GetJSON()
        {
            return "GetJSON";
        }
        [WebMethod]
        public string PostXML(string postXml)
        {
            return postXml;
        }
        [WebMethod]
        public string PostJSON(string postJson,string external)
        {
            return postJson;
        }

        [WebMethod]
        public object GetWithHttpProtocolWithoutParameter()
        {
            return "ok";
        }

        [WebMethod]
        public object GetWithHttpProtocolWithParameter(string first, int second)
        {
            return first + second;
        }
    }
}
