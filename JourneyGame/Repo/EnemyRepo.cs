using JourneyGame.Models.Enums;
using JourneyGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyGame.Repo
{
    public class EnemyRepo
    {
        private List<Enemy> enemies = new List<Enemy>();

        public EnemyRepo()
        {
            InitializeEnemies();
        }

        private void InitializeEnemies()
        {
            // Human enemies (balanced stats)
            enemies.Add(new Enemy("Sir Aldric", 85, 15, Race.Human));
            enemies.Add(new Enemy("Marla the Swift", 75, 18, Race.Human));
            enemies.Add(new Enemy("Gregor Ironhand", 95, 12, Race.Human));
            enemies.Add(new Enemy("Elara the Candle", 70, 20, Race.Human));
            enemies.Add(new Enemy("Tobin Greencoat", 80, 17, Race.Human));

            // Orc enemies (high health, high damage)
            enemies.Add(new Enemy("Grashnok", 120, 22, Race.Orc));
            enemies.Add(new Enemy("Throg the Butcher", 130, 20, Race.Orc));
            enemies.Add(new Enemy("Moktar Doomjaw", 110, 24, Race.Orc));
            enemies.Add(new Enemy("Vrog the Relentless", 140, 18, Race.Orc));
            enemies.Add(new Enemy("Uldrak Bonechewer", 115, 21, Race.Orc));

            // Elf enemies (fast, high precision, lower health)
            enemies.Add(new Enemy("Sylwen Leafsong", 65, 22, Race.Elf));
            enemies.Add(new Enemy("Thalion Quickstep", 70, 20, Race.Elf));
            enemies.Add(new Enemy("Elaria Moondancer", 60, 25, Race.Elf));

            // Goblin enemies (low health, unpredictable)
            enemies.Add(new Enemy("Snib the Shiny", 55, 17, Race.Goblin));
            enemies.Add(new Enemy("Krek the Lurker", 50, 19, Race.Goblin));
            enemies.Add(new Enemy("Zibzib", 45, 21, Race.Goblin));

            // Dwarf enemies (tough, steady fighters)
            enemies.Add(new Enemy("Borin Stonebeard", 125, 16, Race.Dwarf));
            enemies.Add(new Enemy("Durga Emberforge", 115, 18, Race.Dwarf));
            enemies.Add(new Enemy("Korrim Deepdelver", 100, 20, Race.Dwarf));
        }

        public List<Enemy> GetAllenemies()
        {
            return enemies;
        }

        public Enemy GetRandomEnemy()
        {
            if (enemies.Count == 0)
                return null;

            Random random = new Random();
            return enemies[random.Next(enemies.Count)];
        }

        public List<Enemy> GetEnemiesByRace(Race race)
        {
            return enemies.Where(Enemy => Enemy.Race == race).ToList();
        }

        public Enemy GetEnemyByName(string name)
        {
            return enemies.FirstOrDefault(Enemy => Enemy.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
