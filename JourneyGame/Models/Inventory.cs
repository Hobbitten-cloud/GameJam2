namespace JourneyGame.Models
{
    public class Inventory
    {
        public List<Item> items = new List<Item>();
        public void AddItem(string name, int id)
        {
            items.Add(new Item(id, name));

        }
        public void RemoveItem(string name)
        {
            var itemToRemove = items.FirstOrDefault(i => i.Name == name);
            if (itemToRemove != null)
            {
                items.Remove(itemToRemove);
            }

        }
        public void ShowIventory()
        {
            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
