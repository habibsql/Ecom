using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebApi
{
    public class ApiConstants
    {
        public const string JwtKey = "ecom-secrate-key";
        public const string JwtIssuer = "http://localhost.com";
        public const string JwtAudence = "Ecom-Audience";

        public const string UserIdClaim = "userIdClaim";
        public const string UserNameClaim = "userNameClaim";
        public const string EmailClaim = "emailClaim";
        public const string RoleClaim = "roleClaim";
    }
}
