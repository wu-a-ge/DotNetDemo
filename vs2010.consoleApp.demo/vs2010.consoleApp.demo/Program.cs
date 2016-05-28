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

            ExportAccess.Export(args[0],Int32.Parse(args[1]));

        }
    }
}
