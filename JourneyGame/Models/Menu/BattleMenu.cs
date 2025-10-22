using JourneyGame.Models.Enums;
using JourneyGame.Models.ExceptionHandling;

namespace JourneyGame.Models.Menu
{
    public class BattleMenu
    {
        new Player newPlayer;
        public Error Error = new Error();
        public void CombatMenu()
        {
            //Test player - fjern når fulde program køres
            newPlayer = new Player("Skibidi", Race.Dwarf, Job.Warrior);

            //Test enemy
            Enemy enemy = new Enemy("JohnSouls", 10, 5, Race.Orc);

            Console.Clear();
            int playerInput = 0;

            Console.WriteLine($"You are fighting {enemy.Name}\n");
            //need access to the player somehow
            while (newPlayer.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine("What will you do?");
                Console.WriteLine(
                       "1. Attack \n" +
                       "2. Cast spell \n" +
                       "3. Use item \n" +
                       "4. Run \n"
                   // add more options?
                   );

                Console.Write("Write your input: ");
                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Error.BasicException();
                }
                Console.Clear();
                switch (playerInput)
                {
                    case 1:
                        Console.WriteLine($"{newPlayer.Name} is attacking {enemy.Name}\n");
                        int tempdie = RollD20();
                        Console.WriteLine($"Roll 10 or more to hit");
                        Console.WriteLine($"You rolled {tempdie}");
                        Thread.Sleep(1000);

                        if (tempdie >= 10)
                        {
                            Console.WriteLine("You roll a d10 to determine your damage");
                            int d10 = RollD10();
                            Thread.Sleep(500);
                            Console.WriteLine($"You rolled {d10}");
                            Thread.Sleep(500);
                            enemy.TakeDamage(d10);
                            Console.WriteLine($"{enemy.Name} takes {d10} damage");
                        }
                        else
                        {
                            Thread.Sleep(500);
                            Console.WriteLine($"your roll is to low - miss");
                        }
                        Console.WriteLine("Press anything to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        CastSpell();
                        break;
                    case 3:
                        UseItem();
                        break;
                    case 4:
                        Run();
                        break;
                }
                Console.Clear();
                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"{enemy.Name} is dead - VICTORY");
                    Thread.Sleep(5000);
                    break;
                }
                //Console.WriteLine($"{newPlayer.Name} health is: {newPlayer.Health}\n\n{enemy.Name} health is {enemy.Health}\n\n\n");
                //Console.WriteLine("Press anything to continue");
                //if(newPlayer.Health <= 0 || enemy.Health <= 0)
                //{
                //	Console.WriteLine(
                //}
                //Console.ReadLine();
                Console.Clear();

                Console.WriteLine($"{enemy.Name} is attacking you\n");
                int temp = RollD20();
                Console.WriteLine($"{enemy.Name} has to roll 10 or more to hit");
                Console.WriteLine($"{enemy.Name} rolled {temp}");
                Thread.Sleep(1000);
                if (temp >= 10)
                {
                    Console.WriteLine($"{enemy.Name} roll a d10 to determine their damage");
                    int d10 = RollD10();
                    Thread.Sleep(500);
                    Console.WriteLine($"{enemy.Name} rolled {d10 + enemy.Damage}");
                    Thread.Sleep(500);
                    newPlayer.TakeDamage(d10 + enemy.Damage);
                    Console.WriteLine($"{newPlayer.Name} takes {d10 + enemy.Damage} damage");
                }
                else
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"{enemy.Name} roll is to low - miss");
                }
                Console.WriteLine("Press anything to continue");
                Console.ReadLine();
                Console.Clear();
                if (newPlayer.Health <= 0)
                {
                    Console.WriteLine($"{newPlayer.Name} is dead - GAME OVER");
                    Thread.Sleep(10000);
                    break;
                }

                Console.WriteLine($"{newPlayer.Name} health is: {newPlayer.Health}\n\n{enemy.Name} health is {enemy.Health}\n\n\n");
            }
            Console.Clear();
        }
        public void CastSpell()
        {
            //If we make spells 
        }
        public void UseItem()
        {
            //if items do anything
        }
        //Straight up doesn't work ¯\_(ツ)_/¯
        public void Run()
        {
            //You haul ass - maybe some enemies can trip you 
            //how to break twice?
            Console.WriteLine("RUNAWAY!");
            Thread.Sleep(1000);
        }
        public int RollD20()
        {
            Random r = new Random();
            int rInt = r.Next(1, 20);
            return rInt;
        }
        public int RollD10()
        {
            Random r = new Random();
            int rInt = r.Next(1, 10);
            return rInt;
        }
    }
}
