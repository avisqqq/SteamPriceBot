using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Exceptions;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record PriceValue(decimal Amount, Currency Currency)
    {
        public static PriceValue Create(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new DomainException("Price cannot be negative");
            return new PriceValue(decimal.Round(amount, 2), currency);
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}