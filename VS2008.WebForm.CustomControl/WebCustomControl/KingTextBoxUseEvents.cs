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
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:KingTextBoxUseEvents runat=server></{0}:KingTextBoxUseEvents>")]
    public class KingTextBoxUseEvents : Control, IPostBackDataHandler
    {
        public KingTextBoxUseEvents()
        {
        }

        /// <summary>
        /// 设置或获取显示文本
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
        /// 生成呈现Html格式标记
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
             
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"text\" name=");
            sb.Append("\"" + UniqueID + "\"");
            sb.Append(" value=");
            sb.Append("\"" + HttpUtility.HtmlEncode(Text) + "\"");
            sb.Append(" />");
            writer.Write(sb.ToString());
        }

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


        public virtual void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }


        //普通事件
        //public event EventHandler TextChanged;
        //protected virtual void OnTextChanged(EventArgs e)
        //{
        //    if (TextChanged != null)
        //    {
        //        TextChanged(this, e);
        //    }
        //}

        //高效事件
        private static readonly object TextChangedKeyObject = new object();
        public event EventHandler TextChanged
        {
            add
            {
                base.Events.AddHandler(KingTextBoxUseEvents.TextChangedKeyObject, value);
            }
            remove
            {
                base.Events.RemoveHandler(KingTextBoxUseEvents.TextChangedKeyObject, value);
            }
        }
        protected virtual void OnTextChanged(EventArgs e)
        {
            EventHandler handler = base.Events[KingTextBoxUseEvents.TextChangedKeyObject] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

    }
}
