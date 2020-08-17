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
        public async Task<CommandResponse> Checkout([FromBody] CheckoutCommand command)
        {
            CommandResponse response = await commandManager.ExecuteAsync<CheckoutCommand, CommandResponse>(command);

            return response;
        }
    }
}
