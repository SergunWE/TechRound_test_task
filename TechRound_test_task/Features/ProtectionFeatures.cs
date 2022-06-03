namespace TechRound_test_task
{
    public struct ProtectionFeatures
    {
        public int ArmorStrength { get; private set; }
        public int Chopping { get; private set; }
        public int Magic { get; private set; }
        public int Stabbing { get; private set; }

        public ProtectionFeatures(int armorStrength = 1, int chopping = 1, int magic = 1, int stabbing = 1)
        {
            ArmorStrength = armorStrength;
            Chopping = chopping;
            Magic = magic;
            Stabbing = stabbing;
        }
        
        public override string ToString()
        {
            return "Броня: " + ArmorStrength + "\nЗащита от рубящего урона: " + Chopping + 
                   "\nМагическая защита: " + Magic + "\nЗащита от колющего удара: " + Stabbing;
        }
    }
}