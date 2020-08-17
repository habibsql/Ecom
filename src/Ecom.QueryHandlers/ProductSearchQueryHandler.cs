using Ecom.Domain.Entities;
using Ecom.Framework;
using Ecom.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.Queries
{
    public class ProductSearchQueryHandler : IQueryHandler<ProductSearchQuery, QueryResult>
    {
        private readonly IProductRepository productRepository;
        private readonly IEcomConfigManager ecomConfigManager;

        public ProductSearchQueryHandler(IProductRepository productRepository, IEcomConfigManager ecomConfigManager)
        {
            this.productRepository = productRepository;
            this.ecomConfigManager = ecomConfigManager;
        }

        public async Task<QueryResult> HandleAsync(ProductSearchQuery query)
        {
            IEnumerable<string> fields = ecomConfigManager.GetProductSearchableFields();

            IEnumerable<Product> products = await productRepository.SearchProducts(fields, query.SearchText, query.PageNumber, query.PageSize);

            return ProductMapper.Map(products);
        }
    }
}
