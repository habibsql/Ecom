using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<User> GetUserByEmail(string email)
        {
            // Todo: Mongodb will be used later
            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = email,
                Email = email,
                Role = new UserRole { RoleName = "Customer" }
            };

            return await Task.FromResult(user);
        }

        public Task SaveUser(User user)
        {
            //TODO: Save User object to the Mongodatabase using C# Mongodriver

            return Task.CompletedTask;
        }
    } // end class
}
