using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.RemoveTrackedItem
{
    public class RemoveTrackedItemCommandHandler : ICommandHandler<RemoveTrackedItemCommand>
    {
        public Task HandleAsync(RemoveTrackedItemCommand command, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}