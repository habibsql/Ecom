using log4net.Core;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;

namespace Ecom.Framework
{
    public class EcomSecurityContext
    {
        public const string EmailClaim = "email";
        public const string NameClaim = "name";
        public const string RoleClaim = "role";
        public const string SubjectClaim = "sub";
        public const string UserLoggedINClaim = "user_loggedin";
        public const string OriginClaim = "origin";
        public const string UserIdClaim = "user_Id";
        public const string UserExpireOnClaim = "user_expire_on";

        public string Email { get; }
        public string Name { get; }
        public string Role { get; }
        public DateTime UserExpireOn { get; }
        public bool Authenticated { get; }
        public string UserId { get; }


        public EcomSecurityContext(ClaimsIdentity claimsIdentity)
        {
            Name = claimsIdentity.Claims.First(claim => claim.Type.Equals(NameClaim)).Value;
            Email = claimsIdentity.Claims.First(claim => claim.Type.Equals(EmailClaim)).Value;
            Role = claimsIdentity.Claims.First(claim => claim.Type.Equals(RoleClaim)).Value;
            UserExpireOn = DateTime.Today.AddHours(2); // 2 hours lifetime
            UserId = claimsIdentity.Claims.First(claim => claim.Type.Equals(UserIdClaim)).Value;
        }
 
        public EcomSecurityContext(string name, string email, string role, bool authenticated, string userId)
        {
            this.Name = name;
            this.Email = email;
            this.Role = role;
            this.Authenticated = authenticated;
            this.UserId = userId;
        }
    }
}
