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
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [ToolboxData("<{0}:CustomValidateControl runat=server></{0}:CustomValidateControl>")]
    public class CustomValidateControl : BaseValidator
    {
        /// <summary>
        /// 是否允许输入为空
        /// </summary>
        [Description("是否允许输入NULL")]
        [Category("行为")]
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
        /// 是否允许输入为空
        /// </summary>
        [Description("是否使用自定义的ToolTip显示验证信息")]
        [Category("行为")]
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
        /// 设置或获取资源文件夹目录
        /// </summary>        
        [Category("客户端路径")]
        [DefaultValue("")]        
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



        public CustomValidateControl()        
        {
            this.ViewState["ClientPath"] = @".\";
            this.ErrorMessage = "[只能输入数字字符!]";            
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
            
            //ToolTip容器结构
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
                                "<td id='ValidateToolTip_MessageText'>[ToolTip提示信息文本]</td>" +
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
