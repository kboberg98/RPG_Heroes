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

        public override void EquipWeapon(Weapon weapon)
        {
            if (Level >= weapon.RequiredLevel)
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
            else
            {
                Console.WriteLine($"Cannot equip {weapon.Name}: hero is too low lvl");
            }
        }

        public override void EquipArmor(Armor armor)
        {
            if (Level >= armor.RequiredLevel)
            {
                if (ValidArmorTypes.Contains(armor.ArmorType))
                {
                    switch (armor.Slot)
                    {
                        case Slot.Head:
                            Equipment[Slot.Head] = armor;
                            break;
                        case Slot.Body:
                            Equipment[Slot.Body] = armor;
                            break;
                        case Slot.Legs:
                            Equipment[Slot.Legs] = armor;
                            break;
                        default:
                            Console.WriteLine("Invalid item slot.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine($"Cannot equip {armor.Name}: invalid weapon type");
                }
            }
            else
            {
                Console.WriteLine($"Cannot equip {armor.Name}: hero is too low lvl");
            }
        }

        public override void Display()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Strength: " + LevelAttributes.Strength);
            Console.WriteLine("Dexterity: " + LevelAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + LevelAttributes.Intelligence);
            Console.ReadLine();
            Console.Clear();
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
            Console.ReadLine();
            Console.Clear();
        }
    }
}
