using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.IO;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [ToolboxData("<{0}:CustomValidateControl runat=server></{0}:CustomValidateControl>")]
    public class CustomValidateControl : BaseValidator
    {
        /// <summary>
        /// �Ƿ���������Ϊ��
        /// </summary>
        [Description("�Ƿ���������NULL")]
        [Category("��Ϊ")]
        public bool AllowNull
        {
            get
            {

                return ViewState["AllowNull"] == null ? false : (bool)ViewState["AllowNull"];
            }
            set 
            {
                ViewState["AllowNull"] = value; 
            }
        }

        /// <summary>
        /// �Ƿ���������Ϊ��
        /// </summary>
        [Description("�Ƿ�ʹ���Զ����ToolTip��ʾ��֤��Ϣ")]
        [Category("��Ϊ")]
        public bool UseToolTip
        {
            get
            {

                return ViewState["UseToolTip"] == null ? false : (bool)ViewState["UseToolTip"];
            }
            set
            {
                ViewState["UseToolTip"] = value;
            }
        }        
        
        /// <summary>
        /// ���û��ȡ��Դ�ļ���Ŀ¼
        /// </summary>        
        [Category("�ͻ���·��")]
        [DefaultValue("")]        
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



        public CustomValidateControl()        
        {
            this.ViewState["ClientPath"] = @".\";
            this.ErrorMessage = "[ֻ�����������ַ�!]";            
        }

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            if (base.RenderUplevel == true)
            {
                writer.AddAttribute("evaluationfunction", "ClientNumValidateFunc");
                writer.AddAttribute("allowNull", this.AllowNull.ToString());
                writer.AddAttribute("useToolTip", this.UseToolTip.ToString());

                writer.AddAttribute("foreColor", this.ForeColor.Name.ToString());                
                
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (base.RenderUplevel == true)
            {
                string strJSPath = base.ResolveUrl(Path.Combine(this.ClientPath, @"Js\ClientValidate.js"));
                if (!Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), "ClientValidate"))
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "ClientValidate",
                        "<script type='text/javascript' src='" + strJSPath + "'></script>", false);
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            
            //ToolTip�����ṹ
            string strImageFolder = base.ResolveUrl(Path.Combine(this.ClientPath, @"Images\"));
            if (this.DesignMode == false)
            {
                string strToolTipContext = "<table id='ValidateToolTip_Main' border='0' cellspacing='0' cellpadding='0' style='display:none;' onclick=\"this.style.display='none';\" style='z-index:10000;position:absolute;' >" +
                          "<tr>" +
                            "<td width='38px'><table  border='0' cellspacing='0' cellpadding='0'>" +
                              "<tr>" +
                                "<td align='right' valign='top'><img src='" + strImageFolder + "w_03.gif' width='13' height='10' /></td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td align='right'><img src='" + strImageFolder + "w_08.gif' width='38' height='68' /></td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td align='right' valign='bottom'><img src='" + strImageFolder + "w_14.gif' width='13' height='10' /></td>" +
                              "</tr>" +
                            "</table></td>" +
                            "<td  bgcolor='#DBE5F2' style='border-top : 1px double #88B3EB;border-bottom: 1px double #88B3EB;'><table  height='100%' width='100%' border='0' cellspacing='0' cellpadding='0'>" +
                              "<tr>" +
                                "<td>&nbsp;</td>" +
                                "<td>&nbsp;</td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td width='30' height='50' align='center' valign='top'><img src='" + strImageFolder + "w_11.gif' width='14' height='16' /></td>" +
                                "<td id='ValidateToolTip_MessageText'>[ToolTip��ʾ��Ϣ�ı�]</td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td>&nbsp;</td>" +
                                "<td>&nbsp;</td>" +
                              "</tr>" +
                            "</table></td>" +
                            "<td width='14'><table  border='0' cellspacing='0' cellpadding='0'>" +
                              "<tr>" +
                                "<td align='right' valign='top'><img src='" + strImageFolder + "w_05.gif' width='14' height='10' /></td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td height='68' bgcolor='#DBE5F2' style='border-right : 1px double #88B3EB;'>&nbsp;</td>" +
                              "</tr>" +
                              "<tr>" +
                                "<td align='right' valign='bottom'><img src='" + strImageFolder + "w_15.gif' width='14' height='10' /></td>" +
                              "</tr>" +
                            "</table></td>" +
                          "</tr>" +
                        "</table>";

                writer.Write(strToolTipContext);
            }
        }

        protected override bool EvaluateIsValid()
        {
            string strValue = this.GetControlValidationValue(this.ControlToValidate);
            if (this.AllowNull == true && String.IsNullOrEmpty(strValue) == true)
            {
                return true;
            }

            Regex r = new Regex("^[0-9]+$");
            if (r.IsMatch(strValue))
            {
                return true;
            }
            return false;
        }
    }
}
