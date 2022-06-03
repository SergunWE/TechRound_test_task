namespace TechRound_test_task
{
    public abstract class Protection
    {
        protected string Name;
        private ProtectionFeatures _features;

        protected Protection(int armorStrength = 1, int chopping = 1, int magic = 1, int stabbing = 1)
        {
            _features = new ProtectionFeatures(armorStrength, chopping, magic, stabbing);
        }
        
        public string ProtectionName => Name;
        public ProtectionFeatures Features => _features;
    }
}