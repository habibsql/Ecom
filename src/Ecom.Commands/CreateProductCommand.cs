using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Commands
{
    public class CreateProductCommand
    {
        public string ProductDescription { get; set; }

        public string ImagePath { get; set; }

        public string CategoryId { get; set; }

        public long Price { get; set; }
    }
}
