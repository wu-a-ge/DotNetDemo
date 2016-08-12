using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VS2010.ClassLib.DebugAndTrace;
namespace VS2010.WebForm.DebugAndTrace
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DebugTrace.TestOutPut();
            Trace.Warn("page");
            System.Diagnostics.Trace.WriteLine("listener", "ok"); 
             
        }
    }
}