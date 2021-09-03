using System;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            Person kalle = new Person();
            kalle.Name = "Kalle";
            kalle.Age = 28;
            kalle.Adress = "Gatan 5, 12345 Staden";

            Person pelle = new Person("Pelle", 25, "Nån annan stans");

            Person kim = new Person(Gender.NonBinary);

            Console.WriteLine(kalle.Name + kalle.Age + kalle.Adress);
            Console.WriteLine(pelle.Name + pelle.Age + pelle.Adress);
            kalle.CelebrateBirthDay();
            Console.WriteLine(kalle.GetYearsToRetirement());
            kalle.CelebrateBirthDay();

            Console.WriteLine(kalle.GetYearsToRetirement());

            Console.WriteLine("Hello World!");
        }
    }
}