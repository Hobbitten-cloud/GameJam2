using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Race Race { get; set; }
        public Job Job { get; set; }


        public Player(string name, Race race, Job job)
        {
            Name = name;
            Health = 100;;
            Race = race;
            Job = job;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public void Heal(int amount)
        {
            Health += amount;
            if (Health > 100) Health = 100;
        }
    }
}