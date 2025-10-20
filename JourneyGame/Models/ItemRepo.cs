namespace JourneyGame.Models
{
    public class ItemRepo
    {
        public List<Item> items = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Bat",
                Description = "An old Baseball bat",
            },
            new Item
            {
                Id = 2,
                Name = "Ring of Power",
                Description = "Your mothers ring ",

            },
            new Item
            {
                Id = 3,
                Name = "Toothbrush",
                Description = "A used toothbrush",

            },
            new Item
            {
                Id = 4,
                Name = "Chair",
                Description = "An Worn out chair",

            }


        };




    }
}
