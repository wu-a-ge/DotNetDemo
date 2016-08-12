using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class TestHandlerFactory:IHttpHandlerFactory
    {

        #region IHttpHandlerFactory 成员

        public IHttpHandler GetHandler(HttpContext context, string requestType, string url, string pathTranslated)
        {
          return   PageParser.GetCompiledPageInstance(url, pathTranslated, context);
        }

        public void ReleaseHandler(IHttpHandler handler)
        {
             
        }

        #endregion
    }
}
