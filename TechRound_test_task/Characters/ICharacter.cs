namespace TechRound_test_task
{
    public interface ICharacter
    {
        void SetWeapon(Weapon weapon);
        string CharacterName();
        int HitPoints();
        int ManaPoints();
        MainFeatures GetMainFeatures();
        Weapon GetWeapon();
    }
}