using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
namespace VS2010.ConsoleApp.Linq
{
    public class SqlMethod
    {
        public static void LoadLikeMethod()
        {
            Northwind db = new Northwind();
            var q = from c in db.Customers
                    where SqlMethods.Like(c.CustomerID, "C%")
                    select c;
            ObjectDumper.Write(q);
        }
        public static void LoadDateDiffDay()
        {
            Northwind db = new Northwind();
            var q = from o in db.Orders
                    where SqlMethods.DateDiffDay(o.OrderDate, o.ShippedDate) < 10
                    select o;

            ObjectDumper.Write(q);

        }
    }
}
