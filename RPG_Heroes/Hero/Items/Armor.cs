using RPG_Heroes.Hero.Attributes;
using RPG_Heroes.Hero.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Items
{
    public enum ArmorType
    {
        Light,
        Medium,
        Heavy
    }

    class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public HeroAttributes Bonuses { get; set; }

        public Armor(string name, int requiredLevel, int slot, ArmorType armorType, HeroAttributes bonuses)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            Bonuses = bonuses;
        }
    }
}
