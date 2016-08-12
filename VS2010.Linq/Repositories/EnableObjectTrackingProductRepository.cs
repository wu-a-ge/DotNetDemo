using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Repositories
{
    public class EnableObjectTrackingProductRepository : AbstractProductRepository
    {
        public override Product GetProduct(int id)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            db.ObjectTrackingEnabled = false;
            DataLoadOptions loads = new DataLoadOptions();
            loads.LoadWith<Product>(p => p.Order_Details);
            loads.LoadWith<Product>(p => p.Category);
            loads.LoadWith<Product>(p => p.Supplier);
            return db.Products.SingleOrDefault(p => p.ProductID == id);
        }
        /// <summary>
        /// 数据表一定带有版本行特性或时间戳字段
        /// </summary>
        /// <param name="product"></param>
        public override void UpdateProduct(Product product)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            db.Products.Attach(product, true);
            db.SubmitChanges();
        }
    }
}
