using JourneyGame.Models;

namespace JourneyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init game components here
            var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            Console.WriteLine("Welcome to Journey Game!");
            // Game initialization and main loop would go here
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{test.Name} \n{test.Dialogue}");

            var HumanPaladin = new Npc("Ramon", Models.Enums.Race.Human, "I used to be an adventurer like you, then I took a fireball in a tar pit");
            var OrcWizard = new Npc("Brutalitops", Models.Enums.Race.Orc, "My name is Brutalitops (evil laugh) the magician");
            var HumanWarrior = new Npc("Jon Xina", Models.Enums.Race.Human, "I love ice cream!");
        }
    }
}
