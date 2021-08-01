using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Entities;

namespace Shop.Repositories
{
     public interface IProductsRepository
    {
        Task<Product> GetProductAsync(Guid id);
        Task<IEnumerable<Product>> GetProductsAsync();
        Task CreateProductAsync(Product newProduct);
        Task UpdateProductAsync(Product updatedProduct);
        Task DeleteProductAsync(Guid id);
    }
}