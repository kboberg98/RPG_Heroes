using RPG_Heroes.Hero.Attributes;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPG_Heroes.Hero.HeroClasses
{
    class Warrior : Hero
    {
        public HeroAttributes LevelAttributes { get; set; }
        public Warrior(string name) : base(name, new List<WeaponType> { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword }, new List<ArmorType> { ArmorType.Mail, ArmorType.Plate })
        {
            LevelAttributes = new HeroAttributes(5, 2, 1);
        }

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(3, 2, 1);
        }

        public override void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strength: " + LevelAttributes.Strength);
            Console.WriteLine("Dexterity: " + LevelAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + LevelAttributes.Intelligence);
        }

        public override void EquipWeapon(Weapon weapon)
        {
            throw new NotImplementedException();
        }

        public override void EquipArmor(Slot slot, Armor armor)
        {
            throw new NotImplementedException();
        }
    }
}
