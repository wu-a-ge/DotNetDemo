using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;

namespace VS2010.ConsoleApp.Linq
{
    class UpdateWithAttach
    {
        /// <summary>
        /// 实体类中的Attach方法只是对数据表中的数据进行更新和删除，不是插入
        /// </summary>
        public static void Load()
        {
               // Typically you would get entities to attach from deserializing XML from another tier.
            // It is not supported to attach entities from one DataContext to another DataContext.  
            // So to duplicate deserializing the entities, the entities will be recreated here.
            Customer c1;
            List<Order> deserializedOrders = new List<Order>();
            Customer deserializedC1;

            using (Northwind tempdb = new Northwind())
            {
                c1 = tempdb.Customers.Single(c => c.CustomerID == "ALFKI");
                Console.WriteLine("Customer {0}'s original address {1}", c1.CustomerID, c1.Address);
                Console.WriteLine();
                //创建一个新需要更新的客户实体对象
                deserializedC1 = new Customer { Address = c1.Address, City = c1.City,
                                                CompanyName=c1.CompanyName, ContactName=c1.ContactName,
                                                ContactTitle=c1.ContactTitle, Country=c1.Country,
                                                CustomerID=c1.CustomerID, Fax=c1.Fax,
                                                Phone=c1.Phone, PostalCode=c1.PostalCode,
                                                Region=c1.Region};
                //需要更新的订单列表
                Customer tempcust = tempdb.Customers.Single(c => c.CustomerID == "ANTON");
                foreach (Order o in tempcust.Orders)
                {
                    Console.WriteLine("Order {0} belongs to customer {1}", o.OrderID, o.CustomerID);
                    deserializedOrders.Add(new Order {CustomerID=o.CustomerID, EmployeeID=o.EmployeeID,
                                                      Freight=o.Freight, OrderDate=o.OrderDate, OrderID=o.OrderID,
                                                      RequiredDate=o.RequiredDate, ShipAddress=o.ShipAddress,
                                                      ShipCity=o.ShipCity, ShipName=o.ShipName,
                                                      ShipCountry=o.ShipCountry, ShippedDate=o.ShippedDate,
                                                      ShipPostalCode=o.ShipPostalCode, ShipRegion=o.ShipRegion,
                                                      ShipVia=o.ShipVia});
                }
                
                Console.WriteLine();

                Customer tempcust2 = tempdb.Customers.Single(c => c.CustomerID == "CHOPS");
                var c3Orders = tempcust2.Orders.ToList();
                foreach (Order o in c3Orders)
                {
                    Console.WriteLine("Order {0} belongs to customer {1}", o.OrderID, o.CustomerID);
                }
                Console.WriteLine();
            }

            using (Northwind db2 = new Northwind())
            {
                // Attach the first entity to the current data context, to track changes.
                db2.Customers.Attach(deserializedC1);
                Console.WriteLine("***** Update Customer ALFKI's address ******");
                Console.WriteLine();
                // Change the entity that is tracked.
                deserializedC1.Address = "123 First Ave";

                // Attach all entities in the orders list.
                db2.Orders.AttachAll(deserializedOrders);
                // Update the orders to belong to another customer.
                Console.WriteLine("****** Assign all Orders belong to ANTON to CHOPS ******");
                Console.WriteLine();

                foreach (Order o in deserializedOrders)
                {
                    o.CustomerID = "CHOPS";
                }

                // Submit the changes in the current data context.
                db2.SubmitChanges();
            }

            // Check that the orders were submitted as expected.
            using (Northwind db3 = new Northwind())
            {
                Customer dbC1 = db3.Customers.Single(c => c.CustomerID == "ALFKI");

                Console.WriteLine("Customer {0}'s new address {1}", dbC1.CustomerID, dbC1.Address);
                Console.WriteLine();

                Customer dbC2 = db3.Customers.Single(c => c.CustomerID == "CHOPS");

                foreach (Order o in dbC2.Orders)
                {
                    Console.WriteLine("Order {0} belongs to customer {1}", o.OrderID, o.CustomerID);
                }
              
            }

            CleanupInsert10();
        }
        private  static void CleanupInsert10()
        {
            int[] c2OrderIDs = { 10365, 10507, 10535, 10573, 10677, 10682, 10856 };
            using (Northwind tempdb = new Northwind())
            {
                Customer c1 = tempdb.Customers.Single(c => c.CustomerID == "ALFKI");
                c1.Address = "Obere Str. 57";
                foreach (Order o in tempdb.Orders.Where(p => c2OrderIDs.Contains(p.OrderID)))
                    o.CustomerID = "ANTON";
                tempdb.SubmitChanges();
            }
        }
        
    }
}
