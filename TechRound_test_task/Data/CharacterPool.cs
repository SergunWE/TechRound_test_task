using System;
using System.Collections.Generic;

namespace TechRound_test_task
{
    public class CharacterPool
    {
        private readonly List<ICharacter> _characters;
        private ICharacter _currentCharacter;

        public CharacterPool()
        {
            _characters = new List<ICharacter>();
            _currentCharacter = null;
        }

        public void CreateCharacter(CharacterEnum characterType,
            int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            switch (characterType)
            {
                case CharacterEnum.Warrior:
                    _characters.Add(new Warrior(hitPoints, manaPoints, power, agility, intellect));
                    break;
                case CharacterEnum.Shooter:
                    _characters.Add(new Shooter(hitPoints, manaPoints, power, agility, intellect));
                    break;
                case CharacterEnum.Wizard:
                    _characters.Add(new Wizard(hitPoints, manaPoints, power, agility, intellect));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(characterType), characterType, null);
            }
        }

        public ICharacter GetCurrentCharacter()
        {
            return _currentCharacter;
        }

        public void SetCurrentCharacter(int index)
        {
            _currentCharacter = _characters[index];
        }

        public void SetWeapon(WeaponEnum weaponType)
        {
            _currentCharacter.SetWeapon(WeaponFactory.GetWeapon(weaponType));
        }

        public List<ICharacter> Characters => _characters;
    }
}