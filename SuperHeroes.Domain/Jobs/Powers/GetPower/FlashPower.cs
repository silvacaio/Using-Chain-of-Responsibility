using Convert.Domain.Interfaces.Powers;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;
using System;

namespace SuperHeroes.Domain.Jobs.Powers.GetPower
{
    public class FlashPower : IPower
    {
        public FlashPower(IPower next) : base(next)
        {
        }

        protected override Result<Power> CalculatePower(IPowerContext context)
        {
            if (String.Compare(context.SuperHero, "Flash", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return new Power(context.SuperHero, "Speed", 700);
            }

            return Result<Power>.ICantResolver();
        }
    }
}
