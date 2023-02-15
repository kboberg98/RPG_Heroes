using RPG_Heroes.Hero.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG_Heroes.Hero.HeroClasses
{
    class Ranger : Hero
    {
        public HeroAttributes LevelAttributes { get; set; }
        public Ranger(string name) : base(name)
        {
            LevelAttributes = new HeroAttributes(1, 7, 1);
        }

        /*public override void Attack()
        {
            throw new NotImplementedException();
        }*/

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 5, 1);
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
