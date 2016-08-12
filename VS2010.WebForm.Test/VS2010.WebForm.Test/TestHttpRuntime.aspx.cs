using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace VS2010.WebForm.Test
{
    public partial class TestHttpRuntime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("AppDomainAppId=" + HttpRuntime.AppDomainAppId);
            sb.AppendLine("<br/>AppDomainAppPath=" + HttpRuntime.AppDomainAppPath);
            sb.AppendLine("<br/>AppDomainAppVirtualPath=" + HttpRuntime.AppDomainAppVirtualPath);
            sb.AppendLine("<br/>AppDomainId=" + HttpRuntime.AppDomainId);
            sb.AppendLine("<br/>AspClientScriptPhysicalPath=" + HttpRuntime.AspClientScriptPhysicalPath);
            sb.AppendLine("<br/>AspClientScriptVirtualPath=" + HttpRuntime.AspClientScriptVirtualPath);
            sb.AppendLine("<br/>AspInstallDirectory=" + HttpRuntime.AspInstallDirectory);
            sb.AppendLine("<br/>BinDirectory=" + HttpRuntime.BinDirectory);
            sb.AppendLine("<br/>ClrInstallDirectory=" + HttpRuntime.ClrInstallDirectory);
            sb.AppendLine("<br/>CodegenDir=" + HttpRuntime.CodegenDir);
            sb.AppendLine("<br/>IsOnUNCShare=" + HttpRuntime.IsOnUNCShare);
            sb.AppendLine("<br/>MachineConfigurationDirectory=" + HttpRuntime.MachineConfigurationDirectory);
            sb.AppendLine("<br/>UsingIntegratedPipeline=" + HttpRuntime.UsingIntegratedPipeline);
            Response.Write(sb.ToString());
        }
    }
}