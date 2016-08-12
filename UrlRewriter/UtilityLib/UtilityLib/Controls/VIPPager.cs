using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace UtilityLib.Controls
{
    [DefaultProperty("PageSize")]
    [DefaultEvent("PageChanged")]
    [ToolboxData("<{0}:VIPPager runat=server></{0}:VIPPager>")]
    public class VIPPager :CompositeControl
    {
        #region 字段
        //控件
        private LinkButton lbtnFirstPage;
        private LinkButton lbtnPrevPage;
        private LinkButton lbtnNextPage;
        private LinkButton lbtnLastPage;
        private LinkButton lbtnGoToPage;
        private Literal ltlPageCount;
        private Label lblCurrentPageIndex;
        private Label lblPageCount;
        private TextBox txtCurrentPageIndex;

        private VIPPager cloneFrom;
        private readonly static Regex isDigit = new Regex(@"\d+", RegexOptions.Compiled);
        #endregion

        #region 属性
        /// <summary>
        /// 当前页索引，默认值为1
        /// </summary>
        [DefaultValue(1), Category("Appearance"), Description("当前页索引，默认值为1")]
        public int CurrentPageIndex
        {
            get
            {
                if (null != cloneFrom)
                    return cloneFrom.CurrentPageIndex;
                object pageIndex = ViewState["CurrentPageIndex"];
                int pindex = (pageIndex == null) ? 1 : (int)pageIndex;
                //当前页大于总页面数，修正为返回总页面
                // 删除记录时，当前页可能大过了总页数
                if (pindex > PageCount && PageCount > 0)
                    return PageCount;
                if (pindex < 1)
                    return 1;
                return pindex;
            }
            set
            {
                int pageIndex = value;
                if (pageIndex < 1)
                    pageIndex = 1;
                //也要修正
                else if (pageIndex > PageCount)
                    pageIndex = PageCount;
                ViewState["CurrentPageIndex"] = pageIndex;
            }
        }
        /// <summary>
        /// 每页显示记录数，默认值为10
        /// </summary>
        [DefaultValue(10), Category("Appearance"), Description("每页显示记录数，默认值为10")]
        public int PageSize
        {
            get
            {

                if (null != cloneFrom)
                    return cloneFrom.PageSize;
                object obj = ViewState["PageSize"];
                return (obj == null) ? 10 : (int)obj;
            }
            set
            {
                ViewState["PageSize"] = value;
            }
        }
        /// <summary>
        /// 页总数
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageCount
        {
            get
            {
                if (RecordCount == 0)
                    return 0;
                return (int)Math.Ceiling((double)RecordCount / (double)PageSize);
            }
        }
        /// <summary>
        /// 记录总数
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RecordCount
        {
            get
            {
                if (null != cloneFrom)
                    return cloneFrom.RecordCount;
                object obj = ViewState["Recordcount"];
                return (obj == null) ? 0 : (int)obj;
            }
            set { ViewState["Recordcount"] = value; }
        }
        /// <summary>
        /// 当前页的记录起始索引(编号)
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StartRecordIndex
        {
            get
            {

                return (CurrentPageIndex - 1) * PageSize + 1;
            }
        }
        /// <summary>
        /// 当前页的记录的结束索引(编号)
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EndRecordIndex
        {
            get
            {
                return RecordCount - RecordsRemain;
            }
        }

        /// <summary>
        /// 要克隆的控件的ID
        /// </summary>
        [DefaultValue(""), Bindable(false), Themeable(false), Category("Appearance"), Description("要克隆的控件的ID")]
        public string CloneControlID
        {
            get
            {
                return ViewState["CloneControlID"] as string;
            }
            set
            {
                if (null != value && String.Empty == value.Trim())
                    throw new ArgumentNullException("CloneControlID", "The Value of property CloneFrom can not be empty string!");
                if (ID.Equals(value, StringComparison.OrdinalIgnoreCase))
                    throw new ArgumentException("The property value of CloneControlID can not be set to control itself!", "CloneControlID");
                ViewState["CloneControlID"] = value;
            }
        }
        /// <summary>
        /// 剩余记录
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int RecordsRemain
        {
            get
            {
                if (CurrentPageIndex < PageCount)
                    return RecordCount - (CurrentPageIndex * PageSize);
                return 0;
            }
        }
        /// <summary>
        /// 剩余页数，总页面数减去当前页索引
        /// </summary>
       [ Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int PagesRemain
        {
            get
            {
                return PageCount - CurrentPageIndex;
            }
        }
        #endregion

        #region 事件和委托
        private static readonly object EventPageChanged = new object();
        public event EventHandler PageChanged
        {
            add
            {
                Events.AddHandler(EventPageChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventPageChanged, value);
            }
        }
        #endregion

        /// <summary>
        /// 引发事件的方法
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPageChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventPageChanged];
            if (handler != null)
                handler(this, e);
        }
        /// <summary>
        /// 点击命令按钮事件时的事件冒泡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        protected override bool OnBubbleEvent(object sender, EventArgs e)
        {
            bool flag = false;

            if (e is CommandEventArgs)
            {
                CommandEventArgs ce = e as CommandEventArgs;
                switch (ce.CommandName)
                {
                    case "lbtnFirstPage":
                        if (cloneFrom != null)
                        {
                            cloneFrom.CurrentPageIndex = 1;
                            cloneFrom.OnPageChanged(EventArgs.Empty);
                        }
                        else
                        {
                            CurrentPageIndex = 1;
                            OnPageChanged(EventArgs.Empty);
                        }
                        break;
                    case "lbtnPrevPage":
                        if (cloneFrom != null)
                        {
                            cloneFrom.CurrentPageIndex = CurrentPageIndex - 1;
                            cloneFrom.OnPageChanged(EventArgs.Empty);
                        }
                        else
                        {
                            CurrentPageIndex = CurrentPageIndex - 1;
                            OnPageChanged(EventArgs.Empty);
                        }
                        break;
                    case "lbtnNextPage":
                        if (cloneFrom != null)
                        {
                            cloneFrom.CurrentPageIndex = CurrentPageIndex + 1;
                            cloneFrom.OnPageChanged(EventArgs.Empty);
                        }
                        else
                        {
                            CurrentPageIndex = CurrentPageIndex + 1;
                            OnPageChanged(EventArgs.Empty);
                        }
 
                        break;
                    case "lbtnLastPage":
                        if (cloneFrom != null)
                        {
                            cloneFrom.CurrentPageIndex = PageCount;
                            cloneFrom.OnPageChanged(EventArgs.Empty);
                        }
                        else
                        {
                            CurrentPageIndex = PageCount;
                            OnPageChanged(EventArgs.Empty);
                        }
                        break;
                    case "lbtnGoToPage":
                        string str =Page.Request.Form[UniqueID + "$txtCurrentPageIndex"];
                        if (str == null || str.Trim() == string.Empty || !isDigit.IsMatch(str.Trim()))
                            break;
                        else
                        {
                            int pindex = int.Parse(str.Trim());
                            if (pindex > 0 && pindex <= PageCount)
                            {
                                if (cloneFrom != null)
                                {
                                    cloneFrom. CurrentPageIndex = pindex;
                                    cloneFrom.OnPageChanged(EventArgs.Empty);
                                }
                                else
                                {
                                   CurrentPageIndex = pindex;
                                   OnPageChanged(EventArgs.Empty);
                                }
                            }
                        }
                        break;
                }
                flag = true;
            }
            this.RaiseBubbleEvent(sender, e);
            return flag;
        }
        /// <summary>
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            CreateInternalControls();
            ChildControlsCreated = true;
            //base.CreateChildControls();
        }
        /// <summary>
        /// 内部创建子控件
        /// </summary>
        private void CreateInternalControls()
        {
            lbtnFirstPage = new LinkButton();
            lbtnFirstPage.Text = "首页";
            lbtnFirstPage.ID = "lbtnFirstPage";
            lbtnFirstPage.CommandName = "lbtnFirstPage";
            this.Controls.Add(lbtnFirstPage);

            lbtnPrevPage = new LinkButton();
            lbtnPrevPage.Text = "上一页";
            lbtnPrevPage.ID = "lbtnPrevPage";
            lbtnPrevPage.CommandName = "lbtnPrevPage";
            this.Controls.Add(lbtnPrevPage);

            lbtnNextPage = new LinkButton();
            lbtnNextPage.Text = "下一页";
            lbtnNextPage.ID = "lbtnNextPage";
            lbtnNextPage.CommandName = "lbtnNextPage";
            this.Controls.Add(lbtnNextPage);
           
            lbtnLastPage = new LinkButton();
            lbtnLastPage.Text = "末页";
            lbtnLastPage.ID = "lbtnLastPage";
            lbtnLastPage.CommandName = "lbtnLastPage";
            this.Controls.Add(lbtnLastPage);

            lbtnGoToPage = new LinkButton();
            lbtnGoToPage.Text = "跳转";
            lbtnGoToPage.ID = "lbtnGoToPage";
            lbtnGoToPage.CommandName = "lbtnGoToPage";
            this.Controls.Add(lbtnGoToPage);

            txtCurrentPageIndex = new TextBox();
            txtCurrentPageIndex.ID = "txtCurrentPageIndex";
            this.Controls.Add(txtCurrentPageIndex);

            ltlPageCount = new Literal();
            ltlPageCount.ID = "ltlPageCount";
            this.Controls.Add(ltlPageCount);

            lblPageCount = new Label();
            lblPageCount.ID = "lblPageCount";
            this.Controls.Add(lblPageCount);

            lblCurrentPageIndex = new Label();
            lblCurrentPageIndex.ID = "lblCurrentPageIndex";
            this.Controls.Add(lblCurrentPageIndex);

        }
        /// <summary>
        /// 查看是否指定了克隆控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (null != CloneControlID && string.Empty != CloneControlID.Trim())
            {
                VIPPager ctrl = Parent.FindControl(CloneControlID) as VIPPager;
                if (null == ctrl)
                {

                    throw new ArgumentException(@"The control \" + CloneControlID + "\"does not exist or is not of type VIPPager!", "CloneControlID");
                }
                if (null != ctrl.cloneFrom && this == ctrl.cloneFrom)
                {

                    throw new ArgumentException("Invalid value for the CloneControlID property, VIPPager controls can not to be cloned recursively!", "CloneControlID");
                }
                cloneFrom = ctrl;
            }
        }

        /// <summary>
        /// 呈现
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            lbtnGoToPage.Enabled = PageCount != 1 && PageCount != 0;
            lbtnPrevPage.Enabled = lbtnFirstPage.Enabled = CurrentPageIndex != 1;
            lbtnLastPage.Enabled = lbtnNextPage.Enabled = CurrentPageIndex != PageCount && PageCount != 0;
            //显示总页数
            ltlPageCount.Text = "/" + PageCount.ToString();
            lblPageCount.Text = "共"+PageCount+"页";
           
            txtCurrentPageIndex.Text =  CurrentPageIndex.ToString();
            lblCurrentPageIndex.Text = "第"+CurrentPageIndex+"页";

            lblPageCount.RenderControl(writer);
            lbtnFirstPage.RenderControl(writer);
            lbtnPrevPage.RenderControl(writer);
            lblCurrentPageIndex.RenderControl(writer);
            lbtnNextPage.RenderControl(writer);
            lbtnLastPage.RenderControl(writer);
            txtCurrentPageIndex.RenderControl(writer);
            ltlPageCount.RenderControl(writer);
            lbtnGoToPage.RenderControl(writer);

        }
    }
}
