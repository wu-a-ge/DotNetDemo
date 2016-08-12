using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCustomControl
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [DefaultEvent("Click")]
    [ToolboxData("<{0}:PostBackEventControl runat=server></{0}:PostBackEventControl>")]
    public class PostBackEventControl : Control, IPostBackEventHandler
    {        
        public event EventHandler Click;
        
        protected virtual void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(EventArgs.Empty);
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write("<INPUT TYPE=submit name=" + this.UniqueID + " Value='点击我' />");
        }
    }
}
