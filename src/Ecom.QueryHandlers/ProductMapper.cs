using Ecom.Domain.Entities;
using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Queries
{
    public static class ProductMapper
    {
        public static QueryResult Map(IEnumerable<Product> products)
        {
            var queryResult = new QueryResult
            {
                Items = products
            };

            return queryResult;
        }
    }
}
