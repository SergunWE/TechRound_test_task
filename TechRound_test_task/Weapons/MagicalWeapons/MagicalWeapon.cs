namespace TechRound_test_task
{
    public abstract class MagicalWeapon : Weapon
    {
        protected MagicalWeapon(string name, int damage = 1, int specialDamage = 0, int intellect = 1)
            : base(name: name, damage: damage, specialDamage: specialDamage,
                intellect: intellect, specialDamageType: new MagicDamage())
        {
        }
    }
}