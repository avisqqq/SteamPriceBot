using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record Currency(string Code)
    {
        public static readonly Currency USD = new("USD");
        public static readonly Currency EUR = new("EUR");
        public static readonly Currency UAH = new("UAH");
        public static Currency FromCode(string code)
        {
            code = code.ToUpperInvariant();
            return code switch
            {
                "USD" => USD,
                "EUR" => EUR,
                "UAH" => UAH,
                _ => new Currency($"Unsupported currency code: {code}"),
            };
        }
        public override string ToString() => Code;
    }
}