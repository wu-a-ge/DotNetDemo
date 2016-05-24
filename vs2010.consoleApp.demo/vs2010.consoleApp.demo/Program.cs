using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using vs2010.consoleApp.demo.localhost;
namespace vs2010.consoleApp.demo
{
    class Program
    {
        static void Main(string[] args)
        {
           localhost.ReaderInfoService service=new ReaderInfoService();
           service.RequestSoapHeader = new RequestSOAPHeader(); ;
            service.RequestSoapHeader.username = "test";
            service.RequestSoapHeader.password = "test";
            service.getListsByIds("a12340", "reader_number");
        }
    }
}
