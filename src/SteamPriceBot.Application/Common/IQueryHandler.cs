using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.SteamPriceBot.Application.Common
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query, CancellationToken ct = default);
    }
}