using Ecom.Domain.Entities;
using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.WebApi.Identity
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// UserId will be Email. Password will be managed by Thirdpaty authentication provider
        /// The worflow is -> When user provided userid, first checked local database, if found generate token based on that.
        /// Otherwise check Google server and retrive google user info and create a local user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<User> AuthenticateAsync(string userId);
    }
}
