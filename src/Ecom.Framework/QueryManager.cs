using System;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public class QueryManager
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> ExecuteAsync<TQuery, TResponse>(TQuery query)
        {
            var queryHandler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>)) as IQueryHandler<TQuery, TResponse>;

            return queryHandler.HandleAsync(query);
        }
    }
}