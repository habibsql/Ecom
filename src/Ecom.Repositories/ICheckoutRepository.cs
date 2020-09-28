using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Repositories
{
    public interface ICheckoutRepository : IRepository<Checkout>
    {
        Task Save(Checkout checkout);
    }
}
