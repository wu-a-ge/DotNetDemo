using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
namespace VS2008.WebForm.LocalizeAndGlobalize
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //使用强类型后达不到全球化根据语言文化去提取相应的资源
            //想要到达全球化能够根据客户的语言进行查找相应的资源，应该使用字符串查找方法
            //下面的方法只能在当前项目的App_GlobalResources文件夹中进行查找。
            //Label3.Text = GetGlobalResourceObject("CurrentResource", "CurrentPrivacy").ToString();
            //另一种外部引用方法，可以灵活多变的方式
            Label2.Text = VS2008.WebForm.Resources.SR.GetString("PrivacyStatement1");

        }
    }
}
