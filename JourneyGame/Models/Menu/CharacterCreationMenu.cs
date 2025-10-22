using JourneyGame.Models.Enums;
using JourneyGame.Models.ExceptionHandling;

namespace JourneyGame.Models.Menu
{
    public class CharacterCreationMenu
    {
        public CharacterCreationMenu(HouseRulesMenu houseRulesMenu)
        {
            _houseRulesMenu = houseRulesMenu;

        }
        private readonly HouseRulesMenu _houseRulesMenu;
        public Race playerRace = 0;
        new Player newPlayer;
        public Error Error = new Error();
        // Player's selected job/class from the Job enum
        public Job playerJob = 0;
        // Controls the character creation menu loop
        public bool CharacterCreationMenuLoop = true;

        // Character creation sub-loop controls for each step
        public bool CharacterLoop1 = true; // Race selection loop
        public bool CharacterLoop2 = true; // Job/Class selection loop
        public bool CharacterLoop3 = true; // Name input loop
        public bool CharacterLoop4 = true; // Character confirmation loop
        public string playerName = "";
        public void ShowCharacterCreationMenu()

        {

            // Main character creation loop - continues until character is confirmed
            while (CharacterCreationMenuLoop == true)
            {
                Console.Clear();
                int playerInput = 0;

                // ===========================================
                // STEP 1: RACE SELECTION
                // ===========================================
                while (CharacterLoop1 == true)
                {
                    // Display race selection menu with ASCII art
                    Console.WriteLine(" _____ _                          _              _____                _   _             \r\n/  __ \\ |                        | |            /  __ \\              | | (_)            \r\n| /  \\/ |__   __ _ _ __ __ _  ___| |_ ___ _ __  | /  \\/_ __ ___  __ _| |_ _  ___  _ __  \r\n| |   | '_ \\ / _` | '__/ _` |/ __| __/ _ \\ '__| | |   | '__/ _ \\/ _` | __| |/ _ \\| '_ \\ \r\n| \\__/\\ | | | (_| | | | (_| | (__| ||  __/ |    | \\__/\\ | |  __/ (_| | |_| | (_) | | | |\r\n \\____/_| |_|\\__,_|_|  \\__,_|\\___|\\__\\___|_|     \\____/_|  \\___|\\__,_|\\__|_|\\___/|_| |_|\r\n                                                                                        \r\n                                                                                        ");
                    Console.WriteLine("Pick your race");
                    Console.WriteLine($"1.{Race.Human}");
                    Console.WriteLine($"2.{Race.Elf}");
                    Console.WriteLine($"3.{Race.Dwarf}");
                    Console.WriteLine($"4.{Race.Orc}");
                    Console.WriteLine($"5.{Race.Goblin}");
                    Console.WriteLine();
                    Console.Write("Write your input: ");

                    // Get and validate race selection
                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    // Validate input range (1-5)
                    if (playerInput >= 1 && playerInput <= 5)
                    {
                        CharacterLoop1 = false; // Exit race selection loop
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }

                // Set the selected race based on player input
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
                playerInput = 0; // Reset input for next step

                // ===========================================
                // STEP 2: CLASS/JOB SELECTION
                // ===========================================
                while (CharacterLoop2 == true)
                {
                    Console.WriteLine("Pick your class");
                    Console.WriteLine($"1.{Job.Warrior}");
                    Console.WriteLine($"2.{Job.Mage}");
                    Console.WriteLine($"3.{Job.Archer}");
                    Console.WriteLine($"4.{Job.Thief}");
                    Console.WriteLine($"5.{Job.Paladin}");
                    Console.WriteLine($"6.{Job.Banker}");
                    Console.WriteLine($"7.{Job.Butcher}");
                    Console.WriteLine($"8.{Job.Bard}");
                    Console.WriteLine($"9.{Job.Jester}");
                    Console.WriteLine($"10.{Job.Chef}");
                    Console.WriteLine();
                    Console.Write("Write your input: ");

                    // Get and validate class selection
                    try
                    {
                        playerInput = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Error.BasicException();
                    }

                    // Validate input range (1-10)
                    if (playerInput >= 1 && playerInput <= 10)
                    {
                        CharacterLoop2 = false; // Exit class selection loop
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }

                // Set the selected job/class based on player input
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
                    case 6:
                        playerJob = Job.Banker;
                        break;
                    case 7:
                        playerJob = Job.Butcher;
                        break;
                    case 8:
                        playerJob = Job.Bard;
                        break;
                    case 9:
                        playerJob = Job.Jester;
                        break;
                    case 10:
                        playerJob = Job.Chef;
                        break;
                }

                Console.Clear();

                // ===========================================
                // STEP 3: NAME INPUT
                // ===========================================
                while (CharacterLoop3 == true)
                {
                    Console.WriteLine("Who are you?");
                    Console.WriteLine();
                    Console.Write("Write your name: ");
                    playerName = Console.ReadLine();

                    // Validate that name is not empty or whitespace
                    if (!string.IsNullOrWhiteSpace(playerName))
                    {
                        CharacterLoop3 = false; // Exit name input loop
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }

                Console.Clear();
                playerInput = 0; // Reset player input for confirmation
                CharacterLoop4 = true; // Reset confirmation loop

                // ===========================================
                // STEP 4: CHARACTER CONFIRMATION
                // ===========================================

                // Create player object to display stats
                var newPlayer = new Player(playerName, playerRace, playerJob);

                while (CharacterLoop4 == true)
                {
                    // Display character summary for confirmation
                    Console.WriteLine($"Character Details: \n\n" +
                        $"Name: {playerName} - {newPlayer.Title} \n" +
                        $"Race: {playerRace.ToString()} \n" +
                        $"Class: {playerJob.ToString()} \n" +
                        $"Health: {newPlayer.Health}");

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
                        // Player confirms character - proceed to house rules
                        Console.Clear();
                        _houseRulesMenu.Setplayer(newPlayer);
                        CharacterLoop4 = false;
                        _houseRulesMenu.ShowHouseRulesMenu();
                    }
                    else if (playerInput == 2)
                    {
                        // Player wants to restart character creation
                        CharacterLoop4 = false;
                        CharacterLoop1 = true; // Reset race selection
                        CharacterLoop2 = true; // Reset class selection
                        CharacterLoop3 = true; // Reset name input
                        continue; // Restart the character creation process
                    }
                    else
                    {
                        Error.BasicException();
                    }
                }
            }
        }

    }
}
