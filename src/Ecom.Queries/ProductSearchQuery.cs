using Ecom.Framework;
using System;

namespace Ecom.Queries
{
    public class ProductSearchQuery : BaseQuery
    {
        public string SearchText { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
