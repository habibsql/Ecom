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
        private readonly string DefaultDatabaseName;

        public string DefaultDatabaseName1 => DefaultDatabaseName;

        public MongoDbService(IConfiguration configuration)
        {
            string connString = configuration.GetConnectionString("DefaultConnection");           
            DefaultDatabaseName = configuration.GetConnectionString("DefaultDatabase");
            mongoClient = new MongoClient(connString);
            mongoDatabase = mongoClient.GetDatabase(DefaultDatabaseName);
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
            IMongoDatabase database = string.IsNullOrEmpty(databaseName) ? mongoClient.GetDatabase(DefaultDatabaseName) : mongoClient.GetDatabase(databaseName);

            return database.GetCollection<T>(collectionName);
        }

        public IMongoCollection<T> GetCollection<T>(string databaseName)
        {
            IMongoDatabase database = string.IsNullOrEmpty(databaseName) ? mongoClient.GetDatabase(DefaultDatabaseName) : mongoClient.GetDatabase(databaseName);

            return database.GetCollection<T>($"{typeof(T).Name}s");
        }

        public Task<IClientSessionHandle> StartTransactionAsync()
        {
            var sessionOptions = new ClientSessionOptions
            {
                CausalConsistency = true,

            };
            sessionOptions.DefaultTransactionOptions = new TransactionOptions();

            return mongoClient.StartSessionAsync();
        }

        public Task EndTransactionAsync(IClientSessionHandle sessionHandle, bool commit)
        {
            if (null == sessionHandle)            
                throw new ArgumentNullException("SessionHandle should not be null");            

            if (!sessionHandle.IsInTransaction)
            {               
                return Task.CompletedTask;
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
