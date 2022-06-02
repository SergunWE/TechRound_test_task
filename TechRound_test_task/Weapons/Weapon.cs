using System;

namespace TechRound_test_task
{
    public abstract class Weapon
    {
        public string Name { get; private set; }

        private int _damage;
        private MainFeatures _requiredFeatures;

        public Weapon(int damage = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            _damage = damage;
            _requiredFeatures = new MainFeatures(power, agility, intellect);
        }
        
    }
}