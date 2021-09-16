using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberListToStringList
    {
        public List<string> NegativeNumbersIsZip_PositiveNumbersIsZap_ZeroIsBoing(List<int> list)
        {
            List<string> result = new List<string>();
            //result = list.ForEach(i => result.Add(i < 0 ? "ZIP" : i > 0 ? "ZAP" : "BOING"));
            foreach (int number in list)
            {
                result.Add(number < 0 ? "ZIP" : number > 0 ? "ZAP" : "BOING");
            }
            return result;
        }

        public List<string> LongOrShort(List<int> list)
        {
            List<string> result = new List<string>();
            foreach (int i in list)
            {
                if (i > 250 || i < 0)
                {
                }
                else if (i > 160)
                {
                    result.Add($"{i}cm är långt");
                }
                else
                {
                    result.Add($"{i}cm är kort");
                }
            }
            return result;
        }

        public List<string> AddStars(List<int> list)
        {
            List<string> result = new List<string>();
            foreach (int i in list)
            {
                result.Add("***" + i + "***");//$"***{i}***");
            }
            return result;
        }

        public List<string> AddStarsToNumbersHigherThan1000(List<int> list)
        {
            List<string> result = new List<string>();
            foreach (int i in list)
            {
                if (i > 1000)
                {
                    result.Add($"***{i}***");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }
            return result;
        }
    }
}