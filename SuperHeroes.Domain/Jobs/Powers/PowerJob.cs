using Convert.Domain.Interfaces;
using Convert.Domain.Interfaces.Powers;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;

namespace SuperHeroes.Domain.Jobs.Powers
{
    public class PowerJob : IPowerJob
    {
        public IPower _power;
        public IPowerContext _powerContext;

        public PowerJob(IPower power, IPowerContext powerContext)
        {
            _power = power;
            _powerContext = powerContext;
        }

        public override Result<Power> GetPower(IPowerJobContext context)
        {
            _powerContext.Create(context.SuperHero);
            return _power.GetPower(_powerContext);
        }
    }
}
