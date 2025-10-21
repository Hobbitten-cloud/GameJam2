using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;

namespace JourneyGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public Race Race { get; set; }
        public Job Job { get; set; }
        public double PublicRelations { get; set; }


        public Player(string name, Race race, Job job)
        {
            Name = name;
            Race = race;
            Job = job;
            InitializeValues();
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

        public void InitializeValues()
        {
            // ✨ Sexy mapping of stats by Race & Job ✨
            var stats = new Dictionary<Race, Dictionary<Job, (int Health, double PR)>>()
            {
                [Race.Human] = new()
                {
                    [Job.Warrior] = (100, 5),
                    [Job.Mage] = (80, 6),
                    [Job.Archer] = (90, 5.5),
                    [Job.Thief] = (85, 4),
                    [Job.Paladin] = (110, 7),
                    [Job.Banker] = (70, 8),
                    [Job.Butcher] = (95, 4.5),
                    [Job.Bard] = (75, 6.5),
                    [Job.Jester] = (70, 6),
                    [Job.Chef] = (80, 5)
                },
                [Race.Elf] = new()
                {
                    [Job.Warrior] = (90, 5.5),
                    [Job.Mage] = (75, 8),
                    [Job.Archer] = (85, 7.5),
                    [Job.Thief] = (80, 4.5),
                    [Job.Paladin] = (95, 7),
                    [Job.Banker] = (70, 7.5),
                    [Job.Butcher] = (85, 4.5),
                    [Job.Bard] = (70, 8),
                    [Job.Jester] = (70, 7.5),
                    [Job.Chef] = (75, 6)
                },
                [Race.Dwarf] = new()
                {
                    [Job.Warrior] = (110, 5),
                    [Job.Mage] = (70, 4.5),
                    [Job.Archer] = (80, 4),
                    [Job.Thief] = (75, 3),
                    [Job.Paladin] = (100, 6),
                    [Job.Banker] = (75, 6.5),
                    [Job.Butcher] = (95, 4.5),
                    [Job.Bard] = (70, 5.5),
                    [Job.Jester] = (65, 5),
                    [Job.Chef] = (80, 4.5)
                },
                [Race.Orc] = new()
                {
                    [Job.Warrior] = (120, 3),
                    [Job.Mage] = (75, 2),
                    [Job.Archer] = (85, 3.5),
                    [Job.Thief] = (80, 2.5),
                    [Job.Paladin] = (105, 4),
                    [Job.Banker] = (70, 4.5),
                    [Job.Butcher] = (100, 3.5),
                    [Job.Bard] = (75, 4),
                    [Job.Jester] = (70, 4),
                    [Job.Chef] = (80, 3.5)
                },
                [Race.Goblin] = new()
                {
                    [Job.Warrior] = (80, 0),
                    [Job.Mage] = (70, 0),
                    [Job.Archer] = (75, 0),
                    [Job.Thief] = (70, 0),
                    [Job.Paladin] = (85, 0),
                    [Job.Banker] = (65, 9),
                    [Job.Butcher] = (75, 0),
                    [Job.Bard] = (65, 0),
                    [Job.Jester] = (60, 0),
                    [Job.Chef] = (70, 0)
                }
            };

            if (stats.TryGetValue(Race, out var jobStats) && jobStats.TryGetValue(Job, out var values))
            {
                Health = values.Health;
                PublicRelations = values.PR;
            }
            else
            {
                Health = 100;
                PublicRelations = 5;
            }
        }
    }
}
