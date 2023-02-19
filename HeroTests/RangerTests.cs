using RPG_Heroes.Hero.CustomExceptions;
using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Attributes;

namespace HeroTests
{
    public class RangerTests
    {
        [Fact]
        public void CreateRanger_RangerHasCorrect_Name_Level_Attributes()
        {
            //Arrange
            string expectedName = "Legolas";
            int expectedLevel = 1;
            int expectedStrength = 1;
            int expectedDexterity = 7;
            int expectedIntelligence = 1;

            //Act
            Ranger ranger = new("Legolas");

            //Assert
            Assert.Equal(expectedName, ranger.Name);
            Assert.Equal(expectedLevel, ranger.Level);
            Assert.Equal(expectedStrength, ranger.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, ranger.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, ranger.LevelAttributes.Intelligence);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void LevelUpRanger_RangerHasCorrectAttributes(int levelUpAmount)
        {
            //Arrange
            int expectedLevel = 1 + (1 * levelUpAmount);
            int expectedStrength = 1 + (1 * levelUpAmount);
            int expectedDexterity = 7 + (5 * levelUpAmount);
            int expectedIntelligence = 1 + (1 * levelUpAmount);

            //Act
            Ranger ranger = new("Legolas");
            for (int i = 0; i < levelUpAmount; i++) { ranger.LevelUp(); }

            //Assert
            Assert.Equal(expectedLevel, ranger.Level);
            Assert.Equal(expectedStrength, ranger.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, ranger.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, ranger.LevelAttributes.Intelligence);
        }

        [Fact]
        public void EquipArmor_InvalidArmorType_ThrowsInvalidArmorException()
        {
            // Arrange
            Ranger ranger = new Ranger("Legolas");
            Armor armor = new Armor("Invalid Armor", 1, Slot.Body, ArmorType.Plate, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(armor));
        }

        [Fact]
        public void EquipArmor_InvalidArmorLevelRequirement_ThrowsInvalidArmorException()
        {
            // Arrange
            Ranger ranger = new Ranger("Legolas");
            Armor armor = new Armor("Invalid Armor", 5, Slot.Body, ArmorType.Mail, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(armor));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponType_ThrowsInvalidWeaponException()
        {
            // Arrange
            Ranger ranger = new Ranger("Legolas");
            Weapon weapon = new Weapon("Invalid Weapon", 1, WeaponType.Axe, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponLevelRequirement_ThrowsInvalidWeaponException()
        {
            // Arrange
            Ranger ranger = new Ranger("Legolas");
            Weapon weapon = new Weapon("Invalid Weapon", 5, WeaponType.Bow, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(weapon));
        }

        [Fact]
        public void RangerWithoutArmor_RangerHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1;
            int expectedTotalDexterity = 7;
            int expectedTotalIntelligence = 1;

            //Act
            Ranger ranger = new Ranger("Legolas");
            HeroAttributes totalAttributes = ranger.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RangerWithOnePieceOfArmor_RangerHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1 + 1;
            int expectedTotalDexterity = 7 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Ranger ranger = new Ranger("Legolas");
            Armor mailChestPiece = new Armor("Mailchest", 1, Slot.Body, ArmorType.Mail, 1, 2, 1);
            ranger.EquipArmor(mailChestPiece);
            HeroAttributes totalAttributes = ranger.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RangerWithTwoPiecesOfArmor_RangerHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1 + 1;
            int expectedTotalDexterity = 7 + 2 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Ranger ranger = new Ranger("Legolas");
            Armor mailHeadPiece = new Armor("Mailhead", 1, Slot.Head, ArmorType.Mail, 0, 2, 0);
            Armor mailChestPiece = new Armor("Mailchest", 1, Slot.Body, ArmorType.Mail, 1, 2, 1);
            ranger.EquipArmor(mailHeadPiece);
            ranger.EquipArmor(mailChestPiece);
            HeroAttributes totalAttributes = ranger.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RangerWithReplacedPieceOfArmor_RangerHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 1;
            int expectedTotalDexterity = 7 + 4;
            int expectedTotalIntelligence = 1;

            //Act
            Ranger ranger = new Ranger("Harry");
            Armor mailHeadPiece = new Armor("Mailhead", 1, Slot.Head, ArmorType.Mail, 0, 2, 0);
            Armor betterMailHeadPiece = new Armor("Rare Mailhead", 1, Slot.Head, ArmorType.Mail, 0, 4, 0);
            ranger.EquipArmor(mailHeadPiece);
            ranger.EquipArmor(betterMailHeadPiece);
            HeroAttributes totalAttributes = ranger.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RangerDamageWithoutWeapon_RangerHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 1 * (1 + ((double)7 / 100));

            //Act
            Ranger ranger = new Ranger("Legolas");
            double rangerDamage = ranger.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rangerDamage);
        }

        [Fact]
        public void RangerDamageWithWeapon_RangerHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)7 / 100));

            //Act
            Ranger ranger = new Ranger("Legolas");
            Weapon bow = new Weapon("Common Bow", 1, WeaponType.Bow, 2);
            ranger.EquipWeapon(bow);
            double rangerDamage = ranger.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rangerDamage);
        }

        [Fact]
        public void RangerDamageWithReplacedWeapon_RangerHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 5 * (1 + ((double)7 / 100));

            //Act
            Ranger ranger = new Ranger("Legolas");
            Weapon bow = new Weapon("Common Bow", 1, WeaponType.Bow, 2);
            Weapon betterBow = new Weapon("Rare Bow", 1, WeaponType.Bow, 5);
            ranger.EquipWeapon(bow);
            ranger.EquipWeapon(betterBow);
            double rangerDamage = ranger.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rangerDamage);
        }

        [Fact]
        public void RangerDamageWithWeaponAndArmor_RangerHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)(7 + 2 + 4 + 3) / 100));

            //Act
            Ranger ranger = new Ranger("Legolas");
            Weapon bow = new Weapon("Common Bow", 1, WeaponType.Bow, 2);
            Armor mailHelm = new Armor("Common mail helm", 1, Slot.Head, ArmorType.Mail, 0, 2, 0);
            Armor mailChest = new Armor("Common mail chest", 1, Slot.Body, ArmorType.Mail, 0, 4, 0);
            Armor mailLegs = new Armor("Common mail legs", 1, Slot.Legs, ArmorType.Mail, 0, 3, 0);
            ranger.EquipWeapon(bow);
            ranger.EquipArmor(mailHelm);
            ranger.EquipArmor(mailChest);
            ranger.EquipArmor(mailLegs);
            double rangerDamage = ranger.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rangerDamage);
        }
    }
}