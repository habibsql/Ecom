using Ecom.DomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Ecom.Tests.Unit.Discount
{
    public class PercentageDiscountStratigyTests : BaseTest
    {
        private PercentageDiscountStratigy _percentageDiscountStratigy;

        [Fact]
        public void ShouldDiscountPercentage()
        {
            long price = 1000;

            _percentageDiscountStratigy = new PercentageDiscountStratigy(price);

            long discount = _percentageDiscountStratigy.Discount();

            Assert.Equal(150, discount);
        }
    }
}
