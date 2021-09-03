using System;
using System.Linq;

namespace Loopar
{
    class Program
    {
        static void Main(string[] args)
        {
            int result = AskForInt(5, 30, "Fråga!");
            Console.WriteLine(result);
        }

        private static int AskForInt(string question)
        {
            int result;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out result));
            return result;
        }

        private static int AskForInt(int min, int max, string question)
        {
            int result;
            do
            {
                Console.WriteLine(question);
            } while (!int.TryParse(Console.ReadLine(), out result) || result < min || result > max);
            return result;
        }
    }
}