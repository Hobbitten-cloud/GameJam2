using JourneyGame.Models.Enums;
using System;
using System.Collections.Generic;

namespace JourneyGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public string Title { get; set; }
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
            if (Health > MaxHealth) Health = MaxHealth;
        }

        public void InitializeValues()
        {
            // ✨ sexy Stats per Race & Job ✨
            var stats = new Dictionary<Race, Dictionary<Job, (int Health, double PR, string Title)>>()
            {
                [Race.Human] = new()
                {
                    [Job.Warrior] = (100, 5, "the Brave"),
                    [Job.Mage] = (80, 6, "the Wise"),
                    [Job.Archer] = (90, 5.5, "the Keen-Eyed"),
                    [Job.Thief] = (85, 4, "the Shadow"),
                    [Job.Paladin] = (110, 7, "the Righteous"),
                    [Job.Banker] = (70, 8, "the Wealthy"),
                    [Job.Butcher] = (95, 4.5, "the Cleaver"),
                    [Job.Bard] = (75, 6.5, "the Silver-Tongued"),
                    [Job.Jester] = (70, 6, "the Foolish"),
                    [Job.Chef] = (80, 5, "the Culinary")
                },
                [Race.Elf] = new()
                {
                    [Job.Warrior] = (90, 5.5, "the Swiftblade"),
                    [Job.Mage] = (75, 8, "the Mooncaller"),
                    [Job.Archer] = (85, 7.5, "the Moonbow"),
                    [Job.Thief] = (80, 4.5, "the Whisper"),
                    [Job.Paladin] = (95, 7, "the Radiant"),
                    [Job.Banker] = (70, 7.5, "the Financier"),
                    [Job.Butcher] = (85, 4.5, "the Carver"),
                    [Job.Bard] = (70, 8, "the Songweaver"),
                    [Job.Jester] = (70, 7.5, "the Trickster"),
                    [Job.Chef] = (75, 6, "the Herbmaster")
                },
                [Race.Dwarf] = new()
                {
                    [Job.Warrior] = (110, 5, "the Stouthearted"),
                    [Job.Mage] = (70, 4.5, "the Stone Sage"),
                    [Job.Archer] = (80, 4, "the Ironbow"),
                    [Job.Thief] = (75, 3, "the Tunnel Rat"),
                    [Job.Paladin] = (100, 6, "the Faithforged"),
                    [Job.Banker] = (75, 6.5, "the Goldenbeard"),
                    [Job.Butcher] = (95, 4.5, "the Meatmaster"),
                    [Job.Bard] = (70, 5.5, "the Ale-Singer"),
                    [Job.Jester] = (65, 5, "the Drunkard"),
                    [Job.Chef] = (80, 4.5, "the Hearthkeeper")
                },
                [Race.Orc] = new()
                {
                    [Job.Warrior] = (120, 3, "the Bloodfist"),
                    [Job.Mage] = (75, 2, "the Warlock"),
                    [Job.Archer] = (85, 3.5, "the Huntsbane"),
                    [Job.Thief] = (80, 2.5, "the Cutpurse"),
                    [Job.Paladin] = (105, 4, "the Ironhide"),
                    [Job.Banker] = (70, 4.5, "the Coincrusher"),
                    [Job.Butcher] = (100, 3.5, "the Fleshrender"),
                    [Job.Bard] = (75, 4, "the Drumheart"),
                    [Job.Jester] = (70, 4, "the Loud"),
                    [Job.Chef] = (80, 3.5, "the Bonechef")
                },
                [Race.Goblin] = new()
                {
                    [Job.Warrior] = (80, 0, "the Scrapper"),
                    [Job.Mage] = (70, 0, "the Tinkerer"),
                    [Job.Archer] = (75, 0, "the Slinger"),
                    [Job.Thief] = (70, 0, "the Sneaky"),
                    [Job.Paladin] = (85, 0, "the Pretender"),
                    [Job.Banker] = (65, 9, "the Greedy"),
                    [Job.Butcher] = (75, 0, "the Chopper"),
                    [Job.Bard] = (65, 0, "the Noisy"),
                    [Job.Jester] = (60, 0, "the Green Fool"),
                    [Job.Chef] = (70, 0, "the Filthy Cook")
                }
            };

            if (stats.TryGetValue(Race, out var jobStats) && jobStats.TryGetValue(Job, out var values))
            {
                Health = values.Health;
                MaxHealth = Health;
                PublicRelations = values.PR;
                Title = values.Title;
            }
            else
            {
                Health = 100;
                MaxHealth = 100;
                PublicRelations = 5;
                Title = "the Nameless";
            }
        }
    }
}
