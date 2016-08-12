using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nwind;
using System.Data.Linq;

namespace VS2010.ConsoleApp.Linq
{
    class OptimisticConcurrency
    {
        /// <summary>
        /// 乐观并发冲突
        /// </summary>
        public static void Load()
        {
            Console.WriteLine("YOU:  ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
            Northwind db = new Northwind() { Log = Console.Out };
            var product = db.Products.First(p => p.ProductID == 1);

            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");


            Console.WriteLine();
            Console.WriteLine("OTHER USER: ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

            // Open a second connection to the database to simulate another user
            // who is going to make changes to the Products table.
            Northwind otherUser_db = new Northwind() { Log = db.Log };

            var otherUser_product = otherUser_db.Products.First(p => p.ProductID == 1);
            otherUser_product.UnitPrice = 999.99M;
            otherUser_db.SubmitChanges();

            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");


            Console.WriteLine();
            Console.WriteLine("YOU (continued): ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

            product.UnitPrice = 777.77M;

            bool conflict = false;
            try
            {
                db.SubmitChanges();
            }
            //OptimisticConcurrencyException
            catch (ChangeConflictException)
            {
                conflict = true;
            }

            Console.WriteLine();
            if (conflict)
            {
                Console.WriteLine("* * * OPTIMISTIC CONCURRENCY EXCEPTION * * *");
                Console.WriteLine("Another user has changed Product 1 since it was first requested.");
                Console.WriteLine("Backing out changes.");
            }
            else
            {
                Console.WriteLine("* * * COMMIT SUCCESSFUL * * *");
                Console.WriteLine("Changes to Product 1 saved.");
            }

            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
            Cleanup72();  // Restore previous database state
        }

        private static void Cleanup72()
        {
            
            // transaction failure will roll data back automatically
        }
    }
}
