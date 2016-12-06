using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VS2010.ConsoleApp.Test
{
    public class A
    {

        private static string a_str = "a_str";
        private static int  a_int;
        private int ta = 1;

        static A()
        {
            a_int = 1;
        }

        public A()
        {
            ta = 2;
        }

        public void test()
        {
            Console.WriteLine("a_str:" + a_str);
            Console.WriteLine("a_int:" + a_int);
            Console.WriteLine("ta:" + ta);
        }
    }

    internal class B : A
    {
         private static string b_str = "a_str";
        private static int  b_int;
        private int tb = 1;

        static B()
        {
            b_int = 1;
        }

        public B()
        {
            tb = 3;
        }

        public void test()
        {
            Console.WriteLine("b_str:" + b_str);
            Console.WriteLine("b_int:" + b_int);
            Console.WriteLine("tb:" + tb);
            base.test();
        }
    }
}
