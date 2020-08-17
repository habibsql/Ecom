using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Framework
{
    public class QueryResult
    {
        public IEnumerable<object> Items { get; set; } = new List<object>();

        public long TotalCount { get; set; }
    }
}
