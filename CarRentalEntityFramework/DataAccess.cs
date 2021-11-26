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

        // Metod som tar bort och återskapar databasen utifrån ContextModelSnapshot.cs i Migrations-mappen
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

            Employee employee = new Employee();
            employee.Name = "Kenta";
            rentalOffice.Employees.Add(employee);
            // context är databasen, Cars är tabellen som vi lägger till bilen i
            context.Cars.Add(car);
            context.Cars.Add(car2);
            context.RentalOffices.Add(rentalOffice);
            // Om vi inte kör SaveChanges kommer databasen inte att uppdateras.
            context.SaveChanges();
        }

        public List<Car> GetCars()
        {
            // Hämtar en lista med alla rader i tabellen
            return context.Cars.ToList();
        }


    }
}
