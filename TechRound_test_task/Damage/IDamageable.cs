namespace TechRound_test_task.Damage
{
    public interface IDamageable
    {
        bool Attack(object target);
        bool TakeDamage(int damage);
    }
}