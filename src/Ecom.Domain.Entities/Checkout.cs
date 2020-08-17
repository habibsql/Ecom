using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Domain.Entities
{
    public class Checkout : BaseEntity
    {
        /// <summary>
        /// List of products which need to checkout
        /// </summary>
        public IList<CheckoutProduct> CheckoutProducts { get; set; }

        /// <summary>
        /// Utc Datetime of the checkout
        /// </summary>
        public DateTime CheckeoutOn { get; set; }

        public string CouponCode { get; set; }

        public long TotalAmount { get; set; }

        /// <summary>
        /// Will generated based on business policy
        /// </summary>
        public long Discount { get; set; }

        public long PayableAmount { get => TotalAmount - Discount; }

        /// <summary>
        /// Customer who did the checkout
        /// </summary>
        public User CheckeoutBy { get; set; }

    }
}
