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
    abstract class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Dictionary<Slot, Item> Equipment { get; set; }
        public List<WeaponType> ValidWeaponTypes { get; set; }
        public List<ArmorType> ValidArmorTypes { get; set; }

        public Hero(string name, List<WeaponType> validWeaponTypes, List<ArmorType> validArmorTypes)
        {
            Name = name;
            Level = 1;
            Equipment = new Dictionary<Slot, Item>
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
        public abstract void Display();
        public abstract void EquipWeapon(Weapon weapon);
        public abstract void EquipArmor(Armor armor);
        //public abstract void Attack();
    }
}
