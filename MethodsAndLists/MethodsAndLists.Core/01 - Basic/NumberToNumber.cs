using System;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberToNumber
    {
        public int SumNumbers(int from, int to)
        {
            var temp = Enumerable.Range(0, 5);
            return Enumerable.Range(from, to - from + 1).Sum();
            return Enumerable.Range(-13, 12).Sum();
        }

        public int SumNumbersTo(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException();
            }
            return Enumerable.Range(0, input + 1).Sum();
            int sum = 0;
            for (int i = 1; i <= input; i++)
            {
                sum += i;
            }
            return sum;
        }

        public int SumNumbersDividedByThreeOrFive(int input)
        {
            return Enumerable.Range(1, input).Where(i => i % 3 == 0 || i % 5 == 0).Sum();
        }
    }
}