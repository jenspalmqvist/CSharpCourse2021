using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalEntityFramework
{
    internal class DataAccess
    {
        Context context = new Context();

        // Metod som tar bort och återskapar databasen utifrån hur Context.cs ser ut
        public void RecreateDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public void AddCarsAndRentalOffices()
        {
            Car car = new();
            car.Model = "Lada";
            car.Mileage = 57738982;

            Car car2 = new();
            car2.Model = "Volvo";
            car2.Mileage = 2;

            List<Car> carList = new List<Car>();
            carList.Add(car);
            carList.Add(car2);

            RentalOffice rentalOffice = new RentalOffice();
            rentalOffice.Name = "Kontoret";
            rentalOffice.Cars = carList;

            RentalOffice rentalOffice2 = new RentalOffice();
            rentalOffice2.Name = "Det andra kontoret";
            Car car3 = new Car();
            car3.Model = "Opel";
            car3.Mileage = 9953;
            rentalOffice2.Cars.Add(car3);

            Employee employee = new Employee();
            employee.Name = "Kenta";
            rentalOffice.Employees.Add(employee);
            rentalOffice2.Employees.Add(employee);
            // context är databasen, Cars är tabellen som vi lägger till bilen i
            context.Cars.Add(car);
            context.Cars.Add(car2);
            context.Cars.Add(car3);

            context.RentalOffices.Add(rentalOffice);
            context.RentalOffices.Add(rentalOffice2);

            context.Employees.Add(employee);
            // Om vi inte kör SaveChanges kommer databasen inte att uppdateras.
            context.SaveChanges();
        }

        public List<Car> GetCars()
        {
            // Hämtar en lista med alla rader i tabellen
            return context.Cars.ToList();
        }

        public Car GetCarById(int id)
        {
            return context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public List<Car> GetCarsInRentalOffice(int id)
        {
            var rentalOffice = context.RentalOffices.FirstOrDefault(c => c.Id == id);
            if (rentalOffice == null)
            {
                return null;
            }
            else
            {
                return rentalOffice.Cars.ToList();
            }

            return context.RentalOffices.FirstOrDefault(r => r.Id == id)?.Cars.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = context.Employees.FirstOrDefault(c => c.Id == id);
            if (employee == null)
            {
                return null;
            }
            else
            {
                return employee;
            }

            //return context.RentalOffices.FirstOrDefault(r => r.Id == id)?.Cars.ToList();
        }
    }
}
