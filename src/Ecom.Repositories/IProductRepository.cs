using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchProducts(IEnumerable<string> searchableFields, string searchText, int pageNumber, int pageSize);

        Task<Product> GetProductById(Guid guid);

        Task SaveProduct(Product product);
    }
}
