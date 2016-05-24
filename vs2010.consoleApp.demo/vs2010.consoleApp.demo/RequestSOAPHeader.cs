using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vs2010.consoleApp.demo
{
    public class RequestSOAPHeader : System.Web.Services.Protocols.SoapHeader
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
