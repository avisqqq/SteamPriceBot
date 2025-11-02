using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.UpdateThreshold
{
    public class UpdateThresholdCommandHandler : ICommandHandler<UpdateThresholdCommand>
    {
        public Task HandleAsync(UpdateThresholdCommand command, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
    }
}