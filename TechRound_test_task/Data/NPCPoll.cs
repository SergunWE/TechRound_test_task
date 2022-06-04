using System.Collections.Generic;

namespace TechRound_test_task
{
    public static class NPCPoll
    {
        private static readonly List<NPC> _npcs;

        static NPCPoll()
        {
            _npcs = new List<NPC>();
            
            CreateNPC();
            CreateNPC();
            CreateNPC();
        }

        public static void CreateNPC()
        {
            _npcs.Add(new NPC());
        }

        public static List<NPC> NPCs => _npcs;
    }
}