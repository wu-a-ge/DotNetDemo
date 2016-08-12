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
    [DefaultEvent("TextChanged")]
    [ToolboxData("<{0}:KingTextBoxCanPostEvent runat=server></{0}:KingTextBoxCanPostEvent>")]
    public class KingTextBoxCanPostEvent : Control, IPostBackDataHandler
    {
        public KingTextBoxCanPostEvent()
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

        private bool blnAutoPostBack = false;
        /// <summary>
        /// 是否自动回发
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
            //生成回发选项对象[指定如何生成客户端 JavaScript 以启动回发事件]
            PostBackOptions pbo = new PostBackOptions(this);
            pbo.AutoPostBack = this.AutoPostBack;
            pbo.PerformValidation = true;
            //pbo.TrackFocus = true;
            //pbo.ClientSubmit = true ; //一定要设置为True, 使具有从客户端可以引发回发代码的能力.默认值 为TRUE
            pbo.RequiresJavaScriptProtocol = false;
            string strPostBackCode = this.Page.ClientScript.GetPostBackEventReference(pbo);            

            //生成脚本函数
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
        /// 生成呈现Html格式标记
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append("<input type=\"text\" name=");
            sb.Append("\"" + UniqueID + "\""); //标识符，继承自基类Control
            sb.Append(" value=");

            //HttpUtility.HtmlEncode 将用户输入字串转换成Html格式，主要转义用户输入的html关键字为非html关键字字符
            sb.Append("\"" + HttpUtility.HtmlEncode(Text) + "\"");
            sb.Append(" onblur='" + "PostBackFromClient_" + this.ClientID + "();'");
            sb.Append(" />");
            writer.Write(sb.ToString());
        }

        /// <summary>
        /// 当回发时，装载用户输入的新数据
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection">Keys/Values, 且其存储的值对应控件映射到Html标记的value属性</param>
        /// <returns>true表示数据改变,将会执行下面的方法RaisePostDataChangedEvent; 否则数据未改变</returns>
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
        /// 仅当上面方法LoadPostData返回true时，此方法将会执行
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
