using Ecom.Framework;
using System;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public interface IQueryHandler<TQuery, TResponse>
    {
        Task<TResponse> HandleAsync(TQuery query);
    }
}
