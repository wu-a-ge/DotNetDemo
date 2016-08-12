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
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [DefaultProperty("ToolBarItems")]
    [ToolboxData("<{0}:MultiTypeCollectionEditorControl runat=server></{0}:MultiTypeCollectionEditorControl>")]
    [ParseChildren(true, "ToolBarItems")]
    public class MultiTypeCollectionEditorControl : WebControl
    {
        private CommandCollection _ToolBarItems = new CommandCollection();

        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("���߹��߰�ť������")]
        [Category("��������")]
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
            output.Write("�ؼ�����ʾ��, ���:���������<=>������ͼ���� �л��鿴Ч��.");
        }
    }
}
