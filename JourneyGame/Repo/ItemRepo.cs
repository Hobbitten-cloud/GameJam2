using JourneyGame.Models;

namespace JourneyGame.Repo
{
    public class ItemRepo
    {
        public List<Item> items = new List<Item>
        {
            new Item { Id = 1, Name = "Cactus Shield", Description = "It gives a Thorn in the side!" },
            new Item { Id = 2, Name = "Dice Set", Description = "Ready to take a Chance?" },
            new Item { Id = 3, Name = "Sock Sling", Description = "Is this used?" },
            new Item { Id = 4, Name = "Mirror", Description = "Mirror mirror on the wall why am I not this tall" },
            new Item { Id = 5, Name = "Spoon", Description = "SPOON KILLER!!!" },
            new Item { Id = 6, Name = "Photograph", Description = "Look at this photograph... it reminds me of something" },
            new Item { Id = 7, Name = "Jacket", Description = "+1 against cold" },
            new Item { Id = 8, Name = "Mom's Toy", Description = "I should not have this" },
            new Item { Id = 9, Name = "House keys", Description = "Can open all doors" },
            new Item { Id = 10, Name = "Bird Book", Description = "No bird is safe from my observations" },
        };

        public List<Item> GetAllItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - {item.Description}");
            }
            return items;
        }

        public Item? FindById(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }
    }
}
