
namespace SuperHeroes.Domain.Contexts
{
    public abstract class IPowerContext
    {
        public string SuperHero { get; protected set; }

        public abstract void Create(string superHero);
    }

    public class PowerContext : IPowerContext
    {
        public override void Create(string superHero)
        {
            SuperHero = superHero;
        }
    }
}
