using SuperHeroes.Domain.Core.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroes.Domain.Core.Results
{
    public class Result<TSuccess>
    {
        internal Result(TSuccess success)
        {
            Success = success;
            IsError = false;
            IsAnotherRule = false;
        }

        internal Result(string error)
        {
            IsError = true;
            IsAnotherRule = false;
            Error = error;
        }

        internal Result()
        {
            IsError = false;
            IsAnotherRule = true;
        }

        public bool IsSuccess { get { return Success != null; } }
        public bool IsError { get; set; }
        public bool IsAnotherRule { get; set; }
        public TSuccess Success { get; set; }
        public Error Error { get; set; }

        public static implicit operator Result<TSuccess>(string msg)
            => new Result<TSuccess>(msg);

        public static implicit operator Result<TSuccess>(TSuccess success)
           => new Result<TSuccess>(success);
      
        public static Result<TSuccess> ICantResolver()
        {
            return new Result<TSuccess>();
        }
    }
}
