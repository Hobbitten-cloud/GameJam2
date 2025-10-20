using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    public class Menu
    {
        // Start MENUS
        public void StartMenu()
        {
            bool loopEnded = false;

            while (loopEnded == true)
            {
                Console.WriteLine("Welcome to the Journey Game!");
                Console.WriteLine("1. Start New Game");
                Console.WriteLine("2. Credits");
                Console.WriteLine("3. Quit");
                int PlayerInput = Convert.ToInt32(Console.ReadLine());

                if (PlayerInput == 1)
                {
                    Console.WriteLine("");

                }
                else if (PlayerInput == 2)
                {
                    Console.WriteLine("Game developed by: \nBirk\nAlbert\nDennis\nNicklas\nPatrick");
                }
                else if (PlayerInput == 3)
                {
                    Environment.Exit(0);
                }

            }
        }

        public void CharacterCreationMenu()
        {

        }


        // GAME MENUS
        public void HouseMenu()
        {

        }
    }
}
