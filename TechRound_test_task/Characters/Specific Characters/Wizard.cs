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
            SetWeapon(weapon, MainFeatures.Intellect, weapon.RequiredFeatures.Intellect, "Интеллект");
        }

        public override void SetProtected(Protection protection)
        {
            SetProtected<Wizard>(protection);
        }
    }
}