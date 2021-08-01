using System;
using System.Linq;
using System.Collections.Generic;
using Shop.Entities;

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

        public IEnumerable<Product> GetProducts()
        {
            return products;
        }

        public Product GetProduct(Guid id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public void CreateProduct(Product newProduct)
        {
            products.Add(newProduct);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var index = products.FindIndex(existingProd => existingProd.Id == updatedProduct.Id);
            products[index] = updatedProduct;
        }

        public void DeleteProduct(Guid id)
        {
            var index = products.FindIndex(existingProd => existingProd.Id == id);
            products.RemoveAt(index);
        }
    }
}