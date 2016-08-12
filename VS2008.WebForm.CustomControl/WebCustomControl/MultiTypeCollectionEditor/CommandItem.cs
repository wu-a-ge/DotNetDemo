using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing.Design;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    /// <summary>
    ///  命令按钮类
    /// </summary>    
    [ToolboxItem(false)]    
    public class CommandItem : ItemBase
    {
        private CommandActionType _CommandActionType;
        //命令按钮文本
        private string _Text = null;
        //快捷键
        private string _AccessKey = null;
        //提示
        private string _ToolTip = null;
        //是否可用
        private bool _Enable = true;        
        /// <summary>
        /// 默认构造方法
        /// </summary>        
        public CommandItem()
        {
        }

        /// <summary>
        /// 构造方法[ButtonCommand]
        /// </summary>
        /// <param name="bitButtonItemType"></param>        
        /// <param name="strCommandText"></param>
        /// <param name="strAccessKey"></param>
        /// <param name="strToolTip"></param>        
        public CommandItem(CommandActionType commandActionType, string strText, string strAccessKey, string strToolTip)
        {
            this._CommandActionType = commandActionType;
            this._Text = strText;
            this._AccessKey = strAccessKey;
            this._ToolTip = strToolTip;            
        }

        /// <summary>
        /// 命令按钮类型
        /// </summary>
        [NotifyParentProperty(true)]
        public CommandActionType CommandActionType
        {
            get
            {
                return _CommandActionType;
            }
            set
            {
                _CommandActionType = value;
            }
        }

        /// <summary>
        /// 命令按钮文本
        /// </summary>
        [NotifyParentProperty(true)]
        [Browsable(false)]
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        [NotifyParentProperty(true)]
        [Browsable(false)]
        public string AccessKey
        {
            get
            {
                return _AccessKey;
            }
            set
            {
                _AccessKey = value;
            }
        }

        /// <summary>
        /// 帮助提示文本
        /// </summary>
        [NotifyParentProperty(true)]
        [Browsable(false)]
        public string ToolTip
        {
            get
            {
                return _ToolTip;
            }
            set
            {
                _ToolTip = value;
            }
        }

        /// <summary>
        /// 是否可用
        /// </summary>
        [NotifyParentProperty(true)]
        [Browsable(false)]
        public bool Enable
        {
            get
            {
                return _Enable;
            }
            set
            {
                _Enable = value;
            }
        }
    }
    
}
