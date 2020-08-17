using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public interface ICommandHandler<TCommand, CommandResponse>
    {
        Task<CommandResponse> HandleAsync(TCommand command);
    }
}
