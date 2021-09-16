using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberListToString
    {
        public string ReportFirstAndLastValue(List<int> list)
        {
            if (list == null || list.Count < 1)
            {
                throw new ArgumentException();
            }

            return $"Första siffran är {list[0]} och sista siffran är {list[list.Count - 1]}";
        }

        public string ReportNumberOfNegativeValues(List<int> list)
        {
            int numberOfNegatives = 0;
            foreach (int i in list)
            {
                if (i < 0)
                {
                    numberOfNegatives++;
                }
            }
            if (numberOfNegatives == 0)
            {
                return "Jippi! Det finns inga negativa tal i listan";
            }
            else if (numberOfNegatives == 1)
            {
                return "Det finns ett negativt tal i listan";
            }
            else
            {
                return $"Det finns {numberOfNegatives} st negativa tal i listan";
            }
        }
    }
}