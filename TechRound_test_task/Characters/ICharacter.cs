using System;
using TechRound_test_task.Damage;

namespace TechRound_test_task
{
    public interface ICharacter : IDamageable
    {
        void SetWeapon(Weapon weapon);
        string CharacterName();
        int HitPoints();
        int ManaPoints();
        MainFeatures GetMainFeatures();
        Weapon GetWeapon();
        bool Alive();

        object GetCharacterType();
    }
}