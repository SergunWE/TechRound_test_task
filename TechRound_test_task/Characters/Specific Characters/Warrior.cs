using System;

namespace TechRound_test_task
{
    public class Warrior : Character<MeleeWeapon>
    {
        public Warrior(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1) 
            : base(hitPoints, manaPoints, power, agility, intellect)
        {
            Name = "Воин";
        }
        
        public override void SetWeapon(Weapon weapon)
        {
            if (MainFeatures.Power < weapon.RequiredFeatures.Power)
            {
                throw new ArgumentOutOfRangeException
                (nameof(MainFeatures.Power), 
                    $"Персонаж не соответствует характеристике. " +
                    $"Требуется сила {weapon.RequiredFeatures.Power}, текущая {MainFeatures.Power}");
            }
            base.SetWeapon(weapon);
        }
    }
}