using Ecom.Domain.Entities;
using Ecom.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ecom.Tests.Integration.Repositories
{
    public class MongoDbServiceTests
    {
        private readonly IConfiguration configuration = new TestConfig();
        private readonly IMongoDbService mongoDbService;

        public MongoDbServiceTests()
        {
            mongoDbService = new MongoDbService(configuration);
        }

        [Fact]
        public void GetCollectionWhenDatabaseNameAndCollectionNameProvided()
        {
            IMongoCollection<User> userCollection = mongoDbService.GetCollection<User>(null, "Users");

            Assert.NotNull(userCollection);
            Assert.Equal("TestDb", userCollection.Database.DatabaseNamespace.DatabaseName);
        }

        [Fact]
        public void GetDatabaseObject()
        {
            IMongoDatabase database = mongoDbService.GetDatabase(null);

            Assert.Equal("TestDb", database.DatabaseNamespace.DatabaseName);

            IMongoDatabase database2 = mongoDbService.GetDatabase("TestDb");

            Assert.Equal("TestDb", database2.DatabaseNamespace.DatabaseName);
        }


        [Fact]
        public async Task Should_Commit()
        {
            IMongoDatabase database = mongoDbService.GetDatabase("TestDb");
            IMongoCollection<User> userCollection = database.GetCollection<User>("Users");
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("Products");

            var user1 = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User1",
                Email = "User1@gmail.com"
            };
            var product1 = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Product-1",
                Category = new ProductCategory { Id = Guid.NewGuid().ToString(), CategoryName = "Category-1" }
            };

            using (IClientSessionHandle sessionHandle = await mongoDbService.StartTransactionAsync())
            {


                await userCollection.InsertOneAsync(user1);
                await productCollection.InsertOneAsync(product1);

                await mongoDbService.EndTransactionAsync(sessionHandle);
            }
        }

        [Fact]
        public async Task Should_Rollback()
        {
            IMongoDatabase database = mongoDbService.GetDatabase("TestDb");
            IMongoCollection<User> userCollection = database.GetCollection<User>("Users");
            IMongoCollection<Product> productCollection = database.GetCollection<Product>("Products");

            var user1 = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User1",
                Email = "User1@gmail.com"
            };
            var product1 = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Product-1",
                Category = new ProductCategory { Id = Guid.NewGuid().ToString(), CategoryName = "Category-1" }
            };

            using (IClientSessionHandle sessionHandle = await mongoDbService.StartTransactionAsync())
            {            
                await userCollection.InsertOneAsync(user1);
                await productCollection.InsertOneAsync(product1);

                await mongoDbService.EndTransactionAsync(sessionHandle, false);
            }
        }

    }
}
