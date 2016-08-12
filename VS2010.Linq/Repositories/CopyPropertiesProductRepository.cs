using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Repositories
{
    public class CopyPropertiesProductRepository : AbstractProductRepository
    {
        /// <summary>
        /// 采用查询后修改再提交
        /// </summary>
        /// <param name="product"></param>
        public override void UpdateProduct(Product product)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            var dest = db.Products.SingleOrDefault(p => p.ProductID == product.ProductID);
            //CopyObjectProperty(product, dest);
            dest.CategoryID = product.CategoryID;
            dest.Discontinued = product.Discontinued;
            dest.ProductName = product.ProductName;
            dest.QuantityPerUnit = product.QuantityPerUnit;
            dest.ReorderLevel = product.ReorderLevel;
            dest.SupplierID = product.SupplierID;
            dest.UnitPrice = product.UnitPrice;
            dest.UnitsInStock = product.UnitsInStock;
            dest.UnitsOnOrder = product.UnitsOnOrder;
            db.SubmitChanges();
        }

        private static void CopyObjectProperty<T>(T tSource, T tDestination) where T : class
        {
            PropertyInfo[] properties = tSource.GetType().GetProperties();
            foreach (PropertyInfo p in properties)
            {
                p.SetValue(tDestination, p.GetValue(tSource, null), null);
            }
        }
    }
}
