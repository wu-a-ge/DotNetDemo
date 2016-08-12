using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace WebApplication1
{
    public partial class _Default : BasePage
    {
        string strPicXiaoLian = "<Img src='" + "Images\\XL.jpg" + "' /> ";
        string strPicJuSang = "<Img src='" + "Images\\JS.jpg" + "' /> ";
        string strPicBG = "<Img src='" + "Images\\BG.jpg" + "' /> ";
        private Color c = Color.FromName("#C0C0FE");
        //protected void page_preInit(object sender, EventArgs e)
        //{
        
        //}

        protected void Page_Init(object sender, EventArgs e)
        {
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            foreach(string str in Request.Form)
            {

            }
            //禁用页面视图状态测试
            //Page.EnableViewState = false;

            //或禁用控件视图状态测试
            //this.ViewStateControl1.EnableViewState = false;


            //加密视图
            //Page.ViewStateEncryptionMode = ViewStateEncryptionMode.Auto;
            //Page.RegisterRequiresViewStateEncryption();
        }
        protected void btnSetProperty_Click(object sender, EventArgs e)
        {
            ///设置没有用视图状态存储的属性值
            this.ViewStateControl1.Text_NoViewState = "我没有用任何视图状态存储!";

            ///设置用ViewState存储的属性值
            this.ViewStateControl1.Text_ViewState = "我是用ViewState容器存储的!";

            //设置用自定义视图状态存储的属性值
            this.ViewStateControl1.FaceStyle.OK = true;
            this.ViewStateControl1.FaceStyle.BackColor = c;
        }
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// ViewState容器存储测试--测试存储ViewStateControl1.Text_NoViewState属性
            /// </summary>
            if (this.ViewStateControl1.Text_NoViewState == "我没有用任何视图状态存储!")
            {
                this.lbDisplay.Text = "this.ViewStateControl1.Text_NoViewState属性 已经保存了视图状态 " + strPicXiaoLian + " <br><br>";
            }
            else
            {
                this.lbDisplay.Text = "this.ViewStateControl1.Text_NoViewState属性 没有保存视图状态 " + strPicJuSang + " <br><br>";
            }


            /// <summary>
            /// ViewState容器存储测试--测试存储ViewStateControl1.Text_ViewState属性
            /// </summary>
            if (this.ViewStateControl1.Text_ViewState == "我是用ViewState容器存储的!")
            {
                this.lbDisplay.Text += "this.ViewStateControl1.Text_ViewState属性 已经保存了视图状态 " + strPicXiaoLian + " <br><br>";
            }
            else
            {
                this.lbDisplay.Text += "this.ViewStateControl1.Text_ViewState属性 没有保存视图状态 " + strPicJuSang + " <br><br>";
            }


            /// <summary>
            /// 自定义视图状态测试--测试存储类ViewStateControl1.FaceStyle的内部属性OK
            /// </summary>
            if (this.ViewStateControl1.FaceStyle.OK == true)
            {
                this.lbDisplay.Text += "this.ViewStateControl1.FaceStyle属性.OK 已经保存了视图状态 " + strPicXiaoLian + " <br><br>";
            }
            else
            {
                this.lbDisplay.Text += "this.ViewStateControl1.FaceStyle属性.OK 没有保存视图状态 " + strPicJuSang + " <br><br>";
            }


            /// <summary>
            /// 自定义视图状态测试--测试存储类ViewStateControl1.FaceStyle的基类TableItemStyle中的属性BackColor
            /// </summary>
            if (this.ViewStateControl1.FaceStyle.BackColor.Equals(c))
            {
                this.lbDisplay.Text += "this.ViewStateControl1.FaceStyle.BackColor 已经保存了视图状态, 瞧，我的颜色就是保存的颜色 " + strPicXiaoLian + " " + strPicBG + "<br><br>";
                //this.lbDisplay.BackColor = c;
            }
            else
            {
                this.lbDisplay.Text += "this.ViewStateControl1.FaceStyle.BackColor 没有保存视图状态, 瞧，我的颜色还是白色 " + strPicJuSang + " <br><br>";
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
          string tt=   DataBinder.GetPropertyValue(e.Item.DataItem, "UserGroupName").ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_PreRender(object sender, EventArgs e)
        {

        }

 


       
  
    }
}
