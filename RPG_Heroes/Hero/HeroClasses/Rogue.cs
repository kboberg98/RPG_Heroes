using RPG_Heroes.Hero.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG_Heroes.Hero.HeroClasses
{
    class Rogue : Hero
    {
        public HeroAttributes LevelAttributes { get; set; }
        public Rogue(string name) : base(name)
        {
            LevelAttributes = new HeroAttributes(2, 6, 1);
        }

        /*public override void Attack()
        {
            throw new NotImplementedException();
        }*/

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 4, 1);
        }

        public override void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strength: " + LevelAttributes.Strength);
            Console.WriteLine("Dexterity: " + LevelAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + LevelAttributes.Intelligence);
        }
    }
}
