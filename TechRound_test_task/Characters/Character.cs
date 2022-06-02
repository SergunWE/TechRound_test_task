using System;
using InputOutput;
using TechRound_test_task.Damage;

namespace TechRound_test_task
{
    public abstract class Character<TWeaponType> : ICharacter, IDamageable where TWeaponType : Weapon
    {
        private int _hitPoints;
        private int _manaPoints;
        protected string Name;

        private Weapon _weapon;
        protected MainFeatures MainFeatures;

        private bool _alive;

        protected Character(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            if (hitPoints <= 0 || manaPoints <= 0)
            {
                throw new ArgumentException("Значение здоровья или маны не могут быть меньше 1");
            }
            _hitPoints = hitPoints;
            _manaPoints = manaPoints;
            MainFeatures = new MainFeatures(power, agility, intellect);
            _alive = true;
        }

        private bool CheckPoints(ref int points)
        {
            return points > 0;
        }

        public virtual void SetWeapon(Weapon weapon)
        {
            if (weapon is not TWeaponType)
            {
                throw new ArgumentException("Персонаж не соответствует классу");
            }

            _weapon = weapon;
        }

        public object GetCharacterType() => this;
        public string CharacterName() => Name;
        public int HitPoints() => _hitPoints;
        public int ManaPoints() => _manaPoints;
        public MainFeatures GetMainFeatures() => MainFeatures;
        public Weapon GetWeapon() => _weapon;
        public bool Alive() => _alive;
        public bool Attack(object target)
        {
            if (target is not IDamageable damageable || _weapon == null) return false;
            return _alive && damageable.TakeDamage(_weapon.Damage);
        }

        public bool TakeDamage(int damage)
        {
            if(!_alive) return false;
            _hitPoints -= damage;
            //сюда бы события
            ConsoleNotification.PrintNotice($"{Name} получил урон {damage} единиц");
            if (!CheckPoints(ref _hitPoints))
            {
                ConsoleNotification.PrintNotice($"{Name} погиб");
                _alive = false;
                _hitPoints = 0;
            }
            return true;
        }
    }
}