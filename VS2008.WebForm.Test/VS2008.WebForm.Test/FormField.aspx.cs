using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2008.WebForm.Test
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            img1.Alt = "img1";
            img1.Src = "http://www.google.com/logos/2011/Googles_13th_Birthday-2011-hp.jpg";
            href1.HRef = "www.baidu.com";
            div1.InnerText = "div1";
            txt1.Value = "txt1";
            tarea1.Value = "tarea1";
            hfld1.Value = "hfld1";
            chk1.Checked = true;
            chk1.Value = "1";
            rad1.Checked = true;
            rad1.Value = "1";

        }
        protected void button_click(object sender, EventArgs arg)
        {

        }
    }
}

     

