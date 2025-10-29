using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Entities;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Domain.Events
{
    public sealed record PriceThresholdReached(MarketItem Item,
    PriceValue CurrentPrice,
    AlertThreshold Threshold);
        
    
}