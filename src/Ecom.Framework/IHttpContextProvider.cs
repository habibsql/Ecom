using Microsoft.AspNetCore.Http;

namespace Ecom.Framework
{
    public interface IHttpContextProvider
    {
        IHttpContextAccessor GetHttpContext();

        LoggedInContext GetLoggedinContext();
    }
}
