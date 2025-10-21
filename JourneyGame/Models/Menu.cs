using JourneyGame.Models.Enums;
using JourneyGame.Models.ExceptionHandling;
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
        // Menu properties
        #region
        // Class objects
        public Error Error = new Error();

        // Create an instance of your item repository
        ItemRepo itemRepo = new ItemRepo();

        // Set which item is in this room (e.g., the Sock Sling with Id = 3)
        int itemId = -1;

        // Start menu properties
        public bool StartMenuLoop = true;

        // Character creation properties
        public bool CharacterCreationMenuLoop = true;
        public Race playerRace = 0;
        public Job playerJob = 0;
        public string playerName = "";
        public bool CharacterLoop1 = true;
        public bool CharacterLoop2 = true;
        public bool CharacterLoop3 = true;
        public bool CharacterLoop4 = true;

        // House rules properties
        public bool HouseRules = true;

        // House properties
        public int playerMoves = 30;
        public bool HouseMenuLoop = true;
        public bool PlayersBedroomLoop = true;
        public bool HouseLocationLoop1 = true;
        public bool HouseLocationLoop2 = true;
        public bool HouseLocationLoop3 = true;

        #endregion

        // Start MENUS
        public void StartMenu()
        {
            while (StartMenuLoop == true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   ___       _               ___                                   \r\n  |_  |     | |             |_  |                                  \r\n    | | ___ | |__  _ __       | | ___  _   _ _ __ _ __   ___ _   _ \r\n    | |/ _ \\| '_ \\| '_ \\      | |/ _ \\| | | | '__| '_ \\ / _ \\ | | |\r\n/\\__/ / (_) | | | | | | | /\\__/ / (_) | |_| | |  | | | |  __/ |_| |\r\n\\____/ \\___/|_| |_|_| |_| \\____/ \\___/ \\__,_|_|  |_| |_|\\___|\\__, |\r\n                                                              __/ |\r\n                                                             |___/ ");
                Console.ForegroundColor = ConsoleColor.White;
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
                    Error.BasicException();
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
                    Console.WriteLine("Game developed by: \nBirk\nAlbert\nDennis\nNicklas\nPatrick\nArchie\nAsk");
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
            while (CharacterCreationMenuLoop == true)
            {
                Console.Clear();

                int playerInput = 0;

                // Character menu
                while (CharacterLoop1 == true)
                {
                    Console.WriteLine(" _____ _                          _              _____                _   _             \r\n/  __ \\ |                        | |            /  __ \\              | | (_)            \r\n| /  \\/ |__   __ _ _ __ __ _  ___| |_ ___ _ __  | /  \\/_ __ ___  __ _| |_ _  ___  _ __  \r\n| |   | '_ \\ / _` | '__/ _` |/ __| __/ _ \\ '__| | |   | '__/ _ \\/ _` | __| |/ _ \\| '_ \\ \r\n| \\__/\\ | | | (_| | | | (_| | (__| ||  __/ |    | \\__/\\ | |  __/ (_| | |_| | (_) | | | |\r\n \\____/_| |_|\\__,_|_|  \\__,_|\\___|\\__\\___|_|     \\____/_|  \\___|\\__,_|\\__|_|\\___/|_| |_|\r\n                                                                                        \r\n                                                                                        ");
                    Console.WriteLine("Pick your race");
                    Console.WriteLine($"1.{Race.Human}");
                    Console.WriteLine($"2.{Race.Elf}");
                    Console.WriteLine($"3.{Race.Dwarf}");
                    Console.WriteLine($"4.{Race.Orc}");
                    Console.WriteLine($"5.{Race.Goblin}");
                    Console.WriteLine();
                    Console.Write("Write your input: ");

                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    if (playerInput >= 1 && playerInput <= 5)
                    {
                        CharacterLoop1 = false;
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }

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
                while (CharacterLoop2 == true)
                {
                    Console.WriteLine("Pick your class");
                    Console.WriteLine($"1.{Job.Warrior}");
                    Console.WriteLine($"2.{Job.Mage}");
                    Console.WriteLine($"3.{Job.Archer}");
                    Console.WriteLine($"4.{Job.Thief}");
                    Console.WriteLine($"5.{Job.Paladin}");
                    Console.WriteLine();
                    Console.Write("Write your input: ");

                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    if (playerInput >= 1 && playerInput <= 5)
                    {
                        CharacterLoop2 = false;
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }

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
                while (CharacterLoop3 == true)
                {
                    Console.WriteLine("Who are you?");
                    Console.WriteLine();
                    Console.Write("Write your name: ");
                    playerName = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(playerName))
                    {
                        CharacterLoop3 = false;
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }
                Console.Clear();
                playerInput = 0; // Reset player input for next menu
                CharacterLoop4 = true; // reset loop for confirmation

                // Confirm character creation
                var newPlayer = new Player(playerName, playerRace, playerJob);
                while (CharacterLoop4 == true)
                {
                    Console.WriteLine($"Character Details: \n\n" +
                        $"Name: {playerName} \n" +
                        $"Race: {playerRace.ToString()} \n" +
                        $"Class: {playerJob.ToString()}");

                    Console.WriteLine();
                    Console.WriteLine("Are you sure you want to contine?:");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No");
                    Console.WriteLine();
                    Console.Write("Your answer: ");
                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    if (playerInput == 1)
                    {
                        Console.Clear();
                        CharacterLoop4 = false;
                        HouseRulesMenu();
                    }
                    else if (playerInput == 2)
                    {
                        CharacterLoop4 = false;
                        CharacterLoop1 = true;
                        CharacterLoop2 = true;
                        CharacterLoop3 = true;
                        continue;
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }
            }
        }

        // GAME MENUS
        public void HouseRulesMenu()
        {
            int playerInput = 0;

            // Intro to the house menu
            while (HouseRules == true)
            {
                Console.WriteLine(
                    " _   _ _____ _   _ _____ _____  ______ _   _ _      _____ _____ \r\n| | | |  _  | | | /  ___|  ___| | ___ \\ | | | |    |  ___/  ___|\r\n| |_| | | | | | | \\ `--.| |__   | |_/ / | | | |    | |__ \\ `--. \r\n|  _  | | | | | | |`--. \\  __|  |    /| | | | |    |  __| `--. \\\r\n| | | \\ \\_/ / |_| /\\__/ / |___  | |\\ \\| |_| | |____| |___/\\__/ /\r\n\\_| |_/\\___/ \\___/\\____/\\____/  \\_| \\_|\\___/\\_____/\\____/\\____/ \r\n                                                                \r\n                                                                \n" +
                    "1. You have 30 moves to explore your house \n" +
                    "2. Try to find as many items as you can before you leave \n" +
                    "3. You can only move to one room at a time \n" +
                    "4. Have fun!"
                );

                Console.WriteLine();
                Console.Write("Type 1: to continue: ");
                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Error.BasicException();
                }

                if (playerInput == 1)
                {
                    Console.Clear();
                    HouseRules = false;
                    HouseMenu();
                }
                else
                {
                    Error.BasicException();
                }
            }
        }

        public void HouseMenu()
        {
            Console.Clear();
            string currentLocation = "";
            int playerInput = 0;

            while (HouseMenuLoop == true)
            {
                // NOTES FOR TOMORROW
                // MAKE A MAP SYSTEM THAT CAN TRACK WHERE THE PLAYER IS AND WHERE THEY CAN GO FROM THERE
                // MAKE A ITEM SYSTEM THAT CAN ALLOW THE PLAYER TO PICK UP ITEMS AND STORE THEM IN THEIR INVENTORY

                // Navigation information
                while (PlayersBedroomLoop == true)
                {
                    Console.WriteLine($"You are currently at: {playerName}'s bedroom ");
                    Console.WriteLine($"You have {playerMoves} moves left");
                    Console.WriteLine();
                    Console.WriteLine("Do you want to grab some items from your room before leaving?\n" +
                        "1. Yes \n" +
                        "2. No\n"
                    );
                    Console.Write("Write your input: ");
                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    if (playerInput < 1 || playerInput > 2)
                    {
                        Error.BasicException();
                    }

                    // Define which items are in this room
                    int itemId1 = 1; // Cactus Shield
                    int itemId2 = 2; // Dice Set
                    int itemId3 = 3; // Sock Sling
                    int itemId4 = 4; // Mirror
                    int itemId5 = 5; // Spoon
                    int itemId6 = 6; // Photograh
                    int itemId7 = 7; // Jacket
                    int itemId8 = 8; // Moms Toy
                    int itemId9 = 9; // House keys - Forgets this item game ends
                    int itemId10 = 10; // Bird Book

                    // Fetch them once
                    var item1 = itemRepo.FindById(itemId1);
                    var item2 = itemRepo.FindById(itemId2);
                    var item3 = itemRepo.FindById(itemId3);
                    var item4 = itemRepo.FindById(itemId4);
                    var item5 = itemRepo.FindById(itemId5);
                    var item6 = itemRepo.FindById(itemId6);
                    var item7 = itemRepo.FindById(itemId7);
                    var item8 = itemRepo.FindById(itemId8);
                    var item9 = itemRepo.FindById(itemId9);
                    var item10 = itemRepo.FindById(itemId10);

                    // Then when the player chooses option 1 to check the room:
                    if (playerInput == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Items available in your room:\n" +
                            $"1. Pickup {item1.Name} - {item1.Description}\n" +
                            $"2. Pickup {item2.Name} - {item2.Description}\n" +
                            "3. Exit room without picking up items\n"
                        );
                        Console.Write("Select 1 of the options above");
                        Console.WriteLine();

                        if (!int.TryParse(Console.ReadLine(), out int choice))
                        {
                            Error.BasicException();
                        }
                        else
                        {
                            switch (choice)
                            {
                                case 1:
                                    if (item1 != null)
                                    {
                                        Inventory.AddItem(item1);
                                        Console.WriteLine($"You picked up: {item1.Name}");
                                        itemRepo.items.Remove(item1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You already picked this item up");
                                    }
                                    break;
                                case 2:
                                    if (item2 != null)
                                    {
                                        Inventory.AddItem(item1);
                                        Console.WriteLine($"You picked up: {item1.Name}");
                                        itemRepo.items.Remove(item1);
                                    }
                                    else
                                    {
                                        Console.WriteLine("You already picked this item up");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("\nYou leave the room without picking anything up.");
                                    break;
                                default:
                                    Error.BasicException();
                                    break;
                            }
                        }

                        Console.WriteLine("\nPress Enter to continue...");
                        Console.ReadLine();
                    }
                    else if (playerInput == 2)
                    {
                        PlayersBedroomLoop = false;
                    }
                }



                playerInput = 0;
                Console.WriteLine(
                    // ASCII Art Title
                    " _   _             _             _   _             \r\n| \\ | |           (_)           | | (_)            \r\n|  \\| | __ ___   ___  __ _  __ _| |_ _  ___  _ __  \r\n| . ` |/ _` \\ \\ / / |/ _` |/ _` | __| |/ _ \\| '_ \\ \r\n| |\\  | (_| |\\ V /| | (_| | (_| | |_| | (_) | | | |\r\n\\_| \\_/\\__,_| \\_/ |_|\\__, |\\__,_|\\__|_|\\___/|_| |_|\r\n                      __/ |                        \r\n                     |___/                         \n" +
                    "1. Go to the Living Room \n" +
                    "2. Go to the Kitchen \n" +
                    "3. Go to the Bathroom \n" +
                    "4. Go to your parents bedroom \n"
                // add more options?
                );

                Console.Write("Write your input: ");
                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    playerMoves--;
                    Error.BasicException();
                }

                if (playerInput < 1 || playerInput > 4)
                {
                    playerMoves--;
                    Error.BasicException();
                }

                playerMoves--;
                string livingRoom = "Living Room";
                string kitchen = "Kitchen";
                string bathroom = "Bathroom";
                string parentsBedroom = "Parents Bedroom";

                // Choose starter location
                while (HouseLocationLoop1 == true)
                {
                    switch (playerInput)
                    {
                        case 1:
                            currentLocation = livingRoom;
                            break;
                        case 2:
                            currentLocation = kitchen;
                            break;
                        case 3:
                            currentLocation = bathroom;
                            break;
                        case 4:
                            currentLocation = parentsBedroom;
                            break;
                    }
                    if (playerInput < 1 || playerInput > 4)
                    {
                        Console.WriteLine($"Your now at the {currentLocation}");
                    }

                    if (currentLocation == livingRoom)
                    {

                    }
                }


                if (playerMoves <= 0)
                {
                    HouseMenuLoop = false;
                    Console.WriteLine("You have run out of moves! Time to leave the house.");
                    Console.Write("Press any key to continue: ");
                    Console.ReadLine();
                    Console.Clear();
                    WorldMenu();
                }
            }
        }


        public void WorldMenu()
        {
            // World menu logic here
        }
    }
}
