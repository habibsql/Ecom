using Ecom.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.WebApi.Identity
{
    public class JwtTokenService : ITokenService
    {
        public Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApiConstants.JwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ApiConstants.UserIdClaim, user.Id),
                new Claim(ApiConstants.UserNameClaim, user.Name),
                new Claim(ApiConstants.EmailClaim, user.Email),
                new Claim(ApiConstants.RoleClaim, user.Role.RoleName)
            };

            var token = new JwtSecurityToken(ApiConstants.JwtIssuer,
                   ApiConstants.JwtAudence,
                   claims,
                   expires: DateTime.Now.AddHours(8),
                   signingCredentials: credentials) ;

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            string tokenString =jwtTokenHandler.WriteToken(token);

            return Task.FromResult( tokenString);
        }
    }
}
