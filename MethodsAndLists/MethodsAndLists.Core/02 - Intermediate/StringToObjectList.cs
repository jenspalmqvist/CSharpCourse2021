
using System;
using System.Collections.Generic;

namespace MethodsAndLists.Core
{
    public class City
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public City(string name, string population)
        {
            Name = name;
            Population = int.Parse(population);
        }
    }
    public class StringToObjectList
    {
        public List<City> ParseCities(string input)
        {
            if(input == null)
            {
                throw new ArgumentException();
            }
            List<City> cities = new List<City>();
            if (String.IsNullOrWhiteSpace(input))
            {
                return cities;
            }
            var splitString = input.Split(';');
            foreach (var item in splitString)
            {
                string[] splitCity =  item.Split(',');
                cities.Add(new City(splitCity[0].Trim(), splitCity[1].Trim()));
            }
            return cities;
        }
    }
}
