using System;
using System.Collections.Generic;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            ElectricCar c = new ElectricCar("Escort", "Ford");
            Recipe r = new Recipe("Kaka", 5, new List<string>());
            Recipe r2 = new Recipe("Kaka", 5, new List<string>());

            Cake cake = new Cake("Kaka", 5, new List<string>(), 12);
            c.Brand = "Ford";
            c.Model = "Escort";
            c.Honk();
            Console.WriteLine($"{c.Brand} {c.Model}");
        }
    }
}