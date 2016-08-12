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
    [DefaultProperty("SelectFood")]
    [ToolboxData("<{0}:CustomCollectionPropertyConverterControl runat=server></{0}:CustomCollectionPropertyConverterControl>")]
    public class CustomCollectionPropertyConverterControl : WebControl
    {
        private string strSelectFood;
        [Bindable(true)]
        [Category("类别")]                
        [Description("选择食品类别")]
        [TypeConverter(typeof(CustomCollectionPropertyConverter))]
        public string SelectFood
        {
            get
            {
                return strSelectFood;
            }

            set
            {
                strSelectFood = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("控件属性示例, 请从:设计器界面<=>代码视图界面 切换查看效果.");
        }
    }
}
