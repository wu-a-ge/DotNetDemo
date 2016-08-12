using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace VS2008.WebForm.HealthMonitoring
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
  
                AttemptingToLogIntoLockedAccountEvent lockedOutEvent =
                  new AttemptingToLogIntoLockedAccountEvent("被锁定的用户试图登录！！！", this, "xiaofu");

                lockedOutEvent.Raise();
            
        }


    }
}
