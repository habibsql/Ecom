using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public interface IMongoDbService
    {
        /// <summary>
        /// If provide null instead of databasename it will provide default database
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        IMongoDatabase GetDatabase(string databaseName);

        /// <summary>
        /// Convenstion that followed -> Collection name would be pluralize from its type name. ex: UserRole -> UserRoles
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        IMongoCollection<T> GetCollection<T>(string databaseName);

        IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName);

        /// <summary>
        /// Mongodb transaction supported from mongodb version 4.2 or later
        /// </summary>
        /// <returns></returns>
        Task<IClientSessionHandle> StartTransactionAsync();

        /// <summary>
        /// End of the transaction either commit or rollback
        /// </summary>
        /// <param name="sessionHandle"></param>
        /// <param name="commit"></param>
        /// <returns></returns>
        Task EndTransactionAsync(IClientSessionHandle sessionHandle, bool commit = true);
    }
}
