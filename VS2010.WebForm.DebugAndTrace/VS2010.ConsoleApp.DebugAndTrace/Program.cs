using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using VS2010.ClassLib.DebugAndTrace;
namespace VS2010.ConsoleApp.DebugAndTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            //编译器在编译的时候如果是TRACE模式，DEBUG的代码被删除
            //DEUBG模式下两行代码都调用，因为默认项目属性中的DEBUG模式选中了DEBUG和TRACE条件编译符号
            Debug.Write("ok");
            Trace.Write("ii");
            
            Console.Read();
        }
    }
}
