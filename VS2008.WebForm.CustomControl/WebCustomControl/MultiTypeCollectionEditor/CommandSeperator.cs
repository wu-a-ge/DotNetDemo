using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    /// �ָ�����
    /// </summary>
    [ToolboxItem(false)]
    public class CommandSeperator : ItemBase
    {
        private Unit width;
        private Unit Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        private Unit height;
        private Unit Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
}
