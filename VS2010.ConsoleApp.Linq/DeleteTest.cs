using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using newnorthwind;
using NUnit.Framework;

namespace VS2010.ConsoleApp.Linq
{
    [TestFixture]
    class DeleteTest
    {
       private      NewNorthwindDataContext db = new NewNorthwindDataContext();
       private    void ClearCache()
       {
           db = new NewNorthwindDataContext();
       }
        [Test]
        public   void DeleteSingleObject()
        {
            Console.WriteLine("*** BEFORE ***");
            ObjectDumper.Write(from c in db.OrderDetail where c.OrderID == 10255 select c);


            Console.WriteLine();
            Console.WriteLine("*** DELETE ***");
            //Beverages
            OrderDetail orderDetail = db.OrderDetail.First(c => c.OrderID == 10255 && c.ProductID == 36);
            db.OrderDetail.DeleteOnSubmit(orderDetail);
            db.SubmitChanges();
            Console.WriteLine();
            Console.WriteLine("clear cache before");
            ObjectDumper.Write(from c in db.OrderDetail where c.OrderID == 10255 select c);
            Console.WriteLine();
            Console.WriteLine("clear cache after");
            ClearCache();
            ObjectDumper.Write(from c in db.OrderDetail where c.OrderID == 10255 select c);
            Restore1();
            Console.Read();
        }
        private   void Restore1()
        {
            OrderDetail orderDetail = new OrderDetail()
            {
                OrderID = 10255,
                ProductID = 36,
                UnitPrice = 15.200M,
                Quantity = 25,
                Discount = 0.0F
            };
            db.OrderDetail.InsertOnSubmit(orderDetail);

            db.SubmitChanges();
        }
       [Test]
        public   void DeleteOneToMany()
        {
            var orderDetails =
        from o in db.OrderDetail
        where o.Orders.CustomerID == "WARTH" && o.Orders.EmployeeID == 3
        select o;

            Console.WriteLine("*** BEFORE ***");
            ObjectDumper.Write(orderDetails);

            Console.WriteLine();
            Console.WriteLine("*** DELETE ***");
            var order =
                (from o in db.Orders
                 where o.CustomerID == "WARTH" && o.EmployeeID == 3
                 select o).First();
           //如果不删除子对象是无法删除父对象的
           //因为没有设置级联删除,所以必须先删除了子对象才能删除父对象
           //SQL忘光了。。。我擦 ！
            foreach (OrderDetail od in orderDetails)
            {
                db.OrderDetail.DeleteOnSubmit(od);
            }

            db.Orders.DeleteOnSubmit(order);

            db.SubmitChanges();


            Console.WriteLine();
            Console.WriteLine("*** AFTER ***");
            ObjectDumper.Write(orderDetails);



            Cleanup70();  // Restore previous database state

        }
        private   void Cleanup70()
        {
            

            Orders order = new Orders()
            {
                CustomerID = "WARTH",
                EmployeeID = 3,
                OrderDate = new DateTime(1996, 7, 26),
                RequiredDate = new DateTime(1996, 9, 6),
                ShippedDate = new DateTime(1996, 7, 31),
                ShipVia = 3,
                Freight = 25.73M,
                ShipName = "Wartian Herkku",
                ShipAddress = "Torikatu 38",
                ShipCity = "Oulu",
                ShipPostalCode = "90110",
                ShipCountry = "Finland"
            };

            //Order, Cus, Emp, OrderD, ReqD, ShiD, ShipVia, Frei, ShipN, ShipAdd, ShipCi, ShipReg, ShipPostalCost, ShipCountry
            //10266	WARTH	3	1996-07-26 00:00:00.000	1996-09-06 00:00:00.000	1996-07-31 00:00:00.000	3	25.73	Wartian Herkku	Torikatu 38	Oulu	NULL	90110	Finland

            OrderDetail orderDetail = new OrderDetail()
            {
                ProductID = 12,
                UnitPrice = 30.40M,
                Quantity = 12,
                Discount = 0.0F
            };
            order.OrderDetail.Add(orderDetail);

            db.Orders.InsertOnSubmit(order);
            db.SubmitChanges();
        }
        [Test]
        public void DeleteInferred()
        {
            Console.WriteLine("*** BEFORE ***");

            ObjectDumper.Write(from o in db.Orders where o.OrderID == 10248 select o);
            ObjectDumper.Write(from d in db.OrderDetail where d.OrderID == 10248 select d);

            Console.WriteLine();
            Console.WriteLine("*** INFERRED DELETE ***");
            Orders order = db.Orders.First(x => x.OrderID == 10248);
            OrderDetail od = order.OrderDetail.First(d => d.ProductID == 11);
            //通过父对象的子对象集合来删除一个子实体对象
            //只能进行一个一个的删除，不能删除一个集合
            //删除子对象时，如果没有对orderdetail对象中的order对象引用添加
            //DeleteOnNull属性，那么它会去尝试将orderid更新为null，而不是删除，但是这样会报错
            order.OrderDetail.Remove(od);
            db.SubmitChanges();

            Console.WriteLine();
            Console.WriteLine("*** AFTER ***");
            ClearCache();
            ObjectDumper.Write(from o in db.Orders where o.OrderID == 10248 select o);
            ObjectDumper.Write(from d in db.OrderDetail where d.OrderID == 10248 select d);
            CleanupInsert08();  // Restore previous database state
        }
        private void CleanupInsert08()
        {
           
            OrderDetail od = new OrderDetail() { ProductID = 11, Quantity = 12, UnitPrice = 14, OrderID = 10248, Discount = 0 };
            db.OrderDetail.InsertOnSubmit(od);
            db.SubmitChanges();
        }
        [Test]
        public void DeleteCascade()
        {
            MyDbDataContext mydb = new MyDbDataContext();
            var father = mydb.father.First();
            ObjectDumper.Write(father);
            ObjectDumper.Write(father.children);
            mydb.father.DeleteOnSubmit(father);
            mydb.SubmitChanges();
        }
    }
}
