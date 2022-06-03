using System;
using InputOutput;

namespace TechRound_test_task
{
    public class NPC : IDamageable
    {
        public string Name { get; private set; }

        private static readonly Random Random;

        static NPC()
        {
            Random = new Random((int) DateTime.UtcNow.Ticks);
        }
        
        public NPC(string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                Name = "NPC" + Random.Next(0, 1000).ToString("000");
                return;
            }

            Name = name;
        }
        
        public bool Attack(object target)
        {
            return false;
        }

        public bool TakeDamage(int damage)
        {
            ConsoleNotification.PrintNotice(Name + " был атакован");
            return true;
        }
    }
}