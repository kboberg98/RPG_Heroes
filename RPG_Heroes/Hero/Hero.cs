using RPG_Heroes.Hero.Attributes;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Level { get; set; }
        public Dictionary<Slot, Item?> Equipment { get; }
        public List<WeaponType> ValidWeaponTypes { get; }
        public List<ArmorType> ValidArmorTypes { get; }

        public Hero(string name, List<WeaponType> validWeaponTypes, List<ArmorType> validArmorTypes)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Item?>
            {
                {Slot.Weapon, null },
                {Slot.Head, null },
                {Slot.Body, null },
                {Slot.Legs, null }
            };
            ValidWeaponTypes = validWeaponTypes;
            ValidArmorTypes = validArmorTypes;
        }

        public abstract void LevelUp();
        public abstract string Display();
        public abstract void EquipWeapon(Weapon weapon);
        public abstract void EquipArmor(Armor armor);
        public abstract HeroAttributes GetTotalAttributes();
        public abstract double GetHeroDamage();

        public void DisplayEquippedItems()
        {
            Console.WriteLine($"Equipped items for {Name}:");
            foreach (KeyValuePair<Slot, Item?> kvp in Equipment)
            {
                if (kvp.Value != null)
                {
                    if (kvp.Value is Armor)
                    {
                        if (kvp.Value is Armor armor)
                        Console.WriteLine($"{kvp.Key}: {armor.Name} (Armor Stength: {armor.ArmorAttributes.Strength})  (Armor Dexterity: {armor.ArmorAttributes.Dexterity})  (Armor Intelligence: {armor.ArmorAttributes.Intelligence})");
                    }
                    else if (kvp.Value is Weapon)
                    {
                        if (kvp.Value is Weapon weapon)
                        Console.WriteLine($"{kvp.Key}: {weapon.Name} (Damage: {weapon.WeaponDamage})");
                    }
                }
                else
                {
                    Console.WriteLine($"{kvp.Key}: (none)");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }
}   }
