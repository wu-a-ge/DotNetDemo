using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class TestPageAdapter : System.Web.UI.Page
    {
        [SubmitMethod(AutoRedirect = false)]
        public void OnLoginName()
        {

        }
        /// <summary>
        /// 此方法重写不了配器中的onload方法
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {

            //base.OnLoad(e);
        }
    }
}