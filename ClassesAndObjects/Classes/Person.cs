using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndObjects
{
    class Person
    {
        // Properties ska alltid börja på stor bokstav
        public string Name { get; set; }

        public int Age { get; set; }
        public string Adress { get; set; }
        public Gender Gender { get; set; }

        // Det kan finnas flera constructors, här är en som skapar ett tomt Person-objekt
        public Person()
        {
        }

        // Här är en som skapar ett objekt med parametrarna vi skickar in
        public Person(string name, int age, string adress, Gender gender)
        {
            // Observera att variablerna vi skickar in har liten bokstav,
            // dessa använder vi för att sätta värden på klassens properties
            Name = name;
            Age = age;
            Adress = adress;
            Gender = gender;
        }

        public int GetYearsToRetirement()
        {
            return 65 - Age;
        }

        public void CelebrateBirthDay()
        {
            Age++;
        }
    }
}