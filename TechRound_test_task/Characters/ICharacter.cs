namespace TechRound_test_task
{
    public interface ICharacter : IDamageable
    {
        void SetWeapon(Weapon weapon);
        void SetProtected(Protection protection);
        string CharacterName();
        int HitPoints();
        int ManaPoints();
        MainFeatures GetMainFeatures();
        Weapon GetWeapon();
        Protection[] GetProtection();
        bool Alive();
    }
}