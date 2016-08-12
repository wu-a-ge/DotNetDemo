using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;

namespace WebCustomControl
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    /// <summary>
    /// 利用客户端回调技术实现单位值控件
    /// </summary>
    [DefaultProperty("Value")]
    [ToolboxData("<{0}:ClientCallbackControl runat=server></{0}:ClientCallbackControl>")]
    public class ClientCallbackControl : CompositeControl, ICallbackEventHandler
    {
        [Category("控件属性")]
        [DefaultValue("")]
        [Localizable(true)]
        public int Value
        {
            get
            {
                try
                {
                    //HttpContext.Current.Request[]
                    if (String.IsNullOrEmpty(Page.Request.Form[this.ClientID + "_hidden_txt_value"]) == false)
                    {
                        string strValue = Page.Request.Form[this.ClientID + "_hidden_txt_value"];
                        if (String.IsNullOrEmpty(strValue) == true)
                        {
                            return 0;
                        }
                        return int.Parse(strValue);
                    }
                    else
                    {
                        int s = (int)ViewState["Value"];
                        return s;
                    }
                }
                catch //当在页面中设置值时还不能使用this.Page对象
                {
                    int s = (int)ViewState["Value"];
                    return s; 
                }
            }

            set
            {
                try
                {
                    if (String.IsNullOrEmpty(Page.Request.Form[this.ClientID + "_hidden_txt_value"]) == false)
                    {
                        string strValue = Page.Request.Form[this.ClientID + "_hidden_txt_value"];
                        ViewState["Value"] = strValue;
                    }
                    else
                    {
                        ViewState["Value"] = value;
                    }
                }
                catch //当在页面中设置值时还不能使用this.Page对象
                {
                    ViewState["Value"] = value;
                }
            }
        }

        [Category("控件属性")]
        [DefaultValue("")]
        [Localizable(true)]
        public string UnitText
        {
            get
            {
                String s = (String)ViewState["UnitText"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["UnitText"] = value;
            }
        }
                
        [Category("控件属性")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("资源(image/css/js)的客户端根目录")]
        public string ClientPath
        {
            get
            {
                string s = (string)ViewState["ClientPath"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                ViewState["ClientPath"] = value;
            }
        }

        [Category("控件属性")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("指定处理回调结果的客户端方法名称,且含有两个参数(arg,context)")]
        public string OnClientCallBackResult
        {
            get
            {
                String s = (String)ViewState["OnClientCallBackResult"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["OnClientCallBackResult"] = value;
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            string strJSPath = base.ResolveUrl(Path.Combine(this.ClientPath, @"Js\ClientCallbackControl.js"));
            if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "RefControlJS"))
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "RefControlJS",
                    "<script type='text/javascript' src='" + strJSPath + "'></script>", false);
            }


            string strClientCallBackFunctions = "Default_ClientCallBackResult";           
            string strCallBackReference = Page.ClientScript.GetCallbackEventReference(this, "argument", strClientCallBackFunctions, "context");
            string strCallbackScript = "function ExecuteCallBack(argument, context) {" + strCallBackReference + ";}";
            if (Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "ExecuteCallBack") == false)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ExecuteCallBack", strCallbackScript, true);
            }

            //注册隐藏域控件
            Page.ClientScript.RegisterHiddenField(this.ClientID + "_hidden_txt_value", "");


            this.Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "SetHiddenFieldValueWhenSubmit", string.Format("SetHiddenFieldWhenSubmit('{0}', '{1}')",this.ClientID + "_txt", this.ClientID + "_hidden_txt_value"));
            
        }

        protected override void Render(HtmlTextWriter writer)
        {
            HtmlGenericControl div = new HtmlGenericControl("DIV");
            div.ID = "PlanTimeControl";
            div.Attributes["style"] = "width:95px;border:solid 1px darkgreen;position:relative;height:20px;";

            HtmlGenericControl txt = new HtmlGenericControl("INPUT");
            div.Controls.Add(txt);
            txt.ID = this.ClientID + "_txt";
            txt.Attributes["style"] = "vertical-align:middle;height:20px;width:75px;padding:0px;position:absolute;border:0px;line-height:20px;";
            txt.Attributes["value"] = this.Value.ToString() + " " + this.UnitText;

            HtmlGenericControl divUP = new HtmlGenericControl("DIV");
            div.Controls.Add(divUP);
            divUP.ID = "divUP";
            divUP.Attributes["style"] = "position:absolute;right:0px;border:solid 1px darkgreen;height:8px;";
            HtmlGenericControl imgUP = new HtmlGenericControl("IMG");
            divUP.Controls.Add(imgUP);
            imgUP.ID = "imgUP";
            imgUP.Attributes["style"] = "border-width:0px;position:relative;top:-3px;";            
            imgUP.Attributes["src"] = base.ResolveUrl(Path.Combine(this.ClientPath, @"Images\UP.gif"));
            imgUP.Attributes["onclick"] = "var context = new Object;  context.UnitText = '" + this.UnitText + "'; context.OnClientCallBackResult = '" + this.OnClientCallBackResult + "'; context.ControlClientID = '" + txt.ID + "'; context.HiddenClientID = '" + this.ClientID + "_hidden_txt_value" + "'; context.Direction='UP'; ExecuteCallBack('add',context)";

            HtmlGenericControl divDOWN = new HtmlGenericControl("DIV");
            div.Controls.Add(divDOWN);
            divDOWN.ID = "divUP";
            divDOWN.Attributes["style"] = "position:absolute;right:0px;border:solid 1px darkgreen;height:8px;bottom:0px;";
            HtmlGenericControl imgDOWN = new HtmlGenericControl("IMG");
            divDOWN.Controls.Add(imgDOWN);
            imgDOWN.ID = "imgDOWN";
            imgDOWN.Attributes["style"] = "border-width:0px;position:relative;top:-3px;";
            imgDOWN.Attributes["src"] = base.ResolveUrl(Path.Combine(this.ClientPath, @"Images\DOWN.gif"));

            imgDOWN.Attributes["onclick"] = "var context = new Object;  context.UnitText = '" + this.UnitText + "'; context.OnClientCallBackResult = '" + this.OnClientCallBackResult + "'; context.ControlClientID = '" + txt.ID + "'; context.HiddenClientID = '" + this.ClientID + "_hidden_txt_value" + "'; context.Direction='DOWN'; ExecuteCallBack('sub', context)";

            div.RenderControl(writer);    
        }


        #region ICallbackEventHandler 成员

        /// <summary>
        /// 返回Value属性的最初始值
        /// </summary>
        /// <returns></returns>
        public string GetCallbackResult()
        {
            return this.Value.ToString();
        }

        //在该方法中可以增加功能逻辑代码, 用于GetCallbackResult返回
        public void RaiseCallbackEvent(string eventArgument)
        {            
            if (eventArgument == "add")
            {                
            }
            if (eventArgument == "sub")
            {                
            }            
        }

        #endregion
    }
}
