using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace UtilityLib.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [DataBindingHandler("System.Web.UI.Design.TextDataBindingHandler, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Designer("System.Web.UI.Design.WebControls.CheckBoxDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), ControlValueProperty("Checked")]
    [DefaultEvent("CheckedChanged")]
    [DefaultProperty("Checked")]
    [ToolboxData("<{0}:CCheckBox runat=server></{0}:CCheckBox>")]
    public class CCheckBox : WebControl,IPostBackDataHandler
    {
        private static readonly object EventCheckedChanged;
        static CCheckBox()
        {
            EventCheckedChanged = new object();
        }
 
        #region 属性
        /// <summary>
        /// 本属性表示是否在CheckBox旁边显示文本
        /// </summary>
        [DefaultValue(true), Themeable(false), Category("Appearance"), Description("CheckBox_ShowText")]
        public virtual bool ShowText
        {
            get
            {
                object obj = (object)ViewState["ShowText"];
                if (obj == null)
                    return true;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["ShowText"] = value;
            }
        }
        [DefaultValue(false), Themeable(false), Category("Behavior"),Description("CheckBox_AutoPostBack")]
        public virtual bool AutoPostBack
        {
            get
            {
                object obj = (object)ViewState["AutoPostBack"];
                return ((obj != null)&& (bool)obj);
            }

            set
            {
                ViewState["AutoPostBack"] = value;
            }
        }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public virtual  string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public virtual string Value
        {
            get
            {
                String s = (String)ViewState["Value"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Value"] = value;
            }
        }

        [Bindable(true, BindingDirection.TwoWay)]
        [DefaultValue(false)]
        [Localizable(true)]
        [Themeable(false)]
        public virtual bool Checked
        {
            get
            {
                object obj2 = this.ViewState["Checked"];
                return ((obj2 != null) && ((bool)obj2));

            }

            set
            {
                ViewState["Checked"] = value;
            }
        }
        [Category("Appearance"), DefaultValue(TextAlign.Right), Description("WebControl_TextAlign")]
        public virtual TextAlign TextAlign
        {
            get
            {
                object obj2 = this.ViewState["TextAlign"];
                if (obj2 != null)
                {
                    return (TextAlign)obj2;
                }
                return TextAlign.Right;
            }
            set
            {
                if ((value < TextAlign.Left) || (value > TextAlign.Right))
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.ViewState["TextAlign"] = value;
            }
        }

        [Themeable(false), DefaultValue(false),Category("Behavior"),Description("AutoPostBackControl_CausesValidation")]
        public virtual bool CausesValidation
        {
            get
            {
                object obj2 = this.ViewState["CausesValidation"];
                return ((obj2 != null) && ((bool)obj2));
            }
            set
            {
                this.ViewState["CausesValidation"] = value;
            }
        }
        [Category("Behavior"), DefaultValue(""), Themeable(false),Description("PostBackControl_ValidationGroup")]
        public virtual string ValidationGroup
        {
            get
            {
                string str = (string)this.ViewState["ValidationGroup"];
                if (str != null)
                {
                    return str;
                }
                return string.Empty;
            }
            set
            {
                this.ViewState["ValidationGroup"] = value;
            }
        }
 


        #endregion

        #region 事件
        [Category("Action")]
        [Description("Control_OnServerCheckChanged")]
        public event EventHandler CheckedChanged
        {
            add {
                base.Events.AddHandler(EventCheckedChanged, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCheckedChanged, value);
            }
        }
        protected virtual void OnCheckedChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventCheckedChanged];
            if (handler != null)
                handler(this, e);
        }
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            bool autoPostBack = this.AutoPostBack;
            if ((this.Page != null) && base.IsEnabled)
            {
                this.Page.RegisterRequiresPostBack(this);
                
            }
             

        }
        /// <summary>
        /// 根据条件Value和ShowText判断是如何否呈现
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            //当值属性为空时，不用显示text了
            if (Value.Length != 0)
            {
                if (this.TextAlign == TextAlign.Left)
                {
                    if (ShowText)
                        RenderLabel(writer);
                    RenderInputTag(writer);
                  
                }
                else
                {
                    RenderInputTag(writer);
                    if (ShowText)
                        RenderLabel(writer);
                }
            }
            else
            {
                RenderInputTag(writer);
            }

        }
        /// <summary>
        /// 呈现input标记
        /// </summary>
        /// <param name="writer"></param>
        private void RenderInputTag(HtmlTextWriter writer)
        {

            base.AddAttributesToRender(writer);
            string onClick = string.Empty;
            //if (this.ClientID != null)
            //{
            //    writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
            //}
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
            if (this.UniqueID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            }
            if (!string.IsNullOrEmpty(this.Value))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Value, this.Value);
            }
            if (this.Checked)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
            }
            //if (!base.IsEnabled)
            //{
            //    writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            //}
            //string accessKey = this.AccessKey;
            //if (accessKey.Length > 0)
            //{
            //    writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, accessKey);
            //}
            //int tabIndex = this.TabIndex;
            //if (tabIndex != 0)
            //{
            //    writer.AddAttribute(HtmlTextWriterAttribute.Tabindex, tabIndex.ToString(NumberFormatInfo.InvariantInfo));
            //}
            if (this.AutoPostBack)
            {
                PostBackOptions options = new PostBackOptions(this, string.Empty);
                if (this.CausesValidation && (this.Page.GetValidators(this.ValidationGroup).Count > 0))
                {
                    options.PerformValidation = true;
                    options.ValidationGroup = this.ValidationGroup;
                }
                if (this.Page.Form != null)
                {
                    options.AutoPostBack = true;
                }

                onClick = this.Page.ClientScript.GetPostBackEventReference(options, false);
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);

            }
            //else
            //{
            //    if (this.Page != null)
            //    {
            //        this.Page.ClientScript.RegisterForEventValidation(this.UniqueID);
            //    }
            //    if (onClick != null)
            //    {
            //        writer.AddAttribute(HtmlTextWriterAttribute.Onclick, onClick);
            //    }
            //}

            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();
        }
        /// <summary>
        /// 呈现label标记
        /// </summary>
        /// <param name="writer"></param>
        private void RenderLabel(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.For, this.ClientID);
 
            writer.RenderBeginTag(HtmlTextWriterTag.Label);
            writer.Write(Text);
            writer.RenderEndTag();
        }
 
        #region IPostBackDataHandler 成员
        /// <summary>
        /// 这里有个问题，没有被选中，根本就没有name属性啊！这个方法也不会调用了！！悲具了
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            bool flag = false;
            //没有选中为null,选中为on或value属性中的值
            string str = postCollection[postDataKey];
            bool flag2 = !string.IsNullOrEmpty(str);//选中为true，没有选中为false
            flag = flag2 != this.Checked;//不等，值改变，
            this.Checked = flag2;
            return flag;

        }

        public virtual void RaisePostDataChangedEvent()
        {
            this.OnCheckedChanged(EventArgs.Empty);

        }

        bool IPostBackDataHandler.LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            return this.LoadPostData(postDataKey, postCollection);
        }

        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
            this.RaisePostDataChangedEvent();
        }
        #endregion
    }
}
