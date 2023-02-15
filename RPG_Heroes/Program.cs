using RPG_Heroes.Hero.HeroClasses;

namespace RPG_Heroes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Mage mage = new Mage("Harry");
            mage.Display();
            mage.LevelUp();
            mage.Display();
        }
    }
}