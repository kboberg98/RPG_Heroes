using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Inventory
{
    // Enum that defines the possible slots where items can be equipped by a hero
    public enum Slot
    {
        Weapon,
        Head,
        Body,
        Legs
    }

    // Abstract base class for specific types of items that can be equipped by a hero, such as weapons and armor
    public abstract class Item
    {
        public string Name { get; }
        public int RequiredLevel { get; }
        public Slot Slot { get; }

        // Constructor that initializes the Name, RequiredLevel, and Slot properties
        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;

        }
    }
}
