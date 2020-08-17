using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Domain.Entities
{
    public class Product : BaseEntity
    {
        /// <summary>
        /// Description of the product
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Refer to the external source (aws s3, azure blob storage)
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Current price of the product
        /// </summary>
        public long Price { get; set; }

        /// <summary>
        /// Category of the product
        /// </summary>
        public ProductCategory Category { get; set; }
    }
}
