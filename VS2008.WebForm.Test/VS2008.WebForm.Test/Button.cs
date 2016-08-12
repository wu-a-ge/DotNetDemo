using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace VS2008.WebForm.Test
{
  /// <summary>
    /// 在网页上显示下压按钮控件
    /// </summary>
    [DefaultProperty("Text")]
    [DefaultEvent("Click")]
    [ToolboxData("<{0}:Button runat=server></{0}:Button>")]
    public class Button : ControlBase, IPostBackEventHandler
    {
        private static readonly object EventClick = new object();
        /// <summary>
        /// 初始化<see cref="Button"/>类的新实例
        /// </summary>
        public Button()
            : base(HtmlTextWriterTag.Input)
        { 
            
        }
        /// <summary>
        /// 获取或设置在 <see cref="Button"/> 控件中显示的文本标题
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("提交")]
        [Localizable(true)]
        [Description("设置按钮显示的文本标题")]
        public string Text
        {
            get {
                if (ViewState["Text"]==null)//自定义扩展方法 等效于!Object.ReferenceEquals(null,OnViewClick)
                {
                    ViewState["Text"] = "提交";
                }
                return (string)ViewState["Text"];
            }
            set {
                ViewState["Text"] = value;
            }
        }
        /// <summary>
        /// 在单击 <see cref="Button"/>  控件时发生
        /// </summary>
        [ Description("单击控件时发生")]
        public event EventHandler Click
        {
            add {
                base.Events.AddHandler(EventClick, value);
             
            }
            remove {
                base.Events.RemoveHandler(EventClick, value);
             
            }
        }

        /// <summary>
        /// 获取或设置在引发某个 <see cref="Button" /> 控件的 <see cref="Button.Click" /> 事件时所执行的客户端脚本
        /// </summary>
        [DefaultValue(""), Description("在提交前执行的客户端脚本"), Themeable(false), Category("Behavior")]
        public virtual string OnClientClick
        {
            get
            {
               
                string str = (string)this.ViewState["OnClientClick"];
                if (str == null)
                {
                    return string.Empty;
                }
                return str;
            }
            set
            {
                this.ViewState["OnClientClick"] = value;
            }
        }
       // public virtual bool isSubmit
        /// <summary>
        /// 当由类实现时，使服务器控件能够处理将窗体发送到服务器时引发的事件
        /// </summary>
        /// <param name="eventArgument">表示要传递到事件处理程序的可选事件参数的 <see cref="System.String"/></param>
        public void RaisePostBackEvent(string eventArgument)
        {
            EventHandler handler = (EventHandler) base.Events[EventClick];
            if (handler != null)
            {
                handler(this, new EventArgs());
            }

        }
        /// <summary>
        /// 重写引发 <see cref="System.Web.UI.Control.Load"/> 事件
        /// </summary>
        /// <param name="e">包含事件数据的 System.EventArgs 对象</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //if (handler != null)//自定义扩展方法 等效于!EventHandler.ReferenceEquals(null,OnViewClick)
            //{
                string temp = Page.Request.Form[this.ID];
                if (temp!=null)
                {
                    RaisePostBackEvent(temp);
                }
            //}
        }
        protected override void RenderChildren(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.ID);
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "submit");
            base.RenderChildren(writer);
            if (!string.IsNullOrEmpty(OnClientClick))//自定义扩展方法 等效于!string.IsNullOrWhiteSpace(this.OnClientClick)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, this.OnClientClick);
            }
            writer.AddAttribute(HtmlTextWriterAttribute.Value, Text);
            
        }
    }

