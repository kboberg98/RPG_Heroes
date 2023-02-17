﻿using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;

namespace RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MAGE
            Mage mage = new Mage("Harry");
            Weapon shadowmourn = new Weapon("Shadowmourn", 1, WeaponType.Sword, 100);
            Weapon bigstaff = new Weapon("Bigstaff", 2, WeaponType.Staff, 100);
            Armor clothhead = new Armor("Clothhead", 2, Hero.Inventory.Slot.Head, ArmorType.Cloth, 1, 1, 2);
            Armor clothchest = new Armor("Clothchest", 2, Hero.Inventory.Slot.Body, ArmorType.Cloth, 1, 1, 4);
            Armor clothpants = new Armor("Clothpants", 2, Hero.Inventory.Slot.Legs, ArmorType.Cloth, 1, 1, 2);
            mage.LevelUp();
            mage.EquipWeapon(bigstaff);
            mage.EquipWeapon(shadowmourn);
            mage.EquipArmor(clothchest);
            mage.EquipArmor(clothpants);
            mage.EquipArmor(clothhead);
            mage.Display();
            mage.DisplayEquipment();
            // WARRIOR
            Warrior warrior = new Warrior("Aragorn");
            Armor platehead = new Armor("Platehead", 2, Hero.Inventory.Slot.Head, ArmorType.Plate, 2, 2, 1);
            Armor platechest = new Armor("Platechest", 2, Hero.Inventory.Slot.Body, ArmorType.Plate, 4, 3, 1);
            Armor platepants = new Armor("Platepants", 2, Hero.Inventory.Slot.Legs, ArmorType.Plate, 3, 1, 1);
            warrior.LevelUp();
            warrior.EquipWeapon(bigstaff);
            warrior.EquipWeapon(shadowmourn);
            warrior.EquipArmor(platechest);
            warrior.EquipArmor(platepants);
            warrior.EquipArmor(platehead);
            warrior.Display();
            warrior.DisplayEquipment();
            Console.WriteLine("Platehead Strength: " + platehead.ArmorAttributes.Strength);
        }
    }
}