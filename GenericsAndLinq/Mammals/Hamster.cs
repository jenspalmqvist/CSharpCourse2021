using System;

namespace GenericsAndLinq
{
    public class Hamster : Mammal
    {
        public Hamster(Sex sex, string name, double weight, Diet diet, bool isHungry) : base(sex, name, weight, diet, isHungry)
        {
        }

        public string SpinWheel(int numberOfTimes)
        {
            string spinResult = "Okay, I'm ";
            for (int i = 1; i <= numberOfTimes; i++)
            {
                spinResult += "spinning ";
            }
            if (numberOfTimes > 10)
            {
                IsHungry = true;
            }
            return spinResult + "around.";
        }
    }
}