using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public abstract class AbstractProductRepository : IProductRepository
    {
        public void InsertProduct(Product product)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            db.Products.InsertOnSubmit(product);
            db.SubmitChanges();
        }

        public virtual Product GetProduct(int id)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            return db.Products.SingleOrDefault(p => p.ProductID == id);
        }

        public abstract void UpdateProduct(Product product);
    }
}
