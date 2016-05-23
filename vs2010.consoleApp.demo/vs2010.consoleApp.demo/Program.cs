using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vs2010.consoleApp.demo
{
    class Program
    {
        static void Main(string[] args)
        {
            localhost.HelloWorld service = new localhost.HelloWorld();
            service.RequestSOAPHeader = new RequestSOAPHeader();
            service.RequestSOAPHeader.user = "user";
            service.RequestSOAPHeader.password = "abcd";
            service.sayHi("abc");
        }
    }
}
