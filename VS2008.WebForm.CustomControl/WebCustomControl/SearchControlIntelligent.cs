using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using AjaxPro;
using System.Collections;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("ButtonSearchClick")]    
    [ToolboxData("<{0}:SearchControlIntelligent runat=server></{0}:SearchControlIntelligent>")]
    public class SearchControlIntelligent : CompositeControl
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

        /// <summary>
        /// 设置或获取资源文件夹目录
        /// </summary>
        [Bindable(true)]
        [Category("搜索")]                
        [Description("资源(image/css/js)的客户端根目录")]
        public string ClientScriptPath
        {
            get
            {
                String s = (String)ViewState["ClientScriptPath"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["ClientScriptPath"] = value;
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
            btnSearch.Click += new EventHandler(btnSearch_Click);

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

        void btnSearch_Click(object sender, EventArgs e)
        {
            SearchEventArgs args = new SearchEventArgs();
            args.SearchValue = this.Text;
            OnButtonSearchClick(args);
        }

        protected override void OnLoad(EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(AjaxProSearchService), this.Page);
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            string strJSPath = base.ResolveUrl(Path.Combine(this.ClientScriptPath, @"SearchControlIntelligent.js"));
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "SearchControlIntelligentScript"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SearchControlIntelligentScript",
                    "<script type='text/javascript' src='" + strJSPath + "'></script>", false);
            }

            StringBuilder strInitScript = new StringBuilder();
            strInitScript.Append("<script text/javascript> ");
            strInitScript.Append("      InitQueryCode('" + tbSearchText.ClientID + "');");            
            strInitScript.Append("</script>");

            if (!Page.ClientScript.IsStartupScriptRegistered(this.GetType(), "InitScript" + this.UniqueID))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "InitScript" + this.UniqueID,
                    strInitScript.ToString());
            }           

            base.OnPreRender(e);
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

    [AjaxPro.AjaxNamespace("AjaxProSearchService")]
    public class AjaxProSearchService
    {
        [AjaxPro.AjaxMethod]
        public static ArrayList GetSearchItems(string strSearchKey)
        {
            //生成数据源
            ArrayList items = new ArrayList();
            items.Add("King");
            items.Add("Rose");
            items.Add("James");
            items.Add("Elvis");
            items.Add("Jim");
            items.Add("John");
            items.Add("Adams");

            //筛选匹配的数据
            ArrayList selectItems = new ArrayList();
            foreach (string str in items)
            {
                if (str.ToUpper().IndexOf(strSearchKey.ToUpper()) == 0)
                {
                    selectItems.Add(str);
                }
            }
            return selectItems;
        }  
        
    }
}
