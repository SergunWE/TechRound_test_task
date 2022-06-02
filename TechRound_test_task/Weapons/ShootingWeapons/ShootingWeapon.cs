namespace TechRound_test_task
{
    public abstract class ShootingWeapon : Weapon
    {
        protected ShootingWeapon(string name, int damage = 1, int agility = 1)
            : base(name: name, damage: damage, agility: agility)
        {
        }
    }
}