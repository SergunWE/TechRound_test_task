using System.Collections.Generic;

namespace TechRound_test_task
{
    public static class JewelryPool
    {
        private static readonly List<Jewelry> _basedJewelries;
        private static readonly int _basedJewelryCount;

        static JewelryPool()
        {
            _basedJewelries = new List<Jewelry>();
            _basedJewelries.Add(new Jewelry("Коготь сокола"));
            _basedJewelries.Add(new Jewelry("Мешочек с морской солью"));
            _basedJewelries.Add(new Jewelry("Магический амулет"));

            _basedJewelryCount = _basedJewelries.Count;
        }

        public static List<Jewelry> BasedJewelries => _basedJewelries;
        public static int JewelryCount => _basedJewelryCount;
    }
}