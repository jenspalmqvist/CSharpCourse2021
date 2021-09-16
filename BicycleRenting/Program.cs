using System;
using System.Collections.Generic;
using System.Linq;

namespace BicycleRenting
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new ConsoleCompanion();

            List<Bicycle> bicycles = new List<Bicycle> {
            new Bicycle(BicycleType.Unicycle, Brand.Crescent, 150),
            new Bicycle(BicycleType.Unicycle, Brand.Scott, 170),
            new Bicycle(BicycleType.ElectricBike, Brand.Scott, 250),
            new Bicycle(BicycleType.ElectricBike, Brand.Crescent, 250),
            new Bicycle(BicycleType.ElectricBike, Brand.DBS, 300),
            new Bicycle(BicycleType.Tandem, Brand.Kronans, 290),
            new Bicycle(BicycleType.Tandem, Brand.Kronans, 250),
            new Bicycle(BicycleType.MountainBike, Brand.Scott, 250),
            new Bicycle(BicycleType.MountainBike, Brand.Scott, 450),
            new Bicycle(BicycleType.MountainBike, Brand.DBS, 350),
            };

            if (bicycles == null)
            {
                throw new Exception();
            }
            BicycleRental rental = new BicycleRental("Rental one", bicycles);
            BicycleRental rental2 = new BicycleRental("Rental two", new List<Bicycle>());

            var scottBikes = rental.Bicycles.Where(bicycle => bicycle.Brand == Brand.Scott);

            Console.WriteLine(rental.Bicycles[3]);
            rental.RentBicycle(rental.Bicycles[3], 5);
            Console.WriteLine(rental.Revenue);

            rental.ReturnBike(rental.Bicycles[3], rental2);
            Console.WriteLine(rental2.Bicycles[0]);
            Console.WriteLine(rental2.Revenue);
        }
    }
}