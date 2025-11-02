using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.TrackItem
{
    public class TrackItemCommandHandler : ICommandHandler<TrackItemCommand>
    {
        public Task HandleAsync(TrackItemCommand command, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}