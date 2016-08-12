using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.Script.Serialization;
//using UtilityLib;
namespace VS2008.WebForm.AjaxFileUpload
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Handler1 : IHttpHandler
    {
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public void ProcessRequest(HttpContext context)
        {
            HttpFileCollection files = context.Request.Files;
            
            if(files.Count!=0)
            {
                try
                {
                    HttpPostedFile file = files[0];
                    using (StreamReader reader = new StreamReader(file.InputStream,Encoding.GetEncoding("GB2312")))
                    {
                        StringCollection result = new StringCollection();
                        string nextLine ;
                        while((nextLine=reader.ReadLine())!=null)
                        {
                            result.Add(nextLine);
                        }
                        string[] lines = new string[result.Count];
                        result.CopyTo(lines, 0);

                    }
                    //file.SaveAs(context.Server.MapPath("/") + "temp\\" + file.FileName);
                }
                catch(Exception e)
                {

                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sb.AppendLine("<result>");
                sb.AppendLine("<p>successful</p>");
                sb.AppendLine("</result>");
                context.Response.Write(sb.ToString());
                //context.Response.Write(jss.Serialize(new { error = "", msg = "has file successfull" }));
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
