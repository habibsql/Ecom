using Ecom.Domain.Entities;
using Ecom.Framework;
using Ecom.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using System.Security;
using Ecom.DomainServices;

namespace Ecom.WebApi.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly IUserRepository userRepository;
        private readonly IExternalUserService externalUserService;

        public AuthenticationService(IUserRepository userRepository, IUserService userService, IExternalUserService externalUserService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
            this.externalUserService = externalUserService;
        }

        public async Task<User> AuthenticateAsync(string userId)
        {
            UserDto userDto = await externalUserService.GetUserInfoAsync(userId);
            User user = await userRepository.GetUserByEmail(userDto.Email);

            // if user not exists in local database, create first for reference
            if (null == user)
            {
                var externalUserCreateCommand = new CreateExternalUserCommand
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber
                };

                user = await userService.RegisterUser(externalUserCreateCommand);                
            }

            return user;
        }
    
    }
}
