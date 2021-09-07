using System;
using System.Collections.Generic;
using System.Text;

namespace BicycleRenting
{
    class BicycleRental
    {
        public string Name { get; set; }
        public List<Bicycle> Bicycles { get; set; }
        public int Revenue { get; set; }

        public BicycleRental(string name, List<Bicycle> bicycles)
        {
            foreach (Bicycle bicycle in bicycles)
            {
                bicycle.CurrentRentalPlace = this;
            }
            Name = name;
            Bicycles = bicycles;
            Revenue = 0;
        }

        public void RentBicycle(Bicycle bicycle, int numberOfDays)
        {
            Revenue += bicycle.Price * numberOfDays;
            bicycle.IsAvailable = false;
        }

        public void ReturnBike(Bicycle bicycle)
        {
            bicycle.IsAvailable = true;
        }

        public void ReturnBike(Bicycle bicycle, BicycleRental returnRental)
        {
            Bicycles.Remove(bicycle);
            returnRental.Bicycles.Add(bicycle);
            bicycle.CurrentRentalPlace = returnRental;
            bicycle.IsAvailable = true;
        }
    }
}