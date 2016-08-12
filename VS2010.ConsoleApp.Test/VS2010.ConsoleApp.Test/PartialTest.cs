using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//5.分部类、结构使用三个原因：源代码控制，同一个文件中分成 多个逻辑单元，代码拆分(工具生成代码和手工代码)
//6.分部方法：一个分部类中声明，需要时在另一个分部类中实现(本分部类实现也不会报错，但是这样没有意义)。没有实现的分部方法不会生成IL。分部方法返回类型为VOID，参数不能使用OUT关键字。可访问性为PRIVATE，不能更改！
namespace VS2010.ConsoleApp.Test
{
    /// <summary>
    /// 分部类可以在同一个文件中反复声明，也可以分在多个文件中，但是
    /// 它不能跨程序集
    /// </summary>
    partial class PartialTest
    {
        private string T1;
        protected void Method1(string t1) { }
         partial void Method3();
    }
    partial class PartialTest
    {
        partial  void Method3() { }
        protected void Method2() {
            Method1(T1);
        }
    }
    
   
}
