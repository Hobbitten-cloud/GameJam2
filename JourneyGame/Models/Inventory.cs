namespace JourneyGame.Models
{
    public static class Inventory
    {
        private static List<Item> _items = new List<Item>();

        public static IReadOnlyList<Item> Items => _items;

        public static void AddItem(Item item)
        {
            _items.Add(item);
            Console.WriteLine($"You added: {item.Name} - {item.Description}");
        }

        public static void RemoveItem(Item item)
        {
            if (_items.Remove(item))
            {
                Console.WriteLine($"You removed: {item.Name}");
            }
            else
            {
                Console.WriteLine($"Item not found in your inventory.");
            }
        }

        public static void ShowInventory()
        {
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
        }

        public static void Clear()
        {
            _items.Clear();
        }
    }
}