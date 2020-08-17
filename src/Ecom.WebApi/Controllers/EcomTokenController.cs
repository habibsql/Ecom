using Ecom.Commands;
using Ecom.Domain.Entities;
using Ecom.Framework;
using Ecom.Queries;
using Ecom.WebApi.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace Ecom.WebApi.Controllers
{
    public class EcomTokenController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly ITokenService tokenService;

        public EcomTokenController(IAuthenticationService authenticationService, ITokenService tokenService)
        {
            this.authenticationService = authenticationService;
            this.tokenService = tokenService;
        }

        [HttpPost]
        public async Task<string> Token([FromBody] UserInfo  userInfo)
        {
            User user = await authenticationService.AuthenticateAsync(userInfo.UserId);
            string token = await tokenService.GenerateToken(user);

            return token;
        }

    }

    public class UserInfo
    {
        public string UserId { get; set; }
    }
}