[ParseChildren(true), Themeable(true), PersistChildren(false)]
    public  class ControlBase:System.Web.UI.Control
    {
        private HtmlTextWriterTag htmltag=  HtmlTextWriterTag.Span;
        public ControlBase(HtmlTextWriterTag tag)
        {
            htmltag = tag;
        }
        private Style controlsStyle;
        /// <summary>
        /// 获取或设置由 Web 服务器控件在客户端呈现的Style样式
        /// </summary>
         [Browsable(false), Description("在客户端呈现的级联样式表 (CSS) 类"), Editor("System.ComponentModel.Design.MultilineStringEditor,System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(System.Drawing.Design.UITypeEditor))]
        public virtual Style Styles
        {
            get
            {
                if (controlsStyle==null)
                {
                    controlsStyle = new Style();
                }
                return controlsStyle;
            }
            set {
                controlsStyle = value;
            }
        }
         /// <summary>
         /// 获取或设置由 Web 服务器控件在客户端呈现的级联样式表 (CSS) 类
         /// </summary>
         [Category("Appearance"), DefaultValue(""), Description("在客户端呈现的级联样式表 (CSS) 类"), System.Web.UI.CssClassProperty]
         public virtual string CssClass { get { return Styles.CssClass; } set { Styles.CssClass = value; } }
         /// <summary>
         /// 获取或设置 Web 服务器控件的宽度。
         /// </summary>
         [Category("Layout"), DefaultValue(typeof(Unit), ""), Description("器控件的宽度")]
         public virtual Unit Width
         {
             get
             {
                 return Styles.Width;
             }
             set
             {
                 Styles.Width = value;
             }
         }
         /// <summary>获取或设置 Web 服务器控件的背景色。</summary>
         /// <returns>表示控件背景色的 <see cref="T:System.Drawing.Color" />。默认值为 <see cref="F:System.Drawing.Color.Empty" />，表示未设置此属性。</returns>
         [Category("Appearance"), DefaultValue(typeof(Color), ""), Description("设置 Web 服务器控件的背景色"), TypeConverter(typeof(WebColorConverter))]
         public virtual Color BackColor
         {
             get {
                 return this.Styles.BackColor;
             }
             set {
                 this.Styles.BackColor = value;
             }
         }
         /// <summary>获取或设置 Web 控件的边框颜色。</summary>
         /// <returns>表示控件的边框颜色的 <see cref="T:System.Drawing.Color" />。默认值为 <see cref="F:System.Drawing.Color.Empty" />，表示未设置此属性。</returns>
         [Description("边框颜色"), Category("Appearance"), DefaultValue(typeof(Color), ""), TypeConverter(typeof(WebColorConverter))]
         public virtual Color BorderColor
         {
             get
             {
                 return this.Styles.BorderColor;
             }
             set
             {
                  this.Styles.BorderColor=value;
             }
         }
         /// <summary>获取或设置 Web 服务器控件的边框宽度。</summary>
         /// <returns>
         ///<see cref="T:System.Web.UI.WebControls.Unit" />，表示 Web 服务器控件的边框宽度。默认值为 <see cref="F:System.Web.UI.WebControls.Unit.Empty" />，表示未设置此属性。</returns>
         /// <exception cref="T:System.ArgumentException">指定的边框宽度是负值。</exception>
         [Description("控件的边框宽度"), Category("Appearance"), DefaultValue(typeof(Unit), "")]
         public virtual Unit BorderWidth
         {
             get
             {
                 return this.Styles.BorderWidth;
             }
             set
             {
                 this.Styles.BorderWidth = value;
             }
         }
         /// <summary>获取或设置 Web 服务器控件的边框样式。</summary>
         /// <returns>
         ///<see cref="T:System.Web.UI.WebControls.BorderStyle" /> 枚举值之一。默认值为 NotSet。</returns>
         [DefaultValue(BorderStyle.NotSet), Category("Appearance"), Description("控件的边框样式")]
         public virtual BorderStyle BorderStyle
         {
             get
             {
                 return this.Styles.BorderStyle;
             }
             set
             {
                 this.Styles.BorderStyle = value;
             }
         }
         /// <summary>获取与 Web 服务器控件关联的字体属性。</summary>
         /// <returns>
         ///<see cref="T:System.Web.UI.WebControls.FontInfo" />，表示 Web 服务器控件的字体属性。</returns>
         [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Description("控件关联的字体"), Category("Appearance"), NotifyParentProperty(true)]
         public virtual FontInfo Font
         {
             get
             {
                 return Styles.Font;
             }
         }
         /// <summary>获取或设置 Web 服务器控件的前景色（通常是文本颜色）。</summary>
         /// <returns>表示控件前景色的 <see cref="T:System.Drawing.Color" />。默认值为 <see cref="F:System.Drawing.Color.Empty" />。</returns>
         [DefaultValue(typeof(Color), ""), Category("Appearance"), Description("控件的前景色（通常是文本颜色）"), TypeConverter(typeof(WebColorConverter))]
         public virtual Color ForeColor
         {
             get
             {
                 return Styles.ForeColor;
             }
             set
             {
                 Styles.ForeColor = value;
             }
         }
         /// <summary>获取或设置当鼠标指针悬停在 Web 服务器控件上时显示的文本。</summary>
         /// <returns>当鼠标指针悬停在 Web 服务器控件上时显示的文本。默认值为 <see cref="F:System.String.Empty" />。</returns>
         [Category("Behavior"), DefaultValue(""), Description("服务器控件上时显示的文本")]
         public virtual string Title//这里不要改成ToolTip，因为改成ToolTip后在我本机和Vs11里面都会造成VS直接崩溃，
         {
             get
             {
                 string str = (string)this.ViewState["Title"];
                 if (str != null)
                 {
                     return str;
                 }
                 return string.Empty;
             }
             set
             {
                 this.ViewState["Title"] = value;
             }
         }
         public override void RenderControl(HtmlTextWriter writer)
         {
             if (Visible)
             {
                 base.RenderControl(writer);
                 if (!string.IsNullOrEmpty(Title))
                 {
                     writer.AddAttribute(HtmlTextWriterAttribute.Title, Title);
                 }
                 if (!Styles.IsEmpty)
                 {
                     writer.EnterStyle(Styles, htmltag);

                 }
                 else
                 {
                     writer.RenderBeginTag(htmltag);
                 }

                 writer.RenderEndTag();
             }
         }

}
}
