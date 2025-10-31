using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.SteamPriceBot.Application.Common
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, CancellationToken cd = default);
    }
}