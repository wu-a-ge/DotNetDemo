using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace VS2008.ConsoleApp.Test
{
    class ReflectionTest
    {
        internal static void WriteMethods()
        {
            var t = new DerivedTest();
            var lists = (from m in t.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                         let a = (MyTestAttribute[])m.GetCustomAttributes(typeof(MyTestAttribute), true)//这里的true是和AttributeUsageAttribute.Inherited是紧密相关的
                         where a.Length > 0
                         select m
 ).ToList();
            foreach (var m in lists)
            {
                Console.WriteLine(m.Name);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    class MyTestAttribute : Attribute
    {

    }

    class BaseTest
    {
        [MyTest]
        protected void Method1()
        {
            Console.WriteLine("BaseTest");
        }
        [MyTest]
        private void Method2()
        {
            Console.WriteLine("Method2");
        }

    }
    class DerivedTest : BaseTest
    {
        /// <summary>
        /// 这个方法隐藏了基类的方法都可以继承基类的特性？？只是同名方法都可以使用？？？
        /// </summary>
        protected new void Method1()
        {
            Console.WriteLine("DerivedTest");
        }
        /// <summary>
        /// 私有方法是无法继承的，基类对派生类来说是不可见的
        /// </summary>
        private void Method2()
        {
            Console.WriteLine("Method2");
        }

    }
}
