using JourneyGame.Models;

namespace JourneyGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            // NOTES 
            // Ascii font used = Doom
            // Website = https://patorjk.com/software/taag/#p=display&f=Doom&t=John+Journey&x=none&v=4&h=4&w=80&we=false

            // Init game components here
            var gameMenus = new Menu();
            //var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            //Console.WriteLine($"{test.Name} \n{test.Dialogue}");


            // Game initialization and main loop would go here
            //gameMenus.CombatMenu();
            gameMenus.StartMenu();
        }
    }
}