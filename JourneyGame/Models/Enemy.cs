using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Models
{
    internal class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public Race Race { get; set; }

        public Enemy(string name, int health, int damage, Race race)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Race = race;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }
}
