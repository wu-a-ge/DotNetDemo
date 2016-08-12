using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("TextChanged")]
    [ToolboxData("<{0}:KingTextBoxCanPostEvent runat=server></{0}:KingTextBoxCanPostEvent>")]
    public class KingTextBoxCanPostEvent : Control, IPostBackDataHandler
    {
        public KingTextBoxCanPostEvent()
        {
        }

        /// <summary>
        /// ���û��ȡ��ʾ�ı�
        /// </summary>        
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        private bool blnAutoPostBack = false;
        /// <summary>
        /// �Ƿ��Զ��ط�
        /// </summary>
        public bool AutoPostBack
        {
            get
            {
                return blnAutoPostBack;
            }
            set
            {
                blnAutoPostBack = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            //���ɻط�ѡ�����[ָ��������ɿͻ��� JavaScript �������ط��¼�]
            PostBackOptions pbo = new PostBackOptions(this);
            pbo.AutoPostBack = this.AutoPostBack;
            pbo.PerformValidation = true;
            //pbo.TrackFocus = true;
            //pbo.ClientSubmit = true ; //һ��Ҫ����ΪTrue, ʹ���дӿͻ��˿��������ط����������.Ĭ��ֵ ΪTRUE
            pbo.RequiresJavaScriptProtocol = false;
            string strPostBackCode = this.Page.ClientScript.GetPostBackEventReference(pbo);            

            //���ɽű�����
            StringBuilder strPostBackFromClient = new StringBuilder();
            strPostBackFromClient.Append(" function PostBackFromClient_" + this.ClientID + "() ");
            strPostBackFromClient.Append(" { ");            
            strPostBackFromClient.Append(strPostBackCode + ";");
            strPostBackFromClient.Append(" }");
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "PostBackFromClient_" + this.ClientID))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "PostBackFromClient_" + this.ClientID, strPostBackFromClient.ToString(), true);
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// ���ɳ���Html��ʽ���
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"text\" name=");
            sb.Append("\"" + UniqueID + "\""); //��ʶ�����̳��Ի���Control
            sb.Append(" value=");

            //HttpUtility.HtmlEncode ���û������ִ�ת����Html��ʽ����Ҫת���û������html�ؼ���Ϊ��html�ؼ����ַ�
            sb.Append("\"" + HttpUtility.HtmlEncode(Text) + "\"");
            sb.Append(" onblur='" + "PostBackFromClient_" + this.ClientID + "();'");
            sb.Append(" />");
            writer.Write(sb.ToString());
        }

        /// <summary>
        /// ���ط�ʱ��װ���û������������
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection">Keys/Values, ����洢��ֵ��Ӧ�ؼ�ӳ�䵽Html��ǵ�value����</param>
        /// <returns>true��ʾ���ݸı�,����ִ������ķ���RaisePostDataChangedEvent; ��������δ�ı�</returns>
        public virtual bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string strOldValue = Text;
            string strNewValue = postCollection[this.UniqueID];
            if( strOldValue == null || ( strOldValue != null && !strOldValue.Equals(strNewValue)))
            {
                this.Text = strNewValue;
                return true;
            }
            return false;
        }

        /// <summary>
        /// �������淽��LoadPostData����trueʱ���˷�������ִ��
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }

        public event EventHandler TextChanged;
        protected virtual void OnTextChanged(EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(this, e);
            }
        }
    }
}
