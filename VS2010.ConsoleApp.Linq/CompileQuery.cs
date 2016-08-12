using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;
namespace VS2010.ConsoleApp.Linq
{
    class CompileQuery
    {
        public static void LoadCompiledQuery()
        {
            Northwind db = new Northwind();
            //Create compiled query
            //编译后生成委托，应该有更快的执行效率。。。比表达式树好多了吧？
            var fn = CompiledQuery.Compile((Northwind db2, string city) =>
                from c in db2.Customers
                where c.City == city
                select c);

            Console.WriteLine("****** Call compiled query to retrieve customers from London ******");
            var LonCusts = fn(db, "London");
            ObjectDumper.Write(LonCusts);

            Console.WriteLine();

            Console.WriteLine("****** Call compiled query to retrieve customers from Seattle ******");
            var SeaCusts = fn(db, "Seattle");
            ObjectDumper.Write(SeaCusts);

        }
    }
}
