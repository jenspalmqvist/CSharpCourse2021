using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DataAccess är vårt klass där vi jobbar mot databasen
            DataAccess dataAccess = new DataAccess();
            Console.WriteLine("Resetting Database");
            dataAccess.RecreateDatabase();
            Console.WriteLine("Adding Cars and RentalOffices");
            dataAccess.AddCarsAndRentalOffices();
            Console.WriteLine("Fetching cars");
            List<Car> cars = dataAccess.GetCars();
            Console.WriteLine("List of car models:");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}

