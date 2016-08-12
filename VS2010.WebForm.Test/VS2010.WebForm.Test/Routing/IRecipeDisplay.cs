using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace VS2010.WebForm.Test
{
   public  class IRecipeDisplay:IHttpHandler
    {
        public string RecipeName { get; set; }

        public bool IsReusable
        {
            get { throw new NotImplementedException(); }
        }

        public void ProcessRequest(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }
}
