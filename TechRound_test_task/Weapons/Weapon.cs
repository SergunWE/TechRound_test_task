namespace TechRound_test_task
{
    public class Weapon
    {
        private readonly string _name;
        private readonly int _damage;
        private readonly int _specialDamage;
        private readonly ISpecialDamageType _specialDamageType;
        private readonly MainFeatures _requiredFeatures;
        private readonly CharacterClass _characterClass;

        public Weapon(CharacterClass characterClass, string name, int damage = 1, int specialDamage = 0, int power = 1,
            int agility = 1,
            int intellect = 1, ISpecialDamageType specialDamageType = null)
        {
            _characterClass = characterClass;
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
        public ISpecialDamageType SpecialDamageType => _specialDamageType;
        public CharacterClass CharacterClass => _characterClass;
    }
}