using System;

namespace TechRound_test_task
{
    public readonly struct MainFeatures
    {
        private const string FeatureSetError = "Параметр не может быть меньше 1";
        public int Power { get; }
        public int Agility { get; }
        public int Intellect { get; }

        public MainFeatures(int power = 1, int agility = 1, int intellect = 1)
        {
            if (power < 1 || agility < 1 || intellect < 1)
            {
                throw new ArgumentException(FeatureSetError);
            }

            Power = power;
            Agility = agility;
            Intellect = intellect;
        }

        public override string ToString()
        {
            return "Сила: " + Power + " Ловкость: " + Agility + " Интеллект: " + Intellect;
        }
    }
}