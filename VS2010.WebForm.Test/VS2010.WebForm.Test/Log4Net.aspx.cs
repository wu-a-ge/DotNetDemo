using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VS2010.ClassLibs.Log4Net;
namespace VS2010.WebForm.Test
{
    public partial class Log4Net : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Log4NetSingleton.Debug("debug");
            
        }
    }
}