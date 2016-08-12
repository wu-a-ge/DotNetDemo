using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    /// �������Ա༭��
    /// </summary>
    public class CommandCollectionEditor : CollectionEditor
    {
        public CommandCollectionEditor(Type type)
            : base(type)
        {
            string s = "abc";
        }

        protected override bool CanSelectMultipleInstances()
        {
            return true;
        }        

        protected override Type[] CreateNewItemTypes()
        {            
            return new Type[] { typeof(CommandItem), typeof(CommandSeperator) };
        }

        protected override object CreateInstance(Type itemType)
        {
            if (itemType == typeof(CommandItem))
            {
                return new CommandItem();
            }
            if (itemType == typeof(CommandSeperator))
            {
                return new CommandSeperator();
            }
            return null;
        }
    }
}
