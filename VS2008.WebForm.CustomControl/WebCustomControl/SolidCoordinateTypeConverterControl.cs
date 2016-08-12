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
    [DefaultProperty("SolidCoordinate")]
    [ToolboxData("<{0}:SolidCoordinateTypeConverterControl runat=server></{0}:SolidCoordinateTypeConverterControl>")]
    public class SolidCoordinateTypeConverterControl : WebControl
    {
        SolidCoordinate solidCoordinate;
        [Category("转换器")]
        [Description("SolidCoordinate类型属性(具有三个值的扩展类型)")]        
        public SolidCoordinate SolidCoordinate
        {
            get
            {
                if (solidCoordinate == null)
                {
                    solidCoordinate = new SolidCoordinate();
                }
                return solidCoordinate;
            }
            set
            {
                solidCoordinate = value;
            }
 
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("控件属性示例, 请从:设计器界面<=>代码视图界面 切换查看效果.");
        }
    }
}
