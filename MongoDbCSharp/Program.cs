using System;
using System.Threading.Tasks;

namespace MongoDbCSharp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // Vår koppling till databasen
            DataAccess dataAccess = new DataAccess();

            // Lägg till en ny bil i databasen
            await dataAccess.CreateCar(new Car() { Model = "Saab", Mileage = 6412 });

            // Hämta alla bilar
            var cars = await dataAccess.GetAllCarsAsync();

            foreach (Car car in cars)
            {
                Console.WriteLine($"Id: {car.Id} Model: {car.Model} Mileage: {car.Mileage}");
                car.Mileage += 1;
            }
            // Uppdatera den andra bilen i listans mileage i databasen
            await dataAccess.UpdateCar(cars[1]);

            // Hämta alla bilar igen för att påvisa att enbart en bils mileage har ändrats
            cars = await dataAccess.GetAllCarsAsync();
            Console.WriteLine();
            foreach (Car car in cars)
            {
                Console.WriteLine($"Id: {car.Id} Model: {car.Model} Mileage: {car.Mileage}");
            }

            //await dataAccess.UpdateAllCars(cars);
            //Console.WriteLine();
            //foreach (Car car in cars)
            //{
            //    Console.WriteLine($"Id: {car.Id} Model: {car.Model} Mileage: {car.Mileage}");
            //}
        }
    }
}
