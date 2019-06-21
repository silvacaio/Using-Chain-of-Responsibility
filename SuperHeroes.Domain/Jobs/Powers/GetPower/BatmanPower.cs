using Convert.Domain.Interfaces.Powers;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;
using System;

namespace SuperHeroes.Domain.Jobs.Powers.GetPower
{
    public class BatmanPower : IPower
    {
        public BatmanPower(IPower next) : base(next)
        {
        }

        protected override Result<Power> CalculatePower(IPowerContext context)
        {
            if (string.Compare(context.SuperHero, "Batman", StringComparison.InvariantCultureIgnoreCase) == 0) 
            {
                return new Power(context.SuperHero, "All powers, because I HAVE MONEY", 1000);
            }

            return Result<Power>.ICantResolver();
        }
    }
}
