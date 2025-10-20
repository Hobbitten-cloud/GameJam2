using JourneyGame.Models;

namespace JourneyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init game components here
            var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            string banner = @"
 __          __  _                            _          _   _                 _                                                                
 \ \        / / | |                          | |        | | | |               | |                                                               
  \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___   | |_| |__   ___       | | ___  _   _ _ __ _ __   ___ _   _    __ _  __ _ _ __ ___   ___ 
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  | __| '_ \ / _ \  _   | |/ _ \| | | | '__| '_ \ / _ \ | | |  / _` |/ _` | '_ ` _ \ / _ \
    \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |_| | | |  __/ | |__| | (_) | |_| | |  | | | |  __/ |_| | | (_| | (_| | | | | | |  __/
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \__|_| |_|\___|  \____/ \___/ \__,_|_|  |_| |_|\___|\__, |  \__, |\__,_|_| |_| |_|\___|
                                                                                                              __/ |   __/ |                     
                                                                                                             |___/   |___/";

            Console.WriteLine(banner);
            Console.ReadLine(); // Keeps the console open


            // Game initialization and main loop would go here
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{test.Name} \n{test.Dialogue}");
        }
    }
}
