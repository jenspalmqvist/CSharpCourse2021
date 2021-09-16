using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MethodsAndLists.Core
{
    public class StringToBool
    {
        public bool IsPalindrome(string input)
        {
            string result = "";
            if (input == null || !Regex.IsMatch(input, @"^[A-Za-zåäöÅÄÖ]*$"))
            {
                throw new ArgumentException();
            }
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }

            return input == result;
        }

        public bool IsZipCode(string text)
        {
            return text == null ? false : Regex.IsMatch(text, @"^[1-9]\d{2} [1-9]\d{1}$");
        }
    }
}