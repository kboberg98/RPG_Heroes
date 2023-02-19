using RPG_Heroes.Hero.CustomExceptions;
using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Attributes;

namespace HeroTests
{
    public class MageTests
    {
        [Fact]
        public void CreateMage_MageHasCorrect_Name_Level_Attributes()
        {
            //Arrange
            string expectedName = "Harry";
            int expectedLevel = 1;
            int expectedStrength = 1;
            int expectedDexterity = 1;
            int expectedIntelligence = 8;

            //Act
            Mage mage = new("Harry");

            //Assert
            Assert.Equal(expectedName, mage.Name);
            Assert.Equal(expectedLevel, mage.Level);
            Assert.Equal(expectedStrength, mage.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, mage.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, mage.LevelAttributes.Intelligence);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void LevelUpMage_MageHasCorrectAttributes(int levelUpAmount)
        {
            //Arrange
            int expectedLevel = 1 + (1 * levelUpAmount);
            int expectedStrength = 1 + (1 * levelUpAmount);
            int expectedDexterity = 1 + (1 * levelUpAmount);
            int expectedIntelligence = 8 + (5 * levelUpAmount);

            //Act
            Mage mage = new("Harry");
            for(int i = 0; i < levelUpAmount; i++) {mage.LevelUp();}

            //Assert
            Assert.Equal(expectedLevel, mage.Level);
            Assert.Equal(expectedStrength, mage.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, mage.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, mage.LevelAttributes.Intelligence);
        }

        [Fact]
        public void EquipArmor_InvalidArmorType_ThrowsInvalidArmorException()
        {
            // Arrange
            Mage mage = new Mage("Harry");
            Armor armor = new Armor("Invalid Armor", 1, Slot.Body, ArmorType.Mail, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(armor));
        }

        [Fact]
        public void EquipArmor_InvalidArmorLevelRequirement_ThrowsInvalidArmorException()
        {
            // Arrange
            Mage mage = new Mage("Harry");
            Armor armor = new Armor("Invalid Armor", 5, Slot.Body, ArmorType.Cloth, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(armor));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponType_ThrowsInvalidWeaponException()
        {
            // Arrange
            Mage mage = new Mage("Harry");
            Weapon weapon = new Weapon("Invalid Weapon", 1, WeaponType.Axe, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponLevelRequirement_ThrowsInvalidWeaponException()
        {
            // Arrange
            Mage mage = new Mage("Harry");
            Weapon weapon = new Weapon("Invalid Weapon", 5, WeaponType.Staff, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(weapon));
        }

        [Fact]
        public void MageWithoutArmor_MageHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1;
            int expectedTotalDexterity = 1;
            int expectedTotalIntelligence = 8;

            //Act
            Mage mage = new Mage("Harry");
            HeroAttributes totalAttributes = mage.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void MageWithOnePieceOfArmor_MageHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1 + 1;
            int expectedTotalDexterity = 1 + 1;
            int expectedTotalIntelligence = 8 + 2;

            //Act
            Mage mage = new Mage("Harry");
            Armor clothChestPiece = new Armor("Clothchest", 1, Slot.Body, ArmorType.Cloth, 1, 1, 2);
            mage.EquipArmor(clothChestPiece);
            HeroAttributes totalAttributes = mage.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void MageWithTwoPiecesOfArmor_MageHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1 + 1;
            int expectedTotalDexterity = 1 + 1;
            int expectedTotalIntelligence = 8 + 2 + 2;

            //Act
            Mage mage = new Mage("Harry");
            Armor clothHeadPiece = new Armor("Clothhead", 1, Slot.Head, ArmorType.Cloth, 0, 0, 2);
            Armor clothChestPiece = new Armor("Clothchest", 1, Slot.Body, ArmorType.Cloth, 1, 1, 2);
            mage.EquipArmor(clothHeadPiece);
            mage.EquipArmor(clothChestPiece);
            HeroAttributes totalAttributes = mage.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void MageWithReplacedPieceOfArmor_MageHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1;
            int expectedTotalDexterity = 1;
            int expectedTotalIntelligence = 8 + 4;

            //Act
            Mage mage = new Mage("Harry");
            Armor clothHeadPiece = new Armor("Clothhead", 1, Slot.Head, ArmorType.Cloth, 0, 0, 2);
            Armor betterClothHeadPiece = new Armor("Rare Clothhead", 1, Slot.Head, ArmorType.Cloth, 0, 0, 4);
            mage.EquipArmor(clothHeadPiece);
            mage.EquipArmor(betterClothHeadPiece);
            HeroAttributes totalAttributes = mage.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void MageDamageWithoutWeapon_MageHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 1 * (1 + ((double)8 / 100));

            //Act
            Mage mage = new Mage("Harry");
            double mageDamage = mage.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, mageDamage);
        }

        [Fact]
        public void MageDamageWithWeapon_MageHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)8 / 100));

            //Act
            Mage mage = new Mage("Harry");
            Weapon staff = new Weapon("Common Staff", 1, WeaponType.Staff, 2);
            mage.EquipWeapon(staff);
            double mageDamage = mage.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, mageDamage);
        }

        [Fact]
        public void MageDamageWithReplacedWeapon_MageHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 5 * (1 + ((double)8 / 100));

            //Act
            Mage mage = new Mage("Harry");
            Weapon staff = new Weapon("Common Staff", 1, WeaponType.Staff, 2);
            Weapon betterStaff = new Weapon("Rare Staff", 1, WeaponType.Staff, 5);
            mage.EquipWeapon(staff);
            mage.EquipWeapon(betterStaff);
            double mageDamage = mage.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, mageDamage);
        }

        [Fact]
        public void MageDamageWithWeaponAndArmor_MageHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)(8 + 2 + 4 + 3) / 100));

            //Act
            Mage mage = new Mage("Harry");
            Weapon staff = new Weapon("Common Staff", 1, WeaponType.Staff, 2);
            Armor clothHelm = new Armor("Common cloth helm", 1, Slot.Head, ArmorType.Cloth, 0, 0, 2);
            Armor clothChest = new Armor("Common cloth chest", 1, Slot.Body, ArmorType.Cloth, 0, 0, 4);
            Armor clothLegs = new Armor("Common cloth legs", 1, Slot.Legs, ArmorType.Cloth, 0, 0, 3);
            mage.EquipWeapon(staff);
            mage.EquipArmor(clothHelm);
            mage.EquipArmor(clothChest);
            mage.EquipArmor(clothLegs);
            double mageDamage = mage.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, mageDamage);
        }
    }
}