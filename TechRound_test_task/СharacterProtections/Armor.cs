namespace TechRound_test_task
{
    public abstract class Armor<TCharClass> : Protection where TCharClass : ICharacter
    {
        protected Armor(string name, int armorStrength = 1, int chopping = 1, int magic = 1, int stabbing = 1)
            : base(armorStrength, chopping, magic, stabbing)
        {
            Name = name;
        }
    }
}