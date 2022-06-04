namespace TechRound_test_task
{
    public abstract class Protection
    {
        private string _name;
        private ProtectionFeatures _features;

        private CharacterClass _characterClass;

        protected Protection(CharacterClass characterClass, string name, int armorStrength = 1, int chopping = 1, int magic = 1, int stabbing = 1)
        {
            _characterClass = characterClass;
            _name = name;
            _features = new ProtectionFeatures(armorStrength, chopping, magic, stabbing);
        }
        
        public string Name => _name;
        public ProtectionFeatures Features => _features;
        public CharacterClass CharacterClass => _characterClass;
    }
}