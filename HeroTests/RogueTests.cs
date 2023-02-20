using RPG_Heroes.Hero.CustomExceptions;
using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Attributes;

namespace HeroTests
{
    public class RogueTests
    {
        [Fact]
        public void CreateRogue_RogueHasCorrect_Name_Level_Attributes()
        {
            //Arrange
            string expectedName = "Mr.Stealth";
            int expectedLevel = 1;
            int expectedStrength = 2;
            int expectedDexterity = 6;
            int expectedIntelligence = 1;

            //Act
            Rogue rogue = new("Mr.Stealth");

            //Assert
            Assert.Equal(expectedName, rogue.Name);
            Assert.Equal(expectedLevel, rogue.Level);
            Assert.Equal(expectedStrength, rogue.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, rogue.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, rogue.LevelAttributes.Intelligence);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void LevelUpRogue_RogueHasCorrectAttributes(int levelUpAmount)
        {
            //Arrange
            int expectedLevel = 1 + (1 * levelUpAmount);
            int expectedStrength = 2 + (1 * levelUpAmount);
            int expectedDexterity = 6 + (4 * levelUpAmount);
            int expectedIntelligence = 1 + (1 * levelUpAmount);

            //Act
            Rogue rogue = new("Mr.Stealth");
            for (int i = 0; i < levelUpAmount; i++) { rogue.LevelUp(); }

            //Assert
            Assert.Equal(expectedLevel, rogue.Level);
            Assert.Equal(expectedStrength, rogue.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, rogue.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, rogue.LevelAttributes.Intelligence);
        }

        [Fact]
        public void EquipArmor_InvalidArmorType_ThrowsInvalidArmorException()
        {
            // Arrange
            Rogue rogue = new Rogue("Mr.Stealth");
            Armor armor = new Armor("Invalid Armor", 1, Slot.Body, ArmorType.Plate, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(armor));
        }

        [Fact]
        public void EquipArmor_InvalidArmorLevelRequirement_ThrowsInvalidArmorException()
        {
            // Arrange
            Rogue rogue = new Rogue("Mr.Stealth");
            Armor armor = new Armor("Invalid Armor", 5, Slot.Body, ArmorType.Leather, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(armor));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponType_ThrowsInvalidWeaponException()
        {
            // Arrange
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon weapon = new Weapon("Invalid Weapon", 1, WeaponType.Axe, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponLevelRequirement_ThrowsInvalidWeaponException()
        {
            // Arrange
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon weapon = new Weapon("Invalid Weapon", 5, WeaponType.Dagger, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(weapon));
        }

        [Fact]
        public void RogueWithoutArmor_RogueHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 2;
            int expectedTotalDexterity = 6;
            int expectedTotalIntelligence = 1;

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            HeroAttributes totalAttributes = rogue.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RogueWithOnePieceOfArmor_RogueHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 2 + 1;
            int expectedTotalDexterity = 6 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Armor leatherChestPiece = new Armor("Leatherchest", 1, Slot.Body, ArmorType.Leather, 1, 2, 1);
            rogue.EquipArmor(leatherChestPiece);
            HeroAttributes totalAttributes = rogue.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RogueWithTwoPiecesOfArmor_RogueHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 2 + 1;
            int expectedTotalDexterity = 6 + 2 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Armor leatherHeadPiece = new Armor("Leatherhead", 1, Slot.Head, ArmorType.Leather, 0, 2, 0);
            Armor leatherChestPiece = new Armor("Leatherchest", 1, Slot.Body, ArmorType.Leather, 1, 2, 1);
            rogue.EquipArmor(leatherHeadPiece);
            rogue.EquipArmor(leatherChestPiece);
            HeroAttributes totalAttributes = rogue.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RogueWithReplacedPieceOfArmor_RogueHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 2;
            int expectedTotalDexterity = 6 + 4;
            int expectedTotalIntelligence = 1;

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Armor leatherHeadPiece = new Armor("Leatherhead", 1, Slot.Head, ArmorType.Leather, 0, 2, 0);
            Armor betterLeatherHeadPiece = new Armor("Rare Leatherhead", 1, Slot.Head, ArmorType.Leather, 0, 4, 0);
            rogue.EquipArmor(leatherHeadPiece);
            rogue.EquipArmor(betterLeatherHeadPiece);
            HeroAttributes totalAttributes = rogue.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void RogueDamageWithoutWeapon_RogueHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 1 * (1 + ((double)6 / 100));

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            double rogueDamage = rogue.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rogueDamage);
        }

        [Fact]
        public void RogueDamageWithWeapon_RogueHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)6 / 100));

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon dagger = new Weapon("Common Dagger", 1, WeaponType.Dagger, 2);
            rogue.EquipWeapon(dagger);
            double rogueDamage = rogue.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rogueDamage);
        }

        [Fact]
        public void RogueDamageWithReplacedWeapon_RogueHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 5 * (1 + ((double)6 / 100));

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon dagger = new Weapon("Common Dagger", 1, WeaponType.Dagger, 2);
            Weapon betterDagger = new Weapon("Rare Dagger", 1, WeaponType.Dagger, 5);
            rogue.EquipWeapon(dagger);
            rogue.EquipWeapon(betterDagger);
            double rogueDamage = rogue.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rogueDamage);
        }

        [Fact]
        public void RogueDamageWithWeaponAndArmor_RogueHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)(6 + 2 + 4 + 3) / 100));

            //Act
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon dagger = new Weapon("Common Dagger", 1, WeaponType.Dagger, 2);
            Armor leatherHelm = new Armor("Common leather helm", 1, Slot.Head, ArmorType.Leather, 0, 2, 0);
            Armor leatherChest = new Armor("Common leather chest", 1, Slot.Body, ArmorType.Leather, 0, 4, 0);
            Armor leatherLegs = new Armor("Common leather legs", 1, Slot.Legs, ArmorType.Leather, 0, 3, 0);
            rogue.EquipWeapon(dagger);
            rogue.EquipArmor(leatherHelm);
            rogue.EquipArmor(leatherChest);
            rogue.EquipArmor(leatherLegs);
            double rogueDamage = rogue.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, rogueDamage);
        }

        [Fact]
        public void DisplayRogueState_RogueDispayCorrectState()
        {
            // Arrange
            string expectedName = "Mr.Stealth";
            int expectedLevel = 1 + 10;
            int expectedStrength = 2 + (1 * 10) + 2 + 2 + 2;
            int expectedDexterity = 6 + (4 * 10) + 10 + 14 + 12;
            int expectedIntelligence = 1 + (1 * 10) + 2 + 2 + 2;
            double expectedDamage = 100 * (1 + ((double)expectedDexterity / 100));

            // Act: call the Display() method and capture the output
            Rogue rogue = new Rogue("Mr.Stealth");
            Weapon epicWeapon = new Weapon("Epic Dagger", 10, WeaponType.Dagger, 100);
            Armor epicHead = new Armor("Epic Head", 8, Slot.Head, ArmorType.Leather, 2, 10, 2);
            Armor epicChest = new Armor("Epic Chest", 9, Slot.Body, ArmorType.Leather, 2, 14, 2);
            Armor epicLegs = new Armor("Epic Legs", 6, Slot.Legs, ArmorType.Leather, 2, 12, 2);
            for (int i = 0; i < 10; i++) { rogue.LevelUp(); }
            rogue.EquipWeapon(epicWeapon);
            rogue.EquipArmor(epicHead);
            rogue.EquipArmor(epicChest);
            rogue.EquipArmor(epicLegs);

            string output = rogue.Display();

            // Assert: check if the output matches the expected output
            Assert.Contains("Name: " + expectedName, output);
            Assert.Contains("Class: " + "Rogue", output);
            Assert.Contains("Level: " + expectedLevel, output);
            Assert.Contains("Strength: " + expectedStrength, output);
            Assert.Contains("Dexterity: " + expectedDexterity, output);
            Assert.Contains("Intelligence: " + expectedIntelligence, output);
            Assert.Contains("Hero Damage: " + expectedDamage, output);
        }
    }
}