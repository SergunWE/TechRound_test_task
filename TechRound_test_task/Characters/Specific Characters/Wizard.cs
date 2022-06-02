using System;

namespace TechRound_test_task
{
    public class Wizard : Character<MagicalWeapon>
    {
        public Wizard(int hitPoints = 1, int manaPoints = 1, int power = 1, int agility = 1, int intellect = 1) 
            : base(hitPoints, manaPoints, power, agility, intellect)
        {
            Name = "Маг";
        }
        
        public override void SetWeapon(Weapon weapon)
        {
            if (MainFeatures.Intellect < weapon.RequiredFeatures.Intellect)
            {
                throw new ArgumentOutOfRangeException
                (nameof(MainFeatures.Intellect), 
                    $"Персонаж не соответствует характеристике. " +
                    $"Требуется интеллект {weapon.RequiredFeatures.Intellect}, текущий {MainFeatures.Intellect}");
            }
            base.SetWeapon(weapon);
        }
    }
}