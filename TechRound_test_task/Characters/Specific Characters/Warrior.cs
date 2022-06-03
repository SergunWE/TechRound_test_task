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
            SetWeapon(weapon, MainFeatures.Power, weapon.RequiredFeatures.Power, "Сила");
        }

        public override void SetProtected(Protection protection)
        {
            SetProtected<Warrior>(protection);
        }
    }
}