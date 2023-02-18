using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Inventory
{
    public enum Slot
    {
        Weapon,
        Head,
        Body,
        Legs
    }

    abstract class Item
    {
        public string Name { get; }
        public int RequiredLevel { get; }
        public Slot Slot { get; }

        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;

        }
    }
}
