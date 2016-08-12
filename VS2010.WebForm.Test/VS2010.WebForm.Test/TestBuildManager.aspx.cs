using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.Compilation;
using System.Reflection;

namespace VS2010.WebForm.Test
{
    /// <summary>
    /// BuildManager类型使用方法
    /// </summary>
    public partial class TestBuildManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ICollection assemblies = BuildManager.GetReferencedAssemblies();
            foreach (var t in assemblies)
            {
                Response.Write(t.GetType().FullName+"<br/>");
            }
        }
    }
}