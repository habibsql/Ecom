using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Repositories
{
    public interface ICheckoutRepository : IRepository<Checkout>
    {
        void Save(Checkout checkout);
    }
}
