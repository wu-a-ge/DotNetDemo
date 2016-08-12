using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
namespace VS2010.ConsoleApp.Linq
{
    class ConversionOperator
    {
        /// <summary>
        /// "This sample uses AsEnumerable so that the client-side IEnumerable<T> " +
        /// "implementation of Where is used, instead of the default IQueryable<T> " +
        /// "implementation which would be converted to SQL and executed " +
        /// "on the server.  This is necessary because the where clause " +
        /// "references a user-defined client-side method, isValidProduct, " +
        /// "which cannot be converted to SQL."
        /// </summary>
        public static void ASEnumerable()
        {
            Northwind db = new Northwind();
            var q =
               from p in db.Products.AsEnumerable()
               where isValidProduct(p)
               select p;
            //产生了两个查询SQL语句。。。。这个方法不好！因为用到了本地方法，所以转换成Enumerable，但是为什么
            //会生成两个查询语句
            ObjectDumper.Write(q);
        }
        private static bool isValidProduct(Product p)
        {
            return p.ProductName.LastIndexOf('C') == 0;
        }
    }
}
