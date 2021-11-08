using Generics.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Generics
{
    class Program
    {
        private const string LogFilePath = @"C:\temp\log.csv";
        private const string CarsFilePath = @"C:\temp\cars.csv";

        static void Main(string[] args)
        {
            var cars = new List<Car>
            {
                new Car { Brand = "Tesla", Model = "Model Y", Year = 2019 },
                new Car { Brand = "Volvo", Model = "240", Year = 1989 },
                new Car { Brand = "Saab", Model = "9-3", Year = 2005 },
            };

            //NonGeneric.SaveCarsToFile(CarsFilePath, cars);
            Generic.SaveToCsv<Car>(CarsFilePath, cars);

            //var carsFromFile = NonGeneric.ReadCarsFromFile(CarsFilePath);
            var carsFromFile = Generic.ReadFromCsv<Car>(CarsFilePath);

            foreach (var car in carsFromFile)
            {
                Console.WriteLine(car.ToString());
            }

            //var logEntries = new List<LogEntry>
            //{
            //    new LogEntry { Message = "Something was written to database" },
            //    new LogEntry { Message = "Something else was written to database" },
            //    new LogEntry { Message = "Something changed in the database" }
            //};

            //SaveToCsv(LogFilePath, logEntries);

            //var logs = ReadFromCsv<LogEntry>(LogFilePath);
            //foreach (var logEntry in logs)
            //{
            //    Console.WriteLine(logEntry.ToString());
            //}

        }
    }
}
