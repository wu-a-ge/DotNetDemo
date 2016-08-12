using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using newnorthwind;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Data.Linq;
namespace VS2010.ConsoleApp.Linq
{
    [TestFixture]
    class TranslateTest
    {
        [Test]
        public void Test1()
        {
            List<Orders> itemList = GetItemsForListing(10248);
            foreach (Orders item in itemList)
            {
                Console.WriteLine(item);
                foreach (OrderDetail comment in item.OrderDetail)
                {
                    Console.WriteLine(comment.OrderID);
                }
            }
        }
        public  List<Orders> GetItemsForListing(int ownerId)
        {
            NewNorthwindDataContext dataContext = new NewNorthwindDataContext();
            //DataLoadOptions ds = new DataLoadOptions();
            //ds.LoadWith<Orders>(o => o.OrderDetail);
            //dataContext.LoadOptions = ds;
            var query = from item in dataContext.Orders
                        where item.OrderID == ownerId
                        orderby item.OrderDate descending
                        select new
                        {
                            item.OrderID,
                            item.ShipCity,
                            item.ShipAddress,
                            item.ShipCountry
                        };
           
            return dataContext.ExecuteQuery<Orders>(query);
            
        }
    }
}
