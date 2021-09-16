using System;

namespace MethodsAndLists.Core
{
    public class StringListToString
    {
        public string Frame(string[] v)
        {
            string framedString = "";
            int longestWord = 0;
            if (v == null)
            {
                throw new ArgumentException();
            }
            else if (v.Length == 0)
            {
                return framedString;
            }
            foreach (string s in v)
            {
                if (s.Length > longestWord)
                {
                    longestWord = s.Length;
                }
            }
            framedString += $"{new string('*', longestWord + 4)}\n";
            for (int i = 0; i < v.Length; i++)
            {
                int padding = longestWord - v[i].Length;
                framedString += $"* {v[i]}{new string(' ', padding)} *\n";
            }
            framedString += new string('*', longestWord + 4);

            return framedString;
        }
    }
}