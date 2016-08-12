using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Repositories
{
    public class UsingDelegateProductRepository : AbstractProductRepository
    {
        public override void UpdateProduct(Product product)
        {
            
        }
        /// <summary>
        /// 采用查询后修改再提交
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="action"></param>
        public void UpdateProduct(Expression<Func<Product, bool>> predicate, Action<Product> action)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var product = db.Products.SingleOrDefault(predicate);
            action(product);
            db.SubmitChanges();
        }
        /// <summary>
        /// 采用查询后修改再提交
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        public void UpdateProduct(int id, Action<Product> action)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var product = db.Products.SingleOrDefault(p => p.ProductID == id);
            action(product);
            db.SubmitChanges();
        }
    }
}
