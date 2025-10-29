using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteamPriceBot.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string msg) : base(msg){}
    }
}