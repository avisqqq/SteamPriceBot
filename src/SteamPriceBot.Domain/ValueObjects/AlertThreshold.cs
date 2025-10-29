using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Exceptions;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record AlertThreshold(decimal Amount)
    {
        public static AlertThreshold Create(decimal amount)
        {
            if (amount <= 0)
                throw new DomainException("Alert threshold must be greater than zero.");
            return new AlertThreshold(decimal.Round(amount, 2));
        }
        public bool IsBreachedBy(PriceValue currentPrice) =>
            currentPrice.Amount <= Amount;
    }
}