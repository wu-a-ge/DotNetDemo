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
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    [ToolboxData("<{0}:ViewStateControl runat=server></{0}:ViewStateControl>")]
    public class ViewStateControl : WebControl
    {
        private string _text;
        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        [Category("测试视图状态")]
        [Description("没有使用视图状态存储")]
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
        [Category("测试视图状态")]
        [Description("使用ViewState属性来存储数据此属性")]
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
        [Category("测试视图状态")]
        [Description("自定义视图状态(实现IStateManager接口)存储此属性")]
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
                output.Write("[自定义视图状态存储示例控件]");
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
                    throw new ArgumentException("无效的 View State 数据!");
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
