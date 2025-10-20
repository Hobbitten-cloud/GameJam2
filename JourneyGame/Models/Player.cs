using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    internal class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }
        public Race Race { get; set; }
        public Job Job { get; set; }

        public Player(string name, Race race, Job job)
        {
            Name = name;
            Health = 100;
            Level = 1;
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

        public void LevelUp()
        {
            Level++;
            Health = 100; // Restore health on level up
        }
    }
}