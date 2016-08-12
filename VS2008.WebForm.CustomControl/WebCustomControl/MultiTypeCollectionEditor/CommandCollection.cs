using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.UI;
using System.Collections;
using System.Drawing.Design;
using System.Collections.ObjectModel;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    /// <summary>
    /// 工具按钮集合类
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [Editor(typeof(CommandCollectionEditor), typeof(UITypeEditor))]
    public class CommandCollection : Collection<ItemBase>
    {
        #region 定义构造函数

        public CommandCollection()
            : base()
        {
        }

        #endregion

        /// <summary>
        /// 得到集合元素的个数
        /// </summary>
        public new int Count
        {
            get
            {
                return base.Count;
            }
        }

        /// <summary>
        /// 表示集合是否为只读
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 添加对象到集合
        /// </summary>
        /// <param name="item"></param>
        public new void Add(ItemBase item)
        {
            base.Add(item);
        }

        /// <summary>
        /// 清空集合
        /// </summary>
        public new void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// 判断集合中是否包含元素
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Contains(ItemBase item)
        {
            return base.Contains(item);
        }

        /// <summary>
        /// 移除一个对象
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Remove(ItemBase item)
        {
            return base.Remove(item);
        }

        /// <summary>
        /// 设置或取得索引项
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public new ItemBase this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                base[index] = value;
            }
        }        
    }
}
