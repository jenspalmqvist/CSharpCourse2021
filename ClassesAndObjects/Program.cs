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
            kalle.Temp = 132;
            Person pelle = new Person("Pelle", 25, "Nån annanstans", Gender.Other);
            Person kim = new Person("Kim", 31, "En stad nära dig", Gender.NonBinary);

            //Skriv till fil:
            var persons = new List<PersonAbstract> { kalle, pelle, kim };
            string jsonString = JsonSerializer.Serialize(persons, persons.GetType());
            Console.WriteLine(jsonString);
            File.WriteAllText("persons.json", jsonString);
            //Console.ReadLine();

            // Läs från fil:                         Vad är det vi försöker läsa in?
            var personsList = JsonSerializer.Deserialize<List<object>>(File.ReadAllText("persons.json"));
            //List<Person> personsOver30 = personsList.FindAll(person => person.Age > 30);

            foreach (var item in personsList)
            {
                Console.WriteLine("hej");
            }
            Console.WriteLine("Hello World!");
        }
    }
}