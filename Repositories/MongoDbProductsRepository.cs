using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        
        public async Task CreateProductAsync(Product newProduct)
        {
            await productsCollection.InsertOneAsync(newProduct);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);
            await productsCollection.DeleteOneAsync(filter);
        }

        public async Task<Product> GetProductAsync(Guid id)
        {
            var filter = filterBuilder.Eq(product => product.Id, id);
            return await productsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await productsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateProductAsync(Product updatedProduct)
        {
            var filter = filterBuilder.Eq(product => product.Id, updatedProduct.Id);
            await productsCollection.ReplaceOneAsync(filter, updatedProduct);
        }
    }
}