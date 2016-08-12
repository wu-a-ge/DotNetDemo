using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using newnorthwind;
using NUnit.Framework;
namespace VS2010.ConsoleApp.Linq
{
    [TestFixture]
    class SelectNamedType
    {
        /// <summary>
        /// 目的是为了只返回一部分数据，而不是全部，但是这种方式是不允许的
        /// 报错：不允许在查询中显式构造实体类型“newnorthwind.Orders”。
        /// </summary>
        [Test]
        public void Test1()
        {
            NewNorthwindDataContext db = new NewNorthwindDataContext();
            var result = from n in db.Orders
                         select new Orders {  CustomerID=n.CustomerID, OrderID=n.OrderID, ShipName =n.ShipName };
            Console.WriteLine(result);
        }
    }
}
