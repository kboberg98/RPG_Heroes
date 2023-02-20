using RPG_Heroes.Hero.Attributes;
using RPG_Heroes.Hero.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Items
{
    // Enum that defines the possible types of armor that a hero can wear
    public enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }

    // A specific type of item that a hero can equip
    public class Armor : Item
    {
        public ArmorType ArmorType { get; }  // The type of armor (e.g. Cloth, Leather, Mail, Plate)
        public HeroAttributes ArmorAttributes { get; } // The attributes provided by the armor

        // Constructor that initializes the Name, RequiredLevel, Slot, ArmorType, and ArmorAttributes properties
        public Armor(string name, int requiredLevel, Slot slot, ArmorType armorType, int armorStrength, int armorDexterity, int armorIntellect)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = new HeroAttributes(armorStrength, armorDexterity, armorIntellect);
        }
    }
}
