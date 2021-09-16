using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberListToNumberList
    {
        public List<int> Add100ToEachNumber(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] += 100;
            }
            return input;
        }

        public List<int> Add50ToFirstThreeElements(List<int> input)
        {
            var list = input;
            for (int i = 0; i < input.Count; i++)
            {
                if (i < 3)
                {
                    list.Add(input[i] + 50);
                    input[i] += 50;
                }
                else
                {
                    list.Add(input[i]);
                }
            }
            return input;
        }

        public List<int> Add70ToEverySecondElement(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                if (i % 2 == 1)

                {
                    input[i] += 70;
                }
            }
            return input;
        }

        public List<int> DivideEachNumberBy100(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] /= 100;
            }
            return input;
        }

        public List<int> GetNumbersDividableByFive(List<int> input)
        {
            return input.FindAll(num => num % 5 == 0);
        }

        public List<int> GetNumbersHigherThan1000(List<int> input)
        {
            return input.FindAll(num => num > 1000);
        }

        public List<int> NegateEachNumber(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                input[i] *= -1;
            }
            return input;
        }
    }
}