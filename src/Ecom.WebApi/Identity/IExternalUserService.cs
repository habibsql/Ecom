using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebApi.Identity
{
    /// <summary>
    /// Contract will be honored for various 3rd party authenticatio providers like google/facebook/linkedin etc...
    /// </summary>
    public interface IExternalUserService
    {
        Task<ExternalUserInfo> GetUserInfoAsync(string email);
    }
}
