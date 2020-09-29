using Ecom.Domain.Entities;
using Ecom.Repositories;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Ecom.Tests.Integration.Repositorories
{
    public class ProductRepositoryTests
    {
        private readonly IMongoDbService mongoDbService;
        private ProductRepository productRepository;

        public ProductRepositoryTests()
        {
            mongoDbService = new MongoDbService(new TestConfig());
        }

        [Fact]
        public async Task Should_SaveProduct()
        {
            productRepository = new ProductRepository(mongoDbService);

            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Product-1",
                Category = new ProductCategory() { Id = Guid.NewGuid().ToString(), CategoryName = "Category-1" },
                Price = 100 
            };

            await productRepository.SaveProduct(product);
        }


        [Fact]
        public async Task Should_UpdateProduct()
        {
            productRepository = new ProductRepository(mongoDbService);

            string existingProductId = "b1a4844d-93ae-416d-a6f0-9dfd89b0ba61";

            var product = new Product
            {
                Id = existingProductId,
                Description = "Product-200",               
                Price = 200
            };

            await productRepository.SaveProduct(product);
        }
    }
}
