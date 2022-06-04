using System.Collections.Generic;

namespace TechRound_test_task
{
    public static class WeaponPool
    {
        private static List<Weapon> _basedWeapons;
        private static int _basedWeaponCount;

        static WeaponPool()
        {
            _basedWeapons = new List<Weapon>();

            //Стрелковое оружие
            _basedWeapons.Add(new Weapon(CharacterClass.Shooter, "Лук", 12, 6, agility: 6,
                specialDamageType: new StabbingDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Shooter, "Арбалет", 19, 15, agility: 11,
                specialDamageType: new StabbingDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Shooter, "Мушкет", 25, 20, agility: 20,
                specialDamageType: new StabbingDamage()));
            //Оружие ближнего боя
            _basedWeapons.Add(new Weapon(CharacterClass.Warrior, "Кинжал", 6, 3, power: 3,
                specialDamageType: new ChoppingDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Warrior, "Короткий меч", 10, 9, power: 5,
                specialDamageType: new ChoppingDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Warrior, "Длинный меч", 20, 20, power: 9,
                specialDamageType: new ChoppingDamage()));
            //Магическое оружие
            _basedWeapons.Add(new Weapon(CharacterClass.Wizard, "Магический символ", 7, 7, intellect: 3,
                specialDamageType: new MagicDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Wizard, "Магическая книга", 10, 11, intellect: 6,
                specialDamageType: new MagicDamage()));
            _basedWeapons.Add(new Weapon(CharacterClass.Wizard, "Посох", 21, 30, intellect: 12,
                specialDamageType: new MagicDamage()));

            _basedWeaponCount = _basedWeapons.Count;
        }

        public static List<Weapon> BasedWeapons => _basedWeapons;
        public static int BasedCount => _basedWeaponCount;
    }
}