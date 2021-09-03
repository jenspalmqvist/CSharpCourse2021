using System;

namespace CarRental
{
    class Program
    {
        static void Main(string[] args)
        {
            var cc = new ConsoleCompanion();
            Car car = new Car("Volvo", 1550, 45000);
            Car car2 = new Car("Audi", 1750, 30000);
            Car car3 = new Car("Saab", 1250, 90000);
            Car car4 = new Car("Mercedes", 1950, 20000);

            CarRental carRental = new CarRental();
            carRental.AvailableCars.Add(car);
            carRental.AvailableCars.Add(car2);

            CarRental carRental2 = new CarRental();
            carRental.AvailableCars.Add(car3);
            carRental.AvailableCars.Add(car4);

            car.Rent(14, 230);

            Console.WriteLine(car);
        }
    }
}