using System;
using System.Collections.Generic;

namespace MethodsAndLists
{
    public class AddNumberEngine
    {
        public enum Error
        {
            InputIsNotNumber, DontHaveTwoValues, AlreadyHaveTwoValues, SecondValueCantBeLowerThanFirst
        }

        public static Error exceptionType;
        private List<int> result = new List<int>();

        public void Input(string input)
        {
            bool add = true;
            if (int.TryParse(input, out int output))
            {
                if (result.Count == 0)
                    result.Add(output);
                else if (result.Count == 2)
                {
                    exceptionType = Error.AlreadyHaveTwoValues;
                    throw new Exception(nameof(exceptionType));
                }
                else
                {
                    foreach (int i in result)
                    {
                        if (output <= i)
                        {
                            exceptionType = Error.SecondValueCantBeLowerThanFirst;
                            throw new Exception(nameof(exceptionType));
                        }
                        else
                            add = true;
                    }
                    if (add)
                        result.Add(output);
                }
            }
            else
            {
                exceptionType = Error.InputIsNotNumber;
                throw new Exception(nameof(exceptionType));
            }
        }

        public int Result()
        {
            if (result.Count < 2)
            {
                exceptionType = Error.DontHaveTwoValues;
                throw new Exception(nameof(exceptionType));
            }
            int output = 0;

            for (int i = result[0]; i <= result[1]; i++)
            {
                output += i;
            }
            return output;
        }

        public class Exception : SystemException
        {
            public Error Error { get { return exceptionType; } }

            public Exception(string message) : base(message)
            {
            }
        }


    }
}