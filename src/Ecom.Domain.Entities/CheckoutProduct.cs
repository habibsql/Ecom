using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Domain.Entities
{
    public class CheckoutProduct : BaseEntity
    {
        public string ProductId { get; set; }

        public string Description { get; set; }

        public long UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
