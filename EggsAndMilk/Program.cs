using System;

namespace EggsAndMilk
{
    class Program
    {
        static void Main(string[] args)
        {
            int cartonsOfMilk = 0;
            bool storeHasEggs = true;

            if (storeHasEggs)
            {
                cartonsOfMilk = 6;
            }
            else
            {
                cartonsOfMilk = 1;
            }
            Console.WriteLine($"I bought {cartonsOfMilk} cartons of milk!");
        }
    }
}