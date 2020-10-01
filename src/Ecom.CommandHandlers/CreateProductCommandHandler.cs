using Ecom.Commands;
using Ecom.DomainServices;
using Ecom.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.CommandHandlers
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CommandResponse>
    {
        private readonly IProductService productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<CommandResponse> HandleAsync(CreateProductCommand command)
        {
            await productService.CreateProduct(command);

            return new CommandResponse() { };
        }
    }
}
