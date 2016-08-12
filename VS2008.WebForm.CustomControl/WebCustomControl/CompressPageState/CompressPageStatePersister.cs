using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace KingControls
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    public class CompressPageStatePersister : PageStatePersister
    {
        //ҳ��״̬������ҳ���е��ֶ���
        private string PageStateKey = "____VIEWSTATE";
        public CompressPageStatePersister(Page page) : base(page)
        {
        }
        public override void Load()
        {
            //ȡ�ñ��浽�ͻ��˵�״̬����
            string postbackState = Page.Request.Form[PageStateKey];
            if (!string.IsNullOrEmpty(postbackState))
            {
                //ҳ��״̬������ͼ״̬�Ϳؼ�״̬������
                Pair statePair = (Pair)CompressHelp.Decompress(postbackState);
                if (!Page.EnableViewState)
                {
                    this.ViewState = null;
                }
                else
                {
                    ViewState = statePair.First;
                }
                this.ControlState = statePair.Second;
            }
        }

        public override void Save()
        {
            if (!Page.EnableViewState)
            {
                this.ViewState = null;
            }
            if (this.ViewState != null || this.ControlState != null)
            {
                string stateString;
                Pair statePair = new Pair(ViewState, ControlState);
                stateString = CompressHelp.Compress(statePair);
                Page.ClientScript.RegisterHiddenField(PageStateKey, stateString);
            }
        }
    }
}
