using Ecom.Commands;
using Ecom.DomainServices;
using Ecom.Framework;
using System;
using System.Threading.Tasks;

namespace Ecom.Commands
{
    public class CheckoutCommandHandler : ICommandHandler<CheckoutCommand, CommandResponse>
    {
        private readonly IProductService productService;

        public CheckoutCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<CommandResponse> HandleAsync(CheckoutCommand command)
        {
           await this.productService.Checkout(command);

            return new CommandResponse();
        }
    }
}
