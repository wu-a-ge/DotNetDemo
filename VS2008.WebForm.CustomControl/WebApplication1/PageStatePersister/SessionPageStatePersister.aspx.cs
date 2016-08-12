using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

/// <summary>
/// 在App_Browser下面的SessionPageAdapter.browser也可以起到相同的功能
/// </summary>
public partial class F_Chapter6_PageStatePersister_SessionPageStatePersister : System.Web.UI.Page
{
    protected override PageStatePersister PageStatePersister
    {
        get
        {
            return new SessionPageStatePersister(this);
        }
    }    

    string strPicXiaoLian = "<Img src='" + "..\\Images\\XL.jpg" + "' /> ";
    string strPicJuSang = "<Img src='" + "..\\Images\\JS.jpg" + "' /> ";
    string strPicBG = "<Img src='" + "..\\Images\\BG.jpg" + "' /> ";
    private Color c = Color.FromName("#C0C0FE");
    protected void Page_Load(object sender, EventArgs e)
    {
        //禁用页面控件状态测试
        //Page.EnableViewState = false;

        //或禁用控件控件状态测试
        //this.ControlStateControl1.EnableViewState = false;
    }
    protected void btnSetProperty_Click(object sender, EventArgs e)
    {
        ///设置没有用控件状态存储的属性值
        this.ControlStateControl1.Text_NoViewState = "我没有用任何控件状态存储!";

        ///设置用ViewState存储的属性值
        this.ControlStateControl1.Text_ViewState = "我是用ViewState容器存储的!";

        //设置用自定义控件状态存储的属性值
        this.ControlStateControl1.FaceStyle.OK = true;
        this.ControlStateControl1.FaceStyle.BackColor = c;
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        /// <summary>
        /// ViewState容器存储测试--测试存储ControlStateControl1.Text_NoViewState属性
        /// </summary>
        if (this.ControlStateControl1.Text_NoViewState == "我没有使用控件状态存储!")
        {
            this.lbDisplay.Text = "this.ControlStateControl1.Text_NoViewState属性 已经保存了控件状态 " + strPicXiaoLian + " <br><br>";
        }
        else
        {
            this.lbDisplay.Text = "this.ControlStateControl1.Text_NoViewState属性 没有保存控件状态 " + strPicJuSang + " <br><br>";
        }


        /// <summary>
        /// ViewState容器存储测试--测试存储ControlStateControl1.Text_ViewState属性
        /// </summary>
        if (this.ControlStateControl1.Text_ViewState == "我是用ViewState容器存储的!")
        {
            this.lbDisplay.Text += "this.ControlStateControl1.Text_ViewState属性 已经保存了控件状态 " + strPicXiaoLian + " <br><br>";
        }
        else
        {
            this.lbDisplay.Text += "this.ControlStateControl1.Text_ViewState属性 没有保存控件状态 " + strPicJuSang + " <br><br>";
        }


        /// <summary>
        /// 自定义控件状态测试--测试存储类ControlStateControl1.FaceStyle的内部属性OK
        /// </summary>
        if (this.ControlStateControl1.FaceStyle.OK == true)
        {
            this.lbDisplay.Text += "this.ControlStateControl1.FaceStyle属性.OK 已经保存了控件状态 " + strPicXiaoLian + " <br><br>";
        }
        else
        {
            this.lbDisplay.Text += "this.ControlStateControl1.FaceStyle属性.OK 没有保存控件状态 " + strPicJuSang + " <br><br>";
        }


        /// <summary>
        /// 自定义控件状态测试--测试存储类ControlStateControl1.FaceStyle的基类TableItemStyle中的属性BackColor
        /// </summary>
        if (this.ControlStateControl1.FaceStyle.BackColor.Equals(c))
        {
            this.lbDisplay.Text += "this.ControlStateControl1.FaceStyle.BackColor 已经保存了控件状态, 瞧，我的颜色就是保存的颜色 " + strPicXiaoLian + " " + strPicBG + "<br><br>";
            //this.lbDisplay.BackColor = c;
        }
        else
        {
            this.lbDisplay.Text += "this.ControlStateControl1.FaceStyle.BackColor 没有保存控件状态, 瞧，我的颜色还是白色 " + strPicJuSang + " <br><br>";
        }
    }
}
