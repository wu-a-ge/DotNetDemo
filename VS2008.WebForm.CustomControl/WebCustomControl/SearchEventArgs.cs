using System;
using System.Collections.Generic;
using System.Text;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    public delegate void SearchEventHandler(object sender, SearchEventArgs e);
    public class SearchEventArgs : EventArgs
    {
        public SearchEventArgs()
        { 
        }

        private string strSearchValue;
        /// <summary>
        ///  Ҫ�����Ĺؼ���
        /// </summary>
        public string SearchValue
        {
            get { return strSearchValue; }
            set { strSearchValue = value; }
        }

    }
}
