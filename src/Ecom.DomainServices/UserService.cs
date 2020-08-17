using Ecom.Domain.Entities;
using Ecom.Framework;
using Ecom.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DomainServices
{
    public class UserService : IUserService
    {
        private const string CustomerRoleName = "Customer";
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> RegisterUser(ExternalUserInfo externalUser)
        {
            //TODO: validation...

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = externalUser.Name,
                Email = externalUser.Email,
                Phone = externalUser.PhoneNumber,
                Role = new UserRole() { RoleName = CustomerRoleName }
            };

            await userRepository.SaveUser(user);

            return user;
        }
    }
}
