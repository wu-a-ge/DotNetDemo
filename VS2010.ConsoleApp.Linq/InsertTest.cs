using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using newnorthwind;
using System.Data.Linq;
using NUnit.Framework;
namespace VS2010.ConsoleApp.Linq
{
    [TestFixture]
    class InsertTest
    {
          NewNorthwindDataContext db = new NewNorthwindDataContext();
        [TestCase]
        public  void InserSingle()
        {
            var q =
                from c in db.Customer
                where c.Region == "WA"
                select c;

            Console.WriteLine("*** BEFORE ***");
            ObjectDumper.Write(q);


            Console.WriteLine();
            Console.WriteLine("*** INSERT ***");
            var newCustomer = new Customer
            {
                CustomerID = "MCSFT",
                CompanyName = "Microsoft",
                ContactName = "John Doe",
                ContactTitle = "Sales Manager",
                Address = "1 Microsoft Way",
                City = "Redmond",
                Region = "WA",
                PostalCode = "98052",
                Country = "USA",
                Phone = "(425) 555-1234",
                Fax = null
            };
            db.Customer.InsertOnSubmit(newCustomer);
            db.SubmitChanges();


            Console.WriteLine();
            Console.WriteLine("*** AFTER ***");
            ObjectDumper.Write(q);



            Cleanup64();  // Restore previous database state
        }
        private  void Cleanup64()
        {

            db.Customer.DeleteAllOnSubmit(from c in db.Customer where c.CustomerID == "MCSFT" select c);
            db.SubmitChanges();
        }
       [Test]
        public  void InserOneToMany1()
        {

             

            DataLoadOptions ds = new DataLoadOptions();
            ds.LoadWith<nwind.Category>(p => p.Products);
            db.LoadOptions = ds;

            var q = (
                from c in db.Categories
                where c.CategoryName == "Widgets"
                select c);


            Console.WriteLine("*** BEFORE ***");
            ObjectDumper.Write(q, 1);


            Console.WriteLine();
            Console.WriteLine("*** INSERT ***");
            var newCategory = new Categories
            {
                CategoryName = "Widgets",
                Description = "Widgets are the customer-facing analogues " +
                              "to sprockets and cogs."
            };
           //将子对象设置父对象的引用
            var newProduct = new Products
            {
                ProductName = "Blue Widget",
                UnitPrice = 34.56M,
                Categories = newCategory
            };
            db.Categories.InsertOnSubmit(newCategory);
            db.SubmitChanges();


            Console.WriteLine();
            Console.WriteLine("*** AFTER ***");
            ObjectDumper.Write(q, 1);

            Cleanup65();  // Restore previous database state
        }
       [Test]
       public  void InserOneToMany2()
       {



           DataLoadOptions ds = new DataLoadOptions();
           ds.LoadWith<nwind.Category>(p => p.Products);
           db.LoadOptions = ds;

           var q = (
               from c in db.Categories
               where c.CategoryName == "Widgets"
               select c);


           Console.WriteLine("*** BEFORE ***");
           ObjectDumper.Write(q, 1);


           Console.WriteLine();
           Console.WriteLine("*** INSERT ***");
           var newCategory = new Categories
           {
               CategoryName = "Widgets",
               Description = "Widgets are the customer-facing analogues " +
                             "to sprockets and cogs."
           };
           //子对象不设置父对象的引用 
           var newProduct = new Products
           {
               ProductName = "Blue Widget",
               UnitPrice = 34.56M,
               //Categories = newCategory
           };
           //在父对象子对象集合中添加子对象
           newCategory.Products.Add(newProduct);
           db.Categories.InsertOnSubmit(newCategory);
           db.SubmitChanges();


           Console.WriteLine();
           Console.WriteLine("*** AFTER ***");
           ObjectDumper.Write(q, 1);

           Cleanup65();  // Restore previous database state
       }
       [Test]
       public  void InserOneToMany3()
       {



           DataLoadOptions ds = new DataLoadOptions();
           ds.LoadWith<nwind.Category>(p => p.Products);
           db.LoadOptions = ds;

           var q = (
               from c in db.Categories
               where c.CategoryName == "Widgets"
               select c);


           Console.WriteLine("*** BEFORE ***");
           ObjectDumper.Write(q, 1);


           Console.WriteLine();
           Console.WriteLine("*** INSERT ***");
           var newCategory = new Categories
           {
               CategoryName = "Widgets",
               Description = "Widgets are the customer-facing analogues " +
                             "to sprockets and cogs."
           };
           //同时在子对象中设置父对象的引用，在父对象子对象集合中添加子对象
           var newProduct = new Products
           {
               ProductName = "Blue Widget",
               UnitPrice = 34.56M,
               Categories = newCategory
           };
           newCategory.Products.Add(newProduct);
           db.Categories.InsertOnSubmit(newCategory);
           db.SubmitChanges();


           Console.WriteLine();
           Console.WriteLine("*** AFTER ***");
           ObjectDumper.Write(q, 1);

           Cleanup65();  // Restore previous database state
       }
        private  void Cleanup65()
        {


            db.Products.DeleteAllOnSubmit(from p in db.Products where p.Categories.CategoryName == "Widgets" select p);
            db.Categories.DeleteAllOnSubmit(from c in db.Categories where c.CategoryName == "Widgets" select c);
            db.SubmitChanges();
        }
        [Test]
        public void InsertManyToMany()
        {

            NewNorthwindDataContext db2 = new NewNorthwindDataContext();

            DataLoadOptions ds = new DataLoadOptions();
            ds.LoadWith<nwind.Employee>(p => p.EmployeeTerritories);
            ds.LoadWith<nwind.EmployeeTerritory>(p => p.Territory);

            db2.LoadOptions = ds;
            var q = (
                from e in db.Employees
                where e.FirstName == "Nancy"
                select e);



            Console.WriteLine("*** BEFORE ***");
            ObjectDumper.Write(q, 1);


            Console.WriteLine();
            Console.WriteLine("*** INSERT ***");
            var newEmployee = new Employees
            {
                FirstName = "Kira",
                LastName = "Smith"
            };
            var newTerritory = new Territories
            {
                TerritoryID = "12345",
                TerritoryDescription = "Anytown",
                Region = db.Region.First()
            };
            var newEmployeeTerritory = new EmployeeTerritories
            {
                Employees = newEmployee,
                Territories = newTerritory
            };
            db.Employees.InsertOnSubmit(newEmployee);
            db.Territories.InsertOnSubmit(newTerritory);
            db.EmployeeTerritories.InsertOnSubmit(newEmployeeTerritory);
            db.SubmitChanges();


            Console.WriteLine();
            Console.WriteLine("*** AFTER ***");
            ObjectDumper.Write(q, 2);



            Cleanup66();  // Restore previous database state
        }

        private void Cleanup66()
        {
           

            db.EmployeeTerritories.DeleteAllOnSubmit(from et in db.EmployeeTerritories where et.TerritoryID == "12345" select et);
            db.Employees.DeleteAllOnSubmit(from e in db.Employees where e.FirstName == "Kira" && e.LastName == "Smith" select e);
            db.Territories.DeleteAllOnSubmit(from t in db.Territories where t.TerritoryID == "12345" select t);
            db.SubmitChanges();
        }

    }
}
