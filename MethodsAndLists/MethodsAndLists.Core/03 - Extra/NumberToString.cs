
using System;

namespace MethodsAndLists.Core
{
    public class NumberToString
    {
        public string Triangle(int v)
        {
            string triangle = "";
           if(v < 0)
            {
                throw new ArgumentException();
            }
            for (int i = 1; i <= v; i++)
            {
                if(i == 1)
                {
                    triangle += "*";
                }else
                {
                    triangle += $"\n{new string('*', i)}";
                }
            }
            return triangle;
        }

        public string TriangleReversed(int v)
        {
            string triangle = "";
            if (v < 0)
            {
                throw new ArgumentException();
            }
            for (int i = v; i > 0; i--)
            {
                if (i == 1)
                {
                    triangle += "*";
                }
                else
                {
                    triangle += $"{new string('*', i)}\n";
                }
            }
            return triangle;
        }

        public string Triangle(int v1, char v2)
        {
            string triangle = "";
            if (v1 <= 0)
            {
                throw new ArgumentException();
            }
            for (int i = 1; i <= v1; i++)
            {
                if (i == 1)
                {
                    triangle += v2;
                }
                else
                {
                    triangle += $"\n{new string(v2, i)}";
                }
            }
            return triangle;
        }
    }
}
