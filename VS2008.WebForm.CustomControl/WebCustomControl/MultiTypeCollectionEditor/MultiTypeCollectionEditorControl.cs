using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [DefaultProperty("ToolBarItems")]
    [ToolboxData("<{0}:MultiTypeCollectionEditorControl runat=server></{0}:MultiTypeCollectionEditorControl>")]
    [ParseChildren(true, "ToolBarItems")]
    public class MultiTypeCollectionEditorControl : WebControl
    {
        private CommandCollection _ToolBarItems = new CommandCollection();

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("工具工具按钮集设置")]
        [Category("集合设置")]
        public CommandCollection ToolBarItems
        {
            get
            {
                if (_ToolBarItems == null)
                {
                    _ToolBarItems = new CommandCollection();
                }         
                return _ToolBarItems;
            }
        }
        
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("控件属性示例, 请从:设计器界面<=>代码视图界面 切换查看效果.");
        }
    }
}
