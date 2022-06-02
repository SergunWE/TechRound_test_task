using System;

namespace TechRound_test_task
{
    public class Shooter : Character<ShootingWeapon>
    {
        public Shooter(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1) 
            : base(hitPoints, manaPoints, power, agility, intellect)
        {
            Name = "Стрелок";
        }

        public override void SetWeapon(Weapon weapon)
        {
            if (MainFeatures.Agility < weapon.RequiredFeatures.Agility)
            {
                throw new ArgumentOutOfRangeException
                    (nameof(MainFeatures.Agility), 
                        $"Персонаж не соответствует характеристике. " +
                        $"Требуется ловкость {weapon.RequiredFeatures.Agility}, текущая {MainFeatures.Agility}");
            }
            base.SetWeapon(weapon);
        }
    }
}