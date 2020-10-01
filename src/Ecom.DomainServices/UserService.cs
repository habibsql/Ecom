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
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IEncrptor encrptor;

        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IEncrptor encrptor)
        {
            this.userRepository = userRepository;
            this.userRoleRepository = userRoleRepository;
            this.encrptor = encrptor;
        }

        public async Task<User> RegisterUser(CreateExternalUserCommand externalUser)
        {
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

        public async Task<User> RegisterUserLocal(CreateLocalUserCommand externalUser)
        {
            UserRole userRole = await userRoleRepository.GetRoleByName(externalUser.RoleName);
            string passwordHash = await encrptor.HashAsync(externalUser.Password);

            var user = new User
            {
                Id = Guid.NewGuid().ToString(),
                Name = externalUser.Name,
                Email = externalUser.Email,
                Phone = externalUser.PhoneNumber,
                Role = userRole,
                Password = passwordHash
            };

            await userRepository.SaveUser(user);

            return user;
        }
    }
}
