using System;
using System.Diagnostics;
using InputOutput;

namespace TechRound_test_task
{
    public class Character : ICharacter
    {
        private int _hitPoints;
        private int _manaPoints;
        private readonly string Name;

        private Weapon _weapon;
        private readonly MainFeatures _mainFeatures;

        private bool _alive;

        private Protection _armor;
        private Protection _helmet;
        private Jewelry _jewelry;

        private readonly CharacterClass _characterClass;

        public Character(CharacterClass characterClass, string name, int hitPoints = 1, int manaPoints = 1, int power = 1,
            int agility = 1, int intellect = 1)
        {
            if (hitPoints <= 0 || manaPoints <= 0)
            {
                throw new ArgumentException("Значение здоровья или маны не могут быть меньше 1");
            }

            Name = name;
            _characterClass = characterClass;
            _hitPoints = hitPoints;
            _manaPoints = manaPoints;
            _mainFeatures = new MainFeatures(power, agility, intellect);
            _alive = true;
        }

        private bool CheckPoints(ref int points)
        {
            return points > 0;
        }

        public void SetWeapon(Weapon weapon)
        {
            switch (_characterClass)
            {
                case CharacterClass.Warrior:
                    SetWeapon(weapon, _mainFeatures.Power, weapon.RequiredFeatures.Power, "Сила");
                    break;
                case CharacterClass.Shooter:
                    SetWeapon(weapon, _mainFeatures.Agility, weapon.RequiredFeatures.Agility, "Ловкость");
                    break;
                case CharacterClass.Wizard:
                    SetWeapon(weapon, _mainFeatures.Intellect, weapon.RequiredFeatures.Intellect, "Интеллект");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetWeapon(Weapon weapon, int feature, int requiredFeature, string featureName)
        {
            if (weapon.CharacterClass != _characterClass)
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

        public void SetProtected(Protection protection)
        {
            if (protection.CharacterClass != _characterClass)
            {
                throw new ArgumentException("Экипировка не соответствует классу персонажа");
            }
            switch (protection)
            {
                case Armor:
                    _armor = protection;
                    break;
                case Helmet:
                    _helmet = protection;
                    break;
            }
        }

        public void SetJewelry(Jewelry jewelry)
        {
            _jewelry = jewelry;
        }

        public string CharacterName() => Name;
        public int HitPoints() => _hitPoints;
        public int ManaPoints() => _manaPoints;
        public MainFeatures GetMainFeatures() => _mainFeatures;
        public Weapon GetWeapon() => _weapon;
        public CharacterClass GetCharacterClass() => _characterClass;
        public Jewelry GetJewelry() => _jewelry;

        public Protection[] GetProtection()
        {
            return new[] {_armor, _helmet};
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
            damage += weapon.SpecialDamageType.CalculateSpecialDamage(weapon.SpecialDamage, GetProtection());
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
            foreach (var protection in GetProtection())
            {
                if(protection == null) continue;
                protectionValue += protection.Features.ArmorStrength;
            }

            int baseDamage = damage - protectionValue;
            return baseDamage > 0 ? baseDamage : 0;
        }
    }
}