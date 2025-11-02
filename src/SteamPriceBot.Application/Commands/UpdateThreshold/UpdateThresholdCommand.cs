using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.UpdateThreshold
{
    public record UpdateThresholdCommand(Guid TrackItemId, decimal NewThreshold) : ICommand;
}