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
            HeroAttributes TotalAttributes = GetTotalAttributes();
            Double HeroDamage = GetHeroDamage();
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Class: Mage");
            Console.WriteLine("Level: " + Level);
            Console.WriteLine("Strength: " + TotalAttributes.Strength);
            Console.WriteLine("Dexterity: " + TotalAttributes.Dexterity);
            Console.WriteLine("Intelligence: " + TotalAttributes.Intelligence);
            Console.WriteLine("Hero Damage: " + HeroDamage);
            Console.ReadLine();
            Console.Clear();
        }

        public override HeroAttributes GetTotalAttributes()
        {
            HeroAttributes TotalAttributes = new (0, 0, 0);
            TotalAttributes.Increase(LevelAttributes.Strength, LevelAttributes.Dexterity, LevelAttributes.Intelligence);

            foreach (KeyValuePair<Slot, Item> kvp in Equipment)
            {
                if (kvp.Value != null)
                {
                    if (kvp.Value is Armor)
                    {
                        Armor armor = kvp.Value as Armor;
                        TotalAttributes.Increase(armor.ArmorAttributes.Strength, armor.ArmorAttributes.Dexterity, armor.ArmorAttributes.Intelligence);
                    }
                }
            }
            return TotalAttributes;
        }

        public override double GetHeroDamage()
        {
            double HeroDamage;
            HeroAttributes TotalAttributes = GetTotalAttributes();
            if (Equipment[Slot.Weapon] != null)
            {
                Weapon? weapon = Equipment[Slot.Weapon] as Weapon;
                HeroDamage = weapon.WeaponDamage * (1 + (double)TotalAttributes.Intelligence / 100);
            } else
            {
                HeroDamage = 1 * (1 + (double)TotalAttributes.Intelligence / 100);
            }
            return HeroDamage;
        }
    }
}
