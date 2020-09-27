using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Repositories
{
    public interface IMongoService
    {
        IMongoDatabase GetDatabase(string databaseName);

        IMongoDatabase GetDatabase();
    }
}
