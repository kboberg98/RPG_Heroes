using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Heroes.Hero.Inventory
{
    abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public int Slot { get; set; }

        protected Item(string name, int requiredLevel, int slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}
