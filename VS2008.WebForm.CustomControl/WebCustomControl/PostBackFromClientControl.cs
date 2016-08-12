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
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
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


            //����һ: ʹ���ύ��ť
            output.Write("<INPUT TYPE=submit name=" + this.UniqueID + " Value='[ʹ���ύ��ť]' /> <br>");            

            //������: ʹ��Page.ClientScript�����GetPostBackEventReference����
            output.Write("<INPUT type=button name=\"{0}\" value='[ʹ��Page.ClientScript�����GetPostBackEventReference����]' onclick=\"{1}\"> <br>", this.UniqueID, Page.ClientScript.GetPostBackEventReference(this, "",true)); 

            //������: ʹ��Page.ClientScript�����GetPostBackClientHyperlink����
            string href  = Page.ClientScript.GetPostBackClientHyperlink(this, "");
            output.AddAttribute(HtmlTextWriterAttribute.Href, href);
            output.RenderBeginTag(HtmlTextWriterTag.A);
            output.Write("[ʹ��Page.ClientScript�����GetPostBackClientHyperlink����]");
            output.RenderEndTag();            
        }        

    }
}
