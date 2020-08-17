using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public Task<Product> GetProductById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> SearchProducts(IEnumerable<string> searchableFields, string searchText, int pageNumber, int pageSize)
        { 
            IEnumerable<Product> productList = new List<Product> { new Product { Id = Guid.NewGuid().ToString() }, new Product { Id = Guid.NewGuid().ToString() } };

            return await Task.FromResult(productList);
        }
    }
}
