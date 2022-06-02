using System;

namespace TechRound_test_task
{
    public struct MainFeatures
    {
        public int Power { get; private set; }
        public int Agility { get; private set; }
        public int Intellect { get; private set; }

        public MainFeatures(int power = 1, int agility = 1, int intellect = 1)
        {
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