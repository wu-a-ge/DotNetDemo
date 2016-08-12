using System;
using System.Linq;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        void SaveProduct(Product product);
        IQueryable<Product> Products { get; }
        void DeleteProduct(Product product);
    }
}
