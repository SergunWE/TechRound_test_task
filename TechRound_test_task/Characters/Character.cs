using System;

namespace TechRound_test_task
{
    public class Character<TWeaponType>
    {
        public string Name { get; protected set; }

        private int _hitPoints;
        public int HitPoints => _hitPoints;

        private int _manaPoints;
        public int ManaPoints => _manaPoints;

        private Weapon _weapon;
        private MainFeatures _mainFeatures;

        protected Character(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            _hitPoints = hitPoints;
            _manaPoints = manaPoints;
            _mainFeatures = new MainFeatures(power, agility, intellect);
        }

        public void SetWeapon(Weapon weapon)
        {
            if (weapon is not TWeaponType)
            {
                throw new ArgumentException("Incorrect weapon type");
            }

            _weapon = weapon;
        }
    }
}