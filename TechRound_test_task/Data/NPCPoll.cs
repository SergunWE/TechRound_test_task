using System.Collections.Generic;

namespace TechRound_test_task
{
    public class NPCPoll
    {
        private readonly List<NPC> _npcs;

        public NPCPoll()
        {
            _npcs = new List<NPC>();
            CreateNPC();
            CreateNPC();
            CreateNPC();
        }

        public void CreateNPC()
        {
            _npcs.Add(new NPC());
        }

        public List<NPC> NPCs => _npcs;
    }
}