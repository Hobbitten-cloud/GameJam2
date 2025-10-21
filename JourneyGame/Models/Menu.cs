using JourneyGame.Models.Enums;
using JourneyGame.Models.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    /// <summary>
    /// Main Menu class that handles all game menus and user interactions.
    /// This class manages the game flow from start menu through character creation to house exploration.
    /// </summary>
    public class Menu
    {
        // ===========================================
        // CLASS PROPERTIES AND FIELDS
        // ===========================================
        #region Properties and Fields
        
        // Error handling object for managing exceptions throughout the game
        public Error Error = new Error();

        // Item repository instance for managing all game items
        ItemRepo itemRepo = new ItemRepo();

        // Legacy item ID field (currently unused but kept for potential future use)
        int itemId = -1;

        // ===========================================
        // MENU LOOP CONTROL VARIABLES
        // ===========================================
        
        // Controls the main start menu loop
        public bool StartMenuLoop = true;

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
        
        // Legacy bedroom loop controls (kept for compatibility)
        public bool PlayersBedroomLoop1 = true;
        public bool PlayersBedroomLoop2 = true;
        public bool HouseLocationLoop1 = true;
        public bool HouseLocationLoop2 = true;
        public bool HouseLocationLoop3 = true;
        
        // Controls the generic room item interaction loop
        public bool RoomItemLoop = true;

        // ===========================================
        // PLAYER DATA PROPERTIES
        // ===========================================
        
        // Player's selected race from the Race enum
        public Race playerRace = 0;
        
        // Player's selected job/class from the Job enum
        public Job playerJob = 0;
        
        // Player's chosen name
        public string playerName = "";
        
        // Number of moves remaining for house exploration (starts at 30)
        public int playerMoves = 30;

        #endregion

        // ===========================================
        // MAIN GAME MENUS
        // ===========================================

        /// <summary>
        /// Displays the main start menu with game title and navigation options.
        /// Handles user input for starting a new game, viewing credits, or quitting.
        /// </summary>
        public void StartMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Main menu loop - continues until user makes a valid selection
            while (StartMenuLoop == true)
            {
                // Display the game title in green ASCII art
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   ___       _               ___                                   \r\n  |_  |     | |             |_  |                                  \r\n    | | ___ | |__  _ __       | | ___  _   _ _ __ _ __   ___ _   _ \r\n    | |/ _ \\| '_ \\| '_ \\      | |/ _ \\| | | | '__| '_ \\ / _ \\ | | |\r\n/\\__/ / (_) | | | | | | | /\\__/ / (_) | |_| | |  | | | |  __/ |_| |\r\n\\____/ \\___/|_| |_|_| |_| \\____/ \\___/ \\__,_|_|  |_| |_|\\___|\\__, |\r\n                                                              __/ |\r\n                                                             |___/ ");
                
                // Reset console color to white for menu options
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Start New Game");
                Console.WriteLine("2. Credits");
                Console.WriteLine("3. Quit");
                Console.WriteLine();
                Console.Write("Write your input: ");

                int PlayerInput = 0;
                
                // Get and validate player input with error handling
                try
                {
                    PlayerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    // Handle invalid input (non-numeric)
                    Error.BasicException();
                }

                // Process player's menu selection
                if (PlayerInput == 1)
                {
                    // Start New Game selected
                    StartMenuLoop = false; // Exit the start menu loop
                    Console.Clear();
                    
                    // Display game backstory to set the scene
                    Console.WriteLine(
                        "Backstory: \n" +
                        "You just woke up and you realise your parents left for work. \n" +
                        "You are all alone in the house. \n" +
                        "So now its time to choose who you will be. \n" +
                        "Choose wisely!"
                        );
                    Console.Write("\nPress anything to continue ");
                    Console.ReadLine();
                    
                    // Proceed to character creation
                    CharacterCreationMenu();
                }
                else if (PlayerInput == 2)
                {
                    // Credits selected - show development team
                    Console.Clear();
                    Console.WriteLine("Game developed by: \nBirk\nAlbert\nDennis\nNicklas\nPatrick\nArchie\nAsk");
                    Console.WriteLine("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡿⠿⠟⠛⠛⠉⠉⠉⠁⠀⠀⠀⠀⠀⠈⠉⠉⠩⠉⠹⠭⠙⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡿⠿⠫⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀⠀⠀⠀⠈⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠟⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⣀⠀⠈⠁⠀⠒⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⣩⠥⡽⣛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣶⣖⡄⠀⠈⠀⠀⠀⠀⠀⣀⠠⠤⠶⠄⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠖⠂⠀⠀⠀⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠉⢙⡻⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⡿⣛⡯⠖⠀⠀⠀⠀⠀⠀⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡀⠤⡈⢷⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⠿⠏⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⠶⠈⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢶⣹⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⡛⠅⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠁⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡄⠀⢀⠀⠀⠀⠄⠀⠠⠀⠀⡠⠤⠀⠀⠀⠙⢻⣿⣿⣿⣿\r\n⣿⣿⣿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣠⣤⣤⣤⡀⠤⢤⠌⢡⠤⣀⣤⣤⣴⠰⣀⣴⣼⣾⣿⣾⣿⣿⣮⣤⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⢾⣿⣿⣿\r\n⣿⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠦⢐⣥⣦⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣾⣿⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⣇⣀⣼⡂⠀⢀⠀⠀⠀⠀⠁⠀⠀⠀⠠⢤⣿⣿⣿\r\n⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠰⢏⢦⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⢢⠙⣆⠀⠀⠀⠀⡘⠀⠀⠀⠘⣻⣿⣿\r\n⣿⣿⡗⠀⠀⠀⠀⠀⠀⠀⠀⡆⢺⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⡨⢐⠡⠀⠀⠁⢀⠀⠀⠀⠈⠈⢿⣿⣿\r\n⣿⣿⢃⡄⠀⠀⠀⠀⠀⠀⠀⢾⢯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣖⠇⠃⠌⠀⠀⠀⠀⠀⠀⠀⠀⢀⢸⣿⣿\r\n⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⢂⣯⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⡂⠁⠞⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣿⣿\r\n⣿⣿⣿⣇⠏⠀⠀⠀⠀⠀⠠⡘⣮⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣅⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣾⣿⣿\r\n⣿⣿⣿⣟⡀⠀⠀⠀⠀⠀⠰⠱⠞⢿⣿⣿⠿⠿⠿⠿⣿⣿⣿⢿⣿⣿⣟⢿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⡿⠿⡿⢿⠻⠿⠿⠿⠿⠟⠀⢘⠀⡄⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿\r\n⣿⣿⣿⣿⣷⠀⠀⠀⠀⠀⠣⢃⠀⠈⠀⠀⠈⠈⠀⠉⠈⠉⠉⠁⠉⠁⠉⠁⠀⣙⣿⣿⣮⡉⠉⠈⠉⠈⠈⠉⠁⠀⠀⠀⠈⠘⠚⠡⠄⠀⠀⠀⠘⠐⠠⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿\r\n⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⣀⣾⡀⠆⠰⢀⣶⣆⠀⠀⠀⠀⠀⣀⣀⣉⣹⣏⠀⠀⠀⠀⠀⣀⣶⣆⡰⠶⠆⣰⣆⠀⠀⠀⠀⠀⠁⡀⠉⠀⠀⠀⠀⢀⠀⢾⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣧⠀⠀⠀⠈⠲⣜⣶⣤⣦⣄⠘⠉⡻⠟⢛⠿⠭⣩⣱⣽⣯⣧⣞⣿⣻⣿⣿⣿⣰⣬⣿⣿⣯⣼⠟⣯⠭⠯⢋⠭⠑⢁⣤⣄⣠⣒⡤⠁⠀⠂⠀⠠⣌⠀⢠⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣧⠠⡀⠀⢹⢺⣿⣿⣿⣾⣷⣶⣶⣶⣾⣶⣿⣿⣿⣿⣿⣿⣿⣿⣯⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣾⣶⣖⣶⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⢐⠚⢀⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⠀⢔⡀⠈⠎⢹⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣯⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⡛⠀⠀⠀⠀⡴⢁⢀⣼⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣆⠸⠳⠄⠘⡀⠘⢻⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢘⣠⣿⣿⣿⣿⣿⣿⣷⣈⣣⠙⣾⣿⣿⣿⣿⣿⣿⣿⣿⡿⠙⠅⠁⠀⠀⠀⠀⢿⡱⠈⣼⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣾⠀⠀⠀⠁⡙⠬⡹⣿⣿⣿⣿⣿⣿⣿⡃⡟⠿⣿⣿⣿⣿⣿⣿⠟⢸⢩⠆⣿⣿⣿⣿⣿⣿⣿⣏⠣⠌⠁⠂⠀⠀⠀⠀⣶⣤⣴⣾⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠑⡳⣄⣾⢿⣿⣿⣿⣿⣿⣇⠀⠀⠈⠙⠛⠛⠉⠁⠀⠀⠀⢠⣿⣿⣿⣿⣿⣿⣳⢂⡑⡆⠀⠀⠄⠁⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⠀⠀⡄⠀⠈⠾⣶⢿⣿⡿⡿⢿⡿⠟⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠜⠟⡿⣛⢿⣿⣿⠅⢮⢠⠁⠀⠈⠆⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡀⠀⠀⠀⢉⣏⡛⠉⠱⠁⠁⡀⠁⠀⠀⠀⠀⡀⠀⠀⠘⢔⠀⠄⠀⡌⡀⠘⢂⠀⠃⠛⡇⠃⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠈⠀⠀⠄⠀⠀⠂⠀⠀⠐⠂⠡⠐⠲⢇⣠⣤⠾⠂⠘⠀⠙⠐⠈⠀⠀⠀⠀⠐⡌⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⢠⠀⠀⠀⠀⠀⠖⠀⠄⣤⣶⣶⣶⣶⣶⣶⣶⣦⣤⣤⣶⣶⣶⣶⣶⡶⣶⠦⢢⡀⠂⠜⠀⠀⠀⠀⠀⠀⠀⠛⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⣷⠆⠀⠀⠀⠀⠀⠀⠏⠱⠉⡸⠎⠏⠈⠉⠁⠀⠈⠁⠉⠿⠹⠉⠉⠉⠇⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠉⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿\r\n⣿⣿⣿⠿⠟⠛⠛⠉⠀⠀⠀⠀⠀⡿⣖⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣮⠀⠀⠀⠀⠙⠻⢿⣿⣿⣿⣿⣿⣿\r\n⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⣦⠀⠀⠀⠀⠀⠀⢀⣠⠤⢀⢤⡵⢢⣽⡾⡴⢷⡽⣶⡿⣾⣷⢂⠠⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⡖⠁⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠿⢿\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢽⣿⡆⠀⠀⠀⠀⠀⠀⠀⠂⡀⠎⠀⠌⡀⠁⠍⡀⠘⡋⠐⠁⠠⠀⠒⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⠷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣾⣷⡤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⣏⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⣿⣗⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⣿⣿⡟⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀");
                    Console.WriteLine();
                    Console.Write("Press any key to return: ");
                    Console.ReadLine();
                    Console.Clear();
                    
                    // Return to start menu
                    StartMenu();
                }
                else if (PlayerInput == 3)
                {
                    // Quit selected - exit the application
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Handles the complete character creation process including race, class, name selection and confirmation.
        /// This method guides the player through creating their character with validation at each step.
        /// </summary>
        public void CharacterCreationMenu()
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
                        CharacterLoop4 = false;
                        HouseRulesMenu();
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

        // ===========================================
        // GAME RULES AND EXPLORATION MENUS
        // ===========================================

        /// <summary>
        /// Displays the house rules and game mechanics to the player before starting house exploration.
        /// Explains the move system, item collection goal, and navigation rules.
        /// </summary>
        public void HouseRulesMenu()
        {
            int playerInput = 0;

            // House rules explanation loop - continues until player acknowledges rules
            while (HouseRules == true)
            {
                // Display house rules with ASCII art title
                Console.WriteLine(
                    " _   _ _____ _   _ _____ _____  ______ _   _ _      _____ _____ \r\n| | | |  _  | | | /  ___|  ___| | ___ \\ | | | |    |  ___/  ___|\r\n| |_| | | | | | | \\ `--.| |__   | |_/ / | | | |    | |__ \\ `--. \r\n|  _  | | | | | | |`--. \\  __|  |    /| | | | |    |  __| `--. \\\r\n| | | \\ \\_/ / |_| /\\__/ / |___  | |\\ \\| |_| | |____| |___/\\__/ /\r\n\\_| |_/\\___/ \\___/\\____/\\____/  \\_| \\_|\\___/\\_____/\\____/\\____/ \r\n                                                                \r\n                                                                \n" +
                    "1. You have 30 moves to explore your house \n" +
                    "2. Try to find as many items as you can before you leave \n" +
                    "3. You can only move to one room at a time \n" +
                    "4. Have fun!"
                );

                Console.WriteLine();
                Console.Write("Type 1: to continue: ");
                
                // Get and validate player input
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
                    // Player acknowledges rules - proceed to house exploration
                    Console.Clear();
                    HouseRules = false; // Exit rules loop
                    HouseMenu(); // Start house exploration
                }
                else
                {
                    // Invalid input - show error and repeat
                    Error.BasicException();
                }
            }
        }

        /// <summary>
        /// Main house exploration menu that handles room navigation and item collection.
        /// Players start in their bedroom and can explore different rooms to find items.
        /// Each room has specific items and moving between rooms costs moves.
        /// </summary>
        public void HouseMenu()
        {
            Console.Clear();
            string currentLocation = "";
            int playerInput = 0;

            // Main house exploration loop - continues until player runs out of moves
            while (HouseMenuLoop == true)
            {
                // ===========================================
                // STARTING LOCATION: PLAYER'S BEDROOM
                // ===========================================
                
                // Handle bedroom items first (starting location)
                // Items available: Cactus Shield (ID: 1), Sock Sling (ID: 3)
                int[] bedroomItems = { 1, 3 };
                HandleRoomItems($"{playerName}'s bedroom", bedroomItems);

                // ===========================================
                // ROOM NAVIGATION MENU
                // ===========================================
                
                // Display navigation options with ASCII art
                Console.WriteLine(
                    // ASCII Art Title
                    " _   _             _             _   _             \r\n| \\ | |           (_)           | | (_)            \r\n|  \\| | __ ___   ___  __ _  __ _| |_ _  ___  _ __  \r\n| . ` |/ _` \\ \\ / / |/ _` |/ _` | __| |/ _ \\| '_ \\ \r\n| |\\  | (_| |\\ V /| | (_| | (_| | |_| | (_) | | | |\r\n\\_| \\_/\\__,_| \\_/ |_|\\__, |\\__,_|\\__|_|\\___/|_| |_|\r\n                      __/ |                        \r\n                     |___/                         \n" +
                    "1. Go to the Living Room \n" +
                    "2. Go to the Kitchen \n" +
                    "3. Go to the Bathroom \n" +
                    "4. Go to your parents bedroom \n"
                );

                Console.Write("Write your input: ");
                
                // Get and validate navigation input
                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    // Invalid input costs a move and shows error
                    playerMoves--;
                    Error.BasicException();
                }

                // Validate input range (1-4)
                if (playerInput < 1 || playerInput > 4)
                {
                    // Invalid input costs a move and shows error
                    playerMoves--;
                    Error.BasicException();
                }

                // Moving to any room costs 1 move
                playerMoves--;
                
                // Define room names for clarity
                string livingRoom = "Living Room";
                string kitchen = "Kitchen";
                string bathroom = "Bathroom";
                string parentsBedroom = "Parents Bedroom";

                // ===========================================
                // ROOM SELECTION AND ITEM HANDLING
                // ===========================================
                
                // Navigate to selected room and handle its items
                switch (playerInput)
                {
                    case 1:
                        // Living Room - Items: Dice Set (ID: 2), Mirror (ID: 4), Photograph (ID: 6)
                        Console.Clear();
                        currentLocation = livingRoom;
                        int[] livingRoomItems = { 2, 4, 6 };
                        HandleRoomItems(livingRoom, livingRoomItems);
                        break;
                    case 2:
                        // Kitchen - Items: Spoon (ID: 5), Bird Book (ID: 10)
                        Console.Clear();
                        currentLocation = kitchen;
                        int[] kitchenItems = { 5, 10 };
                        HandleRoomItems(kitchen, kitchenItems);
                        break;
                    case 3:
                        // Bathroom - Items: Jacket (ID: 7)
                        Console.Clear();
                        currentLocation = bathroom;
                        int[] bathroomItems = { 7 };
                        HandleRoomItems(bathroom, bathroomItems);
                        break;
                    case 4:
                        // Parents Bedroom - Items: Mom's Toy (ID: 8), House keys (ID: 9)
                        Console.Clear();
                        currentLocation = parentsBedroom;
                        int[] parentsBedroomItems = { 8, 9 };
                        HandleRoomItems(parentsBedroom, parentsBedroomItems);
                        break;
                }

                // ===========================================
                // MOVE LIMIT CHECK
                // ===========================================
                
                // Check if player has run out of moves
                if (playerMoves <= 0)
                {
                    HouseMenuLoop = false; // Exit house exploration
                    Console.WriteLine("You have run out of moves! Time to leave the house.");
                    Console.Write("Press any key to continue: ");
                    Console.ReadLine();
                    Console.Clear();
                    WorldMenu(); // Proceed to world menu
                }
            }
        }


        // ===========================================
        // ROOM ITEM INTERACTION SYSTEM
        // ===========================================

        /// <summary>
        /// Generic method for handling item interactions in any room.
        /// Displays available items, allows player to pick them up, and manages move costs.
        /// This method eliminates code duplication by handling all room item logic in one place.
        /// </summary>
        /// <param name="roomName">The name of the current room for display purposes</param>
        /// <param name="itemIds">Array of item IDs that should be available in this room</param>
        public void HandleRoomItems(string roomName, int[] itemIds)
        {
            RoomItemLoop = true;
            int playerInput = 0;

            // Main room interaction loop - continues until player chooses to leave
            while (RoomItemLoop == true)
            {
                // Display current room status and move count
                Console.WriteLine($"You are currently at: {roomName}");
                Console.WriteLine($"You have {playerMoves} moves left");
                Console.WriteLine();
                Console.WriteLine("Do you want to grab some items from this room before leaving?\n" +
                    "1. Yes \n" +
                    "2. No\n"
                );
                Console.Write("Write your input: ");
                
                // Get and validate initial choice
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

                if (playerInput == 1)
                {
                    // Player wants to look for items
                    Console.Clear();
                    playerInput = 0;
                    
                    // Item selection loop - continues until player exits or picks up items
                    while (RoomItemLoop == true)
                    {
                        // ===========================================
                        // BUILD AVAILABLE ITEMS LIST
                        // ===========================================
                        
                        // Create lists to track available items and menu options
                        var availableItems = new List<(int id, Item item)>();
                        var itemOptions = new List<string>();
                        int optionNumber = 1;

                        // Check each item ID to see if it's still available in the repository
                        foreach (int itemId in itemIds)
                        {
                            var item = itemRepo.FindById(itemId);
                            if (item != null) // Item still exists in repository (not picked up yet)
                            {
                                availableItems.Add((itemId, item));
                                itemOptions.Add($"{optionNumber}. Pickup {item.Name} - {item.Description}");
                                optionNumber++;
                            }
                        }

                        // ===========================================
                        // HANDLE EMPTY ROOM SCENARIO
                        // ===========================================
                        
                        if (availableItems.Count == 0)
                        {
                            // No items available - all have been picked up
                            Console.WriteLine("No items available in this room.");
                            Console.WriteLine("1. Exit room");
                            Console.Write("Select a choice: ");
                            
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
                                // Exit room and show inventory
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("You leave the room");
                                Inventory.ShowInventory();
                                Console.Write("Press anything to continue: ");
                                Console.ReadLine();
                                Console.Clear();
                                RoomItemLoop = false;
                                return;
                            }
                            else
                            {
                                Error.BasicException();
                            }
                        }
                        else
                        {
                            // ===========================================
                            // DISPLAY AVAILABLE ITEMS
                            // ===========================================
                            
                            Console.WriteLine("Items available in this room:\n");
                            foreach (var option in itemOptions)
                            {
                                Console.WriteLine(option);
                            }
                            Console.WriteLine($"{optionNumber}. Exit room\n");
                            Console.Write("Select a choice: ");

                            try
                            {
                                playerInput = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Error.BasicException();
                            }

                            // Validate input range
                            if (playerInput < 1 || playerInput > optionNumber)
                            {
                                Error.BasicException();
                            }

                            if (playerInput == optionNumber) // Exit room selected
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("You leave the room");
                                Inventory.ShowInventory();
                                Console.Write("Press anything to continue: ");
                                Console.ReadLine();
                                Console.Clear();
                                RoomItemLoop = false;
                                return;
                            }
                            else if (playerInput >= 1 && playerInput < optionNumber) // Item pickup selected
                            {
                                // ===========================================
                                // ITEM PICKUP LOGIC
                                // ===========================================
                                
                                var selectedItem = availableItems[playerInput - 1];
                                var pickItem = itemRepo.FindById(selectedItem.id);
                                
                                if (pickItem != null)
                                {
                                    // Item is available - pick it up
                                    Console.Clear();
                                    Inventory.AddItem(pickItem); // Add to player inventory
                                    itemRepo.items.Remove(pickItem); // Remove from room
                                    playerMoves--; // Cost a move to pick up item
                                    Console.WriteLine($"Moves remaining: {playerMoves}");
                                    Console.Write("Press anything to continue: ");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                                else
                                {
                                    // Item was already picked up (edge case)
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("You have already picked up this item.");
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("Press anything to continue: ");
                                    Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                        }
                    }
                }
                else
                {
                    // Player chose not to look for items - exit room interaction
                    RoomItemLoop = false;
                }
            }
        }

        // ===========================================
        // WORLD MENU (FUTURE EXPANSION)
        // ===========================================

        /// <summary>
        /// Placeholder for world menu functionality.
        /// This method will be implemented for future game expansion beyond house exploration.
        /// </summary>
        public void WorldMenu()
        {
            // World menu logic here - to be implemented for future game features
            // This could include outdoor exploration, shops, NPCs, etc.
        }
    }
}
