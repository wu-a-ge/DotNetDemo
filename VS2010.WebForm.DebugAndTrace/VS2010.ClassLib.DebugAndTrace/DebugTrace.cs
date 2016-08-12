using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
namespace VS2010.ClassLib.DebugAndTrace
{
    public class DebugTrace
    {
        [Conditional("test1")]
        public static  void TestDebug()
        {
            Console.WriteLine("Debug");
            Debug.Write("Debug");
            Trace.Write("Trace");
        }
        [Conditional("test2")]
        public static void TestTrace()
        {
            Console.WriteLine("Trace");
            Debug.Write("Debug");
            Trace.Write("Trace");
        }
        public static void TestOutPut()
        {
            //TestDebug();
            //TestTrace();
            Debug.Write("Debug\r\n OK");
            Trace.Write("Trace");
        }
    }
}
