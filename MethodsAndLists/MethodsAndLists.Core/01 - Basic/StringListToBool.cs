using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToBool
    {
        public bool AllWordsAreFiveLettersOrLonger(IEnumerable<string> list)
        {
            if (list == null)
            {
                return false;
            }
            foreach (var word in list)
            {
                if (word.Length < 5)
                {
                    return false;
                }
            }
            return true;
        }

        public bool AllWordsAreFiveLettersOrLonger_Linq(IEnumerable<string> list)
        {
            List<object> temp = new List<object>();
            temp.Add(1);
            temp.Add("hej");

            return list == null ? false : list.All(word => word.Length >= 5);
        }
    }
}