using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Drawing.Design;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    /// <summary>
    ///  ���ť��
    /// </summary>    
    [ToolboxItem(false)]    
    public class CommandItem : ItemBase
    {
        private CommandActionType _CommandActionType;
        //���ť�ı�
        private string _Text = null;
        //��ݼ�
        private string _AccessKey = null;
        //��ʾ
        private string _ToolTip = null;
        //�Ƿ����
        private bool _Enable = true;        
        /// <summary>
        /// Ĭ�Ϲ��췽��
        /// </summary>        
        public CommandItem()
        {
        }

        /// <summary>
        /// ���췽��[ButtonCommand]
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
        /// ���ť����
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
        /// ���ť�ı�
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
        /// ��ݼ�
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
        /// ������ʾ�ı�
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
        /// �Ƿ����
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
