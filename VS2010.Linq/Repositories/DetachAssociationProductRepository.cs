using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Repositories
{
    public class DetachAssociationProductRepository : AbstractProductRepository
    {
        /// <summary>
        ///  数据表一定带有版本行特性或时间戳字段
        /// </summary>
        /// <param name="product"></param>
        public override void UpdateProduct(Product product)
        {
            NorthwindDataContext db = new NorthwindDataContext();
            Detach(product);
            db.Products.Attach(product, true);
            db.SubmitChanges();
        }

        private void Detach<TEntity>(TEntity entity)
        {
            foreach (FieldInfo fi in entity.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (fi.FieldType.ToString().Contains("EntityRef"))
                {
                    var value = fi.GetValue(entity);
                    if (value != null)
                    {
                        fi.SetValue(entity, null);
                    }
                }
                if (fi.FieldType.ToString().Contains("EntitySet"))
                {
                    var value = fi.GetValue(entity);
                    if (value != null)
                    {
                        MethodInfo mi = value.GetType().GetMethod("Clear");
                        if (mi != null)
                        {
                            mi.Invoke(value, null);
                        }
                        fi.SetValue(entity, value);
                    }
                }
            }
        }

    }
}
