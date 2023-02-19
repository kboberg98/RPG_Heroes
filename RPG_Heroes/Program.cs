using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Items;

namespace RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MAGE
            Mage mage = new Mage("Harry");
            Weapon epicWeapon = new Weapon("Epic Staff", 10, WeaponType.Staff, 80);
            Armor epicHead = new Armor("Epic Head", 8, Slot.Head, ArmorType.Cloth, 2, 2, 6);
            Armor epicChest = new Armor("Epic Chest", 9, Slot.Body, ArmorType.Cloth, 2, 2, 8);
            Armor epicLegs = new Armor("Epic Legs", 7, Slot.Legs, ArmorType.Cloth, 2, 2, 10);
            for (int i = 0; i < 10; i++) { mage.LevelUp(); }
            mage.EquipWeapon(epicWeapon);
            mage.EquipArmor(epicHead);
            mage.EquipArmor(epicChest);
            mage.EquipArmor(epicLegs);
            string mageOutput = mage.Display();
            Console.WriteLine(mageOutput);
            mage.DisplayEquippedItems();
        }
    }
}