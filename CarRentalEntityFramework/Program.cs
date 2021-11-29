using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class Program
    {
        static DataAccess dataAccess = new DataAccess();
        static void Main(string[] args)
        {
            // DataAccess är vår klass där vi jobbar mot databasen
            Console.WriteLine("Resetting Database");
            dataAccess.RecreateDatabase();
            Console.WriteLine("Adding Cars and RentalOffices");
            dataAccess.AddCarsAndRentalOffices();
            //DisplayCarInfo();
            //DisplaySpecificCarInfo();
            //DisplayCarsInRentalOffice();
            //DisplayEmployeeInfo();
            //RemoveCarById();
            UpdateCarById();
            UpdateAllCars();
        }

        static void DisplayCarInfo()
        {
            Console.WriteLine("Fetching cars");
            List<Car> cars = dataAccess.GetCars();
            Console.WriteLine("List of cars:");
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplaySpecificCarInfo()
        {
            Console.WriteLine("Fetching car with Id");
            Car car = dataAccess.GetCarById(1);
            if (car == null)
            {
                Console.WriteLine("Car not found");
            }
            else
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayCarsInRentalOffice()
        {
            Console.WriteLine("Fetching cars in RentalOffice with Id 2");
            List<Car> cars = dataAccess.GetCarsInRentalOffice(2);
            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayEmployeeInfo()
        {
            Console.WriteLine("Fetching employee info for employee with Id 1");
            Employee employee = dataAccess.GetEmployeeById(1);

            Console.WriteLine(employee.Name);

        }

        static void RemoveCarById()
        {
            dataAccess.RemoveCarById(1);
        }

        static void UpdateCarById()
        {
            dataAccess.UpdateCarById(1);
        }

        static void UpdateAllCars()
        {
            //dataAccess.ResetAllCarMileages();
            dataAccess.UpdateCarLocations();
        }
    }
}

