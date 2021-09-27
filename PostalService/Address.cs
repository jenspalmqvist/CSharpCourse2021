using System;
using System.Collections.Generic;
using System.Text;

namespace PostalService
{
    public class Address
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public string CO { get; set; }

        public Address(string name, string streetAddress, int zipCode, string city, string co = "")
        {
            Name = name;
            StreetAddress = streetAddress;
            ZipCode = zipCode;
            City = city;
            CO = co;
        }
    }
}