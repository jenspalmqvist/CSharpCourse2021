
using System;
using System.Collections.Generic;

namespace MethodsAndLists.Core
{
    public class StringListToStringList
    {
        public IEnumerable<string> GetEverySecondElement(string[] input)
        {
            if(input == null)
            {
                throw new ArgumentNullException();
            }
            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if(i % 2 != 0)
                {
                    result.Add(input[i]);
                }
            }
            return result;
        }
    }
}
