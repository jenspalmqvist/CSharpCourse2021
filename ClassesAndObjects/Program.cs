using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassesAndObjects

{
    class Program
    {
        static void Main(string[] args)
        {
            Person kalle = new Person();
            kalle.Name = "Kalle";
            kalle.Age = 35;
            kalle.Adress = "Gatan 5, 12345 Staden";
            kalle.Gender = Gender.Male;
            Person pelle = new Person("Pelle", 25, "Nån annanstans", Gender.Other);
            Person kim = new Person("Kim", 31, "En stad nära dig", Gender.NonBinary);

            // Skriv till fil:
            //var persons = new List<Person> { kalle, pelle, kim };
            //string jsonString = JsonSerializer.Serialize(persons);
            //File.WriteAllText("persons.json", jsonString);
            //Console.ReadLine();

            // Läs från fil:                         Vad är det vi försöker läsa in?
            var personsList = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("persons.json"));

            List<Person> personsOver30 = personsList.FindAll(person => person.Age > 30);

            Console.WriteLine("Hello World!");
        }
    }
}