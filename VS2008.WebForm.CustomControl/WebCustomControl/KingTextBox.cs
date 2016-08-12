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
    [ToolboxData("<{0}:KingTextBox runat=server></{0}:KingTextBox>")]
    public class KingTextBox : Control, IPostBackDataHandler  //IPostBackDataHandler: ����ط�����ʹ��
    {
        public KingTextBox()
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
