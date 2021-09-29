using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService
{
    class Address
    {
        public string Name { get; set; }
        public string CO { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

        // Konstruktor för address utan c/o
        public Address(string name, string streetAddress, int zipCode, string city)
        {
            Name = name;
            StreetAddress = streetAddress;
            ZipCode = zipCode;
            City = city;
        }

        // Konstruktor för address med c/o
        public Address(string name, string co, string streetAddress, int zipCode, string city)
        {
            Name = name;
            CO = co;
            StreetAddress = streetAddress;
            ZipCode = zipCode;
            City = city;
        }
    }
}