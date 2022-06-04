using System.Collections.Generic;

namespace TechRound_test_task
{
    public static class ProtectionPool
    {
        private static readonly List<Protection> _basedProtections;
        private static readonly List<Protection> _customProtections;
        private static readonly int _basedProtectionCount;
        

        static ProtectionPool()
        {
            _basedProtections = new List<Protection>();
            _customProtections = new List<Protection>();

            //Экипировка стрелка
            _basedProtections.Add(new Armor(CharacterClass.Shooter, "Кожаная броня", 12, 5, 2, 15));
            _basedProtections.Add(new Helmet(CharacterClass.Shooter, "Шлем разбойника", 10, 5, 2, 10));
            //Экипировка воина
            _basedProtections.Add(new Armor(CharacterClass.Warrior, "Тяжёлая броня",30, 15, 2, 5));
            _basedProtections.Add(new Helmet(CharacterClass.Warrior, "Латный шлем",20, 10, 2, 5));
            //Экипировка мага
            _basedProtections.Add(new Armor(CharacterClass.Wizard, "Магическая броня",5, 2, 30, 5));
            _basedProtections.Add(new Helmet(CharacterClass.Wizard, "Магический колпак",5, 2, 20, 5));

            _basedProtectionCount = _basedProtections.Count;
        }

        public static List<Protection> BasedProtections => _basedProtections;
        public static int ProtectionCount => _basedProtectionCount + _customProtections.Count;
    }
}