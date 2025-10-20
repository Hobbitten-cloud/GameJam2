using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    internal class Event
    {
        public string Description { get; set; }
        public Action<Player> Effect { get; set; }

        public Event(string description, Action<Player> effect)
        {
            Description = description;
            Effect = effect;
        }
    }
}
