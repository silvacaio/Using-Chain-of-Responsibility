
namespace SuperHeroes.Domain.Contexts
{
    public abstract class IPowerJobContext
    {
        public string SuperHero { get; set; }
    }

    public class PowerJobContext : IPowerJobContext
    {

    }
}
