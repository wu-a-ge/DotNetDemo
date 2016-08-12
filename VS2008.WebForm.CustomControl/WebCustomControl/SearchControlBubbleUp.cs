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
    [DefaultProperty("Text")]
    [DefaultEvent("ButtonSearchClick")]
    [ToolboxData("<{0}:SearchControlBubbleUp runat=server></{0}:SearchControlBubbleUp>")]
    public class SearchControlBubbleUp : CompositeControl
    {
        private Button btnSearch;
        private TextBox tbSearchText;

        [Category("搜索")]
        [DefaultValue("")]
        [Description("获取文本框的值")]
        public string Text
        {
            get
            {
                this.EnsureChildControls();
                return tbSearchText.Text;
            }
        }

        private static readonly object ButtonSearchClickObject = new object();
        public event SearchEventHandler ButtonSearchClick
        {
            add
            {
                base.Events.AddHandler(ButtonSearchClickObject, value);
            }
            remove
            {
                base.Events.RemoveHandler(ButtonSearchClickObject, value);
            }
        }

        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            btnSearch = new Button();
            btnSearch.ID = "btn";
            btnSearch.Text = "搜索";
            btnSearch.CommandName = "ButtonSearchClick";           

            tbSearchText = new TextBox();
            tbSearchText.ID = "tb";
            this.Controls.Add(btnSearch);
            this.Controls.Add(tbSearchText);
        }

        protected virtual void OnButtonSearchClick(SearchEventArgs e)
        {
            SearchEventHandler ButtonSearchClickHandler = (SearchEventHandler)Events[ButtonSearchClickObject];
            if (ButtonSearchClickHandler != null)
            {
                ButtonSearchClickHandler(this, e);
            }
        }

        protected override bool OnBubbleEvent(object sender, EventArgs e)
        {
            bool handled = false;
            if (e is CommandEventArgs)
            {
                CommandEventArgs ce = (CommandEventArgs)e;
                if (ce.CommandName == "ButtonSearchClick")
                {
                    SearchEventArgs args = new SearchEventArgs();
                    args.SearchValue = this.Text;
                    OnButtonSearchClick(args);
                    handled = true;
                }
            }
            this.RaiseBubbleEvent(sender, e);
            return handled;
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Border, "0px");
            output.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "5px");
            output.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0px");
            output.RenderBeginTag(HtmlTextWriterTag.Table);
            output.RenderBeginTag(HtmlTextWriterTag.Tr);
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            tbSearchText.RenderControl(output);
            output.RenderEndTag();
            output.RenderBeginTag(HtmlTextWriterTag.Td);
            btnSearch.RenderControl(output);
            output.RenderEndTag();
            output.RenderEndTag();
            output.RenderEndTag();
        }


    }
}
