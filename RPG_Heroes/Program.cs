using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;

namespace RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mage mage = new Mage("Harry");
            Weapon shadowmourn = new Weapon("Shadowmourn", 1, WeaponType.Sword, 100);
            Weapon bigstaff = new Weapon("Bigstaff", 1, WeaponType.Staff, 100);
            mage.LevelUp();
            mage.EquipWeapon(bigstaff);
            mage.Display();
            mage.DisplayEquipment();
        }
    }
}