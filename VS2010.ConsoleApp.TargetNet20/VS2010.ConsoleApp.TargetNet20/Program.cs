using System;
using System.Collections.Generic;
using System.Text;

namespace VS2010.ConsoleApp.TargetNet20
{
    /// <summary>
    /// 直接运行在donet20运行时上，不需要配置文件，配置文件只是当donet40和donet20共同存在时才是必要的
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ok");
            Console.Read();
        }
    }
}
