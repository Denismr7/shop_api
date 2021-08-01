using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Shop.Entities;

namespace Shop.Repositories
{
    public class MongoDbProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Product> productsCollection;
        private const string databaseName = "shop";
        private const string collectionName = "products";
        public MongoDbProductsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            productsCollection = database.GetCollection<Product>(collectionName);
        }

        
        public void CreateProduct(Product newProduct)
        {
            productsCollection.InsertOne(newProduct);
        }

        public void DeleteProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            throw new NotImplementedException();
        }
    }
}