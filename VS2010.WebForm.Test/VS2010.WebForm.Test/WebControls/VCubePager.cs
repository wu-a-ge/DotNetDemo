using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace VS2010.WebForm.Test.WebControls
{
    /// <summary>
    /// 必须为属性PageSize和RecordCount赋值，其它属性值通过计算得出
    /// 事件PageChanged，是给分页后重新绑定页面数据使用
    /// </summary>
    [DefaultProperty("PageSize")]
    [DefaultEvent("PageChanged")]
    [ToolboxData("<{0}:VCubePager runat=server></{0}:VCubePager>")]
    public class VCubePager : CompositeControl
    {
        #region 字段
        private int startPage;// 显示的第一页的页码
        private int endPage;// 显示的最末页的页码
        private bool showPrevious = false;//是否显示首页和第一页
        private bool showNext = false;//是否显示下一页和末页
        private bool showOuterDiv = false;//是否显示外层div
        private int previousPageCount=5;
        private int afterPageCount = 4;
        private int pageSize = 10;//每页记录数
        private LinkButton lbtnFirstPage;
        private LinkButton lbtnPrevPage;
        private LinkButton lbtnNextPage;
        private LinkButton lbtnLastPage;
        private Button btnGoToPage;
        private Literal ltlPageCount;
        private TextBox txtCurrentPageIndex;
        //客户端脚本
        private const string ValidateScript = @"function vipClientPager_CheckInput(id,pageCount){var el=document.getElementById(id);var r=new RegExp('^\\s*(\\d+)\\s*$');if(r.test(el.value)){if(RegExp.$1<1||RegExp.$1>pageCount){alert('页索引超出范围！');el.focus();el.select();return false;}return true;} else {alert('页索引不是有效的数值！');el.focus();el.select();return false;}return true;}";
        private const string EnterScript = "function vipClientPager_Keydown(e,btnId){var kcode;if(window.event){kcode=e.keyCode;}else if(e.which){kcode=e.which;}var validKey=(kcode==8||kcode==46||kcode==37||kcode==39||(kcode>=48&&kcode<=57)||(kcode>=96&&kcode<=105));if(!validKey){if(kcode==13) document.getElementById(btnId).click();if(e.preventDefault) e.preventDefault();else{event.returnValue=false};}}";
        private readonly static Regex isDigit = new Regex(@"\d+", RegexOptions.Compiled);
        #endregion

        #region 属性
        /// <summary>
        /// 是否在分页代码外面加DIV，默认不添加
        /// </summary>
        [DefaultValue(false), Browsable(true), Category("Appearance")]
        public bool ShowOuterDiv
        {
            get  {  return showOuterDiv;}
            set { showOuterDiv = value; }
        }
        /// <summary>
        /// 前页之前可以显示的最多链接数，大于此条链接将被隐藏
        /// </summary>
        [DefaultValue(5),Browsable(true),Category("Appearance")]
        public int PreviousPageCount
        {
            get {
                return previousPageCount;
            }
            set { previousPageCount = value; }
        }
        /// <summary>
        /// 当前页之后可以显示的最多链接数，大于此条链接将被隐藏
        /// </summary>
        [DefaultValue(4), Browsable(true), Category("Appearance")]
        public int AfterPageCount
        {
            get
            {
                return afterPageCount;
            }
            set { afterPageCount = value; }
        }
        /// <summary>
        /// 当前页索引，默认值为1，只有它使用了视图
        /// </summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPageIndex
        {
            get
            {

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
            get { return pageSize; }
            set { pageSize = value; }
        }
        /// <summary>
        /// 记录总数
        /// </summary>
        [Category("Appearance"), Description("总记录数")]
        public int RecordCount
        {
            get;
            set;
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
        /// 当前页的记录起始索引(编号),起始值为1
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
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected int PagesRemain
        {
            get
            {
                return PageCount - CurrentPageIndex;
            }
        }
        #endregion

        #region 事件
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
        /// 创建子控件
        /// </summary>
        protected override void CreateChildControls()
        {
            this.Controls.Clear();
            CreateInternalControls();
            ChildControlsCreated = true;
        }

        private void CreateInternalControls()
        {
            int count = PreviousPageCount + AfterPageCount + 1;

            for (int i = 0; i < count; i++)
            {
                LinkButton lbtnPageIndex = new LinkButton();
                lbtnPageIndex.CommandName = "lbtnPageIndex";
                this.Controls.Add(lbtnPageIndex);
            }
            ltlPageCount = new Literal();
            ltlPageCount.ID = "ltlPageCount";
            this.Controls.Add(ltlPageCount);

            lbtnFirstPage = new LinkButton();
            lbtnFirstPage.Text = "首页";
            //lbtnFirstPage.ID = "lbtnFirstPage";
            lbtnFirstPage.CommandName = "lbtnFirstPage";
            this.Controls.Add(lbtnFirstPage);

            lbtnPrevPage = new LinkButton();
            lbtnPrevPage.Text = "上一页";
            //lbtnPrevPage.ID = "lbtnPrevPage";
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

            btnGoToPage = new Button();
            btnGoToPage.Text = "跳转";
            btnGoToPage.CssClass = "btn";
            btnGoToPage.ID = "btnGoToPage";
            btnGoToPage.CommandName = "btnGoToPage";
            this.Controls.Add(btnGoToPage);

            txtCurrentPageIndex = new TextBox();
            txtCurrentPageIndex.ClientIDMode = ClientIDMode.Static;
            txtCurrentPageIndex.ID = "txtCurrentPageIndex";
            txtCurrentPageIndex.CssClass = "pinput";
            txtCurrentPageIndex.Columns = 5;
            this.Controls.Add(txtCurrentPageIndex);

        }
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
                        CurrentPageIndex = 1;
                        OnPageChanged(EventArgs.Empty);
                        break;
                    case "lbtnPrevPage":
                        CurrentPageIndex = CurrentPageIndex - 1;
                        OnPageChanged(EventArgs.Empty);
                        break;
                    case "lbtnPageIndex":
                        LinkButton lbtnPageIndex = sender as LinkButton;
                        CurrentPageIndex = int.Parse(lbtnPageIndex.CommandArgument);
                        OnPageChanged(EventArgs.Empty);
                        break;
                    case "lbtnNextPage":
                        CurrentPageIndex = CurrentPageIndex + 1;
                        OnPageChanged(EventArgs.Empty);
                        break;
                    case "lbtnLastPage":
                        CurrentPageIndex = PageCount;
                        OnPageChanged(EventArgs.Empty);
                        break;
                    case "btnGoToPage":
                        string str = Page.Request.Form[UniqueID+ "$txtCurrentPageIndex"];
                        if (str == null || str.Trim() == string.Empty || !isDigit.IsMatch(str.Trim()))
                            break;
                        else
                        {
                            int pindex = int.Parse(str.Trim());
                            if (pindex > 0 && pindex <= PageCount)
                            {
                                CurrentPageIndex = pindex;
                                OnPageChanged(EventArgs.Empty);

                            }
                        }
                        break;
                }
                flag = true;
            }
            this.RaiseBubbleEvent(sender, e);
            return flag;
        }
        protected override void OnPreRender(EventArgs e)
        {
            SetStartPage();
            SetEndPage();
            int j = 0;
            for (int i = startPage; i <= endPage; i++)
            {
                LinkButton lbtnPageIndex = this.Controls[j] as LinkButton;
                lbtnPageIndex.CommandArgument = lbtnPageIndex.Text = i.ToString();
                j++;
            }
            base.OnPreRender(e);
        }
        /// <summary>
        /// 呈现
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (ShowOuterDiv)
            {
                if (!string.IsNullOrEmpty(this.CssClass))
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
                writer.RenderBeginTag(HtmlTextWriterTag.Div);
            }
            EnsureControlEnabled();
            //开始呈现按钮
            RenderPageCount(writer);
            RenderHrefPage(writer);
            RenderTextBoxAndGoToPage(writer);
            if (ShowOuterDiv)
                writer.RenderEndTag();
        }
        /// <summary>
        /// 根据按钮的可用性设置样式
        /// </summary>
        private void EnsureControlEnabled()
        {
            //各个按钮是否可用
            btnGoToPage.Enabled = PageCount != 1 && PageCount != 0;
            if (!btnGoToPage.Enabled)
                btnGoToPage.Style[HtmlTextWriterStyle.Color] = "gray";
            lbtnLastPage.Enabled = lbtnNextPage.Enabled = CurrentPageIndex != PageCount && PageCount != 0;
            if (!lbtnLastPage.Enabled && !lbtnNextPage.Enabled)
            {
                lbtnNextPage.Style[HtmlTextWriterStyle.Color] = lbtnLastPage.Style[HtmlTextWriterStyle.Color] = "gray";
            }
        }
        /// <summary>
        /// 显示页总数
        /// </summary>
        /// <param name="writer"></param>
        private void RenderPageCount(HtmlTextWriter writer)
        {
            ltlPageCount.Text = "共" + PageCount + "页";
            ltlPageCount.RenderControl(writer);
            writer.Write("&nbsp;");
        }
        /// <summary>
        /// 呈现首页和前一页链接
        /// </summary>
        /// <param name="writer"></param>
        private void RenderFirstAndPreviousLink(HtmlTextWriter writer)
        {
            lbtnFirstPage.RenderControl(writer);
            writer.Write("&nbsp");
            lbtnPrevPage.RenderControl(writer);

        }
        /// <summary>
        /// 循环输出每页超链接
        /// </summary>
        /// <param name="writer"></param>
        private void RenderHrefPage(HtmlTextWriter writer)
        {
          
            if (showPrevious)// 如果需要显示前一页、第一页链接
                RenderFirstAndPreviousLink(writer);
            // 循环打印链接
            int j = 0;
            for (int i = startPage; i <= endPage; i++)
            {

                LinkButton lbtnPageIndex = this.Controls[j] as LinkButton;
                if (i == CurrentPageIndex)
                {
                    lbtnPageIndex.Style[HtmlTextWriterStyle.Color] = "gray";
                    lbtnPageIndex.Enabled = false;
                }
                lbtnPageIndex.RenderControl(writer);
                if (i == endPage && showNext)// 如果需要显示 下一页、最末页 链接
                    RenderNextAndEndLink(writer);
                j++;
            }
        }
        /// <summary>
        /// 呈现后一面和末页
        /// </summary>
        /// <param name="writer"></param>
        private void RenderNextAndEndLink(HtmlTextWriter writer)
        {
            lbtnNextPage.RenderControl(writer);
            writer.Write("&nbsp");
            lbtnLastPage.RenderControl(writer);
        }
        /// <summary>
        /// 呈现文本框和跳转按钮
        /// </summary>
        /// <param name="writer"></param>
        private void RenderTextBoxAndGoToPage(HtmlTextWriter writer)
        {
            //文本框中显示当前第几页
            txtCurrentPageIndex.Text = CurrentPageIndex.ToString();
            txtCurrentPageIndex.RenderControl(writer);
            btnGoToPage.RenderControl(writer);
        }
        /// <summary>
        /// 根据当前页，当前页之前可以显示的页数，算得从第几页开始进行显示
        /// </summary>
        private void SetStartPage()
        {
            // 如果当前页小于它前面所可以显示的条目数，
            // 那么显示第一页就是实际的第一页
            if (CurrentPageIndex <= PreviousPageCount)
            {
                startPage = 1;
            }
            else
            // 这种情况下 currentPage 前面总是能显示完，
            // 要根据后面的长短确定是不是前面应该多显示
            {
                if (CurrentPageIndex > PreviousPageCount + 1)
                    showPrevious = true;
                int linkLength = (PageCount - CurrentPageIndex + 1) + PreviousPageCount;
                int startPage = CurrentPageIndex - PreviousPageCount;
                while (linkLength < PreviousPageCount + AfterPageCount + 1 && startPage > 1)
                {
                    linkLength++;
                    startPage--;
                }
                this.startPage = startPage;
            }
        }
        /// <summary>
        ///根据CurrentPage、总页数、当前页之后长度 算得显示的最末页是 第几页
        /// </summary>
        private void SetEndPage()
        {
            // 如果当前页加上它之后可以显示的页数 大于 总页数，
            // 那么显示的最末页就是实际的最末页
            if (CurrentPageIndex + AfterPageCount >= PageCount)
            {
                endPage = PageCount;
            }
            else
            {
                // 这种情况下 currentPage后面的总是可以显示完，
                // 要根据前面的长短确定是不是后面应该多显示
                int linkLength = (CurrentPageIndex - startPage + 1) + AfterPageCount;
                int endPage = CurrentPageIndex + AfterPageCount;
                while (linkLength < PreviousPageCount + AfterPageCount + 1 && endPage < PageCount)
                {
                    linkLength++;
                    endPage++;
                }
                if (endPage < PageCount)
                    showNext = true;
                this.endPage = endPage;
            }
        }
    }
}
