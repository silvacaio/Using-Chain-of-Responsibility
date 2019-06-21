using Convert.Domain.Interfaces.Powers;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;
using System;

namespace SuperHeroes.Domain.Jobs.Powers.GetPower
{
    public class HulkPower : IPower
    {
        public HulkPower(IPower next) : base(next)
        {
        }

        protected override Result<Power> CalculatePower(IPowerContext context)
        {
            if (string.Compare(context.SuperHero, "Hulk", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return new Power(context.SuperHero, "Force", 900);
            }

            return Result<Power>.ICantResolver();
        }
    }
}
