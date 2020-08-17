using Ecom.Domain.Entities;
using Ecom.Framework;
using System.Threading.Tasks;

namespace Ecom.DomainServices
{
    public interface IUserService
    {
        Task<User> RegisterUser(ExternalUserInfo externalUser);
    }
}
