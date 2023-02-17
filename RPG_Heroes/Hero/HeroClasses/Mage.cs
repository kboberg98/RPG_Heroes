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
        public HeroAttributes TotalArmorAttributes { get; set; }

        public Mage(string name) : base(name, new List<WeaponType> { WeaponType.Staff, WeaponType.Wand }, new List<ArmorType> { ArmorType.Cloth })
        {
            LevelAttributes = new HeroAttributes(1, 1, 8);
            TotalArmorAttributes = new HeroAttributes(0, 0, 0);
        }

        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 1, 5);
        }

        public override void EquipWeapon(Weapon weapon)
        {
            if(Level >= weapon.RequiredLevel)
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
            } else
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
                            TotalArmorAttributes.Increase(armor.ArmorAttributes.Strength, armor.ArmorAttributes.Dexterity, armor.ArmorAttributes.Intelligence);
                            break;
                        case Slot.Body:
                            Equipment[Slot.Body] = armor;
                            TotalArmorAttributes.Increase(armor.ArmorAttributes.Strength, armor.ArmorAttributes.Dexterity, armor.ArmorAttributes.Intelligence);
                            break;
                        case Slot.Legs:
                            Equipment[Slot.Legs] = armor;
                            TotalArmorAttributes.Increase(armor.ArmorAttributes.Strength, armor.ArmorAttributes.Dexterity, armor.ArmorAttributes.Intelligence);
                            break;
                        default:
                            Console.WriteLine("Invalid item slot.");
                            break;
                    }
                } else
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
            Console.WriteLine("Total armor attributes: ");
            Console.WriteLine("Strength: " + TotalArmorAttributes.Strength);
            Console.WriteLine("Dexterity: " + TotalArmorAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + TotalArmorAttributes.Intelligence);
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
