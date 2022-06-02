using System;

namespace TechRound_test_task
{
    public abstract class Character<TWeaponType> : ICharacter where TWeaponType : Weapon
    {
        private int _hitPoints;
        private int _manaPoints;
        protected string Name;

        private Weapon _weapon;
        protected MainFeatures MainFeatures;

        protected Character(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            if (hitPoints <= 0 || manaPoints <= 0)
            {
                throw new ArgumentException("Значение здоровья или маны не могут быть меньше 1");
            }
            _hitPoints = hitPoints;
            _manaPoints = manaPoints;
            MainFeatures = new MainFeatures(power, agility, intellect);
        }

        public virtual void SetWeapon(Weapon weapon)
        {
            if (weapon is not TWeaponType)
            {
                throw new ArgumentException("Персонаж не соответствует классу");
            }

            _weapon = weapon;
        }
        public string CharacterName() => Name;
        public int HitPoints() => _hitPoints;
        public int ManaPoints() => _manaPoints;
        public MainFeatures GetMainFeatures() => MainFeatures;
        public Weapon GetWeapon() => _weapon;
    }
}