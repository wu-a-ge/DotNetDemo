using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;

namespace VS2010.ConsoleApp.Linq
{
     class UpdateAndDeleteWithAttach
    {
         /// <summary>
         /// 对于EntitySet可以进行CUD
         /// </summary>
        public static void Load()
        {
            // Typically you would get entities to attach from deserializing
            // XML from another tier.
            // This sample uses LoadWith to eager load customer and orders
            // in one query and disable deferred loading.
            Customer cust = null;
            using (Northwind tempdb = new Northwind())
            {
                //这里采用立即加载订单数据，虽然也是生成的两个SQL，但是是在提取客户对象时
                //就提取了相应的订单信息，如果这里不采用立即加载，那么这里的数据上下文已经关闭，
                //再去读取订单信息会出错
                DataLoadOptions shape = new DataLoadOptions();
                shape.LoadWith<Customer>(c => c.Orders);
                // Load the first customer entity and its orders.
                tempdb.LoadOptions = shape;
                tempdb.DeferredLoadingEnabled = false;
                cust = tempdb.Customers.First(x => x.CustomerID == "ALFKI");
            }

            Console.WriteLine("Customer {0}'s original phone number {1}", cust.CustomerID, cust.Phone);
            Console.WriteLine();

            foreach (Order o in cust.Orders)
            {
                Console.WriteLine("Customer {0} has order {1} for city {2}", o.CustomerID, o.OrderID, o.ShipCity);
            }

            Order orderA = cust.Orders.First();
            Order orderB = cust.Orders.First(x => x.OrderID > orderA.OrderID);

            using (Northwind db2 = new Northwind())
            {
                // Attach the first entity to the current data context, to track changes.
                db2.Customers.Attach(cust);
                //附加相关订单集合，可以进行相应的修改，删除等，如果添加的一个新集合，就直接被插入数据库
                // Attach the related orders for tracking; otherwise they will be inserted on submit.
                db2.Orders.AttachAll(cust.Orders.ToList());

                // Update the customer.
                cust.Phone = "2345 5436";
                // Update the first order.
                orderA.ShipCity = "Redmond";
                // Remove the second order.
                cust.Orders.Remove(orderB);
                // Create a new order and add it to the customer.
                Order orderC = new Order() { ShipCity = "New York" };
                Console.WriteLine("Adding new order");
                cust.Orders.Add(orderC);

                //Now submit the all changes
                db2.SubmitChanges();
            }

            // Verify that the changes were applied a expected.
            using (Northwind db3 = new Northwind())
            {
                Customer newCust = db3.Customers.First(x => x.CustomerID == "ALFKI");
                Console.WriteLine("Customer {0}'s new phone number {1}", newCust.CustomerID, newCust.Phone);
                Console.WriteLine();

                foreach (Order o in newCust.Orders)
                {
                    Console.WriteLine("Customer {0} has order {1} for city {2}", o.CustomerID, o.OrderID, o.ShipCity);
                }
            }

            CleanupInsert11();
        }

        private static void CleanupInsert11()
        {
            int[] alfkiOrderIDs = { 10643, 10692, 10702, 10835, 10952, 11011 };

            using (Northwind tempdb = new Northwind())
            {
                Customer c1 = tempdb.Customers.Single(c => c.CustomerID == "ALFKI");
                c1.Phone = "030-0074321";
                Order oa = tempdb.Orders.Single(o => o.OrderID == 10643);
                oa.ShipCity = "Berlin";
                Order ob = tempdb.Orders.Single(o => o.OrderID == 10692);
                ob.CustomerID = "ALFKI";
                foreach (Order o in c1.Orders.Where(p => !alfkiOrderIDs.Contains(p.OrderID)))
                    tempdb.Orders.DeleteOnSubmit(o);

                tempdb.SubmitChanges();
            }
        }
    }
}
