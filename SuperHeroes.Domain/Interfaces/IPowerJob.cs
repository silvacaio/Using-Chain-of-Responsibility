using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Core.Results;
using SuperHeroes.Domain.Models;

namespace Convert.Domain.Interfaces
{
    public abstract class IPowerJob
    {
        public abstract Result<Power> GetPower(IPowerJobContext context);
    }
}
