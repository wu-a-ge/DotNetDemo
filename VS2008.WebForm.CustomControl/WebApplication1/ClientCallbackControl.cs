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
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    /// ���ÿͻ��˻ص�����ʵ�ֵ�λֵ�ؼ�
    /// </summary>
    [DefaultProperty("Value")]
    [ToolboxData("<{0}:ClientCallbackControl runat=server></{0}:ClientCallbackControl>")]
    public class ClientCallbackControl : CompositeControl, ICallbackEventHandler
    {
        [Category("�ؼ�����")]
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
                catch //����ҳ��������ֵʱ������ʹ��this.Page����
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
                catch //����ҳ��������ֵʱ������ʹ��this.Page����
                {
                    ViewState["Value"] = value;
                }
            }
        }

        [Category("�ؼ�����")]
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
                
        [Category("�ؼ�����")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("��Դ(image/css/js)�Ŀͻ��˸�Ŀ¼")]
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

        [Category("�ؼ�����")]
        [DefaultValue("")]
        [Localizable(true)]
        [Description("ָ������ص�����Ŀͻ��˷�������,�Һ�����������(arg,context)")]
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

            //ע��������ؼ�
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


        #region ICallbackEventHandler ��Ա

        /// <summary>
        /// ����Value���Ե����ʼֵ
        /// </summary>
        /// <returns></returns>
        public string GetCallbackResult()
        {
            return this.Value.ToString();
        }

        //�ڸ÷����п������ӹ����߼�����, ����GetCallbackResult����
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
