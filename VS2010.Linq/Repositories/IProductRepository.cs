using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public interface IProductRepository
    {
        void InsertProduct(Product product);

        Product GetProduct(int id);

        void UpdateProduct(Product product);
    }
}
