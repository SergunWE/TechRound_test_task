using System.Collections.Generic;

namespace TechRound_test_task
{
    public static class CharacterPool
    {
        private static readonly List<Character> _basedCharacters;
        private static readonly List<Character> _customCharacters;
        private static Character _currentCharacter;

        private static readonly int _basedCharacterCount;
        private static int _customCharacterCount;

        static CharacterPool()
        {
            _basedCharacters = new List<Character>();
            _customCharacters = new List<Character>();
            _currentCharacter = null;
            
            _basedCharacters.Add(new Character(CharacterClass.Shooter, "Стрелок", 100, 100, agility: 15));
            _basedCharacters.Add(new Character(CharacterClass.Warrior, "Воин", 100, 100, power: 10));
            _basedCharacters.Add(new Character(CharacterClass.Wizard, "Маг", 100, 100, intellect: 9));

            _basedCharacterCount = _basedCharacters.Count;
            _customCharacterCount = 0;
        }

        public static void CreateCharacter(CharacterClass characterType, string name = null,
            int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = characterType.ToString() + ++_customCharacterCount;
            }
            
            _customCharacters.Add(new Character(characterType, name, hitPoints, manaPoints, power, agility, intellect));
        }

        public static ICharacter GetCurrentCharacter()
        {
            return _currentCharacter;
        }

        public static void SetCurrentCharacter(int index)
        {
            if (index >= _basedCharacterCount)
            {
                _currentCharacter = _customCharacters[index - _basedCharacterCount];
                return;
            }
            _currentCharacter = _basedCharacters[index];
        }

        public static void SetWeapon(Weapon weapon)
        {
            _currentCharacter.SetWeapon(weapon);
        }

        public static void SetProtection(Protection protection)
        {
            _currentCharacter.SetProtected(protection);
        }

        public static void SetJewelry(Jewelry jewelry)
        {
            _currentCharacter.SetJewelry(jewelry);
        }

        public static List<Character> BasedCharacters => _basedCharacters;
        public static List<Character> CustomCharacters => _customCharacters;
        public static int CharacterCount => _basedCharacterCount + _customCharacters.Count;
    }
}