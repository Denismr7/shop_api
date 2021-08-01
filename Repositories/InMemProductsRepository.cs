using System;
using System.Linq;
using System.Collections.Generic;
using Shop.Entities;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class InMemProductsRepository : IProductsRepository
    {
        private readonly List<Product> products = new()
        {
            new Product { Id = Guid.NewGuid(), Name = "Tofu", Price = (decimal)3.99, Description = "New Recipe!" },
            new Product { Id = Guid.NewGuid(), Name = "Carrot", Price = (decimal)1.99, Description = "Ecofriendly produced" },
            new Product { Id = Guid.NewGuid(), Name = "Spinach", Price = (decimal)2.50, Description = "High in Vitamin A and Iron" },
        };

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(products);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            return await Task.FromResult(products.FirstOrDefault(product => product.Id == id));
        }

        public async Task CreateProductAsync(Product newProduct)
        {
            products.Add(newProduct);
            await Task.CompletedTask;
        }

        public async Task UpdateProductAsync(Product updatedProduct)
        {
            var index = products.FindIndex(existingProd => existingProd.Id == updatedProduct.Id);
            products[index] = updatedProduct;
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var index = products.FindIndex(existingProd => existingProd.Id == id);
            products.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}