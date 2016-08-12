using System.IO;
using System.Web;
using System.Web.UI;

namespace VS2010.WebForm.Test.RequestUserControl
{
    internal  class UserControlManager
    {

        public static UserControl LoadControl(string path)
        {
            Page m_pageHolder = new Page();
            return (UserControl)m_pageHolder.LoadControl(path);
        }

        public static  string RenderControl(UserControl control)
        {
            StringWriter output = new StringWriter();
            Page m_pageHolder = new Page();
            m_pageHolder.Controls.Add(control);
            HttpContext.Current.Server.Execute(m_pageHolder, output, true);
            return output.ToString();
        }
    }
}
