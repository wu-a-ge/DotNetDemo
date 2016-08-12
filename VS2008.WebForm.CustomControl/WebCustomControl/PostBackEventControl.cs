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
            output.Write("<INPUT TYPE=submit name=" + this.UniqueID + " Value='�����' />");
        }
    }
}
