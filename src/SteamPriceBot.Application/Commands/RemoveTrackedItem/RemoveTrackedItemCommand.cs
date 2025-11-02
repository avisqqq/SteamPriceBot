using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.RemoveTrackedItem
{
    public record RemoveTrackedItemCommand(Guid TrackedItemId) : ICommand;
}