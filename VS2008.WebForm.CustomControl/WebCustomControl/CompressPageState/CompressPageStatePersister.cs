using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace KingControls
{
    /// <summary>
    /// Author: 【夜战鹰】【专注于DotNet技术】【ChengKing(ZhengJian)】
    /// 获得本书的更多章节:【http://blog.csdn.net/ChengKing/archive/2008/08/18/2792440.aspx】
    /// 声明: 【本链接为进阶Asp.net技术的一些文章】【转载时请保留本链接源】
    /// </summary>
    public class CompressPageStatePersister : PageStatePersister
    {
        //页面状态保存在页面中的字段名
        private string PageStateKey = "____VIEWSTATE";
        public CompressPageStatePersister(Page page) : base(page)
        {
        }
        public override void Load()
        {
            //取得保存到客户端的状态内容
            string postbackState = Page.Request.Form[PageStateKey];
            if (!string.IsNullOrEmpty(postbackState))
            {
                //页面状态包括视图状态和控件状态两部分
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
