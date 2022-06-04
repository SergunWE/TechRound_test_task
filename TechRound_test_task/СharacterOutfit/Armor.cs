namespace TechRound_test_task
{
    public class Armor : Protection
    {
        public Armor(CharacterClass characterClass, string name, int armorStrength = 1, int chopping = 1,
            int magic = 1, int stabbing = 1)
            : base(characterClass, name, armorStrength, chopping, magic, stabbing)
        {
        }
    }
}