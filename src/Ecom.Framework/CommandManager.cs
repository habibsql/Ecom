using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public class CommandManager
    {
        private readonly IServiceProvider serviceProvider;

        public CommandManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> ExecuteAsync<TCommand, TResponse>(TCommand command)
        {
            var commandHandler = (ICommandHandler<TCommand, TResponse>)serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResponse>));

            return await commandHandler.HandleAsync(command);
        }
    }
}