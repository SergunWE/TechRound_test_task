using System;

namespace TechRound_test_task
{
    public abstract class Weapon
    {
        private readonly string _name;
        private readonly int _damage;
        private readonly int _specialDamage;
        private readonly ISpecialDamageState _specialDamageType;
        private readonly MainFeatures _requiredFeatures;

        protected Weapon(string name, int damage = 1, int specialDamage = 0, int power = 1, int agility = 1, 
            int intellect = 1, ISpecialDamageState specialDamageType = null)
        {
            _name = name;
            _damage = damage;
            _specialDamage = specialDamage;
            _requiredFeatures = new MainFeatures(power, agility, intellect);
            _specialDamageType = specialDamageType;
        }

        public string Name => _name;
        public int Damage => _damage;
        public int SpecialDamage => _specialDamage;
        public MainFeatures RequiredFeatures => _requiredFeatures;
        public ISpecialDamageState SpecialDamageState => _specialDamageType;
    }
}