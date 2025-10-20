using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    internal class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public Item(int id, string name, string description, int value)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
        }
    }
}
