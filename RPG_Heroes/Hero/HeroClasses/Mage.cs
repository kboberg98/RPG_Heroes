using RPG_Heroes.Hero.Attributes;
using RPG_Heroes.Hero.CustomExceptions;
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
    public class Mage : Hero
    {
        public HeroAttributes LevelAttributes; // the hero attributes for this level

        // constructor for the Mage class
        public Mage(string name) : base(name, new List<WeaponType> { WeaponType.Staff, WeaponType.Wand }, new List<ArmorType> { ArmorType.Cloth })
        {
            LevelAttributes = new HeroAttributes(1, 1, 8); // set the initial hero attributes for the Mage class
        }

        // level up the hero and increase their attributes
        public override void LevelUp()
        {
            Level++;
            LevelAttributes.Increase(1, 1, 5);
        }

        // equip a weapon for the hero
        public override void EquipWeapon(Weapon weapon)
        {
            // check if the hero meets the level requirement for the weapon
            if (Level >= weapon.RequiredLevel)
            {
                // check if the weapon type is valid for the hero
                if (ValidWeaponTypes.Contains(weapon.WeaponType))
                {
                    Equipment[Slot.Weapon] = weapon;
                }
                else
                {
                    throw new InvalidWeaponException($"Cannot equip {weapon.Name}: invalid weapon type for hero");
                }
            } else
            {
                throw new InvalidWeaponException($"Cannot equip {weapon.Name}: hero doesn't meet level requirement for this weapon");
            }
        }

        // equip an armor for the hero
        public override void EquipArmor(Armor armor)
        {
            // check if the hero meets the level requirement for the armor
            if (Level >= armor.RequiredLevel)
            {
                // check if the armor type is valid for the hero
                if (ValidArmorTypes.Contains(armor.ArmorType))
                {
                    // assign the armor to the correct equipment slot
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
                            throw new InvalidArmorException("Invalid item slot");
                    }
                } else
                {
                    throw new InvalidArmorException($"Cannot equip {armor.Name}: invalid armor type for hero");
                }
            }
            else
            {
                throw new InvalidArmorException($"Cannot equip {armor.Name}: hero doesn't meet level requirement for this armor");
            }
        }

        // display the hero's information
        public override string Display()
        {
            HeroAttributes TotalAttributes = GetTotalAttributes();
            Double HeroDamage = GetHeroDamage();

            StringBuilder sb = new StringBuilder(); // use a string builder to create the display string
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Class: " + "Mage");
            sb.AppendLine("Level: " + Level);
            sb.AppendLine("Strength: " + TotalAttributes.Strength);
            sb.AppendLine("Dexterity: " + TotalAttributes.Dexterity);
            sb.AppendLine("Intelligence: " + TotalAttributes.Intelligence);
            sb.AppendLine("Hero Damage: " + HeroDamage);

            return sb.ToString();
        }

        // calculate the hero's total attributes
        public override HeroAttributes GetTotalAttributes()
        {
            HeroAttributes TotalAttributes = new (0, 0, 0);
            TotalAttributes.Increase(LevelAttributes.Strength, LevelAttributes.Dexterity, LevelAttributes.Intelligence);

            foreach (KeyValuePair<Slot, Item?> kvp in Equipment)
            {
                if (kvp.Value != null)
                {
                    if (kvp.Value is Armor)
                    {
                        if (kvp.Value is Armor armor)
                            TotalAttributes.Increase(armor.ArmorAttributes.Strength, armor.ArmorAttributes.Dexterity, armor.ArmorAttributes.Intelligence);
                    }
                }
            }
            return TotalAttributes;
        }

        // calculate the hero's damage
        public override double GetHeroDamage()
        {
            double HeroDamage = 0;
            HeroAttributes TotalAttributes = GetTotalAttributes();
            if (Equipment[Slot.Weapon] != null)
            {
                if (Equipment[Slot.Weapon] is Weapon weapon)
                {
                    HeroDamage = weapon.WeaponDamage * (1 + (double)TotalAttributes.Intelligence / 100);
                }
            } else
            {
                HeroDamage = 1 * (1 + (double)TotalAttributes.Intelligence / 100);
            }
            return HeroDamage;
        }
    }
}
