using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbCSharp
{
    internal class DataAccess
    {

        // setup-variabler för att komma åt vår databas
        const string ConnectionString = "mongodb://localhost:27017";
        const string DatabaseName = "CarRental";
        const string CarCollection = "Cars";
        const string RentalOfficeCollection = "RentalOffices";

        // Metod som tar emot en generisk typ och hämtar den samlingen från databasen
        private IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            // client pratar med databasen
            var client = new MongoClient(ConnectionString);
            // Hämta databasen vi specificerat ovan
            var db = client.GetDatabase(DatabaseName);
            // Returnera collectionen
            return db.GetCollection<T>(collection);
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            // Hämta samlingen med Cars från databasen
            var carCollection = ConnectToMongo<Car>(CarCollection);
            // plocka ut bilarna
            var results = await carCollection.FindAsync(_ => true);
            // returnera en lista
            return results.ToList();
        }

        public Task CreateCar(Car car)
        {
            // Påta in bilen vi skapat i databasen
            var carCollection = ConnectToMongo<Car>(CarCollection);
            return carCollection.InsertOneAsync(car);
        }

        public Task UpdateCar(Car car)
        {

            var carCollection = ConnectToMongo<Car>(CarCollection);
            // Filtrera ut rätt bil från databasen på dess id och byt ut den med vår ändrade version
            var filter = Builders<Car>.Filter.Eq("Id", car.Id);
            return carCollection.ReplaceOneAsync(filter, car);
        }

        //public async Task UpdateAllCars(List<Car> cars)
        //{
        //    var updates = new List<WriteModel<Car>>();
        //    var carCollection = ConnectToMongo<Car>(CarCollection);
        //    var filter = Builders<Car>.Filter.Eq("Model", "Volvo");
        //    foreach (Car car in cars)
        //    {
        //        updates.Add(new ReplaceOneModel<Car>(filter, car));
        //    }
        //    await carCollection.BulkWriteAsync(updates);
        //}
        public Task DeleteCar(Car car)
        {
            var carCollection = ConnectToMongo<Car>(CarCollection);
            // Ta bort bilen med rätt id
            return carCollection.DeleteOneAsync(c => c.Id == car.Id);
        }
    }
}
