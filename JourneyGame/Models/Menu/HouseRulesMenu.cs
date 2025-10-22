using JourneyGame.Models.ExceptionHandling;

namespace JourneyGame.Models.Menu
{
    public class HouseRulesMenu
    {
        private Player _player;


        public GameOverMenu _gameOverMenu;
        public void Setplayer(Player player)
        {
            _player = player;
        }

        public int playerMoves = 5;
        public bool RoomItemLoop = true;
        ItemRepo itemRepo = new ItemRepo();

        public string playerName = "";
        bool firstLoop = true;
        // Controls the house rules explanation menu
        public bool HouseRules = true;

        // Controls the main house exploration menu
        public bool HouseMenuLoop = true;
        public Error Error = new Error();
        // Character creation sub-loop controls for each step
        public bool CharacterLoop1 = true; // Race selection loop
        public bool CharacterLoop2 = true; // Job/Class selection loop
        public bool CharacterLoop3 = true; // Name input loop
        public bool CharacterLoop4 = true; // Character confirmation loop

        public bool StartMenuLoop = true;
        public bool CharacterCreationMenuLoop = true;

        public void ShowHouseRulesMenu()
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
                    HandleRoomItems($"{_player.Name}'s bedroom", bedroomItems);
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
                    //_gameOverMenu.ShowGameOverMenu(); // Show game over menu
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


    }
}







