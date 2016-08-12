using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FSM.DotNetSSH;
namespace VS2008.WebForm.AjaxFileUpload
{
    public partial class SftpFileUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = Request.Files[0];
              SshTransferProtocolBase sshCp=new Sftp("127.0.0.1","test","test");
              sshCp.Connect();
            sshCp.put(new UploadFileStream(file.InputStream),"test.txt");
        }
 
}
    
}
