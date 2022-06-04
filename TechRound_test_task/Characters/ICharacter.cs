namespace TechRound_test_task
{
    public interface ICharacter : IDamageable
    {
        string CharacterName();
        int HitPoints();
        int ManaPoints();
        MainFeatures GetMainFeatures();
        Weapon GetWeapon();
        Protection[] GetProtection();
        Jewelry GetJewelry();
        bool Alive();
        CharacterClass GetCharacterClass();
    }
}