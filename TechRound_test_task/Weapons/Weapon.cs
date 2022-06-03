using System;

namespace TechRound_test_task
{
    public abstract class Weapon
    {
        private readonly string _name;
        private readonly int _damage;
        private readonly MainFeatures _requiredFeatures;

        protected Weapon(string name, int damage = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            _name = name;
            _damage = damage;
            _requiredFeatures = new MainFeatures(power, agility, intellect);
        }

        public string Name => _name;
        public int Damage => _damage;
        public MainFeatures RequiredFeatures => _requiredFeatures;
    }
}