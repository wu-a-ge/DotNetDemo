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
    [ToolboxData("<{0}:PostBackFromClientControl runat=server></{0}:PostBackFromClientControl>")]
    public class PostBackFromClientControl : Control, IPostBackEventHandler
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


            //方案一: 使用提交按钮
            output.Write("<INPUT TYPE=submit name=" + this.UniqueID + " Value='[使用提交按钮]' /> <br>");            

            //方案二: 使用Page.ClientScript对象的GetPostBackEventReference方法
            output.Write("<INPUT type=button name=\"{0}\" value='[使用Page.ClientScript对象的GetPostBackEventReference方法]' onclick=\"{1}\"> <br>", this.UniqueID, Page.ClientScript.GetPostBackEventReference(this, "",true)); 

            //方案三: 使用Page.ClientScript对象的GetPostBackClientHyperlink方法
            string href  = Page.ClientScript.GetPostBackClientHyperlink(this, "");
            output.AddAttribute(HtmlTextWriterAttribute.Href, href);
            output.RenderBeginTag(HtmlTextWriterTag.A);
            output.Write("[使用Page.ClientScript对象的GetPostBackClientHyperlink方法]");
            output.RenderEndTag();            
        }        

    }
}
