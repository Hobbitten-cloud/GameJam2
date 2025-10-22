using JourneyGame.Models.ExceptionHandling;

namespace JourneyGame.Models.Menu
{
    public class GameOverMenu
    {
        // Controls the main start menu loop
        public bool StartMenuLoop = true;
        private readonly MainMenu _mainMenu;

        public GameOverMenu(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;

        }

        // Controls the character creation menu loop
        public bool CharacterCreationMenuLoop = true;

        // Character creation sub-loop controls for each step
        public bool CharacterLoop1 = true; // Race selection loop
        public bool CharacterLoop2 = true; // Job/Class selection loop
        public bool CharacterLoop3 = true; // Name input loop
        public bool CharacterLoop4 = true; // Character confirmation loop

        // Controls the house rules explanation menu
        public bool HouseRules = true;

        // Controls the main house exploration menu
        public bool HouseMenuLoop = true;
        public int playerMoves = 30;
        ItemRepo itemRepo = new ItemRepo();
        // Loop controls
        //public bool PlayersBedroomLoop1 = true;
        //public bool PlayersBedroomLoop2 = true;
        //public bool HouseLocationLoop1 = true;
        //public bool HouseLocationLoop2 = true;
        //public bool HouseLocationLoop3 = true;
        bool firstLoop = true;

        // Controls the generic room item interaction loop
        public bool RoomItemLoop = true;

        public Error Error = new Error();
        public void ShowGameOverMenu()
        {
            Console.Clear();
            int playerInput = 0;
            bool gameOverLoop = true;

            while (gameOverLoop == true)
            {
                // Display game over screen with ASCII art
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  _____                         ____                 \r\n / ____|                       / __ \\                \r\n| |  __  __ _ _ __ ___   ___  ___| |  | |_   _____ _ __ \r\n| | |_ |/ _` | '_ ` _ \\ / _ \\/ __| |  | | | | / _ \\ '__|\r\n| |__| | (_| | | | | | |  __/ (__| |__| | |_| |  __/ |   \r\n \\_____|\\__,_|_| |_| |_|\\___|\\___|\\___\\_\\\\__,_|\\___|_|   \r\n                                                         \r\n                                                         ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("You have run out of moves!");
                Console.WriteLine("Time's up - you couldn't escape the house in time.");
                Console.WriteLine();
                Console.WriteLine($"Items collected: {Inventory.Items.Count}");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Restart Game");
                Console.WriteLine("2. Return to Main Menu");
                Console.WriteLine("3. Quit");
                Console.WriteLine();
                Console.Write("Write your input: ");

                // Get and validate player input
                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Error.BasicException();
                }

                if (playerInput >= 1 && playerInput <= 3)
                {
                    switch (playerInput)
                    {
                        case 1:
                            // Restart Game - reset all game state and start over
                            Console.Clear();
                            Console.WriteLine("Restarting game...");
                            Console.Write("Press any key to continue: ");
                            Console.ReadLine();

                            // Reset all game state
                            playerMoves = 30;
                            firstLoop = true;
                            HouseMenuLoop = true;
                            RoomItemLoop = true;
                            Inventory.Clear(); // Clear inventory

                            // Reset item repository (put all items back)
                            itemRepo = new ItemRepo();

                            Console.Clear();
                            gameOverLoop = false;
                            //HouseMenu(); // Restart house exploration
                            break;
                        case 2:
                            // Return to Main Menu
                            Console.Clear();
                            Console.WriteLine("Returning to main menu...");
                            Console.Write("Press any key to continue: ");
                            Console.ReadLine();

                            // Reset all game state
                            playerMoves = 30;
                            firstLoop = true;
                            HouseMenuLoop = true;
                            RoomItemLoop = true;
                            StartMenuLoop = true;
                            CharacterCreationMenuLoop = true;
                            CharacterLoop1 = true;
                            CharacterLoop2 = true;
                            CharacterLoop3 = true;
                            CharacterLoop4 = true;
                            HouseRules = true;
                            Inventory.Clear(); // Clear inventory

                            // Reset item repository
                            itemRepo = new ItemRepo();

                            Console.Clear();
                            gameOverLoop = false;
                            //StartMenu(); // Return to start menu
                            break;
                        case 3:
                            // Quit Game
                            Console.Clear();
                            Console.WriteLine("Thanks for playing!");
                            Console.Write("Press any key to exit: ");
                            Console.ReadLine();
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    Error.BasicException();
                }
            }
        }

    }
}


