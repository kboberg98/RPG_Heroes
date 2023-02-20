using RPG_Heroes.Hero.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Items
{
    // Enum that defines the possible types of weapons that a hero can wield
    public enum WeaponType
    {
        Axe,
        Bow,
        Dagger,
        Hammer,
        Staff,
        Sword,
        Wand
    }

    // A specific type of item that a hero can equip
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; } // The type of weapon (e.g. Axe, Sword, Wand)
        public int WeaponDamage { get; } // The damage that the weapon can inflict

        // Constructor that initializes the Name, RequiredLevel, WeaponType, WeaponDamage, and Slot properties
        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
            
        }
    }
}
