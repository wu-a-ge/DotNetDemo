using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

[assembly: WebResource("WebCustomControl.CSS.EmbeddedResource_CSS.css", "text/css")]
[assembly: WebResource("WebCustomControl.images.EmbeddedResource_JPG.jpg", "image/jpg")]
[assembly: WebResource("WebCustomControl.js.EmbeddedResource_JS.js", "application/x-javascript", PerformSubstitution = true)]
[assembly: WebResource("WebCustomControl.Sound.clock.avi", "video/avi")]

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>    
    [ToolboxData("<{0}:EmbeddedResourceControl runat=server></{0}:EmbeddedResourceControl>")]
    [System.Drawing.ToolboxBitmap(typeof(EmbeddedResourceControl), @"EmbeddedResourceControl.bmp")]
    public class EmbeddedResourceControl : WebControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);                       

            Page.ClientScript.RegisterClientScriptResource(this.GetType(), "WebCustomControl.js.EmbeddedResource_JS.js");
            ////����
            //string strJSPath = Page.ClientScript.GetWebResourceUrl(typeof(EmbeddedResourceControl), "WebCustomControl.JS.EmbeddedResource_JS.js");
            //if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "ClientJS"))
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientJS",
            //        "<script type='text/javascript' src='" + strJSPath + "'></script>", false);
            //}
            
            //����Դ�ļ��ж�ȡ��ʽ��Դ�ļ�                        
            string strCSS = Page.ClientScript.GetWebResourceUrl(this.GetType(), "WebCustomControl.CSS.EmbeddedResource_CSS.css");
            if (Page.Header != null)
            {
                HtmlLink link = new HtmlLink();
                link.Href = strCSS;
                link.Attributes.Add("type", "text/css");
                link.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(link);
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {            
            //����Դ�ļ��ж�ȡͼƬ��Դ�ļ�
            string str = Page.ClientScript.GetWebResourceUrl(typeof(EmbeddedResourceControl), "WebCustomControl.images.EmbeddedResource_JPG.jpg");
            Image image = new Image();
            image.ImageUrl = str;
            image.Attributes["onclick"] = "PicOnClick();";
            image.CssClass = "filter";
            image.RenderControl(output);

            output.Write("<br><br><br>");

            string strSoundPath = Page.ClientScript.GetWebResourceUrl(typeof(EmbeddedResourceControl), "WebCustomControl.Sound.clock.avi");
            output.Write("<EMBED id='sound' src='" + strSoundPath + "' border=0 autostart=false loop=true></EMBED>");

        }
    }
}
