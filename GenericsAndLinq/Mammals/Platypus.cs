using System;
using System.Collections.Generic;

namespace GenericsAndLinq
{
    public class Platypus : Mammal, IMonotreme, IAquatic
    {
        public int NumberOfEggs { get; set; }
        public int MaxTimeUnderwater { get; set; }

        public Platypus(Sex sex, string name, double weight, Diet diet, bool isHungry, int maxTimeUnderWater, int numberOfEggs) : base(sex, name, weight, diet, isHungry)
        {
            if (Sex != Sex.Female)
            {
                throw new ArgumentException("Male platypus do not lay eggs.");
            }
            NumberOfEggs = numberOfEggs;
            MaxTimeUnderwater = maxTimeUnderWater;
        }

        public Platypus(Sex sex, string name, double weight, Diet diet, bool isHungry, int maxTimeUnderWater) : base(sex, name, weight, diet, isHungry)
        {
            MaxTimeUnderwater = maxTimeUnderWater;
        }

        public List<IMonotreme> HatchEggs(List<string> names, List<Sex> sexes)
        {
            if (Sex != Sex.Female)
            {
                throw new ArgumentException("Male platypus do not hatch eggs.");
            }
            if (NumberOfEggs == 0)
            {
                throw new ArgumentException("No eggs to hatch!");
            }
            if (NumberOfEggs != names.Count || NumberOfEggs != sexes.Count || names.Count != sexes.Count)
            {
                throw new ArgumentException("Invalid input");
            }
            List<IMonotreme> hatchedEggs = new List<IMonotreme>();
            for (int i = 0; i < names.Count; i++)
            {
                hatchedEggs.Add(new Platypus(sexes[i], names[i], 0.1, Diet.Milk, true, 0));
            }

            return hatchedEggs;
        }

       
    }
}