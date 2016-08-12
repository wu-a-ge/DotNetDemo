using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;
namespace VS2010.ConsoleApp.Linq
{
    /// <summary>
    /// 补充一点的就是非延迟和延迟加载不要以生成的SQL语句多少来判断，如果重写了一些分部方法可能会打断成多个SQL语句
    /// </summary>
    class LazyLoadCustomersOrders
    {
        private static string connection = VS2010.ConsoleApp.Linq.Properties.Settings.Default.NorthwindConnectionString;
        private Northwind db = new Northwind(connection) { Log = Console.Out };

        public void LazyLoad()
        {
            IQueryable<nwind.Order> notificationQuery =
            from ord in db.Orders
            where ord.ShipVia == 3
            select ord;

            foreach (nwind.Order ordObj in notificationQuery)
            {
                if (ordObj.Freight > 200)
                    //访问一个订单对象，生成 一个SQL语句
                    Console.WriteLine(ordObj.Customer);
            }

        }
        public void NotLazyLoad()
        {
            //设置非延迟加载，不是说设置这个属性后就会执行立即加载
            //如果指定了LoadOptions属性，下面属性不管设不设置为false都会立即加载
            db.DeferredLoadingEnabled = false;
            //要使用LoadOptions属性才能执行立即加载，不然无法实现立即加载
            //则Customer对象的Orders集合没有值
            var dl = new DataLoadOptions();
            dl.LoadWith<nwind.Customer>(c => c.Orders);//这个指定当前主表和哪个进行相关查询
            db.LoadOptions = dl;

            var custQuery =
                from cust in db.Customers
                where cust.City == "London"
                select cust;
            //使用了立即加载后，一访问客户对象时就会生成一个关联SQL将相关的订单全部检索出来
            //否则就会采用延迟加载,每次访问订单集合时都会生成SQL语句去查询订单
            foreach (nwind.Customer custObj in custQuery)
            {
                Console.WriteLine(custObj);
                foreach (nwind.Order ordObj in custObj.Orders)
                {
                    Console.WriteLine(ordObj);
                }
            }
            Console.Read();
        }
    }
}
