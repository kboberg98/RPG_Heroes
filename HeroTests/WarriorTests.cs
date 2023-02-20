using RPG_Heroes.Hero.CustomExceptions;
using RPG_Heroes.Hero.HeroClasses;
using RPG_Heroes.Hero.Items;
using RPG_Heroes.Hero.Inventory;
using RPG_Heroes.Hero.Attributes;

namespace HeroTests
{
    public class WarriorTests
    {
        [Fact]
        public void CreateWarrior_WarriorHasCorrect_Name_Level_Attributes()
        {
            //Arrange
            string expectedName = "Aragorn";
            int expectedLevel = 1;
            int expectedStrength = 5;
            int expectedDexterity = 2;
            int expectedIntelligence = 1;

            //Act
            Warrior warrior = new("Aragorn");

            //Assert
            Assert.Equal(expectedName, warrior.Name);
            Assert.Equal(expectedLevel, warrior.Level);
            Assert.Equal(expectedStrength, warrior.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, warrior.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, warrior.LevelAttributes.Intelligence);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void LevelUpWarrior_WarriorHasCorrectAttributes(int levelUpAmount)
        {
            //Arrange
            int expectedLevel = 1 + (1 * levelUpAmount);
            int expectedStrength = 5 + (3 * levelUpAmount);
            int expectedDexterity = 2 + (2 * levelUpAmount);
            int expectedIntelligence = 1 + (1 * levelUpAmount);

            //Act
            Warrior warrior = new("Aragorn");
            for (int i = 0; i < levelUpAmount; i++) { warrior.LevelUp(); }

            //Assert
            Assert.Equal(expectedLevel, warrior.Level);
            Assert.Equal(expectedStrength, warrior.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, warrior.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, warrior.LevelAttributes.Intelligence);
        }

        [Fact]
        public void EquipArmor_InvalidArmorType_ThrowsInvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("Aragorn");
            Armor armor = new Armor("Invalid Armor", 1, Slot.Body, ArmorType.Cloth, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(armor));
        }

        [Fact]
        public void EquipArmor_InvalidArmorLevelRequirement_ThrowsInvalidArmorException()
        {
            // Arrange
            Warrior warrior = new Warrior("Aragorn");
            Armor armor = new Armor("Invalid Armor", 5, Slot.Body, ArmorType.Plate, 1, 1, 1);

            // Act and Assert
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(armor));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponType_ThrowsInvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("Aragorn");
            Weapon weapon = new Weapon("Invalid Weapon", 1, WeaponType.Staff, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(weapon));
        }

