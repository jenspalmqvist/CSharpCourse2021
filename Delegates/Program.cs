using System;

namespace Delegates
{
    class Program
    {
        public delegate void DelegateMethod(string temp);

        static void Main(string[] args)
        {
            //DelegateMethod del;
            //for (int i = 0; i <= 10; i++)
            //{
            //    if (i < 5)
            //    {
            //        del = LowerThanFive;
            //    }
            //    else
            //    {
            //        del = HigherThanFive;
            //    }
            //    MethodWithCallback(i, del);
            //}

            Func<int, int, int> add = Sum;
            //Action<int, int> add2 = Sum2;
            //add2(20, 30);
            //Method(add);
            bool temp = MethodWithOutParameter(10, 20, out int num3);
            int num4 = 30;
            bool temp2 = MethodWithRefParameter(10, 20, ref num4);

            string s = "Hej";
            MethodWithRefParameter(ref s);
            Console.WriteLine(s);
            Console.WriteLine(num3.ToString() + temp);
            Console.WriteLine(num4.ToString() + temp2);
        }

        static bool MethodWithOutParameter(int num1, int num2, out int num3)
        {
            num3 = num1 + num2;
            return true;
        }

        static bool MethodWithRefParameter(int num1, int num2, ref int num4)
        {
            num4 += num1 + num2;
            return true;
        }

        static void MethodWithRefParameter(ref string s)
        {
            s += "!";
        }

        static void Method(Func<int, int, int> func)
        {
            int result = func(10, 10);
            Console.WriteLine(result);
        }

        static int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        static void Sum2(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static void LowerThanFive(string temp)
        {
            Console.WriteLine("The number is lower than five");
        }

        static void HigherThanFive(string temp)
        {
            Console.WriteLine(temp);
            Console.WriteLine("The number is higher than five");
        }

        static void MethodWithCallback(int i, DelegateMethod del)
        {
            del.Invoke("hepp");
        }
    }
}