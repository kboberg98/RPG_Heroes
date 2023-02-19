
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Items;

namespace HeroTests
{
    public class ItemTests
    {
        [Fact]
        public void CreateWeapon_WeaponHasCorrect_Name_RequiredLevel_Slot_WeaponType_Damage()
        {
            //Arrange
            string ExpectedName = "Common Axe";
            int ExpectedRequiredLevel = 1;
            Slot ExpectedSlot = Slot.Weapon;
            WeaponType ExpectedWeaponType = WeaponType.Axe;
            int ExpectedWeaponDamage = 2;

            //Act
            Weapon weapon = new("Common Axe", 1, WeaponType.Axe, 2);

            //Assert
            Assert.Equal(ExpectedName, weapon.Name);
            Assert.Equal(ExpectedRequiredLevel, weapon.RequiredLevel);
            Assert.Equal(ExpectedSlot, weapon.Slot);
            Assert.Equal(ExpectedWeaponType, weapon.WeaponType);
            Assert.Equal(ExpectedWeaponDamage, weapon.WeaponDamage);
        }

        [Fact]
        public void CreateArmor_ArmorHasCorrect_Name_RequiredLevel_Slot_ArmorType_ArmorAttributes()
        {
            //Arrange
            string ExpectedName = "Common Plate Chest";
            int ExpectedRequiredLevel = 1;
            Slot ExpectedSlot = Slot.Body;
            ArmorType ExpectedArmorType = ArmorType.Plate;
            int ExpectedArmorStrengthAttribute = 1;
            int ExpectedArmorDexterityAttribute = 0;
            int ExpectedArmorIntelligenceAttribute = 0;

            //Act
            Armor armor = new("Common Plate Chest", 1, Slot.Body, ArmorType.Plate, 1, 0, 0);

            //Assert
            Assert.Equal(ExpectedName, armor.Name);
            Assert.Equal(ExpectedRequiredLevel, armor.RequiredLevel);
            Assert.Equal(ExpectedSlot, armor.Slot);
            Assert.Equal(ExpectedArmorType, armor.ArmorType);
            Assert.Equal(ExpectedArmorStrengthAttribute, armor.ArmorAttributes.Strength);
            Assert.Equal(ExpectedArmorDexterityAttribute, armor.ArmorAttributes.Dexterity);
            Assert.Equal(ExpectedArmorIntelligenceAttribute, armor.ArmorAttributes.Intelligence);
        }
    }
}
