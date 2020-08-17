using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.DomainServices
{
    public interface IDiscountStratigyProvider
    {
        IDiscountStratigy CreateDiscountStratigy(int couponCode, long productPrice);
    }
}
