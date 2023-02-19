using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;

namespace RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MAGE
            Mage mage = new Mage("Harry");
            Weapon shadowmourn = new Weapon("Shadowmourn", 1, WeaponType.Sword, 75);
            Weapon bigstaff = new Weapon("Bigstaff", 2, WeaponType.Staff, 50);
            Armor clothhead = new Armor("Clothhead", 2, Hero.Inventory.Slot.Head, ArmorType.Cloth, 1, 1, 2);
            Armor clothchest = new Armor("Clothchest", 2, Hero.Inventory.Slot.Body, ArmorType.Cloth, 1, 1, 4);
            Armor clothpants = new Armor("Clothpants", 2, Hero.Inventory.Slot.Legs, ArmorType.Cloth, 1, 1, 2);
            Armor mailchest = new Armor("Mailchest", 1, Hero.Inventory.Slot.Body, ArmorType.Mail, 1, 1, 1);
            mage.LevelUp();
            mage.EquipWeapon(bigstaff);
            mage.EquipArmor(clothchest);
            mage.EquipArmor(clothpants);
            mage.EquipArmor(clothhead);
            //mage.EquipWeapon(shadowmourn);
            //mage.EquipArmor(mailchest);
            mage.Display();
            mage.DisplayEquippedItems();
            
            // WARRIOR
            Warrior warrior = new Warrior("Aragorn");
            Armor platehead = new Armor("Platehead", 2, Hero.Inventory.Slot.Head, ArmorType.Plate, 2, 2, 1);
            Armor platechest = new Armor("Platechest", 2, Hero.Inventory.Slot.Body, ArmorType.Plate, 4, 3, 1);
            Armor platepants = new Armor("Platepants", 2, Hero.Inventory.Slot.Legs, ArmorType.Plate, 3, 1, 1);
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.EquipWeapon(shadowmourn);
            warrior.EquipArmor(platechest);
            warrior.EquipArmor(platepants);
            warrior.EquipArmor(platehead);
            warrior.Display();
           
            //Console.WriteLine("Platehead Strength: " + platehead.ArmorAttributes.Strength);
        }
    }
}