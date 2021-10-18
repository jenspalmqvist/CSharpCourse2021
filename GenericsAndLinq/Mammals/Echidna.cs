using System;
using System.Collections.Generic;

namespace GenericsAndLinq
{
    public class Echidna : Mammal, IMonotreme
    {
        public Echidna(Sex sex, string name, double weight, Diet diet, bool isHungry, int numberOfEggs, int numberOfSpikes) : base(sex, name, weight, diet, isHungry)
        {
            if (sex != Sex.Female)
            {
                throw new ArgumentException("Male echidnas do not lay eggs.");
            }
            if (NumberOfEggs < 0)
            {
                throw new ArgumentException("Echidnas cannot have a negative number of eggs.");
            }
            NumberOfEggs = numberOfEggs;
            NumberOfSpikes = numberOfSpikes;
        }

        public Echidna(Sex sex, string name, double weight, Diet diet, bool isHungry, int numberOfSpikes) : base(sex, name, weight, diet, isHungry)
        {
            NumberOfSpikes = numberOfSpikes;
        }

        public int NumberOfEggs { get; set; }
        public int NumberOfSpikes { get; set; }

        public List<IMonotreme> HatchEggs(List<string> names, List<Sex> sexes)
        {
            if (Sex != Sex.Female)
            {
                throw new ArgumentException("Male echidnas do not hatch eggs.");
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
                hatchedEggs.Add(new Echidna(sexes[i], names[i], 0.1, Diet.Milk, true, 100));
            }

            return hatchedEggs;
        }
    }
}