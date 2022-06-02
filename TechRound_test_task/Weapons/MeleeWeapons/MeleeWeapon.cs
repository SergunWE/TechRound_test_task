namespace TechRound_test_task
{
    public abstract class MeleeWeapon : Weapon
    {
        protected MeleeWeapon(string name, int damage = 1, int power = 1)
            : base(name: name, damage: damage, power: power)
        {
        }
    }
}