using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;

namespace Convert.Domain.Interfaces.Powers
{
    public abstract class IPower
    {
        protected IPower(IPower next)
        {
            _next = next;
        }

        protected IPower _next { get; set; }

        public virtual Result<Power> GetPower(IPowerContext context)
        {
            var result = CalculatePower(context);
            if (result.IsSuccess || result.IsError)
                return result;

            if (result.IsAnotherRule && _next != null)
                return _next.GetPower(context);

            return "Este Super herói não tem poderes!?";
        }

        protected abstract Result<Power> CalculatePower(IPowerContext context);
    }
}
