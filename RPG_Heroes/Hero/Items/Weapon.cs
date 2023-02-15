using RPG_Heroes.Hero.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Items
{
    public enum WeaponType
    {
        Sword,
        Axe,
        Bow,
        Wand
    }

    class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon(string name, int requiredLevel, int slot, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, slot)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}
