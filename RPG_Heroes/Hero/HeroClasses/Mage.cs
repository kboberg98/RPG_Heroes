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
    class Mage : Hero
    {
        public HeroAttributes LevelAttributes { get; set; }

        public Mage(string name) : base(name, new List<WeaponType> { WeaponType.Staff, WeaponType.Wand }, new List<ArmorType> { ArmorType.Cloth })
        {
            LevelAttributes = new HeroAttributes(1, 1, 8);
        }

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 1, 5);
        }

        public override void EquipWeapon(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType))
            {
                Equipment[Slot.Weapon] = weapon;
                Console.WriteLine($"Equipped {weapon.Name}");
            }
            else
            {
                Console.WriteLine($"Cannot equip {weapon.Name}: invalid weapon type");
            }
        }

        public override void EquipArmor(Slot slot, Armor armor)
        {
            Equipment[slot] = armor;
        }

        public override void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Strength: " + LevelAttributes.Strength);
            Console.WriteLine("Dexterity: " + LevelAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + LevelAttributes.Intelligence);
        }

        public void DisplayEquipment()
        {
            Console.WriteLine("Current Equipment:");
            foreach (KeyValuePair<Slot, Item> kvp in Equipment)
            {
                Console.Write(kvp.Key.ToString() + ": ");
                if (kvp.Value != null)
                {
                    Console.WriteLine(kvp.Value.Name);
                }
                else
                {
                    Console.WriteLine("empty");
                }
            }
        }
    }
}
