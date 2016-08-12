using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Handlers;
using System.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class FilterStrFactoryHandler:IHttpHandlerFactory
    {


        #region IHttpHandlerFactory 成员

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
            //得到编译实例(通过反射)
            PageHandlerFactory factory =
                (PageHandlerFactory)Activator.CreateInstance(typeof(PageHandlerFactory), true);
            IHttpHandler handler = factory.GetHandler(context, requestType, url, pathTranslated);
            
            //IHttpHandler handler = PageParser.GetCompiledPageInstance(url, pathTranslated, context);
            //以上两种方式有什么区别？
            //过滤字符串
            if (requestType == "POST")
            {
                Page page = handler as Page;
                if (page != null)
                    page.PreLoad += new EventHandler(FilterStrFactoryHandler_PreLoad);
            }

            //返回
            return handler;

        }
        //过滤TextBox、Input和Textarea中的特殊字符
        void FilterStrFactoryHandler_PreLoad(object sender, EventArgs e)
        {
            try
            {
                Page page = sender as Page;
                NameValueCollection postData = page.Request.Form;
                foreach (string postKey in postData)
                {
                    Control ctl = page.FindControl(postKey);
                    if (ctl as TextBox != null)
                    {
                        ((TextBox)ctl).Text = Common.InputText(((TextBox)ctl).Text);
                        continue;
                    }
                    if (ctl as HtmlInputControl != null)
                    {
                        ((HtmlInputControl)ctl).Value = Common.InputText(((HtmlInputControl)ctl).Value);
                        continue;
                    }
                    if (ctl as HtmlTextArea != null)
                    {
                        ((HtmlTextArea)ctl).Value = Common.InputText(((HtmlTextArea)ctl).Value);
                        continue;
                    }
                }
            }
            catch
            {
            }
        }
        private class Common
        {
            //字符串过滤
            public static string InputText(string text)
            {
                text = text.Trim();
                if (string.IsNullOrEmpty(text))
                    return string.Empty;
                text = Regex.Replace(text, "[\\s]{2,}", " ");    //two or more spaces
                text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");    //<br>
                text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");    //&nbsp;
                text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);    //any other tags
                text = text.Replace("'", "''");
                return text;
            }
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
             
        }

        #endregion
    }
}
