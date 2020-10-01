using Ecom.Domain.Entities;
using Ecom.Framework;
using System.Threading.Tasks;

namespace Ecom.DomainServices
{
    public interface IUserService
    {
        /// <summary>
        /// User create from external source
        /// </summary>
        /// <param name="externalUser"></param>
        /// <returns></returns>
        Task<User> RegisterUser(CreateExternalUserCommand externalUser);

        /// <summary>
        /// Local user creation
        /// </summary>
        /// <param name="localUser"></param>
        /// <returns></returns>
        Task<User> RegisterUserLocal(CreateLocalUserCommand localUser);
    }
}
