using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Domain.Entities
{
    public class PriceRecord
    {
        public DateTime TimestampUtc { get; init; } = DateTime.UtcNow;
        public PriceValue Price { get; init; }
        public PriceRecord(PriceValue price)
        {
            Price = price;
        }
    }
}