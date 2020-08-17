using Ecom.DomainServices;
using Xunit;

namespace Ecom.Tests.Unit.Discount
{
    public class PercentageLimitDiscountStratigyTests : BaseTest
    {
        private PercentageLimitDiscountStratigy _percentageLimitDiscountStratigy;

        [Fact]
        public void ShouldDiscountPercentage()
        {
            long price = 1800;

            _percentageLimitDiscountStratigy = new PercentageLimitDiscountStratigy(price);

            long discount = _percentageLimitDiscountStratigy.Discount();

            Assert.Equal(270, discount);
        }

        [Fact]
        public void ShouldDiscountMaxRateWithIgnoringActualCalculatedDiscount()
        {
            long price = 3000;

            _percentageLimitDiscountStratigy = new PercentageLimitDiscountStratigy(price);

            long discount = _percentageLimitDiscountStratigy.Discount();

            Assert.Equal(300, discount);
        }

    }
}
