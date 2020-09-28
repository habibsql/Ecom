using Ecom.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDbService mongoDbService;

        public UserRepository(IMongoDbService mongoDbService)
        {
            this.mongoDbService = mongoDbService;
        }

        public Task<User> GetUserByEmail(string email)
        {
            IMongoCollection<User> userCollection = mongoDbService.GetCollection<User>(null, "Users");

            FilterDefinition<User> filter = Builders<User>.Filter.Eq(item => item.Email, email);

            IFindFluent<User, User> userFluent = userCollection.Find(filter);          

            return Task.FromResult(userFluent.FirstOrDefault());
        }

        public Task SaveUser(User user)
        {
            IMongoCollection<User> userCollection = mongoDbService.GetCollection<User>(null, "Users");

            return userCollection.ReplaceOneAsync<User>(item => item.Id == user.Id, user, new ReplaceOptions { IsUpsert = true });
        }

    } // end class
}
