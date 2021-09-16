using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace MethodsAndLists.Core
{
    public class MultipleArguments
    {
        public List<string> SomeToUpper(List<string> list, List<bool> toUpper)
        {
            if (list == null || toUpper == null || list.Count != toUpper.Count)
            {
                throw new ArgumentException();
            }

            return list.Zip(toUpper).Select(x => x.Second ? x.First.ToUpper() : x.First).ToList();
        }

        public List<double> MultiplyAllBy(int factor, List<double> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentException();
            }
            return numbers.Select(i => i * factor).ToList();
        }

        public List<string> NearbyElements(int position, List<string> list)
        {
            if (position < 0 || position > list.Count)
            {
                throw new ArgumentException();
            }
            if (position == 0)
            {
                return list.GetRange(0, 2);
            }
            else if (position == list.Count - 1)
            {
                return list.GetRange(position - 1, 2);
            }
            return list.GetRange(position - 1, 3);
        }

        public List<List<int>> MultiplicationTable(int rowMax, int colMax)
        {
            if (rowMax <= 0 || colMax <= 0)
            {
                throw new ArgumentException();
            }
            var table = new List<List<int>>();
            for (int i = 0; i < rowMax; i++)
            {
                table.Add(new List<int>());
                for (int j = 0; j < colMax; j++)
                {
                    table[i].Add((i + 1) * (j + 1));
                }
            }
            return table;
        }

        public int ComputeSequenceSumOrProduct(int toNumber, bool sum)
        {
            if (toNumber < 1)
            {
                throw new ArgumentException();
            }
            if (sum)
            {
                return Enumerable.Range(0, toNumber + 1).Sum();
            }

            return Enumerable.Range(0, toNumber + 1).Aggregate((product, i) => product == 0 ? (product + 1) * i : product * i);
        }

        public int[] CombineLists(int[] list1, int[] list2)
        {
            var newList = new List<int>();
            for (int i = 0; i < list1.Length || i < list2.Length; i++)
            {
                if (list1.Length > i)
                    newList.Add(list1[i]);
                if (list2.Length > i)
                    newList.Add(list2[i]);
            }
            return newList.ToArray();
        }

        public int[] RotateList(int[] list, int rotation)
        {
            if (list == null)
                throw new ArgumentException();

            if (rotation < 0)
            {
                rotation *= -1;
                int[] output = list.Skip(rotation).Concat(list.Take(rotation)).ToArray();
                return output;
            }
            else
            {
                rotation = list.Count() - rotation;
                int[] output = list.Skip(rotation).Concat(list.Take(rotation)).ToArray();
                return output;
            }
        }

        public int ComputeSequence(int v, object sum)
        {
            if (v < 1)
            {
                throw new ArgumentException();
            }
            if ((ComputeMethod)sum == ComputeMethod.Sum)
            {
                return Enumerable.Range(0, v + 1).Sum();
            }

            return Enumerable.Range(1, v).Aggregate(1, (product, numberInRange) => product * numberInRange);
        }
    }
}