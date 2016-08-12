using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UtilityLib.Controls
{
    /// <summary>
    /// 这个控件的目的是注册控件状态，使它在关闭视图后，Text仍然回发有数据
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CLiteral runat=server></{0}:CLiteral>")]
    public class CLiteral :Literal
    {
        private string _text;
        [DefaultValue(""), Bindable(true),Description("Literal_Text"), Localizable(true), Category("Appearance")]
        public new  string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if(this.Page!=null)
                Page.RegisterRequiresControlState(this);
        }
        protected  override void Render(HtmlTextWriter writer)
        {
            string text = this.Text;
            if (text.Length != 0)
            {
                if (this.Mode != LiteralMode.Encode)
                {
                    writer.Write(text);
                }
                else
                {
                    HttpUtility.HtmlEncode(text, writer);
                }
            }
        }

        #region 保存和载入控件状态
        protected override void LoadControlState(object savedState)
        {
            if (savedState == null)
            {
                base.LoadControlState(null);
                return;
            }
            else
            {
                Pair p = (Pair)savedState;
                if (p == null)
                {
                    throw new ArgumentException("saveState is null", "saveState");
                }
                base.LoadControlState(p.First);
                if (p.Second != null)
                {
                    _text = (string)p.Second;
                }

            }

        }
        protected override object SaveControlState()
        {
            Pair p = new Pair();
            p.First = base.SaveControlState();
            p.Second = _text;
            return p;
        }
        #endregion
    }
}
