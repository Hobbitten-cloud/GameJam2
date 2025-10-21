namespace JourneyGame.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Item(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Item()
        {

        }
    }
}