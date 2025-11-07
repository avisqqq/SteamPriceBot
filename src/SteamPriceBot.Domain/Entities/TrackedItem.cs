using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Common;
using SteamPriceBot.Domain.Events;
using SteamPriceBot.Domain.ValueObjects;

namespace SteamPriceBot.Domain.Entities
{
    public class TrackedItem : EntityBase
    {
        public MarketItem? Item { get; private set; }
        public AlertThreshold? Threshold { get; private set; }
        public TrackedItem(MarketItem item, AlertThreshold? threshold = null)
        {
            Item = item;
            Threshold = threshold;
        }

        public void UpdateThreshold(AlertThreshold threshold)
        {
            Threshold = threshold;
        }

        
        private TrackedItem(){} // EF Core
        public void EvaluatePrice(PriceValue current)
        {
            if (Threshold is null)
                return;
            if (Threshold.IsBreachedBy(current))
            {
                AddDomainEvent(new PriceThresholdReached(Item!, current, Threshold));
            }
        }
    }
}