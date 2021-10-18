using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace GenericsAndLinq
{
    public class Fox : Mammal
    {
        public Fox(Sex sex, string name, double weight, Diet diet, bool isHungry, List<string> stuffItSays) : base(sex, name, weight, diet, isHungry)
        {
            StuffItSays = stuffItSays;
        }

        public Fox(Sex sex, string name, double weight, Diet diet, bool isHungry) : base(sex, name, weight, diet, isHungry)
        {
        }

        public List<string> StuffItSays { get; set; }

        public string WhatDoesItSay()
        {
            if (StuffItSays is null || StuffItSays.Count == 0)
            {
                return "It is silent";
            }
            string itSays = StuffItSays[0];
            StuffItSays.RemoveAt(0);
            return itSays;
        }
    }
}