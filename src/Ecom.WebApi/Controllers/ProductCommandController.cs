using Ecom.Commands;
using Ecom.Framework;
using Ecom.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.WebApi.Controllers
{
    public class ProductCommandController : ControllerBase
    {
        private readonly CommandManager commandManager;

        public ProductCommandController(CommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        [HttpPost]
        public async Task<CommandResponse> CreateProduct([FromBody] CreateProductCommand command)
        {
            return await commandManager.ExecuteAsync<CreateProductCommand, CommandResponse>(command);
        }

        [HttpPost]
        public async Task<CommandResponse> Checkout([FromBody] CheckoutCommand command)
        {
            return await commandManager.ExecuteAsync<CheckoutCommand, CommandResponse>(command);
        }

    }
}
