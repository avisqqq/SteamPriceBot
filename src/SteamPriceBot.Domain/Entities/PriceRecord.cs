using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Common;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Domain.Entities
{
    public class PriceRecord : EntityBase
    {
        public Guid TrackedItemId { get; private set; }
        public DateTime TimestampUtc { get; init; } = DateTime.UtcNow;
        public PriceValue Price { get; private set; } = null!;
        public PriceRecord(Guid trackedItemId, PriceValue price)
        {
            TrackedItemId = trackedItemId;
            Price = price;
        }
        private PriceRecord() { } // EF Core
    }
}