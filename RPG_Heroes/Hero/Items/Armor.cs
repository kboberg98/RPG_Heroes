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
        Cloth,
        Leather,
        Mail,
        Plate
    }

    class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public HeroAttributes ArmorAttributes { get; set; }

        public Armor(string name, int requiredLevel, Slot slot, ArmorType armorType, int armorStrength, int armorDexterity, int armorIntellect)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = new HeroAttributes(armorStrength, armorDexterity, armorIntellect);
        }
    }
}
