using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace VS2008.WebForm.Test
{
    [AttributeUsage(AttributeTargets.Method,Inherited=false)]
    class MyTestAttribute : Attribute
    {
         
    }
    public partial class ReflectionTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //asp.net页面编译后生成的类变了，比如当前生成的类变成了asp.reflectiontest_aspx,如果用反射this.GetType()
            //就是得不到私有方法(为什么？)，可能得到保护和公有的，要取得私有的或其它的只有用typeof(ReflectionTest)
            var lists = (from m in typeof(ReflectionTest) .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static|BindingFlags.Public)
                         let a = (MyTestAttribute[])m.GetCustomAttributes(typeof(MyTestAttribute), false)//这里的参数inherit和AttributeUsage里的属性Inherit是一个意思
                         select m
        ).ToList();
//            var lists = (from m in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public)
//                         let a = (MyTestAttribute[])m.GetCustomAttributes(typeof(MyTestAttribute), false)
//                         select m
//).ToList();
            foreach (var t in lists)
            {
                //if (t.Name.Equals("test", StringComparison.OrdinalIgnoreCase))
                //{
                    Response.Write(t.Name);
                    //t.Invoke(this, null);
                //}
            }
        }
        [MyTest]
        private void Test()
        {
            Response.Write("test");

        }
        [MyTest]
        protected void Test1()
        {
            Response.Write("test");

        }
        [MyTest]
        private static void Test2()
        {
           HttpContext.Current.Response.Write("test");

        }
        [MyTest]
        public void Test3()
        {
            Response.Write("test");

        }
    }
}
