using JourneyGame.Models;

namespace JourneyGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Init game components here
            var gameMenus = new Menu();
            //var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            //Console.WriteLine($"{test.Name} \n{test.Dialogue}");


            // Game initialization and main loop would go here
            //gameMenus.StartMenu();
            gameMenus.StartMenu();
        }
    }
}
