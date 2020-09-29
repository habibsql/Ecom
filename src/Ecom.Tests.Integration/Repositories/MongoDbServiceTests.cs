using Ecom.Domain.Entities;
using Ecom.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecom.Tests.Integration.Repositories
{
    public class MongoDbServiceTests
    {
        private readonly IConfiguration configuration = new TestConfig();
        private readonly MongoDbService mongoDbService;

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

    }
}
