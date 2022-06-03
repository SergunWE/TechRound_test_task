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
            SetWeapon(weapon, MainFeatures.Agility, weapon.RequiredFeatures.Agility, "Ловкость");
        }

        public override void SetProtected(Protection protection)
        {
            SetProtected<Shooter>(protection);
        }
    }
}