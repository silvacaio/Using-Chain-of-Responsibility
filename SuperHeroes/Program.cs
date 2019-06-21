using Convert.Domain.Interfaces.Powers;
using SuperHeroes.Domain.Contexts;
using SuperHeroes.Domain.Jobs.Powers;
using SuperHeroes.Domain.Jobs.Powers.GetPower;
using System;

namespace SuperHeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            var power = RegisterDependencies();

            Resolve(power, "Batman");
            Resolve(power, "Flash");
            Resolve(power, "SuperDog");
            Resolve(power, "Hulk");

            Console.ReadLine();

        }

        private static void Resolve(IPower power, string heroi)
        {
            PowerContext context = new PowerContext();
            PowerJobContext contextJob = new PowerJobContext();
            PowerJob job = new PowerJob(power, context);

            contextJob.SuperHero = heroi;

            var result = job.GetPower(contextJob);

            if (result.IsSuccess)
            {
                Console.WriteLine($"Herói: {result.Success.NameHero}");
                Console.WriteLine($"Poder: {result.Success.Name}");
                Console.WriteLine($"Dano: {result.Success.Damage}");
            }
            else
            {
                Console.WriteLine($"Herói: {heroi }");
                Console.WriteLine($"Error: {result.Error.Msg }");
            }

            Console.WriteLine();
            Console.WriteLine("// ------------------------ //");
            Console.WriteLine();
        }

        private static IPower RegisterDependencies()
        {
            //In a real project, this part must be with dependency injection using decorators...
            BatmanPower batman = new BatmanPower(null);
            HulkPower hulk = new HulkPower(batman);
            FlashPower flash = new FlashPower(hulk);
            return flash;
        }
    }
}
