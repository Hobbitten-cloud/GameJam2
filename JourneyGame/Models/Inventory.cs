namespace JourneyGame.Models
{
    public static class Inventory
    {
        private static List<Item> _items = new List<Item>();

        public static IReadOnlyList<Item> Items => _items;

        public static void AddItem(Item item)
        {
            _items.Add(item);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You picked up: {item.Name} - {item.Description}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void RemoveItem(Item item)
        {
            if (_items.Remove(item))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You removed: {item.Name}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine($"Item not found in your inventory.");
            }
        }

        public static void ShowInventory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n=== Inventory ===");
            if (_items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in _items)
                {
                    Console.WriteLine($"{item.Name} - {item.Description}");
                }
            }
            Console.WriteLine("=================\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Clear()
        {
            _items.Clear();
        }
    }
}