using Ecom.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecom.Tests.Unit.Discount
{
    public class FlatRateDiscountStratigyTests : BaseTest
    {
        private FlatRateDiscountStratigy _flatRateDiscountStratigy;

        [Fact]
        public void ShouldDiscountFixedAmount()
        {
            long price = 1000;

            _flatRateDiscountStratigy = new FlatRateDiscountStratigy(price);

            long discount = _flatRateDiscountStratigy.Discount();

            Assert.Equal(700, discount);
        }
    }
}
