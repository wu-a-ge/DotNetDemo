using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
namespace VS2008.WebForm.Test
{
    public partial class Ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string GetXML()
        {
            return "GetXML";
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string GetJSON()
        {
            return "GetJSON";
        }
        [WebMethod]
        public static string PostXML()
        {
            return "PostXML";
        }
        [WebMethod]
        public static string PostJSON()
        {
            return "PostJSON";
        }
    }
}
