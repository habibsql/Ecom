using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebApi.Identity
{
    public interface ITokenService
    {
        /// <summary>
        /// Generatetoken for authorization request
        /// </summary>
        /// <param name="user">User Entity</param>
        /// <returns></returns>
        Task<string> GenerateToken(User user);
    }
}
