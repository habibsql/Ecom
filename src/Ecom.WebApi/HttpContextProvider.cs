using Ecom.Framework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecom.WebApi
{
    public class HttpContextProvider : IHttpContextProvider
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public HttpContextProvider(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public IHttpContextAccessor GetHttpContext()
        {
            return httpContextAccessor;
        }

        public LoggedInContext GetLoggedinContext()
        {
            ClaimsPrincipal claimsPrinciple = httpContextAccessor.HttpContext.User;

            bool authenticated = claimsPrinciple.Identity.IsAuthenticated;

            if (!authenticated)
            {
                return null;
            }

            string userId = claimsPrinciple.Claims.Where(c => c.Type == ApiConstants.UserIdClaim).First().Value;
            string userName = claimsPrinciple.Claims.Where(c => c.Type == ApiConstants.UserNameClaim).First().Value;
            string email = claimsPrinciple.Claims.Where(c => c.Type == ApiConstants.EmailClaim).First().Value;
            string role = claimsPrinciple.Claims.Where(c => c.Type == ApiConstants.RoleClaim).First().Value;

            return new LoggedInContext(userId, userName, email, role);
        }
      
    }
}
