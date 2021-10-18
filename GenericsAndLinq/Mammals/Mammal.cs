using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndLinq
{
    public abstract class Mammal
    {
        public Sex Sex { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public Diet Diet { get; set; }
        public bool IsHungry { get; set; }
        public bool IsAlive { get; set; } = true;

        public Mammal(Sex sex, string name, double weight, Diet diet, bool isHungry)
        {
            Sex = sex;
            Name = name;
            Weight = weight;
            Diet = diet;
            IsHungry = isHungry;
        }

        virtual public string Feed(Diet food)
        {
            if (food != Diet)
            {
                return "I don't like this food!";
            }
            else if (!IsHungry)
            {
                return "I don't want to eat right now.";
            }
            else
            {
                IsHungry = false;
                return "Yum! Thank you!";
            };
        }
    }
}