using Ecom.Commands;
using Ecom.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DomainServices
{
    public interface IProductService
    {
        Task Checkout(CheckoutCommand command);
    }
}
