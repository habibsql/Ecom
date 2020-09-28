using Ecom.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver.Core.Operations;

namespace Ecom.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoDbService mongoDbService;

        public ProductRepository(IMongoDbService mongoService)
        {
            this.mongoDbService = mongoService;
        }

        public Task<Product> GetProductById(Guid guid)
        {
            IMongoCollection<Product> productCollection = mongoDbService.GetCollection<Product>(null, "Products");

            FilterDefinition<Product> filterClause = Builders<Product>.Filter.Eq(item => item.Id, guid.ToString());

            IFindFluent<Product, Product> product = productCollection.Find(filterClause);

            return Task.FromResult<Product>(product.FirstOrDefault());
        }

        public async Task<IEnumerable<Product>> SearchProducts(IEnumerable<string> searchableFields, string searchText, int pageNumber, int pageSize)
        {
            IMongoCollection<Product> productCollection = mongoDbService.GetCollection<Product>(null, "Products");
            var filterClauses = new List<FilterDefinition<Product>>();

            foreach (string field in searchableFields)
            {
                FilterDefinition<Product> filterClause = Builders<Product>.Filter.Eq(item => field, searchText);

                filterClauses.Add(filterClause);
            }

            FilterDefinition<Product> productFilter = Builders<Product>.Filter.Or(filterClauses);
            IFindFluent<Product, Product> productFluentList = productCollection.Find<Product>(productFilter);

            int skip = (pageNumber - 1) * pageSize;
            productFluentList.Skip(skip).Limit(pageSize);

            return await productFluentList.ToListAsync();
        }

        public Task SaveProduct(Product product)
        {
            IMongoCollection<Product> productCollection = mongoDbService.GetCollection<Product>(null, "Products");

            FilterDefinition<Product> replaceFilter = Builders<Product>.Filter.Eq(item => item.Id, product.Id);

            return productCollection.ReplaceOneAsync(replaceFilter, product, new ReplaceOptions { IsUpsert = true });
        }

    }
}