        [Fact]
        public void EquipWeapon_InvalidWeaponLevelRequirement_ThrowsInvalidWeaponException()
        {
            // Arrange
            Warrior warrior = new Warrior("Aragorn");
            Weapon weapon = new Weapon("Invalid Weapon", 5, WeaponType.Sword, 1);

            // Act and Assert
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(weapon));
        }

        [Fact]
        public void WarriorWithoutArmor_WarriorHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 5;
            int expectedTotalDexterity = 2;
            int expectedTotalIntelligence = 1;

            //Act
            Warrior warrior = new Warrior("Aragorn");
            HeroAttributes totalAttributes = warrior.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void WarriorWithOnePieceOfArmor_WarriorHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 5 + 5;
            int expectedTotalDexterity = 2 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Armor plateChestPiece = new Armor("Platechest", 1, Slot.Body, ArmorType.Plate, 5, 2, 1);
            warrior.EquipArmor(plateChestPiece);
            HeroAttributes totalAttributes = warrior.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void WarriorWithTwoPiecesOfArmor_WarriorHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 5 + 5 + 1;
            int expectedTotalDexterity = 2 + 2 + 2;
            int expectedTotalIntelligence = 1 + 1;

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Armor plateHeadPiece = new Armor("Platehead", 1, Slot.Head, ArmorType.Plate, 5, 2, 0);
            Armor plateChestPiece = new Armor("Platechest", 1, Slot.Body, ArmorType.Plate, 1, 2, 1);
            warrior.EquipArmor(plateHeadPiece);
            warrior.EquipArmor(plateChestPiece);
            HeroAttributes totalAttributes = warrior.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void WarriorWithReplacedPieceOfArmor_WarriorHasCorrectTotalAttributes()
        {
            //Arrange
            int expectedTotalStrength = 5 + 4;
            int expectedTotalDexterity = 2;
            int expectedTotalIntelligence = 1;

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Armor plateHeadPiece = new Armor("Platehead", 1, Slot.Head, ArmorType.Plate, 2, 0, 0);
            Armor betterPlateHeadPiece = new Armor("Rare Platehead", 1, Slot.Head, ArmorType.Plate, 4, 0, 0);
            warrior.EquipArmor(plateHeadPiece);
            warrior.EquipArmor(betterPlateHeadPiece);
            HeroAttributes totalAttributes = warrior.GetTotalAttributes();

            //Assert
            Assert.Equal(expectedTotalStrength, totalAttributes.Strength);
            Assert.Equal(expectedTotalDexterity, totalAttributes.Dexterity);
            Assert.Equal(expectedTotalIntelligence, totalAttributes.Intelligence);
        }

        [Fact]
        public void WarriorDamageWithoutWeapon_WarriorHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 1 * (1 + ((double)5 / 100));

            //Act
            Warrior warrior = new Warrior("Aragorn");
            double warriorDamage = warrior.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, warriorDamage);
        }

        [Fact]
        public void WarriorDamageWithWeapon_WarriorHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)5 / 100));

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Weapon sword = new Weapon("Common Sword", 1, WeaponType.Sword, 2);
            warrior.EquipWeapon(sword);
            double warriorDamage = warrior.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, warriorDamage);
        }

        [Fact]
        public void WarriorDamageWithReplacedWeapon_WarriorHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 5 * (1 + ((double)5 / 100));

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Weapon sword = new Weapon("Common Sword", 1, WeaponType.Sword, 2);
            Weapon betterDagger = new Weapon("Rare Sword", 1, WeaponType.Sword, 5);
            warrior.EquipWeapon(sword);
            warrior.EquipWeapon(betterDagger);
            double warriorDamage = warrior.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, warriorDamage);
        }

        [Fact]
        public void WarriorDamageWithWeaponAndArmor_WarriorHasCorrectDamage()
        {
            //Arrange
            double expectedDamage = 2 * (1 + ((double)(5 + 2 + 4 + 3) / 100));

            //Act
            Warrior warrior = new Warrior("Aragorn");
            Weapon sword = new Weapon("Common Sword", 1, WeaponType.Sword, 2);
            Armor plateHelm = new Armor("Common plate helm", 1, Slot.Head, ArmorType.Plate, 2, 0, 0);
            Armor plateChest = new Armor("Common plate chest", 1, Slot.Body, ArmorType.Plate, 4, 0, 0);
            Armor plateLegs = new Armor("Common plate legs", 1, Slot.Legs, ArmorType.Plate, 3, 0, 0);
            warrior.EquipWeapon(sword);
            warrior.EquipArmor(plateHelm);
            warrior.EquipArmor(plateChest);
            warrior.EquipArmor(plateLegs);
            double warriorDamage = warrior.GetHeroDamage();

            //Assert
            Assert.Equal(expectedDamage, warriorDamage);
        }

        [Fact]
        public void DisplayWarriorState_WarriorDispayCorrectState()
        {
            // Arrange
            string expectedName = "Aragorn";
            int expectedLevel = 1 + 10;
            int expectedStrength = 5 + (3 * 10) + 10 + 14 + 12;
            int expectedDexterity = 2 + (2 * 10) + 2 + 2 + 2;
            int expectedIntelligence = 1 + (1 * 10) + 2 + 2 + 2;
            double expectedDamage = 100 * (1 + ((double)expectedStrength / 100));

            // Act: call the Display() method and capture the output
            Warrior warrior = new Warrior("Aragorn");
            Weapon epicWeapon = new Weapon("Epic Sword", 10, WeaponType.Sword, 100);
            Armor epicHead = new Armor("Epic Head", 8, Slot.Head, ArmorType.Plate, 10, 2, 2);
            Armor epicChest = new Armor("Epic Chest", 9, Slot.Body, ArmorType.Plate, 14, 2, 2);
            Armor epicLegs = new Armor("Epic Legs", 1, Slot.Legs, ArmorType.Plate, 12, 2, 2);
            for (int i = 0; i < 10; i++) { warrior.LevelUp(); }
            warrior.EquipWeapon(epicWeapon);
            warrior.EquipArmor(epicHead);
            warrior.EquipArmor(epicChest);
            warrior.EquipArmor(epicLegs);

            string output = warrior.Display();

            // Assert: check if the output matches the expected output
            Assert.Contains("Name: " + expectedName, output);
            Assert.Contains("Class: " + "Warrior", output);
            Assert.Contains("Level: " + expectedLevel, output);
            Assert.Contains("Strength: " + expectedStrength, output);
            Assert.Contains("Dexterity: " + expectedDexterity, output);
            Assert.Contains("Intelligence: " + expectedIntelligence, output);
            Assert.Contains("Hero Damage: " + expectedDamage, output);
        }
    }
}