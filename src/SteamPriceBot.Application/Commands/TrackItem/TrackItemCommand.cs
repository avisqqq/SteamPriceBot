using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Application.Common;

namespace SteamPriceBot.Application.Commands.TrackItem
{
    public record TrackItemCommand(string MarketHashName, decimal? AlertThereshold, string CurrencyCode) : ICommand;
}