using Ecom.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly IMongoDbService mongoDbService;

        public UserRoleRepository(IMongoDbService mongoDbService)
        {
            this.mongoDbService = mongoDbService;
        }

        public Task<UserRole> GetRoleByName(string roleName)
        {
            IMongoCollection<UserRole> userRoleCollection = mongoDbService.GetCollection<UserRole>(null);

            FilterDefinition<UserRole> filterCriteria = Builders<UserRole>.Filter.Eq(item => item.RoleName, roleName);

            return userRoleCollection.Find(filterCriteria).FirstOrDefaultAsync();
        }
    }
}
