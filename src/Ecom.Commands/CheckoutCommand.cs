using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecom.Commands
{
    public class CheckoutCommand : BaseCommand
    {
        public int CouponCode { get; set; }

        public IEnumerable<CheckoutItem> CheckoutItems { get; set; } = new List<CheckoutItem>();

        public long GetTotalPrice()
        {
            long totalPrice = 0;

           foreach(CheckoutItem item in CheckoutItems)
            {
                totalPrice += item.UnitPrice * item.Quantity;
            }

            return totalPrice;
        }

    }

    public class CheckoutItem
    {
        public string ProductId { get; set; }

        public string Description { get; set; }

        public long UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}
