using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroes.Domain.Models
{
    public class Power
    { 
        public Power(string nameHero, string name, int damage)
        {
            NameHero = nameHero;
            Name = name;
            Damage = damage;
        }

        public string NameHero { get; private set; }
        public string Name { get; private set; }
        public int Damage { get; private set; }
    }
}
