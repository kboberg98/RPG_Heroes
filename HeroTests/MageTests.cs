using RPG_Heroes.Hero.HeroClasses;
namespace HeroTests
{
    public class MageTests
    {
        [Fact]
        public void CreateMage_MageHasCorrectName()
        {
            //Arrange
            Mage mage = new Mage("Harry");

            //Act
            string expectedName = "Harry";

            //Assert
            Assert.Equal(expectedName, mage.Name);

        }
    }
}