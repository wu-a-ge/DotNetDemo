using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Compilation;
namespace VS2010.WebForm.ModuleAndHandler
{
    public class HttpHandlerFactory:IHttpHandlerFactory
    {
        #region IHttpHandlerFactory 成员

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {

            IHttpHandler handler = BuildManager.CreateInstanceFromVirtualPath(url, typeof(IHttpHandler)) as IHttpHandler;
            //返回
            return handler;
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
           
        }

        #endregion
    }
}