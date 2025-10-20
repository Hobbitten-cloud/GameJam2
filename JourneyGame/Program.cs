using JourneyGame.Models;

namespace JourneyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init game components here
            var gameMenus = new Menu();
            //var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            // Game initialization and main loop would go here
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{test.Name} \n{test.Dialogue}");
        }
    }
}
