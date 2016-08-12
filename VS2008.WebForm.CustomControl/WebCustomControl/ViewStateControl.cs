using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCustomControl
{
    /// <summary>
    /// Author: ��ҹսӥ����רע��DotNet��������ChengKing(ZhengJian)��
    /// ��ñ���ĸ����½�:��http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx��
    /// ����: ��������Ϊ����Asp.net������һЩ���¡���ת��ʱ�뱣��������Դ��
    /// </summary>
    [ToolboxData("<{0}:ViewStateControl runat=server></{0}:ViewStateControl>")]
    public class ViewStateControl : WebControl
    {
        private string _text;
        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        [Category("������ͼ״̬")]
        [Description("û��ʹ����ͼ״̬�洢")]
        public string Text_NoViewState
        {
            get
            {
                return _text;
            }

            set
            {
                this._text = value;
            }
        }

        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        [Category("������ͼ״̬")]
        [Description("ʹ��ViewState�������洢���ݴ�����")]
        public string Text_ViewState
        {
            get
            {
                String s = (String)ViewState["Text_ViewState"];
                return ((s == null) ? String.Empty : s);

            }

            set
            {
                ViewState["Text_ViewState"] = value;

            }
        }

        private FaceStyle _faceStyle;
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [NotifyParentProperty(true)]
        [Category("������ͼ״̬")]
        [Description("�Զ�����ͼ״̬(ʵ��IStateManager�ӿ�)�洢������")]
        public FaceStyle FaceStyle
        {
            get
            {
                if (_faceStyle == null)
                {
                    _faceStyle = new FaceStyle();
                }

                //if (IsTrackingViewState)
                //{
                //    ((IStateManager)_faceStyle).TrackViewState();
                //}

                return _faceStyle;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            if (DesignMode)
            {
                output.Write("[�Զ�����ͼ״̬�洢ʾ���ؼ�]");
            }
        }

        protected override object SaveViewState()
        {
            Pair p = new Pair();
            p.First = base.SaveViewState();
            p.Second = ((IStateManager)FaceStyle).SaveViewState();
            for (int i = 0; i < 2; i++)
            {
                if (p.First != null || p.Second != null)
                {
                    return p;
                }
            }
            return null;
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
            {
                base.LoadViewState(null);
                return;
            }
            else
            {
                Pair p = (Pair)savedState;
                if (p == null)
                {
                    throw new ArgumentException("��Ч�� View State ����!");
                }
                base.LoadViewState(p.First);
                if (p.Second != null)
                {
                    ((IStateManager)FaceStyle).LoadViewState(p.Second);
                }
            }            
        }

        //protected override void OnPreRender(EventArgs e)
        //{
        //    this.Page.RegisterRequiresViewStateEncryption();
        //    base.OnPreRender(e);
        //}
    }
}
