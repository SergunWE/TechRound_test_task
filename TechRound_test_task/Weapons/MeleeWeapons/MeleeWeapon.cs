namespace TechRound_test_task
{
    public abstract class MeleeWeapon : Weapon
    {
        protected MeleeWeapon(string name, int damage = 1, int specialDamage = 30, int power = 1)
            : base(name: name, damage: damage, specialDamage: specialDamage, power: power,
                specialDamageType: new ChoppingDamage())
        {
        }
    }
}