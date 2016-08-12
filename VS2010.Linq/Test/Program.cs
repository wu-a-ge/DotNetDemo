using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeTimer.Time("Copy Properties", 1000, () => Execute(new CopyPropertiesProductRepository()));

            CodeTimer.Time("Enable Object Tracking", 1000, () => Execute(new EnableObjectTrackingProductRepository()));

            CodeTimer.Time("Detach Associations", 1000, () => Execute(new DetachAssociationProductRepository()));

            CodeTimer.Time("Using Delegate", 1000, () => ExecuteDelegate(new UsingDelegateProductRepository()));

            Console.ReadLine();
        }

        static void Execute(IProductRepository pr)
        {
            var p1 = new Product
            {
                CategoryID = 1,
                ProductName = "Before changing",
                SupplierID = 1,
                UnitPrice = (decimal)2.0,
                UnitsInStock = 100,
                Discontinued = true,
                ReorderLevel = 10
            };
            pr.InsertProduct(p1);
            var p2 = pr.GetProduct(p1.ProductID);
            p2.CategoryID = 2;
            p2.ProductName = "Arfer changing";
            p2.SupplierID = 2;
            p2.UnitPrice = (decimal)3;
            p2.UnitsInStock = 200;
            p2.Discontinued = false;
            p2.ReorderLevel = 20;
            pr.UpdateProduct(p2);
        }

        static void ExecuteDelegate(UsingDelegateProductRepository pr)
        {
            var p1 = new Product
            {
                CategoryID = 1,
                ProductName = "Before changing",
                SupplierID = 1,
                UnitPrice = (decimal)2.0,
                UnitsInStock = 100,
                Discontinued = true,
                ReorderLevel = 10
            };
            pr.InsertProduct(p1);
            pr.UpdateProduct(p1.ProductID, p =>
            {
                p.CategoryID = 2;
                p.ProductName = "Arfer changing";
                p.SupplierID = 2;
                p.UnitPrice = (decimal)3;
                p.UnitsInStock = 200;
                p.Discontinued = false;
                p.ReorderLevel = 20;
            });
        }
    }
}
