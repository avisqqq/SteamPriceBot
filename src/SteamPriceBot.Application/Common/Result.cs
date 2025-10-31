using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.SteamPriceBot.Application.Common
{
    public sealed class Result<T>
    {
        public bool Success { get; }
        public string? Error { get; }
        public T? Value { get; }

        private Result(bool success, T? value, string? error)
        {
            Success = success;
            Error = error;
            Value = value;
        }
        public static Result<T> Ok(T value) => new(true, value, null);
        public static Result<T> Fail(string error) => new(false, default, error);
    }
}