using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    public class Menu
    {
        public bool StartMenuLoop = true;

        // Character creation properties
        public Race playerRace = 0;
        public Job playerJob = 0;
        public string playerName = "";

        // Start MENUS
        public void StartMenu()
        {
            while (StartMenuLoop == true)
            {
                Console.WriteLine("Welcome to the [PLACEHOLDER]");
                Console.WriteLine("1. Start New Game");
                Console.WriteLine("2. Credits");
                Console.WriteLine("3. Quit");
                Console.WriteLine();
                Console.Write("Write your input: ");

                int PlayerInput = 0;
                // Get Player Input
                try
                {
                    PlayerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error! Please try again!");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (PlayerInput == 1)
                {
                    StartMenuLoop = false;
                    Console.Clear();
                    Console.WriteLine(
                        "Backstory: \n" +
                        "You just woke up and you realise your parents left for work. \n" +
                        "You are all alone in the house. \n" +
                        "So now its time to choose who you will be. \n" +
                        "Choose wisely!"
                        );
                    Console.Write("\nPress anything to continue ");
                    Console.ReadLine();
                    CharacterCreationMenu();
                }
                else if (PlayerInput == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Game developed by: \nBirk\nAlbert\nDennis\nNicklas\nPatrick");
                    Console.WriteLine();
                    Console.Write("Press any key to return: ");
                    Console.ReadLine();
                    Console.Clear();
                    StartMenu();
                }
                else if (PlayerInput == 3)
                {
                    Environment.Exit(0);
                }

            }
        }

        public void CharacterCreationMenu()
        {
            Console.Clear();

            int playerInput;

            // Character menu
            Console.WriteLine("Character Creation Menu");
            Console.WriteLine("Pick your race");
            Console.WriteLine($"1.{Race.Human}");
            Console.WriteLine($"2.{Race.Elf}");
            Console.WriteLine($"3.{Race.Dwarf}");
            Console.WriteLine($"4.{Race.Orc}");
            Console.WriteLine($"5.{Race.Goblin}");
            Console.WriteLine();
            Console.Write("Write your input: ");
            playerInput = Convert.ToInt32(Console.ReadLine());

            switch (playerInput)
            {
                case 1:
                    playerRace = Race.Human;
                    break;
                case 2:
                    playerRace = Race.Elf;
                    break;
                case 3:
                    playerRace = Race.Dwarf;
                    break;
                case 4:
                    playerRace = Race.Orc;
                    break;
                case 5:
                    playerRace = Race.Goblin;
                    break;
            }

            Console.Clear();
            playerInput = 0;

            // Class selection for your character
            Console.WriteLine("Pick your class");
            Console.WriteLine($"1.{Job.Warrior}");
            Console.WriteLine($"2.{Job.Mage}");
            Console.WriteLine($"3.{Job.Archer}");
            Console.WriteLine($"4.{Job.Thief}");
            Console.WriteLine($"5.{Job.Paladin}");
            Console.WriteLine();
            Console.Write("Write your input: ");
            playerInput = Convert.ToInt32(Console.ReadLine());

            switch (playerInput)
            {
                case 1:
                    playerJob = Job.Warrior;
                    break;
                case 2:
                    playerJob = Job.Mage;
                    break;
                case 3:
                    playerJob = Job.Archer;
                    break;
                case 4:
                    playerJob = Job.Thief;
                    break;
                case 5:
                    playerJob = Job.Paladin;
                    break;
            }

            Console.Clear();

            // Name your character
            Console.WriteLine("Who are you?");
            Console.WriteLine();
            Console.Write("Write your name: ");
            playerName = Console.ReadLine();

            Console.Clear();
            var newPlayer = new Player(playerName, playerRace, playerJob);
            Console.WriteLine($"Character Details: \n\n" +
                $"Name: {playerName} \n" +
                $"Race: {playerRace.ToString()} \n" +
                $"Class: {playerJob.ToString()}");

            Console.WriteLine();
            Console.Write("Press any key to continue: ");
            Console.ReadLine();
            Console.Clear();
            HouseMenu();
        }

        // GAME MENUS
        public void HouseMenu()
        {
            bool houseMenuLoop = true;
            int playerMoves = 30;

            // Intro to the house menu
            Console.WriteLine(
                "YOU ARE NOW READY \n" +
                "" +
                "You just created your character and are ready to start your adventure! \n" +
                "But first, you need to explore your house before you can leave. \n" +
                $"You have {playerMoves} moves to explore your house. \n" +
                $"Try to find as many items as you can before you leave. \n" +
                "Good luck! \n"
                );
            Console.Write("Press anything to continue: ");
            Console.ReadLine();

            string currentLocation = "";
            int playerInput = 0;

            // House menu loop
            Console.WriteLine();
            while (houseMenuLoop == true)
            {
                // NOTES FOR TOMORROW
                // MAKE A MAP SYSTEM THAT CAN TRACK WHERE THE PLAYER IS AND WHERE THEY CAN GO FROM THERE
                // MAKE A ITEM SYSTEM THAT CAN ALLOW THE PLAYER TO PICK UP ITEMS AND STORE THEM IN THEIR INVENTORY

                Console.WriteLine($"You are here: ");
                Console.WriteLine($"You have {playerMoves} moves left");

                playerInput = Convert.ToInt32(Console.ReadLine());


                if (playerMoves <= 0)
                {
                    Console.WriteLine("You have run out of moves! Time to leave the house.");
                    houseMenuLoop = false;
                    break;
                }
            }
        }
    }
}
