using RPG_Heroes.Hero.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG_Heroes.Hero.HeroClasses
{
    public enum ValidWeaponTypes
    {
        Staffs,
        Wands
    }
    public enum ValidArmorTypes
    {
        Cloth
    }

    class Mage : Hero
    {
        public HeroAttributes LevelAttributes { get; set; }
        public ValidArmorTypes ValidArmorTypes { get; set; }
        public ValidWeaponTypes ValidWeaponTypes { get; set; }

        public Mage(string name) : base(name)
        {
            LevelAttributes = new HeroAttributes(1, 1, 8);
        }

        /*public override void Attack()
        {
            throw new NotImplementedException();
        }*/

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 1, 5);
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
