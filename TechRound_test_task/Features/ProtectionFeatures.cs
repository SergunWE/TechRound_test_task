using System;

namespace TechRound_test_task
{
    public struct ProtectionFeatures
    {
        private const string FeatureSetError = "Параметр не может быть меньше 1";
        public int ArmorStrength { get; private set; }
        public int Chopping { get; private set; }
        public int Magic { get; private set; }
        public int Stabbing { get; private set; }

        public ProtectionFeatures(int armorStrength = 1, int chopping = 1, int magic = 1, int stabbing = 1)
        {
            if (armorStrength < 1 || chopping < 1 || magic < 1 || stabbing < 1)
            {
                throw new ArgumentException(FeatureSetError);
            }
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