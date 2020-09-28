using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public interface IMongoDbService
    {
        IMongoDatabase GetDatabase(string databaseName);

        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName);

        Task<IClientSessionHandle> StartTransactionAsync();

        Task EndTransactionAsync(IClientSessionHandle sessionHandle, bool commit = true);
    }
}
