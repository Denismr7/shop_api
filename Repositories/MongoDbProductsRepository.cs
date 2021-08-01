using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Shop.Entities;

namespace Shop.Repositories
{
    public class MongoDbProductsRepository : IProductsRepository
    {
        private readonly IMongoCollection<Product> productsCollection;
        private const string databaseName = "shop";
        private const string collectionName = "products";
        private readonly FilterDefinitionBuilder<Product> filterBuilder = Builders<Product>.Filter;
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
            var filter = filterBuilder.Eq(product => product.Id, id);
            productsCollection.DeleteOne(filter);
        }

        public Product GetProduct(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);
            return productsCollection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<Product> GetProducts()
        {
            return productsCollection.Find(new BsonDocument()).ToList();
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var filter = filterBuilder.Eq(product => product.Id, updatedProduct.Id);
            productsCollection.ReplaceOne(filter, updatedProduct);
        }
    }
}