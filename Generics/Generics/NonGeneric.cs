using Generics.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Generics
{
    static class NonGeneric
    {
        public static List<Car> ReadCarsFromFile(string filePath)
        {
            var cars = new List<Car>();

            var lines = File.ReadAllLines(filePath).ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var car = line.Split(';');
                cars.Add(new Car { Brand = car[0], Model = car[1], Year = int.Parse(car[2]) });
            }

            return cars;
        }

        public static void SaveCarsToFile(string filePath, List<Car> cars)
        {
            var lines = new List<string>();
            lines.Add("Brand;Model;Year");

            foreach (var car in cars)
            {
                lines.Add($"{car.Brand};{car.Model};{car.Year}");
            }

            File.WriteAllLines(filePath, lines);
        }

        public static List<LogEntry> ReadLogEntryFromFile(string filePath)
        {
            var logEntries = new List<LogEntry>();

            var lines = File.ReadAllLines(filePath).ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                var logEntry = line.Split(';');
                logEntries.Add(new LogEntry { Message = logEntry[0], Time = DateTime.Parse(logEntry[1]) });
            }

            return logEntries;
        }

        public static void SaveLogEntiresToFile(string filePath, List<LogEntry> logEntries)
        {
            var lines = new List<string>();
            lines.Add("Message;Time");

            foreach (var logEntry in logEntries)
            {
                lines.Add($"{logEntry.Message};{logEntry.Time}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
