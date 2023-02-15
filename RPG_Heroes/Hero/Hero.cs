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

        public Hero(string name)
        {
            Name = name;
            Level = 1;
        }

        public abstract void LevelUp();
        public abstract void Display();
        //public abstract void Attack();

        /*public void Equip(Item item)
        {
            if (Level >= item.RequiredLevel)
            {
                switch (item.Slot)
                {
                    case ItemSlot.Head:
                        if (Head != null)
                            Unequip(Head);
                        Head = (Armor)item;
                        break;
                    case ItemSlot.Chest:
                        if (Chest != null)
                            Unequip(Chest);
                        Chest = (Armor)item;
                        break;
                    case ItemSlot.Legs:
                        if (Legs != null)
                            Unequip(Legs);
                        Legs = (Armor)item;
                        break;
                    case ItemSlot.Feet:
                        if (Feet != null)
                            Unequip(Feet);
                        Feet = (Armor)item;
                        break;
                    case ItemSlot.MainHand:
                        if (MainHand != null)
                            Unequip(MainHand);
                        MainHand = (Weapon)item;
                        break;
                    case ItemSlot.OffHand:
                        if (OffHand != null)
                            Unequip(OffHand);
                        OffHand = (Weapon)item;
                        break;
                    default:
                        throw new InvalidItemSlotException("Invalid item slot.");
                }
            }
            else
            {
                throw new InsufficientLevelException("Hero's level is not high enough to equip this item.");
            }
        }

        private void Unequip(Item item)
        {
            switch (item.Slot)
            {
                case ItemSlot.Head:
                    Head = null;
                    break;
                case ItemSlot.Chest:
                    Chest = null;
                    break;
                case ItemSlot.Legs:
                    Legs = null;
                    break;
                case ItemSlot.Feet:
                    Feet = null;
                    break;
                case ItemSlot.MainHand:
                    MainHand = null;
                    break;
                case ItemSlot.OffHand:
                    OffHand = null;
                    break;
            }
        }*/
    }
}
