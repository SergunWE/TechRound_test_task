namespace TechRound_test_task
{
    public interface IDamageable
    {
        bool Attack(object target);
        bool TakeDamage(Weapon weapon);
    }
}