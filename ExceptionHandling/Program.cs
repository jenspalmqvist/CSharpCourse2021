using System;
using System.Threading.Tasks.Dataflow;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dela talen!");

            try
            {
                int a = 5;
                int b = 0;
                int c = a / b;
                int d = int.Parse("987523947851927835");
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}