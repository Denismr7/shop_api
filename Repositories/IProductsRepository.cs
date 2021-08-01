using System;
using System.Collections.Generic;
using Shop.Entities;

namespace Shop.Repositories
{
     public interface IProductsRepository
    {
        Product GetProduct(Guid id);
        IEnumerable<Product> GetProducts();
        void CreateProduct(Product newProduct);
        void UpdateProduct(Product updatedProduct);
        void DeleteProduct(Guid id);
    }
}