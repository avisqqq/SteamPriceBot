using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record ItemId(int AppId, string MarketHashName)
    {
        public override string ToString() => $"{AppId} : {MarketHashName}";
    }
}