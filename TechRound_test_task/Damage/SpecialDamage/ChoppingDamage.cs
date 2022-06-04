namespace TechRound_test_task
{
    public class ChoppingDamage : ISpecialDamageType
    {
        public int CalculateSpecialDamage(int specialDamage, Protection[] protections)
        {
            if (protections == null) return specialDamage;
            int damage = specialDamage;
            foreach (var protection in protections)
            {
                if(protection == null) continue;
                damage -= protection.Features.Chopping;
            }
            return damage > 0 ? damage : 0;
        }
    }
}