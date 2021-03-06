using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class Program
    {
        static DataAccess dataAccess = new DataAccess();
        static void Main(string[] args)
        {
            // DataAccess är vår klass där vi jobbar mot databasen
            //Console.WriteLine("Resetting Database");
            //dataAccess.RecreateDatabase();
            //Console.WriteLine("Adding Cars and RentalOffices");
            //dataAccess.AddCarsAndRentalOffices();
            //CreateCar();
            //UpdateChosenCar();
            //RemoveChosenCar();
            DisplayCarInfo();
            //DisplayEmployeesInSameOffice();
            //DisplaySpecificCarInfo();
            //DisplayCarsInRentalOffice();
            //DisplayEmployeeInfo();
            //RemoveCarById();
            UpdateCarById();
            //UpdateAllCars();
        }

        static void CreateCar()
        {
            Car car = new Car();
            car.Mileage = 0;
            car.Model = "Tesla";
            List<RentalOffice> offices = dataAccess.GetRentalOffices();
            car.CurrentOffice = offices[0];
            dataAccess.CreateCar(car);
        }

        static void UpdateChosenCar()
        {
            List<Car> cars = dataAccess.GetCars();
            Console.WriteLine("List of cars:");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Id + " " + car);
            }
            Console.Write("Input Id of the car you want to update: ");
            int input = int.Parse(Console.ReadLine());
            Car chosenCar = cars.First(c => c.Id == input);
            chosenCar.Model = "Mercedes";
            dataAccess.UpdateChosenCar(chosenCar);
        }

        static void RemoveChosenCar()
        {
            List<Car> cars = dataAccess.GetCars();
            Console.WriteLine("List of cars:");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Id + " " + car);
            }
            Console.Write("Input Id of the car you want to remove: ");
            int input = int.Parse(Console.ReadLine());
            Car chosenCar = cars.First(c => c.Id == input);
            dataAccess.RemoveChosenCar(chosenCar);
        }

        static void DisplayCarInfo()
        {
            Console.WriteLine("Fetching cars");
            List<Car> cars = dataAccess.GetCars();
            Console.WriteLine("List of cars:");
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Id + " " + car);
            }
        }

        static void DisplaySpecificCarInfo()
        {
            Console.WriteLine("Fetching car with Id");
            Car car = dataAccess.GetCarById(87);
            if (car == null)
            {
                Console.WriteLine("Car not found");
            }
            else
            {
                Console.WriteLine(car);
            }
        }

        static void DisplayEmployeesInSameOffice()
        {
            Console.WriteLine("Fetching employees from same office as car with Id");
            Car car = dataAccess.GetEmployeesInSameOffice(1);
            if (car == null)
            {
                Console.WriteLine("Car not found");
            }
            else
            {
                // På grund av att vi har inkluderat CurrentOffice och Employee inne i dataAccess så får vi ut all info här 
                foreach (Employee e in car.CurrentOffice.Employees)
                {
                    Console.WriteLine(e.Name);
                }
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

