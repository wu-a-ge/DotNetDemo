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
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    /// ���߰�ť������
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [Editor(typeof(CommandCollectionEditor), typeof(UITypeEditor))]
    public class CommandCollection : Collection<ItemBase>
    {
        #region ���幹�캯��

        public CommandCollection()
            : base()
        {
        }

        #endregion

        /// <summary>
        /// �õ�����Ԫ�صĸ���
        /// </summary>
        public new int Count
        {
            get
            {
                return base.Count;
            }
        }

        /// <summary>
        /// ��ʾ�����Ƿ�Ϊֻ��
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// ��Ӷ��󵽼���
        /// </summary>
        /// <param name="item"></param>
        public new void Add(ItemBase item)
        {
            base.Add(item);
        }

        /// <summary>
        /// ��ռ���
        /// </summary>
        public new void Clear()
        {
            base.Clear();
        }

        /// <summary>
        /// �жϼ������Ƿ����Ԫ��
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Contains(ItemBase item)
        {
            return base.Contains(item);
        }

        /// <summary>
        /// �Ƴ�һ������
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public new bool Remove(ItemBase item)
        {
            return base.Remove(item);
        }

        /// <summary>
        /// ���û�ȡ��������
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
