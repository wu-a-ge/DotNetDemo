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
           ReaderInfoService service=new ReaderInfoService();
            service.RequestSOAPHeader=new RequestSOAPHeader();
            service.RequestSOAPHeader.user = "root";
            service.RequestSOAPHeader.password="root";
            //service.getListsByIds("A1234", "is_active");
            service.getUserInfo("abc", "1234");
        }
    }
}
