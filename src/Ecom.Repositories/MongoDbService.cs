using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoDatabase mongoDatabase;
        private readonly IMongoClient mongoClient;

        public MongoDbService(IConfiguration configuration)
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

        public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName)
        {
            IMongoDatabase database = string.IsNullOrEmpty(databaseName) ? mongoDatabase : mongoClient.GetDatabase(databaseName);

            return database.GetCollection<T>(collectionName);
        }

        public Task<IClientSessionHandle> StartTransactionAsync()
        {
            return mongoClient.StartSessionAsync();
        }

        public Task EndTransactionAsync(IClientSessionHandle sessionHandle, bool commit)
        {
            if (null == sessionHandle)
            {
                throw new ArgumentNullException("SessionHandle should not be null");
            }

            if (commit)
            {
                return sessionHandle.CommitTransactionAsync();
            } 
            else
            {
                return sessionHandle.AbortTransactionAsync();
            }
        }
    }
}
