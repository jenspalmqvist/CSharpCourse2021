using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndObjects
{
    interface ITest
    {
    }

    public abstract class PersonAbstract
    {
        public abstract string Name { get; set; }

        public abstract int Age { get; set; }
        public abstract string Adress { get; set; }
        public abstract Gender Gender { get; set; }
    }

    class Person : PersonAbstract, ITest
    {
        // Properties ska alltid börja på stor bokstav
        public override string Name { get; set; }

        public override int Age { get; set; }
        public override string Adress { get; set; }
        public override Gender Gender { get; set; }
        public int Temp { get; set; }

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
            Temp = 15;
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