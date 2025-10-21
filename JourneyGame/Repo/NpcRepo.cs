using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JourneyGame.Models;
using JourneyGame.Models.Enums;

namespace JourneyGame.Repo
{
    public class NpcRepo
    {
        private List<Npc> npcs = new List<Npc>();

        public NpcRepo()
        {
            InitializeNpcs();
        }

        private void InitializeNpcs()
        {
            // Human NPCs
            npcs.Add(new Npc("Ramon", Race.Human, "I used to be an adventurer like you, then I took a fireball in a tar pit"));
            npcs.Add(new Npc("Jon Xina", Race.Human, "I love ice cream!"));
            npcs.Add(new Npc("Gandolf", Race.Human, "How big do you think this room is?"));
            npcs.Add(new Npc("Jeremy", Race.Human, "I never miss"));
            npcs.Add(new Npc("Sticky Fingered Jonathan", Race.Human, "Your pockets look heavy..."));

            // Orc NPCs
            npcs.Add(new Npc("Brutalitops", Race.Orc, "My name is Brutalitops (evil laugh) the magician"));
            npcs.Add(new Npc("John Pork", Race.Orc, "I've been here around 6-7 years. 6, 7..."));
            npcs.Add(new Npc("Ogg", Race.Orc, "I just wanted a quiet life, but the local lord seized my land"));
            npcs.Add(new Npc("Ric Rol", Race.Orc, "Bow makes for good club"));
            npcs.Add(new Npc("Paul", Race.Orc, "You no see Paul!"));

            // Elf NPCs
            npcs.Add(new Npc("Quincy, son of Quincy", Race.Elf, "Nothing gets past my bow"));
            npcs.Add(new Npc("Ash", Race.Elf, "This is my BOOM stick"));
            npcs.Add(new Npc("Fleet-Footed Fenty", Race.Elf, "Wanna see me run to that mountain and back? Wanna see me do it again?"));

            // Goblin NPCs
            npcs.Add(new Npc("Etienne", Race.Goblin, "bogos binted 0.0"));
            npcs.Add(new Npc("Dart", Race.Goblin, "I once befriended a worg"));

            // Dwarf NPCs
            npcs.Add(new Npc("Gimli", Race.Dwarf, "You have my axe"));
            npcs.Add(new Npc("The Gilded One", Race.Dwarf, "People keep making fun of my bronze hammer painted yellow"));
            npcs.Add(new Npc("Glowstick Jarn", Race.Dwarf, "I like frost spells. They're very cool"));
        }

        public List<Npc> GetAllNpcs()
        {
            return npcs;
        }

        public Npc GetRandomNpc()
        {
            if (npcs.Count == 0)
                return null;

            Random random = new Random();
            return npcs[random.Next(npcs.Count)];
        }

        public List<Npc> GetNpcsByRace(Race race)
        {
            return npcs.Where(npc => npc.Race == race).ToList();
        }

        public Npc GetNpcByName(string name)
        {
            return npcs.FirstOrDefault(npc => npc.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}
