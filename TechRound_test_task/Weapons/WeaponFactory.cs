using System;

namespace TechRound_test_task
{
    public static class WeaponFactory
    {
        public static Weapon GetWeapon(WeaponEnum weaponType)
        {
            return weaponType switch
            {
                WeaponEnum.Bow => new Bow(),
                WeaponEnum.Crossbow => new Crossbow(),
                WeaponEnum.Musket => new Musket(),
                WeaponEnum.ShortSword => new ShortSword(),
                WeaponEnum.LongSword => new LongSword(),
                WeaponEnum.Dagger => new Dagger(),
                WeaponEnum.Staff => new Staff(),
                WeaponEnum.MagicBook => new MagicBook(),
                WeaponEnum.MagicSymbol => new MagicSymbol(),
                _ => throw new ArgumentOutOfRangeException(nameof(weaponType), weaponType, null)
            };
        }
    }
}