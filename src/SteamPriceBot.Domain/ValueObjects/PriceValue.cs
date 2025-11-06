using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SteamPriceBot.Domain.Exceptions;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record PriceValue
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; } = null!;

        private PriceValue(){} //EF CORE

        public PriceValue(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
        public static PriceValue Create(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new DomainException("Price cannot be negative");
            return new PriceValue(decimal.Round(amount, 2), currency);
        }

        public override string ToString() => $"{Amount} {Currency}";
    }
}