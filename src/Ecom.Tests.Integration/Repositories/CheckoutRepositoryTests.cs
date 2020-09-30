using Ecom.Domain.Entities;
using Ecom.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ecom.Tests.Integration.Repositories
{
    public class CheckoutRepositoryTests
    {
        private CheckoutRepository checkoutRepository;
        private readonly IConfiguration configuration = new TestConfig();
        private readonly IMongoDbService mongoDbService;

        public CheckoutRepositoryTests()
        {
            mongoDbService = new MongoDbService(configuration);
            checkoutRepository = new CheckoutRepository(mongoDbService);
        }

        [Fact]
        public async Task ShouldSave()
        {
            var product1 = new CheckoutProduct { Id = Guid.NewGuid().ToString(), Description = "Product-1", ProductId = Guid.NewGuid().ToString(), Quantity = 2, UnitPrice = 200 };
            var product2 = new CheckoutProduct { Id = Guid.NewGuid().ToString(), Description = "Product-2", ProductId = Guid.NewGuid().ToString(), Quantity = 1, UnitPrice = 400 };
            var product3 = new CheckoutProduct { Id = Guid.NewGuid().ToString(), Description = "Product-3", ProductId = Guid.NewGuid().ToString(), Quantity = 2, UnitPrice = 100 };

            var checkout = new Checkout
            {
                Id = Guid.NewGuid().ToString(),
                CheckeoutBy = new User { Id = Guid.NewGuid().ToString(),Name = "test@email.com"},
                TotalAmount = 1000,
                Discount = 100,
                CouponCode = "123",
                CheckoutProducts = new List<CheckoutProduct> { product1, product2, product3}
            };

            await checkoutRepository.Save(checkout);
        }

    }
}
