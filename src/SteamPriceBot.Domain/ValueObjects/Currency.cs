using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPriceBot.Domain.ValueObjects
{
    public sealed record Currency
    {
        private Currency() { } //EF Core

        public Currency(string code) { FromCode(code); } 

        public string Code { get; private set; } = "USD";
        public static readonly Currency USD = new() { Code = "USD"};
        public static readonly Currency EUR = new(){ Code = "EUR"};
        public static readonly Currency UAH = new(){ Code = "UAH"};
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