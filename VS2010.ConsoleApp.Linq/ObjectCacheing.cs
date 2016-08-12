using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
 

namespace VS2010.ConsoleApp.Linq
{
    class ObjectCacheing
    {
        /// <summary>
        /// 相同的查询会被缓存,也即只会产生一次SQL语句，对象也会对缓存
        /// </summary>
        public static void SameQueryCacheingObject()
        {
            Northwind db = new Northwind();
            Customer cust1 = db.Customers.First(c => c.CustomerID == "BONAP");
            Customer cust2 = db.Customers.First(c => c.CustomerID == "BONAP");

            Console.WriteLine("cust1 and cust2 refer to the same object in memory: {0}",
                              Object.ReferenceEquals(cust1, cust2));
        }
        public static void DiffentQueryCacheingObject()
        {
            Northwind db = new Northwind();
            Customer cust1 = db.Customers.First(c => c.CustomerID == "BONAP");
            Customer cust2 = (
                from o in db.Orders
                where o.Customer.CustomerID == "BONAP"
                select o)
                .First()
                .Customer;

            Console.WriteLine("cust1 and cust2 refer to the same object in memory: {0}",
                              Object.ReferenceEquals(cust1, cust2));
        }
    }
}
