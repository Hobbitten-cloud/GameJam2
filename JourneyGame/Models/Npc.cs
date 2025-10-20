using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    internal class Npc
    {
        public string Name { get; set; }
        public Race Race { get; set; }
        public string Dialogue { get; set; }
        public Npc(string name, Race race, string dialogue)
        {
            Name = name;
            Race = race;
            Dialogue = dialogue;
        }
    }
}
