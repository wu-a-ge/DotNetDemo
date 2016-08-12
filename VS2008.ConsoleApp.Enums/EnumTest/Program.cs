using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EnumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = SourceEnum.ColorTest.White;

            if (SourceEnum.ColorTest.Red == t)
            {
                Console.WriteLine("ok");
            }
            Console.Read();
        }
    }
}
