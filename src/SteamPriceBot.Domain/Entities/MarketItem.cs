using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Common;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Domain.Entities
{
    public class MarketItem : EntityBase
    {
        public ItemId ItemId { get; private set; }
        public string DisplayName { get; private set; }

        private readonly List<PriceRecord> _priceHistory = new();
        public IReadOnlyCollection<PriceRecord> PriceHistory => _priceHistory.AsReadOnly();
        public MarketItem(ItemId itemId, string displayName)
        {
            ItemId = itemId;
            DisplayName = displayName;
        }

        public void AddPriceRecord(PriceRecord priceRecord)
        {
            _priceHistory.Add(priceRecord);
        }
    }
}