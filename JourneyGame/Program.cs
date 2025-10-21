using JourneyGame.Models;

namespace JourneyGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init game components here
            var test = new Npc("Den store tester", Models.Enums.Race.Dwarf, "Du skal simpelthen opføre dig ordentligt!");

            Console.WriteLine("Welcome to Journey Game!");
            // Game initialization and main loop would go here
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"{test.Name} \n{test.Dialogue}");

            var HumanPaladin = new Npc("Ramon", Models.Enums.Race.Human, "I used to be an adventurer like you, then I took a fireball in a tar pit");
            var HumanWarrior = new Npc("Jon Xina", Models.Enums.Race.Human, "I love ice cream!");
            var HumanMage = new Npc("Gandolf", Models.Enums.Race.Human, "How big do you think this room is?");
            var HumanArcher = new Npc("Jeremy", Models.Enums.Race.Human, "I never miss");
            var HumanThief = new Npc("Sticky Fingered Jonathan", Models.Enums.Race.Human, "Your pockets look heavy...");
            var OrcMage = new Npc("Brutalitops", Models.Enums.Race.Orc, "My name is Brutalitops (evil laugh) the magician");
            var OrcPaladin = new Npc("John Pork", Models.Enums.Race.Orc, "I've been here around 6-7 years. 6, 7...");
            var OrcWarrior = new Npc("Ogg", Models.Enums.Race.Orc, "I just wanted a quiet life, but the local lord seized my land");
            var OrcArcher = new Npc("Ric Rol", Models.Enums.Race.Orc, "Bow makes for good club");
            var OrcThief = new Npc("Paul", Models.Enums.Race.Orc, "You no see Paul!");
            var ElfArcher = new Npc("Quincy, son of Quincy", Models.Enums.Race.Elf, "Nothing gets past my bow");
            var ElfMage = new Npc("Ash", Models.Enums.Race.Elf, "This is my BOOM stick");
            var ElfThief = new Npc("Fleet-Footed Fenty", Models.Enums.Race.Elf, "Wanna see me run to that mountain and back? Wanna see me do it again?");
            var GoblinMage = new Npc("Etienne", Models.Enums.Race.Goblin, "bogos binted 0.0");
            var DwarfWarrior = new Npc("Gimli", Models.Enums.Race.Dwarf, "Diggy diggy hole");
        }
    }
}