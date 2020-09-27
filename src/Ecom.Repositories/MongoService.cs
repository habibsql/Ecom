using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Repositories
{
    public class MongoService : IMongoService
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoClient mongoClient;

        public MongoService(IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("DefaultConnection");
            mongoClient = new MongoClient(connString);
        }

        public IMongoDatabase GetDatabase(string databaseName)
        {
            if (string.IsNullOrEmpty(databaseName))
            {
                return mongoDatabase;
            }

            return mongoClient.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return mongoDatabase;
        }
    }
}
