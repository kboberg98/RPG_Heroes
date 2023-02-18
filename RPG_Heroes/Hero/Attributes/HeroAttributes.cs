using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Attributes
{
    class HeroAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        /*public HeroAttributes Add(HeroAttributes other)
        {
            return new HeroAttributes(
                Strength + other.Strength,
                Dexterity + other.Dexterity,
                Intelligence + other.Intelligence);
        }*/

        public HeroAttributes Increase(int strength, int dexterity, int intelligence)
        {
            Strength += strength;
            Dexterity += dexterity;
            Intelligence += intelligence;
            return this;
        }
    }
}
