using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;

namespace VS2010.ConsoleApp.Linq
{
    
    class LazyLoadCatergoriesProducts
    {
        private static string connection = VS2010.ConsoleApp.Linq.Properties.Settings.Default.NorthwindConnectionString;
        public void LazyLoad()
        {
            Northwind db = new Northwind(connection) { Log = Console.Out };
            IQueryable<Product> notificationQuery =
            from ord in db.Products
            where ord.SupplierID == 4
            select ord;

            foreach (Product ordObj in notificationQuery)
            {
                Console.WriteLine(ordObj.Category);
            }
            Console.Read();

        }
        /// <summary>
        /// 这个有点特殊，延迟和非延迟都是生成两次SQL，由于被手工重写了方法的原因，在NorthwindExtended.cs类中进行了处理LoadProducts，如果注释掉此方法就会生成一个SQL代码
        /// 和LazyLoadCustomersOrders.cs一样的
        /// </summary>
        public void NotLazyLoad()
        {
            Northwind db2 = new Northwind(connection) { Log = Console.Out };
            //立即加载
            DataLoadOptions ds = new DataLoadOptions();
            ds.LoadWith<Category>(p => p.Products);
            db2.LoadOptions = ds;
            db2.DeferredLoadingEnabled = false;
            var q = (
                from c in db2.Categories
                where c.CategoryName == "Condiments"
                select c);

            foreach (Category detail in q)
            {
                foreach (var item in detail.Products)
                {
                    Console.WriteLine(item);
                }

            }
            Console.Read();
        }
    }
}
