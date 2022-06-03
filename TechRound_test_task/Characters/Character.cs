using System;
using InputOutput;

namespace TechRound_test_task
{
    public abstract class Character<TWeaponType> : ICharacter where TWeaponType : Weapon
    {
        private int _hitPoints;
        private int _manaPoints;
        protected string Name;

        private Weapon _weapon;
        protected MainFeatures MainFeatures;

        private bool _alive;

        private Protection _armor;
        private Protection _helmet;
        private Protection _jewelry;

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

        public abstract void SetWeapon(Weapon weapon);

        protected void SetWeapon(Weapon weapon, int feature, int requiredFeature, string featureName)
        {
            if (weapon is not TWeaponType)
            {
                throw new ArgumentException("Оружие не соответствует классу персонажа");
            }

            if (feature < requiredFeature)
            {
                throw new ArgumentOutOfRangeException
                (nameof(requiredFeature),
                    $"Персонаж не соответствует характеристике {featureName}. " +
                    $"Требуется {requiredFeature}, значение персонажа {feature}");
            }

            _weapon = weapon;
        }

        public abstract void SetProtected(Protection protection);

        protected void SetProtected<T>(Protection protection) where T : ICharacter
        {
            switch (protection)
            {
                case Armor<T>:
                    _armor = protection;
                    break;
                case Helmet<T>:
                    _helmet = protection;
                    break;
                case Jewelry<T>:
                    _jewelry = protection;
                    break;
                default:
                    throw new ArgumentException("Экипировка не соответствует классу персонажа");
            }
        }

        public string CharacterName() => Name;
        public int HitPoints() => _hitPoints;
        public int ManaPoints() => _manaPoints;
        public MainFeatures GetMainFeatures() => MainFeatures;
        public Weapon GetWeapon() => _weapon;

        public Protection[] GetProtection()
        {
            return new[] {_armor, _helmet, _jewelry};
        }

        public bool Alive() => _alive;

        public bool Attack(object target)
        {
            if (target is not IDamageable damageable || _weapon == null) return false;
            return _alive && damageable.TakeDamage(_weapon);
        }

        public bool TakeDamage(Weapon weapon)
        {
            if (!_alive) return false;

            int damage = GetBaseDamage(weapon.Damage);
            damage += weapon.SpecialDamageState.CalculateSpecialDamage(weapon.SpecialDamage, new[]
            {
                _armor, _helmet
            });
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

        private int GetBaseDamage(int damage)
        {
            int protectionValue = 0;
            if (_armor != null)
            {
                protectionValue += _armor.Features.ArmorStrength;
            }

            if (_helmet != null)
            {
                protectionValue += _helmet.Features.ArmorStrength;
            }

            int baseDamage = damage - protectionValue;
            return baseDamage > 0 ? baseDamage : 0;
        }
    }
}