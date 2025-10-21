using JourneyGame.Models.Enums;
using JourneyGame.Models.ExceptionHandling;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace JourneyGame.Models
{
	public class Menu
	{
		// Menu properties
		#region
		// Class objects
		public Error Error = new Error();

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
		public bool HouseLocationLoop1 = true;
		public bool HouseLocationLoop2 = true;
		public bool HouseLocationLoop3 = true;

		#endregion
		new Player newPlayer;

		// Start MENUS
		public void StartMenu()
		{
			//For at teste Combat - fjern senere
			CombatMenu();

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
				newPlayer = new Player(playerName, playerRace, playerJob);
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
				Console.WriteLine($"You are currently at: {playerName} bedroom ");
				Console.WriteLine($"You have {playerMoves} moves left");
				Console.WriteLine();

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
					Error.BasicException();
				}

				playerMoves--;

				switch (playerInput)
				{
					case 1:
						currentLocation = "Living Room";
						break;
					case 2:
						currentLocation = "Kitchen";
						break;
					case 3:
						currentLocation = "Bathroom";
						break;
					case 4:
						currentLocation = "Parents Bedroom";
						break;
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
		public void CombatMenu()
		{
			//Test player - fjern når fulde program køres
			newPlayer = new Player("Skibidi", Race.Dwarf, Job.Warrior);

			//Test enemy
			Enemy enemy = new Enemy("JohnSouls", 10, 5, Race.Orc);

			Console.Clear();
			int playerInput = 0;

			Console.WriteLine($"You are fighting {enemy.Name}\n");
			//need access to the player somehow
			while (newPlayer.Health > 0 && enemy.Health > 0)
			{
				Console.WriteLine("What will you do?");
				Console.WriteLine(
					   "1. Attack \n" +
					   "2. Cast spell \n" +
					   "3. Use item \n" +
					   "4. Run \n"
				   // add more options?
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
				Console.Clear();
				switch (playerInput)
				{
					case 1:
						Console.WriteLine($"{newPlayer.Name} is attacking {enemy.Name}\n");
						int tempdie = RollD20();
						Console.WriteLine($"Roll 10 or more to hit");
						Console.WriteLine($"You rolled {tempdie}");
						Thread.Sleep(1000);

						if (tempdie >= 10)
						{
							Console.WriteLine("You roll a d10 to determine your damage");
							int d10 = RollD10();
							Thread.Sleep(500);
                            Console.WriteLine($"You rolled {d10}");
							Thread.Sleep(500);
							enemy.TakeDamage(d10);
                            Console.WriteLine($"{enemy.Name} takes {d10} damage");
						}
						else
						{
							Thread.Sleep(500);
							Console.WriteLine($"your roll is to low - miss");
						}
						Console.WriteLine("Press anything to continue");
						Console.ReadLine();
						Console.Clear();
						break;
					case 2:
						CastSpell();
						break;
					case 3:
						UseItem();
						break;
					case 4:
						Run();
						break;
				}
				Console.Clear();
				if (enemy.Health <= 0)
				{
					Console.WriteLine($"{enemy.Name} is dead - VICTORY");
					Thread.Sleep(5000);
					break;
				}
				//Console.WriteLine($"{newPlayer.Name} health is: {newPlayer.Health}\n\n{enemy.Name} health is {enemy.Health}\n\n\n");
				//Console.WriteLine("Press anything to continue");
				//if(newPlayer.Health <= 0 || enemy.Health <= 0)
				//{
				//	Console.WriteLine(
				//}
				//Console.ReadLine();
				Console.Clear();

				Console.WriteLine($"{enemy.Name} is attacking you\n");
				int temp = RollD20();
				Console.WriteLine($"{enemy.Name} has to roll 10 or more to hit");
				Console.WriteLine($"{enemy.Name} rolled {temp}");
				Thread.Sleep(1000);
				if (temp >= 10)
				{
					Console.WriteLine($"{enemy.Name} roll a d10 to determine their damage");
					int d10 = RollD10();
					Thread.Sleep(500);
					Console.WriteLine($"{enemy.Name} rolled {d10 + enemy.Damage}");
					Thread.Sleep(500);
					newPlayer.TakeDamage(d10+enemy.Damage);
					Console.WriteLine($"{newPlayer.Name} takes {d10+enemy.Damage} damage");
				}
				else
				{
					Thread.Sleep(500);
					Console.WriteLine($"{enemy.Name} roll is to low - miss");
				}
				Console.WriteLine("Press anything to continue");
				Console.ReadLine();
				Console.Clear();
				if(newPlayer.Health <= 0)
				{
					Console.WriteLine($"{newPlayer.Name} is dead - GAME OVER");
					Thread.Sleep(10000);
					break;
				}
				
				Console.WriteLine($"{newPlayer.Name} health is: {newPlayer.Health}\n\n{enemy.Name} health is {enemy.Health}\n\n\n");
			}
			Console.Clear();
		}
		public void CastSpell()
		{
			//If we make spells 
		}
		public void UseItem()
		{
			//if items do anything
		}
		//Straight up doesn't work ¯\_(ツ)_/¯
		public void Run()
		{
			//You haul ass - maybe some enemies can trip you 
			//how to break twice?
			Console.WriteLine("RUNAWAY!");
			Thread.Sleep(1000);
		}
		public int RollD20()
		{
			Random r = new Random();
			int rInt = r.Next(1, 20);
			return rInt;
		}
		public int RollD10()
		{
			Random r = new Random();
			int rInt = r.Next(1, 10);
			return rInt;
		}


	}
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

        // Loop controls
        //public bool PlayersBedroomLoop1 = true;
        //public bool PlayersBedroomLoop2 = true;
        //public bool HouseLocationLoop1 = true;
        //public bool HouseLocationLoop2 = true;
        //public bool HouseLocationLoop3 = true;
        bool firstLoop = true;

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
                // STARTING LOCATION: PLAYER'S BEDROOM (ONLY ONCE)
                // ===========================================

                // Only handle bedroom items on the first loop iteration
                if (firstLoop == true)
                {
                    // Handle bedroom items first (starting location)
                    // Items available: Cactus Shield (ID: 1), Sock Sling (ID: 3)
                    int[] bedroomItems = { 1, 3 };
                    HandleRoomItems($"{playerName}'s bedroom", bedroomItems);
                    firstLoop = false; // Mark that bedroom has been visited
                    Console.Clear();
                }

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
                    "4. Go to your parents bedroom \n" +
                    "5. Check your inventory \n" +
                    "6. Exit house"
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
                if (playerInput < 1 || playerInput > 6)
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
                string viewPlayerInventory = "Inventory";
                string exitHouse = "Exit House";

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
                    case 5:
                        // Parents Bedroom - Items: Mom's Toy (ID: 8), House keys (ID: 9)
                        Console.Clear();
                        Inventory.ShowInventory();
                        Console.Write("Press anything to continue: ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        // Exit House selected - check if player has house keys
                        Console.Clear();
                        bool hasHouseKeys = Inventory.Items.Any(item => item.Id == 9); // House keys have ID 9
                        
                        if (hasHouseKeys)
                        {
                            // Player has house keys - allow exit
                            HouseMenuLoop = false;
                            Console.WriteLine("You use the house keys to unlock the door and leave the house.");
                            Console.WriteLine("Congratulations! You have successfully escaped!");
                            Console.Write("Press any key to continue: ");
                            Console.ReadLine();
                        }
                        else
                        {
                            // Player doesn't have house keys - can't exit
                            Console.WriteLine("You try to leave the house, but the door is locked.");
                            Console.WriteLine("You need the house keys to unlock the door!");
                            Console.Write("Press any key to continue: ");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                }

                // ===========================================
                // MOVE LIMIT CHECK
                // ===========================================

                // Check if player has run out of moves
                if (playerMoves <= 0)
                {
                    HouseMenuLoop = false; // Exit house exploration
                    GameOverMenu(); // Show game over menu
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

                // Get and validate initial choice with proper error handling
                bool validInput = false;
                while (!validInput)
                {
                    try
                    {
                        string input = Console.ReadLine();

                        // Check if input is empty or just whitespace
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a valid number - not whitespace");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Write your input: ");
                            continue;
                        }

                        playerInput = Convert.ToInt32(input);

                        // Validate input range
                        if (playerInput >= 1 && playerInput <= 2)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter 1 or 2.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("Write your input: ");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number (no letters or special characters).");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Write your input: ");
                    }
                    catch (OverflowException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The number you entered is too large. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Write your input: ");
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Write your input: ");
                    }
                }

                if (playerInput == 2)
                {
                    // Player chose not to look for items - exit room interaction
                    // If this is the bedroom (firstLoop), mark it as completed
                    if (firstLoop == true)
                    {
                        firstLoop = false;
                    }
                    RoomItemLoop = false;
                }
                else if (playerInput == 1)
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
            }
        }

        // ===========================================
        // GAME OVER AND RESTART MENU
        // ===========================================

        /// <summary>
        /// Displays the game over menu when the player runs out of moves.
        /// Allows the player to restart the game or return to the main menu.
        /// </summary>
        public void GameOverMenu()
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
                            HouseMenu(); // Restart house exploration
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
                            StartMenu(); // Return to start menu
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
