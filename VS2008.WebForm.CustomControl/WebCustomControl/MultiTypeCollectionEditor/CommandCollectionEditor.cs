using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    /// <summary>
    /// 集合属性编辑器
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
